using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// A day-anchored measurement window of an achievement signal query.
    /// </summary>
    /// <remarks>
    /// Entries combine as ANY-of. A null time window means the entire day. A window whose
    /// <see cref="From"/> is later than its <see cref="To"/> extends past midnight into the
    /// next calendar day and is still attributed to <see cref="Day"/> — "(Friday, 22:00–06:00)"
    /// is Friday night including Saturday's early hours. Time bounds require both values
    /// (enforced by <see cref="SignalProviderBase"/>) and are evaluated on the local clock
    /// defined by <see cref="SignalQuery.TimeZoneId"/>. Multiple entries may share a day to
    /// express multiple windows within it.
    /// </remarks>
    /// <param name="Day">Day of week the window is anchored to.</param>
    /// <param name="From">Optional window start time of day.</param>
    /// <param name="To">Optional window end time of day.</param>
    public sealed record SignalDayWindow(DayOfWeek Day, TimeOnly? From = null, TimeOnly? To = null);
}
