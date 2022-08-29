using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Base attribute for store values that support custom formatting.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class OptionValueCustomStringFormatAttribute : Attribute
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Creates formatted string from the value specified.
        /// </summary>
        /// <param name="value">Value instance to format.</param>
        /// <returns>Formated value.</returns>
        public abstract string Format(object value); 

        #endregion
    }
}
