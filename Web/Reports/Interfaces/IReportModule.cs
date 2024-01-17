using System.Threading.Tasks;
using System.Threading;

namespace Gizmo.Web.Reports
{
    /// <summary>
    /// Report module interface.
    /// </summary>
    public interface IReportModule
    {
        /// <summary>
        /// Generates report model.
        /// </summary>
        /// <param name="reportRangeFilter">Range filter.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Generated report model.</returns>
        /// <remarks>
        /// Parameter <paramref name="reportRangeFilter"/> will be equal to <see cref="ReportRangeFilter.None"/> in case report module have indicated that it does not support range in their filter.<br></br>
        /// The returned report model will be passed to the reports visual component in view data parameters.
        /// </remarks>
        Task<object> GnerateReportAsync(ReportRangeFilter reportRangeFilter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets filter model.
        /// </summary>
        public IReportFilter Filter { get; }
    }
}
