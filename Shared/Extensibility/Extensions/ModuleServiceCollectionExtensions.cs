using System;
using System.Collections.Generic;
using System.Reflection;
using Gizmo.Extensibility.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gizmo.Extensibility
{
    public static class ModuleServiceCollectionExtensions
    {
        /// <param name="sharedAssemblyNames">
        /// Additional assembly names to resolve from the host's Default ALC rather than from the
        /// plugin folder. <see cref="ModuleLoadContext.DefaultShared"/> (framework and extensibility
        /// contract assemblies) is always included and does not need to be repeated here.
        /// Pass extra names for any host-specific assemblies that plugins should share
        /// (e.g. Gizmo.DAL, project-specific contracts).
        /// </param>
        public static IServiceCollection AddModules(
            this IServiceCollection services,
            IEnumerable<ModuleSpec> modules,
            IReadOnlyList<IntegrationSpec> integrations,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot,
            params string[] sharedAssemblyNames)
        {
            var registry = new ModuleAssemblyRegistry();
            var typeRegistry = new IntegrationTypeRegistry();

            foreach (var m in modules)
            {
                ModuleLoader.LoadModuleIntoServices(
                    services,
                    m,
                    integrations,
                    hostEnvironment,
                    modulesDataRoot,
                    sharedAssemblyNames,
                    registry,
                    typeRegistry);
            }

            services.AddSingleton(registry);
            services.AddSingleton(typeRegistry);

            return services;
        }

        /// <summary>
        /// Registers directly-referenced assemblies using the same discovery and registration
        /// logic as plugin DLLs. Must be called after <see cref="AddModules"/> so that the
        /// <see cref="ModuleAssemblyRegistry"/> and <see cref="IntegrationTypeRegistry"/>
        /// singletons are already registered.
        /// </summary>
        public static IServiceCollection AddAssemblyModules(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            IReadOnlyList<IntegrationSpec> integrations,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot)
        {
            var registry = GetRegisteredSingleton<ModuleAssemblyRegistry>(services);
            var typeRegistry = GetRegisteredSingleton<IntegrationTypeRegistry>(services);

            foreach (var asm in assemblies)
            {
                ModuleLoader.LoadAssemblyIntoServices(
                    services,
                    asm,
                    integrations,
                    hostEnvironment,
                    modulesDataRoot,
                    registry,
                    typeRegistry);
            }

            return services;
        }

        /// <summary>
        /// Registers explicitly listed host-assembly types as integration modules. Must be called after
        /// <see cref="AddModules"/>. See <see cref="ModuleLoader.LoadHostTypesIntoServices"/> for why the
        /// containing assembly is not registered as a module assembly.
        /// </summary>
        public static IServiceCollection AddHostTypeModules(
            this IServiceCollection services,
            IReadOnlyList<Type> types,
            IReadOnlyList<IntegrationSpec> integrations,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot)
        {
            var typeRegistry = GetRegisteredSingleton<IntegrationTypeRegistry>(services);

            ModuleLoader.LoadHostTypesIntoServices(
                services,
                types,
                integrations,
                hostEnvironment,
                modulesDataRoot,
                typeRegistry);

            return services;
        }

        private static T GetRegisteredSingleton<T>(IServiceCollection services) where T : class
        {
            foreach (var descriptor in services)
            {
                if (descriptor.ServiceType == typeof(T) && descriptor.ImplementationInstance is T instance)
                    return instance;
            }
            throw new InvalidOperationException(
                $"{typeof(T).Name} not found. Call AddModules before AddAssemblyModules.");
        }
    }
}
