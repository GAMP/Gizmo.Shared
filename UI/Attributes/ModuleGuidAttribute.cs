using System;

namespace Gizmo.UI
{
    /// <summary>
    /// Module guid attribute.
    /// </summary>
    /// <remarks>
    /// Used to uniquely identify modules.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModuleGuidAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid string.</param>
        public ModuleGuidAttribute(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentNullException(nameof(guid));

            Guid = guid;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid.</param>
        public ModuleGuidAttribute(Guid guid)
        {
            Guid = guid.ToString();
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets guid.
        /// </summary>
        public string Guid
        {
            get;
            init;
        }

        #endregion
    }
}
