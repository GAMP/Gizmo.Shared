using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Per-integration metadata sourced from the <c>Integration</c> DB table.
    /// One <see cref="IntegrationSpec"/> corresponds to exactly one module type
    /// (identified by <see cref="TypeGuid"/>) within a plugin library.
    /// </summary>
    public sealed record IntegrationSpec(
        /// <summary>
        /// Matches <see cref="ModuleMetadataAttribute.ModuleGuid"/>.
        /// Used to locate the concrete registrar type inside the loaded assembly.
        /// </summary>
        Guid TypeGuid,

        /// <summary>
        /// Per-installation stable public identity from the Integration row.
        /// Suitable as a keying value for data directories, keyed DI registrations, etc.
        /// </summary>
        Guid PublicId,

        /// <summary>
        /// Human-readable display name (Integration.Name).
        /// </summary>
        string Name,

        /// <summary>
        /// Raw JSON configuration from the Integration row.
        /// <c>null</c> when no DB config has been stored yet.
        /// </summary>
        string? ConfigJson,

        /// <summary>
        /// Schema version tag carried from the Integration row.
        /// Plugins may use this to detect config migrations.
        /// </summary>
        int? ConfigSchemaVersion);
}
