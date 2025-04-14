using System;

namespace Gizmo
{
    /// <summary>
    /// Disables metadata generation for applied class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class HideMetadataAttribute : Attribute
    {
    }
}
