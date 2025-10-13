using System;

namespace Gizmo.UI
{
    /// <summary>
    /// Generic attribute to identify user menu modules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited =false)]
    public sealed class UserMenuUIModuleAttribute : UIModuleAttribute { }
}
