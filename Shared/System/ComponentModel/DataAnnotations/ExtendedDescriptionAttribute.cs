#nullable enable

using Gizmo;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Description attribute.
    /// </summary>
    /// <remarks>
    /// This attribute allows addition of extended description metadata.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false)]
    public sealed class ExtendedDescriptionAttribute : LocalizedAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Description.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="description"/>is equal to null or empty string.</exception>
        public ExtendedDescriptionAttribute(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Description. This will be used if localized value is not found.</param>
        /// <param name="resourceKey">Localization resource key.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="description"/> or <paramref name="resourceKey"/> is equal to null or empty string.</exception>
        public ExtendedDescriptionAttribute(string description,string resourceKey):base(resourceKey)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets description.
        /// </summary>
        /// <remarks>
        /// The value is used if <see cref="LocalizedAttribute.ResourceKey"/> is not found.
        /// </remarks>
        public string Description { get; init; } 

        #endregion
    }
}
