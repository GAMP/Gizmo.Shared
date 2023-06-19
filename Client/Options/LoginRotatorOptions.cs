#nullable enable

using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Login rotator options.
    /// </summary>
    public sealed class LoginRotatorOptions
    {
        /// <summary>
        /// Gets or sets if rotator is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets path of images/videos.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// Defines delay between feed rotation in seconds.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int RotateEvery { get; init; } = 6;
    }
}
