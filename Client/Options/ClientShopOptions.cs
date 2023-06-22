using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class ClientShopOptions
    {
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get;set;
        }
    }
}
