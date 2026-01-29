
using System.ComponentModel;

namespace Gizmo.Client.Options
{
    [MessagePack.MessagePackObject]
    public sealed class HostQRCodeOptions
    {
        /// <summary>
        /// Defines if host qr code is enabled.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// Defines if host qr code is base 64.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsBase64 { get; set; } = false;
        
        /// <summary>
        /// Title text 
        /// </summary>
        /// <remarks>
        /// It is displayed on the login card
        /// </remarks>
        [MessagePack.Key(2)]
        public string? Title { get; set; }
        
        /// <summary>
        /// Description text 
        /// </summary>
        /// <remarks>
        /// It is displayed on the login card
        /// </remarks>
        [MessagePack.Key(3)]
        public string? Description { get; set; }


        /// <summary>
        /// Defines if QR should contain url.
        /// </summary>
        [MessagePack.Key(4)]
        [DefaultValue(false)]
        public bool GenerateURL { get; set; } = false;

        /// <summary>
        /// Defines QR code parameters url.
        /// </summary>
        [MessagePack.Key(5)]
        [DefaultValue(false)]
        public string? URL { get; set; }
    }
}
