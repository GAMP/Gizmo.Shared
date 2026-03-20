using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly List<IntegrationInstanceEntry> _instances = new();

        /// <summary>
        /// All discovered integration types.
        /// </summary>
        public IReadOnlyList<IntegrationTypeEntry> Entries => _entries;

        /// <summary>
        /// All discovered integration instances.
        /// </summary>
        public IReadOnlyList<IntegrationInstanceEntry> Instances => _instances;

        /// <summary>
        /// Adds a discovered integration type to the registry.
        /// </summary>
        internal void Add(Guid typeGuid, string name, Type implementationType, IReadOnlyList<Guid> capabilities)
        {
            _entries.Add(new IntegrationTypeEntry(typeGuid, name, implementationType, capabilities));
        }

        /// <summary>
        /// Adds a discovered integration instance to the registry.
        /// </summary>
        internal void AddInstance(Guid typeGuid, Guid publicId, Type implementationType)
        {
            _instances.Add(new IntegrationInstanceEntry(typeGuid, publicId, implementationType));
        }

        /// <summary>
        /// Finds the first instance whose type has the specified capability.
        /// </summary>
        public IntegrationInstanceEntry? FindInstanceByCapability(Guid capabilityGuid)
        {
            var typeGuids = _entries
                .Where(e => e.Capabilities.Contains(capabilityGuid))
                .Select(e => e.TypeGuid)
                .ToHashSet();

            return _instances.FirstOrDefault(i => typeGuids.Contains(i.TypeGuid));
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

    /// <summary>
    /// Describes a single integration instance (a configured installation of an integration type).
    /// </summary>
    /// <param name="TypeGuid">The type this instance belongs to.</param>
    /// <param name="PublicId">The unique instance identifier used as the DI keyed-service key.</param>
    /// <param name="ImplementationType">The CLR implementation type.</param>
    public sealed record IntegrationInstanceEntry(
        Guid TypeGuid,
        Guid PublicId,
        Type ImplementationType);
}
