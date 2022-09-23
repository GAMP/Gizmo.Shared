using System;

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

        #endregion
    }
}
