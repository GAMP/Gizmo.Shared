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
    public sealed record ModuleSpec(
        string ModuleId,
        string AssemblyPath,
        bool Enabled = true);

    public static class ModuleLoader
    {
        public static void LoadModuleIntoServices(
            IServiceCollection services,
            ModuleSpec spec,
            IConfiguration hostConfig,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot,
            IReadOnlyCollection<string> sharedAssemblyNames)
        {
            if (!spec.Enabled) return;

            var fullPath = Path.GetFullPath(spec.AssemblyPath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Module DLL not found: {fullPath}");

            var alc = new ModuleLoadContext(fullPath, sharedAssemblyNames);
            var asm = alc.LoadFromAssemblyPath(fullPath);

            var baseDir = Path.GetDirectoryName(fullPath)!;
            var dataDir = Path.Combine(modulesDataRoot, spec.ModuleId);

            Directory.CreateDirectory(dataDir);

            var ctx = new ModuleContext
            {
                ModuleId = spec.ModuleId,
                AssemblyPath = fullPath,
                BaseDirectory = baseDir,
                DataDirectory = dataDir,
                HostEnvironment = hostEnvironment,
                Configuration = hostConfig.GetSection("Modules").GetSection(spec.ModuleId),
                Version = asm.GetName().Version
            };

            // (Optional) register keyed context + accessor per module id here if you want it injectable
            // services.AddKeyedSingleton(spec.ModuleId, ctx);

            var registrars = asm.GetExportedTypes()
                .Where(t => !t.IsAbstract && typeof(IServiceRegistrar).IsAssignableFrom(t))
                .Where(t => t.GetCustomAttribute<ServiceRegistrarAttribute>() != null) // safety gate
                .Select(t => new
                {
                    Type = t,
                    Order = typeof(IOrderedRegistrar).IsAssignableFrom(t)
                        ? ((IOrderedRegistrar)Activator.CreateInstance(t)!).Order
                        : 0
                })
                .OrderBy(x => x.Order)
                .ThenBy(x => x.Type.FullName, StringComparer.Ordinal)
                .Select(x => x.Type)
                .ToArray();

            if (registrars.Length == 0)
                throw new InvalidOperationException(
                    $"Module '{spec.ModuleId}' has no public registrars marked with [ServiceRegistrar].");

            foreach (var t in registrars)
            {
                var registrar = (IServiceRegistrar)Activator.CreateInstance(t)!;
                registrar.RegisterServices(services, ctx);
            }
        }
    }
}
