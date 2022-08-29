#nullable  enable
using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Provides option unique store name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StoreOptionKeyAttribute : Attribute
    {
        #region CONSTRUCTOR

        public StoreOptionKeyAttribute(string key, string group)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (key.Length > 45)
                throw new ArgumentException(nameof(key.Length), nameof(key));

            if (string.IsNullOrWhiteSpace(group))
                throw new ArgumentNullException(nameof(group));

            if (group.Length > 45)
                throw new ArgumentException(nameof(group.Length), nameof(key));

            Key = key;
            Group = group;
        }

        public StoreOptionKeyAttribute(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (key.Length > 45)
                throw new ArgumentException(nameof(key.Length), nameof(key));

            Key = key;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets options key.
        /// </summary>
        public string Key
        {
            get;
        }

        /// <summary>
        /// Gets or sets optional option group.
        /// </summary>
        /// <remarks>
        /// This value used to override <see cref="StoreOptionsGroupAttribute"/> value.
        /// </remarks>
        public string? Group
        {
            get; 
        }

        /// <summary>
        /// Gets or sets if default value should be set in database.
        /// </summary>
        /// <remarks>
        /// In order to be applied an DefaultValue attribute must be set on the property.
        /// </remarks>
        public bool ApplyDefaultValue
        {
            get; init;
        }

        #endregion
    }
}
