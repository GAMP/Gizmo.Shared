using System.ComponentModel;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Client shop.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientShopOptions
    {
        /// <summary>
        /// Defines if client shop is disabled.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get;set;
        }
    }
}
