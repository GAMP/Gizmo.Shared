#nullable enable
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Options extensions.
    /// </summary>
    public static class OptionsExtenstions
    {
        #region STATIC READ ONLY FIELDS
        private readonly static MethodInfo? ADD_OPTIONS_METHOD = typeof(OptionsServiceCollectionExtensions)
            .GetMethods()
            .Where(method => method.IsGenericMethod && method.Name == nameof(OptionsServiceCollectionExtensions.AddOptions))
            .FirstOrDefault() ?? throw new ArgumentException($"{nameof(OptionsServiceCollectionExtensions.AddOptions)} not found.");
        private readonly static MethodInfo BIND_OPTIONS_METHOD = typeof(OptionsBuilderConfigurationExtensions)
            .GetMethods()
            .Where(method => method.IsGenericMethod && method.Name == nameof(OptionsBuilderConfigurationExtensions.Bind))
            .FirstOrDefault() ?? throw new ArgumentException($"{nameof(OptionsBuilderConfigurationExtensions.Bind)} not found.");
        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Gets all types that implement specified interface.
        /// </summary>
        /// <param name="interfaceType">Interface type.</param>
        /// <returns>List of types.</returns>
        /// <remarks>
        /// This function searches type from assemblies that are loaded in current app domain.
        /// </remarks>
        public static IEnumerable<Type> GetTypesByInteface(Type interfaceType)
        {
            //check that type represents an inteface
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Only interface types are supported.");

            foreach (var loadedAssembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in loadedAssembly.GetTypes()
                    .Where(t => t.IsAbstract == false && t.IsInterface == false)
                    .Where(t => t.GetInterfaces().Any(ifc => ifc == interfaceType)))
                    yield return type;
            }
        }

        /// <summary>
        /// Configures all payment providers.
        /// </summary>
        /// <param name="serviceCollection">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        /// <param name="interfaceType">Interface type.</param>
        /// <exception cref="ArgumentException">thrown if some of required parameters are not set.</exception>
        /// <remarks>
        /// This function will discover all implementations specified by <paramref name="interfaceType"/> and register any options provided by <see cref="StoreOptionsTypeAttribute"/>.<br></br>
        /// The types must provide <see cref="OptionsConfigurationSectionAttribute"/> in order for us to be able to bind them to a configuration section, if they not <see cref="ArgumentException"/> will be thrown.
        /// </remarks>
        public static void AddStoreOptions(this IServiceCollection serviceCollection, IConfiguration configuration, Type interfaceType)
        {
            //get all present payment providers
            foreach (var targetType in GetTypesByInteface(interfaceType))
            {
                //get store options type if one specified
                var storeOptionsType = targetType.GetCustomAttribute<StoreOptionsTypeAttribute>()?.OptionsType;
                if (storeOptionsType == null)
                    continue;

                //get configuration section, we require it to be able to map options to configuration section
                var configurationSection = storeOptionsType.GetCustomAttribute<OptionsConfigurationSectionAttribute>()?.Section;
                if (string.IsNullOrWhiteSpace(configurationSection))
                    throw new ArgumentException("Options section must be provided.");

                //add options by type
                object? optionsBuilder = ADD_OPTIONS_METHOD?.MakeGenericMethod(new Type[] { storeOptionsType }).Invoke(null, new[] { serviceCollection });

                //bind options to specified section
                BIND_OPTIONS_METHOD?.MakeGenericMethod(new Type[] { storeOptionsType }).Invoke(null, new[] { optionsBuilder, configuration.GetSection(configurationSection) });
            }
        }

        #endregion
    }
}
