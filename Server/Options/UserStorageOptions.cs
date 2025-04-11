using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Shared.Server.Options
{
    [OptionsConfigurationSection("USERSTORAGE")]
    [StoreOptionsGroup("USER_STORAGE")]
    [MessagePack.MessagePackObject()]
    public sealed class UserStorageOptions : IStoreOptions
    {
        [Name("Enabled")]
        [ExtendedDescription("Specifies if user storage is enabled")]
        [StoreOptionKey("ENABLED")]
        [MessagePack.Key(0)]
        public bool IsEnabled { get; init; }

        [Name("Mount point")]
        [ExtendedDescription("Specifies user storage mount point")]
        [StoreOptionKey("MOUNT_POINT")]
        [DefaultValue("U:")]
        [StringLength(2)]
        [MessagePack.Key(1)]
        public string MountPoint { get; init; } = string.Empty;

        [Name("Size")]
        [ExtendedDescription("Specifies user storage size")]
        [StoreOptionKey("SIZE")]
        [MessagePack.Key(2)]
        public long Size { get; init; }

        [Name("Redirected folders")]
        [ExtendedDescription("Specifies user storage redirected folders")]
        [StoreOptionKey("REDIRECTED_FOLDERS")]
        [MessagePack.Key(3)]
        public int RedirectedFolders { get; init; }
    }
}
