using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Provides section name to be used with .net configuration infrastructure.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    public sealed class OptionsConfigurationSectionAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="section">Section.</param>
        public OptionsConfigurationSectionAttribute(string section)
        {
            Section = section;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets configuration section name.
        /// </summary>
        public string Section
        {
            get; init;
        } 

        #endregion
    }
}
