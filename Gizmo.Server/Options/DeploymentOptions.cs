using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("DEPLOYMENT")]
    [StoreOptionsGroup("DEPLOYMENT")]
    [MessagePack.MessagePackObject()]
    public sealed class DeploymentOptions : IStoreOptions
    {
        [Name("Disk space allocation")]
        [ExtendedDescription("Specifies disk space allocation")]
        [DefaultValue(DiskSpaceAllocations.Zero)]
        [StoreOptionKey("DISK_SPACE_ALLOCATION")]
        [MessagePack.Key(0)]
        public DiskSpaceAllocations DiskSpaceAllocation
        {
            get;init;
        }
    }
}
