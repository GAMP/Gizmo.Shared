using MessagePack;

namespace Gizmo.Client.UI
{
    [MessagePackObject]
    public sealed class HostQRCodeOptions
    {
        /// <summary>
        /// Indicates if host qr code is enabled.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [Key(0)]
        public bool Enabled { get; init; } = false;
    }
}
