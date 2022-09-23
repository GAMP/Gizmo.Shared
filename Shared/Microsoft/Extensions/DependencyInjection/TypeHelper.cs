using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Type helper.
    /// </summary>
    public static class TypeHelper
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets type short name.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>Type short name.</returns>
        /// <remarks>
        /// This will create an short name for the type excluding assembly version etc.
        /// </remarks>
        public static string GetShortTypeName(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return $"{type.FullName}, {type.Assembly.GetName().Name}";
        }

        /// <summary>
        /// Gets all types implementing <typeparamref name="TInterface"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <returns>Found types.</returns>
        /// <remarks>
        /// This function searches type from assemblies that are loaded in current app domain.
        /// </remarks>
        /// <exception cref="ArgumentException">thrown in case <typeparamref name="TInterface"/> type does not represent an interface.</exception>
        public static IEnumerable<Type> GetTypes<TInterface>()
        {
            //get interface type
            var interfaceType = typeof(TInterface);

            //check if type specified represents interface
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Only interface types are supported.", nameof(interfaceType));

            //check that type represents an inteface
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Only interface types are supported.");

            //read all matching types from assemblies loaded in app domain
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes()
                        .Where(t => t.IsAbstract == false && t.IsInterface == false)
                        .Where(t => t.GetInterfaces().Any(ifc => ifc == interfaceType));
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        //catch type load exceptions
                        //this will happen if one of the types in assembly cant be loaded

                        return Enumerable.Empty<Type>();
                    }
                });
        }

        /// <summary>
        /// Gets all types implementing <typeparamref name="TInterface"/> and their guid being equal to value specified by <paramref name="guid"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="guid">Guid.</param>
        /// <returns>Found types.</returns>
        /// <exception cref="ArgumentException">thrown in case <typeparamref name="TInterface"/> type does not represent an interface.</exception>
        public static IEnumerable<Type> GetTypes<TInterface>(Guid guid)
        {
            //get all types that implement specified interface
            var types = GetTypes<TInterface>();

            //we dont need to check the GuidAttribute, if one set on the object it will be automatically present on Type
            //https://learn.microsoft.com/en-us/dotnet/api/system.type.guid?view=net-6.0
            return types.Where(type => type.GUID == guid);
        }

        /// <summary>
        /// Gets all types with guid being equal to <paramref name="guid"/>.
        /// </summary>
        /// <param name="guid">Guid.</param>
        /// <returns>Found types.</returns>
        public static IEnumerable<Type> GetTypes(Guid guid)
        {
            //read all matching types from assemblies loaded in app domain
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes().Where(t => t.GUID == guid);
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        //catch type load exceptions
                        //this will happen if one of the types in assembly cant be loaded

                        return Enumerable.Empty<Type>();
                    }
                });
        }

        /// <summary>
        /// Gets single type implementing <typeparamref name="TInterface"/> and its guid being equal to value specified by <paramref name="guid"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="guid">Guid.</param>
        /// <returns>Found type.</returns>
        /// <exception cref="InvalidOperationException">thrown in case of multiple types found with same guid.</exception>
        /// <exception cref="ArgumentException">thrown in case <typeparamref name="TInterface"/> type does not represent an interface.</exception>
        public static Type GetType<TInterface>(Guid guid)
        {
            return GetTypes<TInterface>(guid)
                .SingleOrDefault();
        }

        /// <summary>
        /// Gets single type by guid.
        /// </summary>
        /// <param name="guid">Guid.</param>
        /// <returns>Found type.</returns>
        /// <exception cref="InvalidOperationException">thrown in case of multiple types found with same guid.</exception>
        public static Type GetType(Guid guid)
        {
            return GetTypes(guid).SingleOrDefault();
        }

        #endregion

    }
}
