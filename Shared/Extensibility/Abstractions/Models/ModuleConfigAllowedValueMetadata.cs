using MessagePack;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Describes a single allowed value for a module configuration property.
    /// </summary>
    [MessagePackObject]
    public sealed class ModuleConfigAllowedValueMetadata
    {
        /// <summary>
        /// Display name for this value, or <see langword="null"/> if not specified.
        /// Sourced from <c>[Name]</c> on the enum member, or <see langword="null"/> for
        /// values declared via <see cref="ModuleConfigAllowedValuesAttribute"/>.
        /// </summary>
        [Key(0)]
        public string? Name { get; init; }

        /// <summary>
        /// Description for this value, or <see langword="null"/> if not specified.
        /// Sourced from <c>[ExtendedDescription]</c> on the enum member.
        /// </summary>
        [Key(1)]
        public string? Description { get; init; }

        /// <summary>
        /// The string representation of the value as it appears in <c>ConfigJson</c>.
        /// </summary>
        [Key(2)]
        public string Value { get; init; } = string.Empty;
    }
}
