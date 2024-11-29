#nullable enable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("SMTP")]
    [StoreOptionsGroup("SMTP")]
    [MessagePack.MessagePackObject()]
    public sealed class SMTPOptions : IStoreOptions
    {
        [Name("Enable SMTP", "SERVER_OPTION_SMTP_ENABLED_NAME")]
        [StoreOptionKey("ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool IsEnabled
        {
            get; init;
        }

        [Name("SMTP Host", "SERVER_OPTION_SMTP_HOST_NAME")]
        [StoreOptionKey("HOST")]
        [StringLength(255)]
        [Required()]
        [MessagePack.Key(1)]
        public string Host
        {
            get; init;
        } = null!;

        [Name("SMTP Port", "SERVER_OPTION_SMTP_PORT_NAME")]
        [StoreOptionKey("PORT")]
        [DefaultValue(465)]
        [Range(1, 65536)]
        [MessagePack.Key(2)]
        public int Port
        {
            get; init;
        }

        [Name("Enable authentication", "SERVER_OPTION_SMTP_ENABLE_AUTHENTICATION_NAME")]
        [StoreOptionKey("ENABLE_AUTHENTICATION")]
        [DefaultValue(false)]
        [MessagePack.Key(3)]
        public bool EnableAuthentication
        {
            get; init;
        }

        [Name("SMTP Username", "SERVER_OPTION_SMTP_USERNAME_NAME")]
        [StoreOptionKey("USERNAME")]
        [DataMember()]
        [StringLength(255)]
        [MessagePack.Key(4)]
        public string? Username  
        {
            get; init;
        }

        [Name("SMTP Password", "SERVER_OPTION_SMTP_PASSWORD_NAME")]
        [StoreOptionKey("PASSWORD")]
        [StringLength(255)]
        [MessagePack.Key(5)]
        public string? Password
        {
            get; init;
        }

        [Name("Use SSL", "SERVER_OPTION_SMTP_USE_SSL_NAME")]
        [StoreOptionKey("USE_SSL")]
        [DefaultValue(true)]
        [MessagePack.Key(6)]
        public bool UseSSL
        {
            get; init;
        }

        [Name("SMTP Security", "SERVER_OPTION_SMTP_SMTP_SECURITY_NAME")]
        [StoreOptionKey("SMTP_SECURITY")]
        [DefaultValue(SMTPSecurity.SSL)]
        [MessagePack.Key(7)]
        public SMTPSecurity SMTPSecurity
        {
            get; init;
        }

        [Name("Reply to address", "SERVER_OPTION_SMTP_REPLY_TO_ADDRESS_NAME")]
        [StoreOptionKey("REPLY_TO_ADDRESS")]
        [EmailNullEmptyValidation()]
        [MessagePack.Key(8)]
        public string? ReplyToAddress
        {
            get; init;
        }
    }
}
