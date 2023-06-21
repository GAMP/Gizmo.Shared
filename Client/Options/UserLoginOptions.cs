using System.ComponentModel;
using MessagePack;

namespace Gizmo.Client.UI
{
    [MessagePackObject()]
    public sealed class UserLoginOptions
    {
        /// <summary>
        /// Indicates if user login is disabled.
        /// </summary>
        /// <remarks>
        /// This will disable manual user login from host. False by default.
        /// </remarks>
        [Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; init; } = false;
    }
}
