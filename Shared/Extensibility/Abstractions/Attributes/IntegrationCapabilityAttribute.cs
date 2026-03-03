using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Marks an interface as a well-known integration capability.
    /// When a plugin type implements an interface decorated with this attribute,
    /// the capability GUID is recorded in the <see cref="IntegrationTypeRegistry"/>
    /// so that consumers can filter integrations by supported functionality.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public sealed class IntegrationCapabilityAttribute : Attribute
    {
        public IntegrationCapabilityAttribute(string capabilityGuid)
        {
            CapabilityGuid = Guid.Parse(capabilityGuid);
        }

        /// <summary>
        /// The stable GUID identifying this capability.
        /// </summary>
        public Guid CapabilityGuid { get; }
    }
}
