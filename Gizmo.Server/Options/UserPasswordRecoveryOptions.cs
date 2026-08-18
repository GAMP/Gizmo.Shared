using System;
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
        [Obsolete("The concrete recovery method is configured on the verification methods page.")]
        [Name("Method")]
        [ExtendedDescription("Specifies user password recovery method")]
        [StoreOptionKey("METHOD")]
        [MessagePack.Key(0)]
        [DefaultValue(UserRecoveryMethod.None)]
        public UserRecoveryMethod Method { get; init; }

        [Name("Client enabled")]
        [ExtendedDescription("Specifies if client user password recovery is enabled")]
        [StoreOptionKey("CLIENT_ENABLED")]
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsClientEnabled { get; init; }
    }
}
