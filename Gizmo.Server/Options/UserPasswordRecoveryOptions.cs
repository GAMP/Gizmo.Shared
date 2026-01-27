using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERPASSWORDRECOVERY")]
    [StoreOptionsGroup("USER_PASSWORD_RECOVERY")]
    [MessagePack.MessagePackObject()]
    public sealed class UserPasswordRecoveryOptions : IStoreOptions
    {
        [Name("Method")]
        [ExtendedDescription("Specifies user password recovery method")]
        [StoreOptionKey("METHOD")]
        [MessagePack.Key(0)]
        [DefaultValue(UserRecoveryMethod.None)]
        public UserRecoveryMethod Method { get; init; }
    }
}
