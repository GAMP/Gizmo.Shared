#nullable enable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERFILES")]
    [StoreOptionsGroup("USER_FILES")]
    [MessagePack.MessagePackObject()]
    public sealed class UserFilesOptions : IStoreOptions
    {
        [Name("User data path", "SERVER_OPTION_FILES_USER_DATA_PATH_NAME")]
        [ExtendedDescription("Specifies user data path", "SERVER_OPTION_FILES_USER_DATA_PATH_DESCRIPTION")]
        [StoreOptionKey("USER_DATA_PATH")]
        [DefaultValue("UserData")]
        [StringLength(255)]
        [MessagePack.Key(0)]
        public string? UserDataPath
        {
            get;
            set;
        }

        [Name("Defaults user data path", "SERVER_OPTION_FILES_DEFAULTS_USER_DATA_PATH_NAME")]
        [ExtendedDescription("Specifies defaults data path", "SERVER_OPTION_FILES_DEFAULTS_USER_DATA_PATH_DESCRIPTION")]
        [StoreOptionKey("DEFAULTS_USER_DATA_PATH")]
        [DefaultValue("DefaultUserFiles")]
        [StringLength(255)]
        [MessagePack.Key(1)]
        public string? DefaultsUserDataPath
        {
            get;
            set;
        }
    }
}
