using System.Collections.Generic;
using MessagePack;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Describes the configuration schema for one <see cref="ModuleOptionsAttribute"/> entry
    /// declared on a module type.
    /// </summary>
    /// <remarks>
    /// A single module type may carry multiple <see cref="ModuleOptionsAttribute"/> declarations,
    /// each producing one <see cref="ModuleConfigSectionMetadata"/> instance.
    /// </remarks>
    [MessagePackObject]
    public sealed class ModuleConfigSectionMetadata
    {
        /// <summary>
        /// Fully qualified type name of the options class (e.g. <c>"MyPlugin.ConnectionOptions"</c>).
        /// </summary>
        [Key(0)]
        public string OptionsTypeName { get; init; } = string.Empty;

        /// <summary>
        /// The JSON section name this options class is bound from, or <see langword="null"/>
        /// when the entire <c>ConfigJson</c> root is used.
        /// Matches <see cref="ModuleOptionsAttribute.SectionName"/>.
        /// </summary>
        [Key(1)]
        public string? SectionName { get; init; }

        /// <summary>
        /// Metadata for each bindable property in the options class.
        /// Properties annotated with <c>[JsonIgnore]</c> are excluded.
        /// </summary>
        [Key(2)]
        public IReadOnlyList<ModuleConfigPropertyMetadata> Properties { get; init; } = [];
    }
}
