using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Result of a signal collection pass.
    /// </summary>
    public sealed record CollectResult(
        /// <summary>
        /// Facts produced by this pass, across all of the collector's signals.
        /// May be empty when no new source data was found.
        /// </summary>
        IReadOnlyCollection<SignalFact> Facts,

        /// <summary>
        /// Advanced synchronization cursors keyed by user id.
        /// Only users whose cursor changed need to be present. The host persists these
        /// and supplies them back via <see cref="LinkedUser.Cursor"/> on the next pass —
        /// a cursor must only be advanced for users whose source data was fully processed,
        /// so that a partial failure results in re-collection rather than data loss.
        /// </summary>
        IReadOnlyDictionary<int, string?> UpdatedCursors);
}
