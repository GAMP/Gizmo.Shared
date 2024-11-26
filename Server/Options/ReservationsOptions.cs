using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("RESERVATIONS")]
    [StoreOptionsGroup("RESERVATIONS")]
    [MessagePack.MessagePackObject()]
    public sealed class ReservationsOptions : IStoreOptions
    {
        [Name("Enable login block", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_NAME")]
        [ExtendedDescription("Specifies default currency", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_DESCRIPTION")]
        [StoreOptionKey("ENABLE_LOGIN_BLOCK")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool EnableLoginBlock
        {
            get; set;
        }

        [Name("Login block time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_TIME_NAME")]
        [ExtendedDescription("Specifies login block time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_TIME_DESCRIPTION")]
        [StoreOptionKey("LOGIN_BLOCK_TIME")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(1)]
        public int LoginBlockTime
        {
            get; set;
        }

        [Name("Enable login unblock", "SERVER_OPTION_RESERVATIONS_LOGIN_UNBLOCK_NAME")]
        [ExtendedDescription("Specifies if login unblock is enabled", "SERVER_OPTION_RESERVATIONS_LOGIN_UNBLOCK_DESCRIPTION")]
        [StoreOptionKey("ENABLE_LOGIN_UNBLOCK")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool EnableLoginUnblock
        {
            get; set;
        }

        [Name("Login unblock time", "SERVER_OPTION_CURRENCY_CURRENCY_NAME")]
        [ExtendedDescription("Specifies login unblock time", "SERVER_OPTION_RESERVATIONS_LOGIN_UNBLOCK_TIME_DESCRIPTION")]
        [StoreOptionKey("LOGIN_UNBLOCK_TIME")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(3)]
        public int LoginUnblockTime
        {
            get; set;
        }

        [Name("Enable reservation timeout", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_NAME")]
        [ExtendedDescription("Specifies if reservation timeout is enabled", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_DESCRIPTION")]
        [StoreOptionKey("ENABLE_TIMEOUT")]
        [DefaultValue(false)]
        [MessagePack.Key(4)]
        public bool EnableTimeout
        {
            get; init;
        }

        [Name("Reservation timeout time", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_TIME_NAME")]
        [ExtendedDescription("Specifies reservation timeout time", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_TIME_DESCRIPTION")]
        [StoreOptionKey("TIMEOUT")]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(5)]
        public int Timeout
        {
            get;init;
        }
    }
}
