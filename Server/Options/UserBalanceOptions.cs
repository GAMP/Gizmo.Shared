using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERBALANCE")]
    [StoreOptionsGroup("USER_BALANCE")]
    [MessagePack.MessagePackObject()]
    public sealed class UserBalanceOptions : IStoreOptions
    {
        [Name("Protocols", "SERVER_OPTION_USER_BALANCE_WITHOLD_UNPAID_USAGE_SESSION_DEPOSITS_NAME")]
        [StoreOptionKey("WITHOLD_UNPAID_USAGE_SESSION_DEPOSITS")]
        [DefaultValue(true)]
        [MessagePack.Key(0)]
        public bool WithholdUnpaidUsageSessionDeposits { get;init;}
    }
}
