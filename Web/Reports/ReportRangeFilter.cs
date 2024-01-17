using System;

namespace Gizmo.Web.Reports
{
    public sealed class ReportRangeFilter
    {
        public static readonly ReportRangeFilter None = new();

        public ReportRangeType RangeType { get; init; }

        public DateTime? Start { get; init; }

        public DateTime? End { get; init; }
    }
}
