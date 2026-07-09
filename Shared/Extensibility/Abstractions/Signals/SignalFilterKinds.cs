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

        /// <summary>
        /// Restrict measurement to activity within a time-of-day window.
        /// </summary>
        DayTime = 4,

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
    }
}
