#nullable enable

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("SECURITY")]
    [StoreOptionsGroup("SECURITY")]
    [MessagePack.MessagePackObject()]
    public sealed class SecurityOptions : IStoreOptions
    {
        [Name("JWT secret key")]
        [ExtendedDescription("Specifies jwt secret key")]
        [StoreOptionKey("SECRET_KEY")]
        [MessagePack.Key(0)]
        public string? SecretKey { get; init; }
    }
}
