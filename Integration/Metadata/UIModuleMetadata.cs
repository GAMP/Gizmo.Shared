using System;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// User interface module metadata.
    /// </summary>
    public abstract class UIModuleMetadata
    {
        #region PROPERTIES

        /// <summary>
        /// Gets module title.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Get title localization key.
        /// </summary>
        public string TitleLocalizationKey { get; init; }

        /// <summary>
        /// Gets module description.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Gets description localization key.
        /// </summary>
        public string DescriptionLocalizationKey { get; init; }

        /// <summary>
        /// Gets module display order.
        /// </summary>
        public int DisplayOrder { get; init; }

        /// <summary>
        /// Gets module type.
        /// </summary>
        public Type Type { get; init; }

        /// <summary>
        /// Gets module guid.
        /// </summary>
        public string Guid { get; init; }

        #endregion
    }
}
