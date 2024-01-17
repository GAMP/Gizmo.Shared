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
        private readonly TReportFilter _filterModel = new();

        public IReportFilter Filter => _filterModel;
     
        public abstract Task<object> GnerateReportAsync(ReportRangeFilter reportRangeFilter, CancellationToken cancellationToken = default);      
    }
}
