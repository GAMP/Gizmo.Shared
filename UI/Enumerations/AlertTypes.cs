using System.ComponentModel;

namespace Gizmo.UI
{
    public enum AlertTypes
    {
        None,

        [Description("danger")]
        Danger,

        [Description("success")]
        Success,

        [Description("warning")]
        Warning,

        [Description("info")]
        Info
    }
}
