#nullable enable

using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Popular items options.
    /// </summary>
    [MessagePackObject()]
    public sealed class PopularItemsOptions
    {
        /// <summary>
        /// Gets or sets maximum popular products to display.
        /// </summary>
        [Key(0)]
        public int MaxPopularProducts { get; set; }

        /// <summary>
        /// Gets or sets maximum popular applications to display.
        /// </summary>
        [Key(1)]
        public int MaxPopularApplications { get; set; }

        /// <summary>
        /// Gets or sets maximum quick launch executables to display.
        /// </summary>
        [Key(2)]
        public int MaxQuickLaunchExecutables { get; set; }

        /// <summary>
        /// Gets or sets maximum home page items per row to display.
        /// </summary>
        [Key(3)]
        public int HomePageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets apps home page items per row to display.
        /// </summary>
        [Key(4)]
        public int AppsPageMaxItemsPerRow { get; set; }

        /// <summary>
        /// Gets or sets products home page items per row to display.
        /// </summary>
        [Key(5)]
        public int ProductsPageMaxItemsPerRow { get; set; }
    }
}
