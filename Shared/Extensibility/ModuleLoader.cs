using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Gizmo.Extensibility.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gizmo.Extensibility
{
    public sealed record ModuleSpec(string AssemblyPath);

    public static class ModuleLoader
    {
        // Cached reference to Configure<TOptions>(IServiceCollection, IConfiguration)
        private static readonly MethodInfo s_configureMethod =
            typeof(OptionsConfigurationServiceCollectionExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(m =>
                    m.Name == nameof(OptionsConfigurationServiceCollectionExtensions.Configure)
                    && m.IsGenericMethodDefinition
                    && m.GetParameters().Length == 2
                    && m.GetParameters()[1].ParameterType == typeof(IConfiguration));

        public static void LoadModuleIntoServices(
            IServiceCollection services,
            ModuleSpec spec,
            IReadOnlyList<IntegrationSpec> integrations,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot,
            IReadOnlyCollection<string> sharedAssemblyNames,
            ModuleAssemblyRegistry registry,
            IntegrationTypeRegistry typeRegistry)
        {
            var fullPath = Path.GetFullPath(spec.AssemblyPath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Module DLL not found: {fullPath}");

            var alc = new ModuleLoadContext(fullPath, sharedAssemblyNames);
            var asm = alc.LoadFromAssemblyPath(fullPath);

            var baseDir = Path.GetDirectoryName(fullPath)!;

            var moduleName = Path.GetFileNameWithoutExtension(fullPath);

            registry.Add(asm, baseDir, moduleName);
            services.AddKeyedSingleton(asm, new ModuleInfo(moduleName, baseDir));
            var asmVersion = asm.GetName().Version;

            // 1. Discover and run all DLL-wide registrars (ordered, no integration context)
            var registrars = asm.GetExportedTypes()
                .Where(t => !t.IsAbstract
                         && typeof(IServiceRegistrar).IsAssignableFrom(t))
                .Select(t => new
                {
                    Type = t,
                    Order = typeof(IOrderedRegistrar).IsAssignableFrom(t)
                        ? ((IOrderedRegistrar)Activator.CreateInstance(t)!).Order
                        : 0
                })
                .OrderBy(x => x.Order)
                .ThenBy(x => x.Type.FullName, StringComparer.Ordinal)
                .ToArray();

            foreach (var r in registrars)
            {
                var registrar = (IServiceRegistrar)Activator.CreateInstance(r.Type)!;
                registrar.RegisterServices(services);
            }

            // 2. Discover integration implementation types via [ModuleMetadata]
            var moduleTypes = asm.GetExportedTypes()
                .Select(t => (Type: t, Attr: t.GetCustomAttribute<ModuleMetadataAttribute>()))
                .Where(x => x.Attr != null)
                .ToArray();

            // Build a lookup so multiple Integration rows with the same TypeGuid are all matched.
            var lookup = integrations.ToLookup(i => i.TypeGuid);

            // 3. For each [ModuleMetadata] type, register one instance per matching IntegrationSpec.
            //    Multiple rows sharing a TypeGuid represent distinct configured instances (different
            //    PublicId and ConfigJson), so each gets its own keyed singleton.
            foreach (var (type, attr) in moduleTypes)
            {
                var typeGuid = Guid.Parse(attr!.ModuleGuid);

                var capabilities = DiscoverCapabilities(type);
                typeRegistry.Add(typeGuid, attr.Id, asm, capabilities);

                // Config schema metadata is the same for all instances of this type — extract once
                // and register keyed by TypeGuid so the Manager UI can request it before any
                // instance exists (e.g. when showing the "create integration" form).
                var configMetadata = ModuleConfigMetadataExtractor.Extract(type);
                services.AddKeyedSingleton(typeGuid, configMetadata);

                foreach (var integration in lookup[typeGuid])
                {
                    var publicId = integration.PublicId;
                    var dataDir = Path.Combine(modulesDataRoot, publicId.ToString());
                    var (config, reloader) = BuildModuleConfiguration(integration.ConfigJson);

                    var ctx = new ModuleContext
                    {
                        ModuleId = integration.Name,
                        TypeGuid = typeGuid,
                        PublicId = publicId,
                        AssemblyPath = fullPath,
                        BaseDirectory = baseDir,
                        DataDirectory = dataDir,
                        HostEnvironment = hostEnvironment,
                        Configuration = config,
                        ConfigSchemaVersion = integration.ConfigSchemaVersion,
                        Version = asmVersion
                    };

                    // Keyed by PublicId string — one entry per instance, unique across the container.
                    services.AddKeyedSingleton(publicId.ToString(), ctx);

                    // Reloader — host resolves this by PublicId and calls Reload(newJson) when
                    // ConfigJson is updated in the DB; IOptionsMonitor<T> fires automatically.
                    services.AddKeyedSingleton(publicId, reloader);

                    // Key the implementation type by PublicId so two instances of the same class
                    // remain independent singletons. A lightweight wrapper IServiceProvider makes the
                    // correct ModuleContext available for constructor injection without requiring it —
                    // plugin types that don't need ModuleContext are not constrained to declare it.
                    services.AddKeyedSingleton(type, publicId, (sp, _) =>
                        ActivatorUtilities.CreateInstance(new ModuleServiceProvider(sp, ctx), type));

                    if (typeof(IModuleInitialize).IsAssignableFrom(type))
                        services.Add(ServiceDescriptor.Singleton(
                            typeof(IModuleInitialize),
                            sp => (IModuleInitialize)sp.GetRequiredKeyedService(type, publicId)));

                    if (typeof(IModuleStart).IsAssignableFrom(type))
                        services.Add(ServiceDescriptor.Singleton(
                            typeof(IModuleStart),
                            sp => (IModuleStart)sp.GetRequiredKeyedService(type, publicId)));

                    if (typeof(IModuleStop).IsAssignableFrom(type))
                        services.Add(ServiceDescriptor.Singleton(
                            typeof(IModuleStop),
                            sp => (IModuleStop)sp.GetRequiredKeyedService(type, publicId)));

                    // Auto-bind [ModuleOptions] declared on the integration type
                    BindModuleOptions(services, type, config);
                }
            }
        }

        /// <summary>
        /// Scans the type's interface tree for interfaces decorated with
        /// <see cref="IntegrationCapabilityAttribute"/> and collects their capability GUIDs.
        /// </summary>
        private static IReadOnlyList<Guid> DiscoverCapabilities(Type type)
        {
            var caps = new List<Guid>();
            foreach (var iface in type.GetInterfaces())
            {
                var capAttr = iface.GetCustomAttribute<IntegrationCapabilityAttribute>();
                if (capAttr != null)
                    caps.Add(capAttr.CapabilityGuid);
            }
            return caps;
        }

        private static (IConfiguration Config, IModuleConfigurationReloader Reloader) BuildModuleConfiguration(string? configJson)
        {
            var source = new ReloadableJsonConfigurationSource(configJson);
            var config = new ConfigurationBuilder().Add(source).Build();
            return (config, source.Provider);
        }

        private static void BindModuleOptions(IServiceCollection services, Type integrationType, IConfiguration config)
        {
            foreach (var attr in integrationType.GetCustomAttributes<ModuleOptionsAttribute>())
            {
                var section = string.IsNullOrWhiteSpace(attr.SectionName)
                    ? config
                    : config.GetSection(attr.SectionName);

                s_configureMethod
                    .MakeGenericMethod(attr.OptionsType)
                    .Invoke(null, [services, section]);
            }
        }

        /// <summary>
        /// Wraps the root <see cref="IServiceProvider"/> and returns the module-specific
        /// <see cref="ModuleContext"/> when requested, so that plugin constructors may
        /// optionally inject it without being required to.
        /// </summary>
        private sealed class ModuleServiceProvider(IServiceProvider inner, ModuleContext ctx) : IServiceProvider, IKeyedServiceProvider
        {
            public object? GetService(Type serviceType) =>
                serviceType == typeof(ModuleContext) ? ctx : inner.GetService(serviceType);

            public object? GetKeyedService(Type serviceType, object? serviceKey) =>
                (inner as IKeyedServiceProvider)?.GetKeyedService(serviceType, serviceKey);

            public object GetRequiredKeyedService(Type serviceType, object? serviceKey) =>
                (inner as IKeyedServiceProvider)?.GetRequiredKeyedService(serviceType, serviceKey)
                ?? throw new InvalidOperationException(
                    $"No keyed service of type {serviceType} with key '{serviceKey}' is registered.");
        }
    }
}
