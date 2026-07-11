using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Filter kinds an achievement signal provider can apply to its measurement.
    /// </summary>
    /// <remarks>
    /// A provider declares the filters it actually applies via
    /// <see cref="IAchievementSignalProvider.SupportedFilters"/>. The declaration is enforced
    /// at achievement configuration time (editors only offer supported filters) and at
    /// evaluation time (queries carrying undeclared filters are rejected) — a filter must
    /// never be silently ignored. Each new <see cref="SignalQuery"/> filter property ships
    /// together with its flag here.
    /// </remarks>
    [Flags]
    public enum SignalFilterKinds : long
    {
        /// <summary>
        /// No filters supported.
        /// </summary>
        None = 0,

        /// <summary>
        /// Restrict measurement to activity on any of the specified hosts.
        /// </summary>
        Host = 1,

        /// <summary>
        /// Restrict measurement to activity on hosts of any of the specified host groups.
        /// </summary>
        HostGroup = 2,

        // 4 is reserved — was DayTime, merged into DayOfWeek when day-anchored
        // time windows moved onto the day of week filter entries.

        /// <summary>
        /// Restrict measurement to activity settled with any of the specified payment methods.
        /// </summary>
        PaymentMethod = 8,

        /// <summary>
        /// Provider-interpreted custom key/value parameters (typically plugin signals).
        /// </summary>
        Parameters = 16,

        /// <summary>
        /// Restrict measurement to activity attributed to any of the specified branches.
        /// </summary>
        Branch = 32,

        /// <summary>
        /// Restrict measurement to activity in any of the specified applications.
        /// </summary>
        App = 64,

        /// <summary>
        /// Restrict measurement to activity in applications of any of the specified app groups.
        /// </summary>
        AppGroup = 128,

        /// <summary>
        /// Restrict measurement to activity involving any of the specified products.
        /// </summary>
        Product = 256,

        /// <summary>
        /// Restrict measurement to activity involving products of any of the specified product groups.
        /// </summary>
        ProductGroup = 512,

        /// <summary>
        /// Restrict measurement to activity billed under any of the specified bill profiles.
        /// </summary>
        BillProfile = 1024,

        /// <summary>
        /// Restrict measurement to activity within any of the specified day-anchored
        /// windows — a day of week, optionally narrowed to a time-of-day window
        /// (see <see cref="SignalDayWindow"/>).
        /// </summary>
        DayOfWeek = 2048,

        /// <summary>
        /// Restrict measurement to activity in any of the specified application executables.
        /// </summary>
        AppExe = 4096,

        /// <summary>
        /// Restrict measurement to activity in applications of any of the specified categories.
        /// </summary>
        AppCategory = 8192,
    }
}
