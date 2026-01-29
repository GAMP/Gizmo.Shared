
using System.ComponentModel;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Client logo options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class LogoOptions
    {
        /// <summary>
        /// Gets logo.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(null)]
        public string? Logo { get; set; }
    }
}
