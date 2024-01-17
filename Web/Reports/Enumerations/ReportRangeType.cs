namespace Gizmo.Web.Reports
{
    /// <summary>
    /// Represent report ranges.
    /// </summary>
    public enum ReportRangeType
    {
        /// <summary>
        /// Custom date/time ranges.
        /// </summary>
        Custom = 0,
        /// <summary>
        /// Daily range.
        /// </summary>
        Daily = 1,
        /// <summary>
        /// Weekly range.
        /// </summary>
        Weekly = 2,
        /// <summary>
        /// Monthly range.
        /// </summary>
        Monthly = 3,
        /// <summary>
        /// Yeraly range.
        /// </summary>
        Yearly = 4,
    }
}
