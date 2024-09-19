#nullable enable
using System.Linq;
using System.Reflection;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Options extensions.
    /// </summary>
    public static class OptionsExtensions
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
        /// Configures all store options for specified interface.
        /// </summary>
        /// <param name="serviceCollection">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <exception cref="ArgumentException">thrown if some of required parameters are not set.</exception>
        /// <remarks>
        /// This function will discover all implementations specified by <typeparam name="TInterface">Interface type.</typeparam> and register any options provided by <see cref="StoreOptionsTypeAttribute"/>.<br></br>
        /// The types must provide <see cref="OptionsConfigurationSectionAttribute"/> in order for us to be able to bind them to a configuration section, if they not <see cref="ArgumentException"/> will be thrown.
        /// </remarks>
        public static void AddStoreOptions<TInterface>(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //get all present payment providers
            foreach (var targetType in TypeHelper.GetTypes<TInterface>())
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
                object? optionsBuilder = ADD_OPTIONS_METHOD?.MakeGenericMethod([storeOptionsType]).Invoke(null, [serviceCollection]);

                //bind options to specified section
                BIND_OPTIONS_METHOD?.MakeGenericMethod([storeOptionsType]).Invoke(null, [optionsBuilder, configuration.GetSection(configurationSection)]);
            }
        }

        /// <summary>
        /// Gets store option type.
        /// </summary>
        /// <param name="typeGuid">Type guid.</param>
        /// <returns>Option type, null if no type specified.</returns>
        public static Type? StoreOptionTypeGet(Guid typeGuid)
        {
            //get payment provider
            var targetType = TypeHelper.GetType(typeGuid);

            //get options type
            return targetType?.GetCustomAttribute<StoreOptionsTypeAttribute>()?.OptionsType;
        }

        #endregion
    }
}
