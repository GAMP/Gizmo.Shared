using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Feed options.
    /// </summary>
    public sealed class FeedsOptions
    {
        /// <summary>
        /// Defines delay between feed rotation in seconds.
        /// </summary>
        [Range(1,int.MaxValue)]
        public int RotateEvery { get; init; } = 6;
    }
}
