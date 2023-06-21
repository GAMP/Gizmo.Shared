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
        /// Gets or sets maximum popular user executables to display.
        /// </summary>
        [Key(2)]
        public int MaxPopularUserExecutables { get; set; }
    }
}
