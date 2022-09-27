using System;

namespace Gizmo.UI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true)]
    public sealed class UIModuleAttribute : Attribute
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

        #endregion
    }
}
