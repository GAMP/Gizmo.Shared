using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class UserLoginOptions
    {
        /// <summary>
        /// Indicates if user login is disabled.
        /// </summary>
        /// <remarks>
        /// This will disable user login form in the UI. False by default.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; set; } = false;
    }
}
