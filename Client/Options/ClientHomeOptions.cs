using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class ClientHomeOptions
    {
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get;set;
        }
    }
}
