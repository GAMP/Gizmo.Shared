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
        /// <summary>Stable module identifier (prefer metadata-driven, not file name).</summary>
        public required string ModuleId { get; init; }

        /// <summary>Full path to the module's main assembly (.dll) that the host loaded.</summary>
        public required string AssemblyPath { get; init; }

        /// <summary>Directory that contains the module assembly and its private dependencies.</summary>
        public required string BaseDirectory { get; init; }

        /// <summary>Host-provided configuration section scoped to this module (e.g. Modules:{ModuleId}).</summary>
        public required IConfiguration Configuration { get; init; }

        /// <summary>Host environment (Development/Staging/Production, content root, etc.).</summary>
        public required IHostEnvironment HostEnvironment { get; init; }

        /// <summary>
        /// A host-controlled writable directory for module data (cache, temp, small local DBs).
        /// Never assume BaseDirectory is writable.
        /// </summary>
        public required string DataDirectory { get; init; }

        /// <summary>
        /// Optional: module version as seen by the host (usually assembly version or metadata version).
        /// </summary>
        public Version? Version { get; init; }
    }
}
