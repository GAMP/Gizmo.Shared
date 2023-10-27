#nullable enable

using System.ComponentModel;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Assistance request options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class AssistanceRequestOptions
    {
        /// <summary>
        /// Defines if the assistance requests should be disabled.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; set; }
    }
}
