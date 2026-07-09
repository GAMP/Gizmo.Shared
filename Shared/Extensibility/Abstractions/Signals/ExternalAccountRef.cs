namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Reference to a user account in an external account system.
    /// </summary>
    /// <remarks>
    /// <see cref="Value"/> is opaque to the core — only the collector that declared the
    /// account system interprets it. Collectors requiring composite identity serialize
    /// it into the value in a format of their own choosing.
    /// </remarks>
    public sealed record ExternalAccountRef(
        /// <summary>
        /// Account system identifier (e.g. <c>steam</c>).
        /// Shared between all collectors that consume accounts of the same system.
        /// </summary>
        string System,

        /// <summary>
        /// Account identity within the system. Opaque, collector-interpreted.
        /// </summary>
        string Value);
}
