namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// A user with a linked external account, as presented to a signal collector.
    /// </summary>
    /// <remarks>
    /// This is the only contract in the signal pipeline where both identities
    /// (Gizmo user id and external account) are visible. Identity translation
    /// happens at collection time, exactly once; everything downstream of the
    /// fact store operates on user ids only.
    /// </remarks>
    public sealed record LinkedUser(
        /// <summary>
        /// Gizmo user id.
        /// </summary>
        int UserId,

        /// <summary>
        /// Linked external account in the collector's required account system.
        /// </summary>
        ExternalAccountRef Account,

        /// <summary>
        /// Opaque synchronization cursor from the previous successful collection for this user,
        /// or <c>null</c> when the user has never been collected. Content is collector-defined
        /// (e.g. last processed match id, serialized snapshot state).
        /// One cursor exists per user per collector — a single collection pass advances it
        /// atomically for all of the collector's signals.
        /// </summary>
        string? Cursor);
}
