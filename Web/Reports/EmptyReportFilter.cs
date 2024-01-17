using Gizmo.Shared.Web.Reports.Interfaces;

namespace GizmoWeb.Reports
{
    /// <summary>
    /// Report filter used when report module does not support any filters.
    /// </summary>
    public sealed class EmptyReportFilter : IReportFilter
    {
        /// <summary>
        /// Static instance.
        /// </summary>
        public static readonly EmptyReportFilter Instance = new();
    }
}
