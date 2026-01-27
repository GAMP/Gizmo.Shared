using System;

namespace Gizmo.UI
{
    /// <summary>
    /// Module icon attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModuleIconAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleIconAttribute(string icon)
        {
            if (string.IsNullOrWhiteSpace(icon))
                throw new ArgumentNullException(nameof(icon));

            Icon = icon;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets icon.
        /// </summary>
        public string Icon
        {
            get;
            init;
        }

        #endregion
    }
}
