using System;

namespace Gizmo
{
    /// <summary>
    /// Disables metadata generation for applie class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class HideMetadataAttribute : Attribute
    {
    }
}
