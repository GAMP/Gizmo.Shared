using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service provider extensions.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Get service of type <typeparamref name="TInterface"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="guid">Service type guid.</param>
        /// <returns>A service object of type <typeparamref name="TInterface"/>.</returns>
        /// <exception cref="InvalidOperationException">thrown in case found service not implementing <typeparamref name="TInterface"/>specified.</exception>
        /// <exception cref="ArgumentException">thrown in case <typeparamref name="TInterface"/> type does not represent an interface.</exception>
        public static TInterface GetRequiredService<TInterface>(this IServiceProvider serviceProvider, Guid guid)
        {
            //get service type
            var serviceType = TypeHelper.GetType<TInterface>(guid);

            //get service
            var service = serviceProvider.GetRequiredService(serviceType);

            //check if service implements specified interface
            if (service is not TInterface implementation)
                throw new InvalidOperationException();

            //return service
            return implementation;
        }

        /// <summary>
        /// Get service of type <typeparamref name="TInterface"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="guid">Service type guid.</param>
        /// <returns>A service object of type <typeparamref name="TInterface"/>.</returns>
        /// <exception cref="InvalidOperationException">thrown in case found service not implementing <typeparamref name="TInterface"/>specified.</exception>
        /// <exception cref="ArgumentException">thrown in case <typeparamref name="TInterface"/> type does not represent an interface.</exception>
        public static TInterface GetService<TInterface>(this IServiceProvider serviceProvider, Guid guid)
        {
            //get service type
            var serviceType = TypeHelper.GetType<TInterface>(guid);

            //check if we obtained the service type, if not we should return default value
            if (serviceType == null)
                return default;

            //get service
            var service = serviceProvider.GetService(serviceType);

            //check if we obtained the service instance, if not we should return default value
            if (service == null)
                return default;

            //check if service implements specified interface
            if (service is not TInterface implementation)
                throw new InvalidOperationException();

            //return service
            return implementation;
        }

        /// <summary>
        /// Get service from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="guid">Service type guid.</param>
        /// <returns>A service object.</returns>
        public static object GetRequiredService(this IServiceProvider serviceProvider, Guid guid)
        {
            //get service type
            var serviceType = TypeHelper.GetType(guid);

            //get service
            var service = serviceProvider.GetRequiredService(serviceType);

            //return service
            return service;
        }

        /// <summary>
        /// Get service of type <typeparamref name="TInterface"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="serviceProvider">Service provider.</param>
        /// <returns>Services of type <typeparamref name="TInterface"/>.</returns>
        public static IEnumerable<Type> GetServiceTypes<TInterface>(this IServiceProvider serviceProvider)
        {
            //get IServiceProviderIsService, this service will help us determine if type is registered in service provider
            var isServiceService = serviceProvider.GetRequiredService<IServiceProviderIsService>();

            //filter out types
            return TypeHelper.GetTypes<TInterface>().Where(type => isServiceService.IsService(type));
        }

        /// <summary>
        /// Determines if service of type specified by <paramref name="type"/> is registered in <paramref name="serviceProvider"/>.
        /// </summary>
        /// <param name="serviceProvider">Service provider.</param>
        /// <param name="type">Service type.</param>
        /// <returns>true if the specified service is a available, false if it is not.</returns>
        public static bool IsService(this IServiceProvider serviceProvider, Type type)
        {
            //get IServiceProviderIsService, this service will help us determine if type is registered in service provider
            var isServiceService = serviceProvider.GetRequiredService<IServiceProviderIsService>();

            //check if type is registered in service provider
            return isServiceService.IsService(type);
        }

        #endregion
    }
}
