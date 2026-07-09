using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// A single additive signal event produced by a signal collector.
    /// </summary>
    /// <remarks>
    /// Facts are additive deltas, never snapshots: the value of a signal over an interval
    /// is the sum of fact values with timestamps inside that interval. Collectors syncing
    /// sources that only expose lifetime totals must convert them to deltas using their cursor.
    /// Negative values are permitted for corrections.
    /// </remarks>
    public sealed record SignalFact(
        /// <summary>
        /// Gizmo user id the fact belongs to.
        /// </summary>
        int UserId,

        /// <summary>
        /// Identity of the signal this fact contributes to.
        /// Must be one of the signals declared by the emitting collector.
        /// </summary>
        Guid SignalGuid,

        /// <summary>
        /// Delta value in the signal's native unit.
        /// </summary>
        decimal Value,

        /// <summary>
        /// UTC time the underlying event occurred. Determines which evaluation
        /// intervals the fact falls into — use the source event time when available,
        /// not the collection time.
        /// </summary>
        DateTime TimestampUtc,

        /// <summary>
        /// Optional idempotency token unique within the signal (e.g. external match id).
        /// Facts carrying a reference already stored for the same signal are ignored,
        /// making repeated collection of the same source data safe.
        /// </summary>
        string? ExternalRef);
}
