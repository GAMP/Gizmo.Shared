#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Login rotator options.
    /// </summary>
    [MessagePackObject()]
    public sealed class LoginRotatorOptions
    {
        /// <summary>
        /// Gets or sets if rotator is enabled.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets path of images/videos.
        /// </summary>
        [MessagePack.Key(1)]
        public string? Path { get; set; }

        /// <summary>
        /// Defines delay between feed rotation in seconds.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(5)]
        [Range(1, int.MaxValue)]
        public int RotateEvery { get; init; };
    }
}
