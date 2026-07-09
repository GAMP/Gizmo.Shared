using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Collects signal facts for externally sourced signals (e.g. game statistics).
    /// </summary>
    /// <remarks>
    /// <para>
    /// A collector is the ingest side of external signals: it fetches data from an
    /// external source and converts it into additive <see cref="SignalFact"/> records.
    /// One collector serves one external source and may emit facts for several signals —
    /// a single pass processes all of them under one cursor, so related signals can never
    /// drift out of sync with each other.
    /// </para>
    /// <para>
    /// Collectors never schedule themselves. The host invokes <see cref="CollectAsync"/>
    /// on the configured interval, supplies only users that hold a linked account in
    /// <see cref="RequiredAccountSystem"/>, and owns fact persistence, cursor storage
    /// and failure-to-staleness reporting.
    /// </para>
    /// </remarks>
    public interface ISignalCollector
    {
        /// <summary>
        /// Gets the registrations of all signals emitted by this collector.
        /// </summary>
        IReadOnlyList<SignalRegistration> Signals { get; }

        /// <summary>
        /// Gets the account system this collector requires (e.g. <c>steam</c>).
        /// Determines which linked user accounts are supplied to <see cref="CollectAsync"/>.
        /// </summary>
        string RequiredAccountSystem { get; }

        /// <summary>
        /// Collects new signal facts for the specified users.
        /// </summary>
        /// <param name="users">
        /// Users to collect, each carrying their linked external account and the cursor
        /// from the previous successful pass. The host guarantees a bounded set.
        /// </param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Produced facts and advanced cursors.</returns>
        Task<CollectResult> CollectAsync(
            IReadOnlyList<LinkedUser> users,
            CancellationToken cancellationToken = default);
    }
}
