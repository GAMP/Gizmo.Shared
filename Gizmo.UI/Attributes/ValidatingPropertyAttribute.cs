using System;

namespace Gizmo.UI
{
    /// <summary>
    /// Marks property eligible for validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ValidatingPropertyAttribute : Attribute
    {
        /// <summary>
        /// Defines if aync validation should be executed for this property.
        /// </summary>
        public bool IsAsync { get; init; } = false;
    }

    /// <summary>
    /// Inidicates what triggered validation.
    /// </summary>
    public enum ValidationTrigger
    {
        /// <summary>
        /// Validation is done upon user input.
        /// </summary>
        Input = 0,
        /// <summary>
        /// Validation is done upon EditContext validation request.
        /// </summary>
        Request = 1,
    }
}
