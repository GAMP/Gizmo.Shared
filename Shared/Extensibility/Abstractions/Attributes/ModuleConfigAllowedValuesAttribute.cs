using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Restricts the allowed values for a module configuration property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Manager UI will render the property as a dropdown/select control populated with
    /// the values declared here. Each value is stored as its <see cref="object.ToString()"/>
    /// representation in <c>ConfigJson</c>.
    /// </para>
    /// <para>
    /// For <c>enum</c>-typed properties the allowed values are derived automatically from the
    /// enum members — this attribute is only needed when you want to restrict a non-enum
    /// property to a fixed set of choices.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ModuleConfigAllowedValuesAttribute : Attribute
    {
        /// <param name="values">The allowed values for this property.</param>
        public ModuleConfigAllowedValuesAttribute(params object[] values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
        }

        /// <summary>Gets the allowed values for this property.</summary>
        public object[] Values { get; }
    }
}
