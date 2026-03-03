using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Collects integration type metadata discovered by <see cref="ModuleLoader"/> so that
    /// downstream consumers (e.g. integration management API) can enumerate all available
    /// integration types without scanning assemblies again.
    /// </summary>
    public sealed class IntegrationTypeRegistry
    {
        private readonly List<IntegrationTypeEntry> _entries = new();

        /// <summary>
        /// All discovered integration types.
        /// </summary>
        public IReadOnlyList<IntegrationTypeEntry> Entries => _entries;

        /// <summary>
        /// Adds a discovered integration type to the registry.
        /// </summary>
        internal void Add(Guid typeGuid, string name, Assembly assembly)
        {
            _entries.Add(new IntegrationTypeEntry(typeGuid, name, assembly));
        }
    }

    /// <summary>
    /// Describes a single integration type discovered from a <see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute"/>.
    /// </summary>
    /// <param name="TypeGuid">The stable type identifier (<see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute.ModuleGuid"/>).</param>
    /// <param name="Name">Human-readable name (<see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute.Id"/>).</param>
    /// <param name="Assembly">The assembly containing the integration type, used for resource resolution.</param>
    public sealed record IntegrationTypeEntry(
        Guid TypeGuid,
        string Name,
        Assembly Assembly);
}
