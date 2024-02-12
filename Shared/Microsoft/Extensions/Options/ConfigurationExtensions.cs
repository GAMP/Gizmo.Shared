using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;

namespace Microsoft.Extensions.Options
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Configurs store options instance.
        /// </summary>
        /// <typeparam name="TOptions">Options type.</typeparam>
        /// <param name="services">Services collection.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <returns>Services collection.</returns>
        /// <exception cref="ArgumentNullException">thrown in case options type does not have <see cref="OptionsConfigurationSectionAttribute"/> applied.</exception>
        public static IServiceCollection ConfigureOptions<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class, IStoreOptions
        {
            var sectionAttribute = typeof(TOptions).GetCustomAttribute<OptionsConfigurationSectionAttribute>();
            if (sectionAttribute == null)
                throw new ArgumentNullException(nameof(sectionAttribute), "This options type does not have section attribute applied to it.");

            return services.Configure<TOptions>(configuration.GetSection(sectionAttribute.Section));
        }
    }
}
