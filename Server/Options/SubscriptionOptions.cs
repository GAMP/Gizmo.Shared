#nullable enable

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("SUBSCRIPTION")]
    [StoreOptionsGroup("SUBSCRIPTION")]
    [MessagePack.MessagePackObject()]
    public sealed class SubscriptionOptions : IStoreOptions
    {
        [Name("Username", "SERVER_OPTION_SUBSCRIPTION_USERNAME_NAME")]
        [ExtendedDescription("Subscription username", "SERVER_OPTION_SUBSCRIPTION_USERNAME_DESCRIPTION")]
        [StoreOptionKey("USERNAME")]
        [MessagePack.Key(0)]
        public string? Username { get; init; }

        [Name("Password", "SERVER_OPTION_SUBSCRIPTION_PASSWORD_NAME")]
        [ExtendedDescription("Subscription password", "SERVER_OPTION_SUBSCRIPTION_PASSWORD_DESCRIPTION")]
        [StoreOptionKey("PASSWORD")]
        [MessagePack.Key(1)]
        public string? Password { get; init; }
    }
}
