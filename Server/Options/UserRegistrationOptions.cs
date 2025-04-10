using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERREGISTRATION")]
    [StoreOptionsGroup("USER_REGISTRATION")]
    [MessagePack.MessagePackObject()]
    public sealed class UserRegistrationOptions : IStoreOptions
    {
        [Name("Client enabled")]
        [ExtendedDescription("Specifies if client user registration is enabled")]
        [StoreOptionKey("CLIENT_ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool IsClientEnabled { get; init; }

        [Name("Web portal enabled")]
        [ExtendedDescription("Specifies if web portal user registration is enabled")]
        [StoreOptionKey("PORTAL_ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(1)]
        public bool IsPortalEnabled { get; init; }

        [Name("Verification method")]
        [ExtendedDescription("Specifies user verification method")]
        [StoreOptionKey("VERIFICATION_METHOD")]
        [MessagePack.Key(2)]
        [DefaultValue(UserRecoveryMethod.None)]
        public RegistrationVerificationMethod VerificationMethod { get; init; }
    }
}
