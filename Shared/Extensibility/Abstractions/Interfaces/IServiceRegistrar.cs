using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Entry point for a plugin assembly to register services into the host DI container.
    /// Implementations must be stateless and fast; do not resolve services here.
    /// </summary>
    public interface IServiceRegistrar
    {
        /// <summary>
        /// Called by the host during startup to add services to the host's service collection.
        /// </summary>
        void RegisterServices(IServiceCollection services, ModuleContext context);
    }
}
