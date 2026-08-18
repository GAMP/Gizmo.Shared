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

        /// <summary>
        /// Defines if user registration is enabled on the client.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsRegistrationEnabled { get; set; }

        /// <summary>
        /// Defines if direct user registration is enabled on the client.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool IsDirectRegistrationEnabled { get; set; }

        /// <summary>
        /// Defines if user password recovery is enabled on the client.
        /// </summary>
        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool IsPasswordRecoveryEnabled { get; set; }
    }
}
