using System;

namespace Gizmo.UI
{
    /// <summary>
    /// Module display order attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModuleDisplayOrderAttribute : Attribute
    {
        #region CONSTRUCTOR
        public ModuleDisplayOrderAttribute(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display order value.
        /// </summary>
        public int DisplayOrder { get; }

        #endregion
    }
}
