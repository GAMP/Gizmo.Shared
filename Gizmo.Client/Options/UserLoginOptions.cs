using System.ComponentModel;

namespace Gizmo.Client.Options
{
    [MessagePack.MessagePackObject()]
    public sealed class UserLoginOptions
    {
        /// <summary>
        /// Defines if user login is disabled.
        /// </summary>
        /// <remarks>
        /// This will disable user login form in the UI. False by default.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; set; } = false;
    }
}
