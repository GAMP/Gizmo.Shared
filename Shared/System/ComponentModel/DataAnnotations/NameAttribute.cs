#nullable enable

using Gizmo;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Name attribute.
    /// </summary>
    /// <remarks>
    /// This attribute allows addition of extended metadata.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false)]
    public class NameAttribute : LocalizedAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="name"/>is equal to null or empty string.</exception>
        public NameAttribute(string name):base()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">Default name. This will be used if localized value is not found.</param>
        /// <param name="resourceKey">Localization resource key.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="name"/> or <paramref name="resourceKey"/> is equal to null or empty string.</exception>
        public NameAttribute(string name, string resourceKey) : base(resourceKey)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
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
