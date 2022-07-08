using Gizmo.Client.UI.View.States;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Gizmo.Client.UI
{
    public static class ObjectPropertyCache
    {
        #region READ ONLY FIELDS
        private static readonly Type STRING_TYPE = typeof(string);
        private static readonly ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> _propertyCache = new();
        #endregion

        #region PREDICTATE

        private static readonly Predicate<PropertyInfo> _validatingPropertiesPredictate = (p) =>
        {
            //must not contain property change ignore attribute
            return p.GetCustomAttribute<PropertyChangeIgnoreAttribute>() == null &&
            //must contain validating attribute
            p.GetCustomAttribute<ValidatingPropertyAttribute>() != null;
        };

        private static readonly Predicate<PropertyInfo> _nonClassPredictate = (p) =>
        {
            //must be a primitve type https://docs.microsoft.com/en-us/dotnet/api/system.type.isprimitive?view=net-6.0 or string
            //other types might need to be added
            return p.PropertyType.IsPrimitive || p.PropertyType == STRING_TYPE;
        };

        private static readonly Predicate<PropertyInfo> _classPredictate = (p) =>
        {
            //must not be primitive type https://docs.microsoft.com/en-us/dotnet/api/system.type.isprimitive?view=net-6.0 and not string
            //some other types might need to be added
            return p.PropertyType.IsClass && !p.PropertyType.IsPrimitive && p.PropertyType != STRING_TYPE;
        };

        #endregion

        public static IEnumerable<ValidatingObjectInfo> GetValidationObjects(IValidatingViewState root)
        {
            List<ValidatingObjectInfo> validationObjects = new();
            GetValidationObjects(root, root.GetType(), validationObjects);

            return validationObjects;
        }

        #region PRIVATE FUNCTIONS
        
        /// <summary>
        /// Gets all validation properties on specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>List of property info.</returns>
        private static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return _propertyCache.GetOrAdd(type, k =>
            {
                return k.GetProperties().Where(property => _validatingPropertiesPredictate(property));
            });
        }

        private static void GetValidationObjects(object instance, Type type, IList<ValidatingObjectInfo> validationObjects)
        {
            //get all validating properties on that object
            var properties = GetProperties(type);

            //create new info
            validationObjects.Add(new ValidatingObjectInfo()
            {
                Instance = instance,
                InstanceType = type,
                Properties = properties.Where(p => _nonClassPredictate(p))
            });

            //get all properties that represent a class
            var classProperties = properties.Where(p => _classPredictate(p));

            //recurse all properties
            foreach (var property in classProperties)
            {
                //get instance value
                var obj = property.GetValue(instance);

                //get properties that should be validated
                GetValidationObjects(obj, property.PropertyType, validationObjects);
            }
        } 

        #endregion

    }

    /// <summary>
    /// Validating object information.
    /// </summary>
    public sealed class ValidatingObjectInfo
    {     
        #region PROPERTIES

        /// <summary>
        /// Gets object instance.
        /// </summary>
        public object Instance
        {
            get; init;
        }

        /// <summary>
        /// Gets instance type.
        /// </summary>
        public Type InstanceType
        {
            get; init;
        }

        /// <summary>
        /// Public gets properties.
        /// </summary>
        public IEnumerable<PropertyInfo> Properties
        {
            get; init;
        }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Gets value for specified property from the current object instance.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="propertyInfo">Property ingfo.</param>
        /// <returns>Current property value specified by <paramref name="propertyInfo"/> set on <see cref="Instance"/> object.</returns>
        public T GetVaule<T>(PropertyInfo propertyInfo)
        {
            return (T)propertyInfo.GetValue(Instance);
        } 

        #endregion
    }
}
