namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Describes the semantic kind of a module configuration property value.
    /// Used by the Manager UI to select the appropriate input widget and to
    /// determine how the value should be serialized in the configuration JSON.
    /// </summary>
    public enum ModuleConfigPropertyKind
    {
        /// <summary>
        /// A text value. Serialized as a JSON string: <c>"value"</c>.
        /// </summary>
        String,

        /// <summary>
        /// A whole-number value (<c>int</c>, <c>long</c>, <c>short</c>, etc.).
        /// Serialized as a JSON number: <c>42</c>.
        /// </summary>
        Integer,

        /// <summary>
        /// A floating-point or fixed-point value (<c>double</c>, <c>float</c>, <c>decimal</c>).
        /// Serialized as a JSON number: <c>3.14</c>.
        /// </summary>
        Decimal,

        /// <summary>
        /// A true/false value. Serialized as a JSON boolean: <c>true</c> or <c>false</c>.
        /// </summary>
        Boolean,

        /// <summary>
        /// An enumeration value. <see cref="ModuleConfigPropertyMetadata.AllowedValues"/> is
        /// always populated. Serialized as the enum member name string because
        /// <c>IConfiguration</c> binds enums by name: <c>"MemberName"</c>.
        /// </summary>
        Enum,

        /// <summary>
        /// A nested configuration object. <see cref="ModuleConfigPropertyMetadata.NestedProperties"/>
        /// contains the metadata for the child properties.
        /// Serialized as a JSON object: <c>{ "Child": { "Key": "value" } }</c>.
        /// </summary>
        Object,
    }
}
