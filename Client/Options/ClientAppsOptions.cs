using System.ComponentModel;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Applications options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientAppsOptions
    {
        /// <summary>
        /// Default application sorting.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(ApplicationSortingOption.Popularity)]
        public ApplicationSortingOption DefaultSortingOption
        {
            get; set;
        }
    }
}
