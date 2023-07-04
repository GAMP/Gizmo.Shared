using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Feed options.
    /// </summary>
    [MessagePackObject()]
    public sealed class FeedsOptions
    {
        /// <summary>
        /// Defines if feeds are disabled.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get; set;
        }

        /// <summary>
        /// Defines delay between feed rotation in seconds.
        /// </summary>
        [MessagePack.Key(1)]   
        [DefaultValue(5)]
        [Range(1, int.MaxValue)]
        public int RotateEvery { get; set; }
    }
}
