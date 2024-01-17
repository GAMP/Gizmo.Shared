using System;

namespace Gizmo.Web.Reports
{
    /// <summary>
    /// Identifies report modules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ReportModuleAttribute : Attribute 
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="componentType">Report module visual component type.</param>
        /// <param name="guid">Report module unique Guid string.</param>
        public ReportModuleAttribute(Type componentType, string guid)
        {
            _componentType = componentType;
            _guid = Guid.Parse(guid);
        }

        private readonly Type _componentType;
        private readonly Guid _guid;

        /// <summary>
        /// Report unique guid.
        /// </summary>
        public Guid Guid => _guid;

        /// <summary>
        /// Gets component type.
        /// </summary>
        public Type ComponentType => _componentType;

        /// <summary>
        /// Indicated that report supports range filtering.
        /// </summary>
        /// <remarks>
        /// The default value is true.
        /// </remarks>
        public bool SupportRangeFilter { get; set; } = true;
    }
}
