using System.Collections.Generic;
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

            foreach (var m in modules)
            {
                ModuleLoader.LoadModuleIntoServices(
                    services,
                    m,
                    integrations,
                    hostEnvironment,
                    modulesDataRoot,
                    sharedAssemblyNames,
                    registry);
            }

            services.AddSingleton(registry);

            return services;
        }
    }
}
