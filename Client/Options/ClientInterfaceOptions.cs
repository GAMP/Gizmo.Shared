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

        /// <summary>
        /// Gets or sets maximum home page items per row to display.
        /// </summary>
        [Key(4)]
        public int HomePageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets apps home page items per row to display.
        /// </summary>
        [Key(5)]
        public int AppsPageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets products home page items per row to display.
        /// </summary>
        [Key(6)]
        public int ProductsPageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets maximum quick quick executables to display.
        /// </summary>
        /// <remarks>
        /// This enforces maximum on both user favorites and quick launch executables.
        /// </remarks>
        [Key(7)]
        public int QuickLaunchMaxItems { get; set; }
    }
}
