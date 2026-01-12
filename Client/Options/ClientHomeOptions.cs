using System.ComponentModel;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Home options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientHomeOptions
    {
        /// <summary>
        /// Disable home.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get;set;
        }
    }
}
