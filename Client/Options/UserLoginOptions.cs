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
        /// This will disable manual user login from host. False by default.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; init; } = false;
    }
}
