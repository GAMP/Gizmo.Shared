using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Holds the current UI-editable values for all properties in one configuration section.
    /// Mirrors the structure of <see cref="ModuleConfigSectionMetadata"/> with mutable value slots.
    /// </summary>
    public sealed class IntegrationConfigSectionValues
    {
        /// <summary>
        /// The schema metadata this section corresponds to.
        /// </summary>
        public ModuleConfigSectionMetadata Schema { get; init; } = null!;

        /// <summary>
        /// Value nodes for each property in the section, in schema order.
        /// </summary>
        public List<IntegrationConfigPropertyValue> Properties { get; init; } = [];
    }
}
