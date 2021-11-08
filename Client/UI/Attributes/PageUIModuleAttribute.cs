using System;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Generic attribute to identify page modules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false, Inherited =false)]
    public class PageUIModuleAttribute : UIModuleAttribute
    {
    }
}
