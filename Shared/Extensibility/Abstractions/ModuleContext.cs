using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Host-provided information for module registration time.
    /// Keep this immutable and "boring": paths, identity, config, environment.
    /// </summary>
    public sealed record ModuleContext
    {
        /// <summary>Human-readable module name (Integration.Name from the DB).</summary>
        public required string ModuleId { get; init; }

        /// <summary>
        /// Integration type identity. Matches <see cref="ModuleMetadataAttribute.ModuleGuid"/>.
        /// Constant across installations.
        /// </summary>
        public required Guid TypeGuid { get; init; }

        /// <summary>
        /// Per-installation stable public identity (Integration.PublicId from the DB).
        /// Use this for keying persistent data (data directories, keyed DI registrations, etc.).
        /// </summary>
        public required Guid PublicId { get; init; }

        /// <summary>Full path to the module's main assembly (.dll) that the host loaded.</summary>
        public required string AssemblyPath { get; init; }

        /// <summary>Directory that contains the module assembly and its private dependencies.</summary>
        public required string BaseDirectory { get; init; }

        /// <summary>
        /// Merged configuration for this integration sourced from ConfigJson in the Integration DB row.
        /// </summary>
        public required IConfiguration Configuration { get; init; }

        /// <summary>Host environment (Development/Staging/Production, content root, etc.).</summary>
        public required IHostEnvironment HostEnvironment { get; init; }

        /// <summary>
        /// A host-controlled writable directory for module data (cache, temp, small local DBs).
        /// Scoped to <see cref="PublicId"/> so each installation of a module gets its own space.
        /// Never assume BaseDirectory is writable.
        /// </summary>
        public required string DataDirectory { get; init; }

        /// <summary>
        /// Config schema version from the Integration DB row.
        /// Plugins may use this to detect and perform config migrations.
        /// </summary>
        public int? ConfigSchemaVersion { get; init; }

        /// <summary>
        /// Optional: module version as seen by the host (usually assembly version or metadata version).
        /// </summary>
        public Version? Version { get; init; }
    }
}
