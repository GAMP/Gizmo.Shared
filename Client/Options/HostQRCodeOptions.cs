using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject]
    public sealed class HostQRCodeOptions
    {
        /// <summary>
        /// Indicates if host qr code is enabled.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Enabled { get; init; } = false;
    }
}
