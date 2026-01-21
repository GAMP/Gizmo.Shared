using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gizmo.Extensibility
{
    public static class ModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddModules(
            this IServiceCollection services,
            IEnumerable<ModuleSpec> modules,
            IConfiguration configuration,
            IHostEnvironment hostEnvironment,
            string modulesDataRoot,
            params string[] sharedAssemblyNames)
        {
            foreach (var m in modules)
            {
                ModuleLoader.LoadModuleIntoServices(
                    services,
                    m,
                    configuration,
                    hostEnvironment,
                    modulesDataRoot,
                    sharedAssemblyNames);
            }

            return services;
        }
    }
}
