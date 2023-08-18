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
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// Indicates if host qr code is base 64.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsBase64 { get; set; } = false;
    }
}
