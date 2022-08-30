#nullable enable

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Name attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Property,AllowMultiple =false)]
    public class NameAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="name"/>is equal to null or empty string.</exception>
        public NameAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name
        {
            get;
        } 
        #endregion
    }
}
