using System;

namespace Gizmo.UI
{ 
    /// <summary>
    /// Marks property eligible for validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ValidatingPropertyAttribute : Attribute
    {
    }
}
