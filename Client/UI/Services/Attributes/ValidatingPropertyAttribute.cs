using System;

namespace Gizmo.Client.UI.View.States
{
    /// <summary>
    /// Marks property eligible for validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ValidatingPropertyAttribute : Attribute
    {
    }
}
