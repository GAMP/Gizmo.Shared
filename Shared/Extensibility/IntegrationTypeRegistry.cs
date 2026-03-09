using System;
using System.Collections.Generic;

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
        internal void Add(Guid typeGuid, string name, Type implementationType, IReadOnlyList<Guid> capabilities)
        {
            _entries.Add(new IntegrationTypeEntry(typeGuid, name, implementationType, capabilities));
        }
    }

    /// <summary>
    /// Describes a single integration type discovered from a <see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute"/>.
    /// </summary>
    /// <param name="TypeGuid">The stable type identifier (<see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute.ModuleGuid"/>).</param>
    /// <param name="Name">Human-readable name (<see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute.Id"/>).</param>
    /// <param name="ImplementationType">The CLR type decorated with <see cref="Gizmo.Extensibility.Abstractions.ModuleMetadataAttribute"/>, used for resource resolution.</param>
    /// <param name="Capabilities">Well-known capability GUIDs discovered from interfaces decorated with <see cref="Abstractions.IntegrationCapabilityAttribute"/>.</param>
    public sealed record IntegrationTypeEntry(
        Guid TypeGuid,
        string Name,
        Type ImplementationType,
        IReadOnlyList<Guid> Capabilities);
}
