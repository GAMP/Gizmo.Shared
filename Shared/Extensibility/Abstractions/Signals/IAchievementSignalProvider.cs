using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Provides windowed per-user values of a single achievement signal.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A provider serves exactly one signal. Signal identity (stable guid plus
    /// human-readable id) is declared with a class-level <see cref="ModuleMetadataAttribute"/>.
    /// The provider answers one question: how much of the signal did each requested user
    /// accumulate within the queried interval.
    /// </para>
    /// <para>
    /// Providers are measurement only and must not contain policy. Interval selection,
    /// candidate filtering (guests, exemptions), value normalization and completion
    /// evaluation are all owned by the caller. Optional query filters are honored only
    /// when declared in <see cref="SupportedFilters"/> — a provider must never silently
    /// ignore a filter it does not apply.
    /// </para>
    /// <para>
    /// Implement via <see cref="SignalProviderBase"/>, which enforces the query contract.
    /// This interface stays frozen; future capabilities are added as virtual members on the
    /// base class — implementing the interface directly forfeits that forward compatibility.
    /// </para>
    /// </remarks>
    public interface IAchievementSignalProvider
    {
        /// <summary>
        /// Maximum number of users a caller may pass in a single query.
        /// </summary>
        public const int MaxBatchSize = 1000;

        /// <summary>
        /// Gets the native measurement unit of the signal values.
        /// </summary>
        SignalUnit Unit { get; }

        /// <summary>
        /// Gets the query filter kinds this provider actually applies.
        /// Queries carrying filters outside this set are rejected, never silently ignored.
        /// </summary>
        SignalFilterKinds SupportedFilters { get; }

        /// <summary>
        /// Gets culture-neutral metadata of the custom parameters this provider accepts via
        /// <see cref="SignalQuery.Parameters"/> — used by configuration editors to generate
        /// parameter input UI. Empty when the provider accepts no custom parameters; must be
        /// non-empty exactly when <see cref="SignalFilterKinds.Parameters"/> is declared in
        /// <see cref="SupportedFilters"/>.
        /// </summary>
        IReadOnlyList<SignalParameterMetadata> Parameters { get; }

        /// <summary>
        /// Gets accumulated signal values for the queried users within the queried interval.
        /// </summary>
        /// <param name="query">Signal value query (half-open UTC interval, bounded user set, optional filters).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Sparse result map keyed by user id with values in the signal's native unit
        /// (see <see cref="SignalUnit"/>). Users with no qualifying activity are absent
        /// from the map and must be treated as zero by the caller.
        /// </returns>
        Task<IReadOnlyDictionary<int, decimal>> GetValuesAsync(
            SignalQuery query,
            CancellationToken cancellationToken = default);
    }
}
