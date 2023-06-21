#nullable enable


using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Client user interface options.
    /// </summary>
    [MessagePackObject()]
    public sealed class ClientInterfaceOptions
    {
        /// <summary>
        /// Gets background.
        /// </summary>
        [Key(0)]
        public string? Background
        {
            get; set;
        }

        /// <summary>
        /// Gets skin.
        /// </summary>
        [Key(1)]
        public string? Skin
        {
            get; set;
        }

        /// <summary>
        /// Whether the app details are disabled.
        /// </summary>
        [Key(2)]
        public bool DisableAppDetails
        {
            get; set;
        }

        /// <summary>
        /// Whether the product details are disabled.
        /// </summary>
        [Key(3)]
        public bool DisableProductDetails
        {
            get; set;
        }
    }
}
