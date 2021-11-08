using System;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Module display order attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    public class ModuleDisplayOrderAttribute : Attribute
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
