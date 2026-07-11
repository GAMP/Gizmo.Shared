using System;
using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Achievement signal value query.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Carries the mandatory measurement scope (users and evaluation interval) plus optional
    /// filters. The class grows by adding optional properties so the provider contract never
    /// changes shape; every filter property has a matching <see cref="SignalFilterKinds"/> flag
    /// and is only honored by providers that declare it in
    /// <see cref="IAchievementSignalProvider.SupportedFilters"/>.
    /// </para>
    /// <para>
    /// Filter semantics: within one filter kind the specified values combine as ANY-of
    /// (e.g. activity on host group 3 or 5); across kinds all filters must hold. A null or
    /// empty id collection means the filter is absent, never "match nothing".
    /// </para>
    /// </remarks>
    public sealed class SignalQuery
    {
        /// <summary>
        /// Gets user ids to evaluate. Callers guarantee a bounded set of at most
        /// <see cref="IAchievementSignalProvider.MaxBatchSize"/> ids.
        /// </summary>
        public required IReadOnlyCollection<int> UserIds { get; init; }

        /// <summary>
        /// Gets evaluation interval start (UTC, inclusive).
        /// </summary>
        public required DateTime RangeStartUtc { get; init; }

        /// <summary>
        /// Gets evaluation interval end (UTC, exclusive).
        /// </summary>
        public required DateTime RangeEndUtc { get; init; }

        /// <summary>
        /// Gets optional host filter — count only activity on any of the specified hosts.
        /// </summary>
        public IReadOnlyCollection<int>? HostIds { get; init; }

        /// <summary>
        /// Gets optional host group filter — count only activity on hosts of any of the specified groups.
        /// </summary>
        public IReadOnlyCollection<int>? HostGroupIds { get; init; }

        /// <summary>
        /// Gets optional branch filter — count only activity attributed to any of the specified branches.
        /// </summary>
        public IReadOnlyCollection<int>? BranchIds { get; init; }

        /// <summary>
        /// Gets optional application filter — count only activity in any of the specified applications.
        /// </summary>
        public IReadOnlyCollection<int>? AppIds { get; init; }

        /// <summary>
        /// Gets optional app group filter — count only activity in applications of any of the specified groups.
        /// </summary>
        public IReadOnlyCollection<int>? AppGroupIds { get; init; }

        /// <summary>
        /// Gets optional payment method filter — count only activity settled with any of the specified methods.
        /// </summary>
        public IReadOnlyCollection<int>? PaymentMethodIds { get; init; }

        /// <summary>
        /// Gets optional product filter — count only activity involving any of the specified products.
        /// </summary>
        public IReadOnlyCollection<int>? ProductIds { get; init; }

        /// <summary>
        /// Gets optional product group filter — count only activity involving products of any of the specified groups.
        /// </summary>
        public IReadOnlyCollection<int>? ProductGroupIds { get; init; }

        /// <summary>
        /// Gets optional bill profile filter — count only activity billed under any of the specified profiles.
        /// </summary>
        public IReadOnlyCollection<int>? BillProfileIds { get; init; }

        /// <summary>
        /// Gets optional application executable filter — count only activity in any of the specified executables.
        /// </summary>
        public IReadOnlyCollection<int>? AppExeIds { get; init; }

        /// <summary>
        /// Gets optional app category filter — count only activity in applications of any of the specified categories.
        /// </summary>
        public IReadOnlyCollection<int>? AppCategoryIds { get; init; }

        /// <summary>
        /// Gets optional day window filter — count only activity within any of the specified
        /// day-anchored windows (see <see cref="SignalDayWindow"/> for anchoring and wrap
        /// semantics). <see cref="TimeZoneId"/> is required when set.
        /// </summary>
        public IReadOnlyCollection<SignalDayWindow>? DayWindows { get; init; }

        /// <summary>
        /// Gets the time zone id defining the local clock for the day windows.
        /// Required when <see cref="DayWindows"/> is set; fact timestamps (stored UTC) are
        /// projected into this zone before the windows are applied.
        /// </summary>
        public string? TimeZoneId { get; init; }

        /// <summary>
        /// Gets optional provider-interpreted custom parameters.
        /// Only meaningful to providers declaring <see cref="SignalFilterKinds.Parameters"/>.
        /// </summary>
        public IReadOnlyDictionary<string, string> Parameters { get; init; } = EmptyParameters;

        /// <summary>
        /// Gets the filter kinds carried by this query.
        /// </summary>
        public SignalFilterKinds FilterKinds =>
            (HostIds is { Count: > 0 } ? SignalFilterKinds.Host : SignalFilterKinds.None) |
            (HostGroupIds is { Count: > 0 } ? SignalFilterKinds.HostGroup : SignalFilterKinds.None) |
            (BranchIds is { Count: > 0 } ? SignalFilterKinds.Branch : SignalFilterKinds.None) |
            (AppIds is { Count: > 0 } ? SignalFilterKinds.App : SignalFilterKinds.None) |
            (AppGroupIds is { Count: > 0 } ? SignalFilterKinds.AppGroup : SignalFilterKinds.None) |
            (PaymentMethodIds is { Count: > 0 } ? SignalFilterKinds.PaymentMethod : SignalFilterKinds.None) |
            (ProductIds is { Count: > 0 } ? SignalFilterKinds.Product : SignalFilterKinds.None) |
            (ProductGroupIds is { Count: > 0 } ? SignalFilterKinds.ProductGroup : SignalFilterKinds.None) |
            (BillProfileIds is { Count: > 0 } ? SignalFilterKinds.BillProfile : SignalFilterKinds.None) |
            (AppExeIds is { Count: > 0 } ? SignalFilterKinds.AppExe : SignalFilterKinds.None) |
            (AppCategoryIds is { Count: > 0 } ? SignalFilterKinds.AppCategory : SignalFilterKinds.None) |
            (DayWindows is { Count: > 0 } ? SignalFilterKinds.DayOfWeek : SignalFilterKinds.None) |
            (Parameters.Count > 0 ? SignalFilterKinds.Parameters : SignalFilterKinds.None);

        private static readonly IReadOnlyDictionary<string, string> EmptyParameters = new Dictionary<string, string>();
    }
}
