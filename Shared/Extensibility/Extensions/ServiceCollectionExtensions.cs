using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Extensibility.Extensions
{
    /// <summary>
    /// Extensibility extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExtensibility(this IServiceCollection services) 
        {           
            return services;
        }
    }
}
