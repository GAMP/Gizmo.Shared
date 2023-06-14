#nullable enable


namespace Gizmo.Client.UI
{
    /// <summary>
    /// Client user interface options.
    /// </summary>
    public sealed class ClientUIOptions
    {
        /// <summary>
        /// Gets background.
        /// </summary>
        public string? Background
        {
            get; set;
        }

        /// <summary>
        /// Gets skin.
        /// </summary>
        public string? Skin
        {
            get; set;
        }

        /// <summary>
        /// Whether the app details are disabled.
        /// </summary>
        public bool DisableAppDetails
        {
            get; set;
        }

        /// <summary>
        /// Whether the product details are disabled.
        /// </summary>
        public bool DisableProductDetails
        {
            get; set;
        }
    }
}
