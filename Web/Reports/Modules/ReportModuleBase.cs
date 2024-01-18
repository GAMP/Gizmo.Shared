using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Reports;

namespace Gizmo.Shared.Web.Reports
{
    /// <summary>
    /// Base report module implementation.
    /// </summary>
    public abstract class ReportModuleBase<TReportFilter> : IReportModule where TReportFilter : IReportFilter, new()
    {
        protected TReportFilter _filterModel = new();

        public IReportFilter Filter => _filterModel;

        /// <summary>
        /// Gets concrete filter.
        /// </summary>
        /// <remarks>
        /// This model can be used to construct the desired report filter in <see cref="GenerateReportAsync(ReportRangeFilter, CancellationToken)"/> method.<br></br>
        /// All the filter parameters will be set and validated before calling <see cref="GenerateReportAsync(ReportRangeFilter, CancellationToken)"/>.
        /// </remarks>
        protected TReportFilter FilterConcrete => _filterModel;
    
        public abstract Task<object> GenerateReportAsync(ReportRangeFilter reportRangeFilter, CancellationToken cancellationToken = default);      
    }
}
