#nullable enable
using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Specifies allowed values on an options property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class StoreOptionsAllowedValuesAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="value">Allowed values.</param>
        public StoreOptionsAllowedValuesAttribute(params object[] value)
        {
            Values = value;
        } 

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets allowed value.
        /// </summary>
        public object[] Values
        {
            get;
        } 
        #endregion
    }
}
