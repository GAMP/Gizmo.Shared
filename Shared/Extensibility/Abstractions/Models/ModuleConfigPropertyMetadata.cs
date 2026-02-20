using System.Collections.Generic;
using MessagePack;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Describes a single bindable property within a module configuration options class.
    /// </summary>
    [MessagePackObject]
    public sealed class ModuleConfigPropertyMetadata
    {
        /// <summary>
        /// The JSON key for this property as it appears in <c>ConfigJson</c>.
        /// Sourced from <c>[JsonPropertyName]</c> if present, otherwise the property name
        /// converted to camelCase following <c>System.Text.Json</c> conventions.
        /// </summary>
        [Key(0)]
        public string JsonKey { get; init; } = string.Empty;

        /// <summary>
        /// Display name for the UI.
        /// Sourced from <c>[Name]</c> if present, otherwise the property name.
        /// </summary>
        [Key(1)]
        public string DisplayName { get; init; } = string.Empty;

        /// <summary>
        /// Optional description shown as a hint or tooltip in the UI.
        /// Sourced from <c>[ExtendedDescription]</c> if present.
        /// </summary>
        [Key(2)]
        public string? Description { get; init; }

        /// <summary>
        /// Semantic kind of the property value.
        /// Determines the UI widget to render and the JSON serialization format.
        /// </summary>
        [Key(3)]
        public ModuleConfigPropertyKind Kind { get; init; }

        /// <summary>
        /// Indicates that the property accepts <see langword="null"/> as a valid value.
        /// Always <see langword="false"/> for <c>string</c> (use <see cref="IsRequired"/>
        /// to determine whether the string may be absent or empty).
        /// </summary>
        [Key(4)]
        public bool IsNullable { get; init; }

        /// <summary>
        /// Default value as a string, or <see langword="null"/> if none is declared.
        /// Sourced from <c>[System.ComponentModel.DefaultValue]</c>.
        /// </summary>
        [Key(5)]
        public string? DefaultValue { get; init; }

        /// <summary>
        /// Allowed values for this property.
        /// Populated from <see cref="ModuleConfigAllowedValuesAttribute"/> for non-enum types,
        /// or automatically from enum members (including their <c>[Name]</c> and
        /// <c>[ExtendedDescription]</c>) for enum-typed properties.
        /// Empty when there is no restriction.
        /// </summary>
        [Key(6)]
        public IReadOnlyList<ModuleConfigAllowedValueMetadata> AllowedValues { get; init; } = [];

        /// <summary>
        /// Indicates that this property is required in the configuration.
        /// Sourced from <c>[JsonRequired]</c>.
        /// </summary>
        [Key(7)]
        public bool IsRequired { get; init; }

        /// <summary>
        /// Indicates that this property holds sensitive data (password, API key, token).
        /// The UI should mask the value.
        /// Sourced from <see cref="ModuleConfigSensitiveAttribute"/>.
        /// </summary>
        [Key(8)]
        public bool IsSensitive { get; init; }

        /// <summary>
        /// For <see cref="ModuleConfigPropertyKind.Object"/> properties, the metadata of the
        /// nested child properties. <see langword="null"/> for all other kinds.
        /// Also <see langword="null"/> when a circular reference was detected during extraction.
        /// </summary>
        [Key(9)]
        public IReadOnlyList<ModuleConfigPropertyMetadata>? NestedProperties { get; init; }
    }
}
