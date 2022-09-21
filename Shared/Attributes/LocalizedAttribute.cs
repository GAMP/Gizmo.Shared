#nullable enable
using System;

namespace Gizmo
{
    /// <summary>
    /// Localized object attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LocalizedAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance of attribute.
        /// </summary>
        /// <param name="resourceKey">Resource key.</param>
        /// <param name="localize">Indicates if value should be localized.</param>
        public LocalizedAttribute(string resourceKey)
        {
            if (string.IsNullOrWhiteSpace(resourceKey))
                throw new ArgumentNullException("ResourceKey", "Resource key may not be null or empty.");

            ResourceKey = resourceKey;
        }

        /// <summary>
        /// Protected constructor.
        /// </summary>
        protected LocalizedAttribute()
        {
            ResourceKey = string.Empty;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the resource key for this attribute.
        /// </summary>
        public string ResourceKey
        {
            get;
        }

        #endregion
    }    
}