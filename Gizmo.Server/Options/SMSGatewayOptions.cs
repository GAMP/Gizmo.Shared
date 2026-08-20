using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("SMSGATEWAY")]
    [StoreOptionsGroup("SMS_GATEWAY")]
    [MessagePack.MessagePackObject()]
    public sealed class SMSGatewayOptions : IStoreOptions
    {
        [Name("Enable SMS Gateway", "SERVER_OPTION_SMS_GATEWAY_ENABLED_NAME")]
        [StoreOptionKey("ENABLED")]
        [MessagePack.Key(0)]
        public bool IsEnabled
        {
            get; set;
        }

        [Name("SMS Gateway provider", "SERVER_OPTION_SMS_GATEWAY_PROVIDER_NAME")]
        [StoreOptionKey("PROVIDER")]
        [MessagePack.Key(1)]
        public Guid? Provider
        {
            get; set;
        }

        [Name("Confirmation code message", "SERVER_OPTION_SMS_GATEWAY_CONFIRMATION_MESSAGE_NAME")]
        [ExtendedDescription("Message sent with the verification code. Use the {0} token to include the code.", "SERVER_OPTION_SMS_GATEWAY_CONFIRMATION_MESSAGE_DESCRIPTION")]
        [StoreOptionKey("CONFIRMATION_MESSAGE")]
        [DefaultValue("Hi! Your mobile phone verification code is {0}.")]
        [MessagePack.Key(2)]
        public string? ConfirmationCodeMessage
        {
            get; set;
        }

        [Name("Recovery confirmation code message", "SERVER_OPTION_SMS_GATEWAY_RECOVERY_CONFIRMATION_MESSAGE_NAME")]
        [ExtendedDescription("Message sent with the verification code for password recovery. Use the {0} token to include the code.", "SERVER_OPTION_SMS_GATEWAY_RECOVERY_CONFIRMATION_MESSAGE_DESCRIPTION")]
        [StoreOptionKey("RECOVERY_CONFIRMATION_MESSAGE")]
        [DefaultValue("Hi! Your mobile phone verification code is {0}.")]
        [MessagePack.Key(3)]
        public string? RecoveryConfirmationCodeMessage
        {
            get; set;
        }
    }
}
