#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Popular items options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class PopularItemsOptions
    {
        /// <summary>
        /// Gets or sets maximum popular products to display.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(8)]
        [Range(0, int.MaxValue)]
        public int MaxPopularProducts { get; set; }

        /// <summary>
        /// Gets or sets maximum popular applications to display.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(8)]
        [Range(0, int.MaxValue)]
        public int MaxPopularApplications { get; set; }
    }
}
