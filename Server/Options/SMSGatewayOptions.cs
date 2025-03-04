using System;
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
    }
}
