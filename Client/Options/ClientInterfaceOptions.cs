#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Client user interface options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientInterfaceOptions
    {
        /// <summary>
        /// Gets background.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(null)]
        public string? Background
        {
            get; set;
        }

        /// <summary>
        /// Gets login background.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(null)]
        public string? LoginBackground
        {
            get;set;
        }

        /// <summary>
        /// Gets custom style sheet.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(null)]
        public string? StyleSheet
        {
            get; set;
        }

        /// <summary>
        /// Whether the app details are disabled.
        /// </summary>
        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool DisableAppDetails
        {
            get; set;
        }

        /// <summary>
        /// Whether the product details are disabled.
        /// </summary>
        [MessagePack.Key(4)]
        [DefaultValue(false)]
        public bool DisableProductDetails
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets maximum home page items per row to display.
        /// </summary>
        [MessagePack.Key(5)]
        [DefaultValue(8)]
        [Range(1,int.MaxValue)]
        public int HomePageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets apps home page items per row to display.
        /// </summary>
        [MessagePack.Key(6)]
        [DefaultValue(8)]
        [Range(1, int.MaxValue)]
        public int AppsPageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets products home page items per row to display.
        /// </summary>
        [MessagePack.Key(7)]
        [DefaultValue(6)]
        [Range(1, int.MaxValue)]
        public int ProductsPageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets maximum quick quick executables to display.
        /// </summary>
        /// <remarks>
        /// This enforces maximum on both user favorites and quick launch executables.
        /// </remarks>
        [MessagePack.Key(8)]
        [DefaultValue(16)]
        [Range(1,int.MaxValue)]
        public int QuickLaunchMaxItems { get; set; }
    }
}
