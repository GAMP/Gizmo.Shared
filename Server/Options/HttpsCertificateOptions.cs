#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("HTTPS_CERTIFICATE")]
    [StoreOptionsGroup("HTTPS_CERTIFICATE")]
    [MessagePack.MessagePackObject()]
    public sealed class HttpsCertificateOptions : IStoreOptions
    {
        [Name("HTTPS certificate type", "SERVER_OPTION_HTTPS_CERTIFICATE_TYPE_NAME")]
        [DefaultValue(null)]
        [StoreOptionKey("TYPE")]
        [MessagePack.Key(0)]
        public HttpsCertificateType? Type { get; init; }

        [Name("HTTPS certificate", "SERVER_OPTION_HTTPS_CERTIFICATE_NAME")]
        [DefaultValue(null)]
        [StoreOptionKey("CERTIFICATE")]
        [MessagePack.Key(1)]
        public string? Certificate {  get; init; }

        [Name("HTTPS certificate password", "SERVER_OPTION_HTTPS_CERTIFICATE_PASSWORD_NAME")]
        [DefaultValue(null)]
        [StoreOptionKey("CERTIFICATE_PASSWORD")]
        [MessagePack.Key(1)]
        public string? Password { get; init; }
    }
}
