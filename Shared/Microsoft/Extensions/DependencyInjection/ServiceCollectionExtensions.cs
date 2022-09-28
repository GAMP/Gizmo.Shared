#nullable enable

using System.Reflection;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region FUNCTIONS

        /// <summary>
        /// Registers all services in specified assembly.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="assembly">Source assembly.</param>
        /// <returns>Service collection.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">thrown in case the registration requirements are not met.</exception>
        /// <remarks>
        /// In order to be registered services must have <see cref="RegisterAttribute"/> applied to them.<br/>
        /// <see cref="RegisterAttribute"/> enforces applied type to be an class and it is the only supported type for depencency injection registration.
        /// </remarks>
        public static IServiceCollection RegisterServices(this IServiceCollection services, Assembly assembly)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            //get all services in specified assembly
            var assemblyServices = assembly
                .GetTypes()
                .Where(type => type.IsClass) //only classes
                .Where(type => type.IsAbstract == false) //only non abstract types
                .Select(type => new
                {
                    Type = type,
                    Attribute = type.GetCustomAttribute<RegisterAttribute>()
                })
                .Where(result => result.Attribute != null)
                .ToList();

            foreach (var service in assemblyServices)
            {
                var registerAttribute = service.Attribute;
                if (registerAttribute == null)
                    continue;

                //early validation to avoid and service misconfiguration
                foreach(var extendedType in registerAttribute.Types)
                {
                    //if extended type is an inteface make sure that service does implement it
                    if (extendedType.IsInterface)
                    {
                        if (!service.Type.GetInterfaces().Where(ifc => ifc == extendedType).Any())
                            throw new ArgumentException($"Specified service type {service.Type} does not implement {extendedType}.");
                    }
                    else if(extendedType.IsClass)
                    {
                        if(!service.Type.IsSubclassOf(extendedType))
                            throw new ArgumentException($"Specified service type {service.Type} is not subclass of {extendedType}.");
                    }
                    else
                    {
                        throw new ArgumentException("Only interface or class supported as registration type.");
                    }
                }

                if (registerAttribute.Scope == RegisterScope.Scoped)
                {
                    services.AddScoped(service.Type);
                    foreach (var extendedType in registerAttribute.Types)
                        services.AddScoped(extendedType, (sp) => sp.GetRequiredService(service.Type));
                }
                else if (registerAttribute.Scope == RegisterScope.Singelton)
                {
                    services.AddSingleton(service.Type);
                    foreach (var extendedType in registerAttribute.Types)
                        services.AddSingleton(extendedType, (sp) => sp.GetRequiredService(service.Type));
                
                }
                else if (registerAttribute.Scope == RegisterScope.Transient)
                {
                    services.AddTransient(service.Type);
                    foreach(var extendedType in registerAttribute.Types)
                        services.AddTransient(extendedType, (sp) => sp.GetRequiredService(service.Type));                    
                }
            }

            return services;
        } 

        #endregion
    }
}
