using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Holds the current UI-editable value for one property in an integration configuration form.
    /// Mirrors the structure of <see cref="ModuleConfigPropertyMetadata"/> with a mutable value slot.
    /// </summary>
    public sealed class IntegrationConfigPropertyValue
    {
        /// <summary>
        /// The schema metadata this value node corresponds to.
        /// </summary>
        public ModuleConfigPropertyMetadata Schema { get; init; } = null!;

        /// <summary>
        /// The current string representation of the value for scalar property kinds
        /// (<see cref="ModuleConfigPropertyKind.String"/>,
        /// <see cref="ModuleConfigPropertyKind.Integer"/>,
        /// <see cref="ModuleConfigPropertyKind.Decimal"/>,
        /// <see cref="ModuleConfigPropertyKind.Boolean"/>,
        /// <see cref="ModuleConfigPropertyKind.Enum"/>).
        /// Always <see langword="null"/> for <see cref="ModuleConfigPropertyKind.Object"/> kinds —
        /// use <see cref="NestedValues"/> instead.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// For <see cref="ModuleConfigPropertyKind.Object"/> properties, the value nodes for
        /// the nested child properties. <see langword="null"/> for all scalar kinds.
        /// </summary>
        public List<IntegrationConfigPropertyValue>? NestedValues { get; init; }

        /// <summary>
        /// Validation error message for this property, or <see langword="null"/> when valid.
        /// Set by the UI validation layer.
        /// </summary>
        public string? ValidationMessage { get; set; }
    }
}
