using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Base class for achievement signal providers enforcing the query contract.
    /// </summary>
    /// <remarks>
    /// Owns the contract guards so implementations only contain measurement:
    /// argument validation, batch size limit, rejection of filters the provider
    /// did not declare in <see cref="SupportedFilters"/>, and the empty-scope
    /// short circuit. Providers should derive from this class rather than
    /// implementing <see cref="IAchievementSignalProvider"/> directly.
    /// </remarks>
    public abstract class SignalProviderBase : IAchievementSignalProvider
    {
        /// <inheritdoc/>
        public abstract SignalUnit Unit { get; }

        /// <inheritdoc/>
        public abstract SignalFilterKinds SupportedFilters { get; }

        /// <inheritdoc/>
        public virtual IReadOnlyList<SignalParameterMetadata> Parameters => _noParameters;

        /// <inheritdoc/>
        public Task<IReadOnlyDictionary<int, decimal>> GetValuesAsync(SignalQuery query, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(query);
            ArgumentNullException.ThrowIfNull(query.UserIds);

            if (query.UserIds.Count > IAchievementSignalProvider.MaxBatchSize)
                throw new ArgumentException($"At most {IAchievementSignalProvider.MaxBatchSize} user ids may be requested in a single call.", nameof(query));

            if ((query.FilterKinds & SignalFilterKinds.DayTime) != SignalFilterKinds.None)
            {
                if (!query.DayTimeFrom.HasValue || !query.DayTimeTo.HasValue)
                    throw new ArgumentException("A day time window requires both DayTimeFrom and DayTimeTo.", nameof(query));

                if (query.DayTimeFrom.Value == query.DayTimeTo.Value)
                    throw new ArgumentException("Day time window is empty — DayTimeFrom must differ from DayTimeTo.", nameof(query));

                if (string.IsNullOrWhiteSpace(query.TimeZoneId))
                    throw new ArgumentException("A day time window requires TimeZoneId to define the local clock.", nameof(query));
            }

            var unsupportedFilters = query.FilterKinds & ~SupportedFilters;
            if (unsupportedFilters != SignalFilterKinds.None)
                throw new NotSupportedException($"Signal provider {GetType().FullName} does not support the requested filter(s): {unsupportedFilters}.");

            if (query.UserIds.Count == 0 || query.RangeEndUtc <= query.RangeStartUtc)
                return Task.FromResult(_emptyResult);

            return GetValuesCoreAsync(query, cancellationToken);
        }

        /// <summary>
        /// Performs the measurement. Called only with a validated query: non-empty bounded
        /// user set, a non-degenerate interval, and filters within <see cref="SupportedFilters"/>.
        /// </summary>
        /// <param name="query">Validated query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Sparse per-user value map in the signal's native unit.</returns>
        protected abstract Task<IReadOnlyDictionary<int, decimal>> GetValuesCoreAsync(SignalQuery query, CancellationToken cancellationToken);

        private static readonly IReadOnlyDictionary<int, decimal> _emptyResult = new Dictionary<int, decimal>();

        private static readonly IReadOnlyList<SignalParameterMetadata> _noParameters = [];
    }
}
