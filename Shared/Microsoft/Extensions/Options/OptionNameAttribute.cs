using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Option name attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class,AllowMultiple =false)]
    public sealed class OptionNameAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">Option name.</param>
        public OptionNameAttribute(string name)
        {
            Name = name;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets option name.
        /// </summary>
        public string Name { get; } 
        
        #endregion
    }
}
