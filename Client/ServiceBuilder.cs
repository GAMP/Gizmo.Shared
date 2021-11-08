using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Client.UI
{
    public static class ServiceBuilder
    {
        public static IConfigurationBuilder AddClientConfiguration(this IConfigurationBuilder configuration)
        {
            //add our main configuration file
            configuration.AddJsonFile("appsettings.json", true);            

            return configuration;
        }

        public static IConfigurationBuilder AddClientConfiguration(this IConfigurationBuilder configuration, string fileName)
        {
            //add our main configuration file
            configuration.AddJsonFile(fileName, true);

            return configuration;
        }

        public static IServiceCollection AddClientConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //bind client app configuration to the desired class
            services.Configure<ClientAppSettings>((options) => configuration.GetSection("App").Bind(options));
            services.Configure<ClientUISettings>((options) => configuration.GetSection("Interface").Bind(options));

            return services;
        }
    }
}
