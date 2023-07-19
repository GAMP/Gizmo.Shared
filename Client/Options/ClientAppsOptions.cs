using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class ClientAppsOptions
    {
        [MessagePack.Key(0)]
        [DefaultValue(ApplicationSortingOption.Popularity)]
        public ApplicationSortingOption DefaultSortingOption
        {
            get; set;
        }
    }
}
