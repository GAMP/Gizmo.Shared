using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;
using Gizmo.Shared;

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
        [DefaultValue(0)]
        [MessagePack.Key(5)]
        public int Timeout
        {
            get; init;
        }

        [Name("Disable time products", "SERVER_OPTION_RESERVATIONS_TIME_PRODUCTS_DISABLE_NAME")]
        [ExtendedDescription("Specifies if time product purchase disabled for reservations", "SERVER_OPTION_RESERVATIONS_TIME_PRODUCTS_DISABLE_DESCRIPTION")]
        [StoreOptionKey("TIME_PRODUCTS_DISABLE")]
        [DefaultValue(false)]
        [MessagePack.Key(6)]
        public bool TimeProductsDisable
        {
            get; init;
        }

        [Name("Enable custom reservation time", "SERVER_OPTION_RESERVATIONS_CUSTOM_TIME_ENABLE_NAME")]
        [ExtendedDescription("Specifies if custom time is enabled for reservations", "SERVER_OPTION_RESERVATIONS_CUSTOM_TIME_ENABLE_DESCRIPTION")]
        [StoreOptionKey("CUSTOM_TIME_ENABLE")]
        [DefaultValue(false)]
        [MessagePack.Key(7)]
        public bool CustomTimeEnable
        {
            get; init;
        }

        [Name("Minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_NAME")]
        [ExtendedDescription("Specifies minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_TIME")]
        [MessagePack.Key(8)]
        public int? MinimumTime
        {
            get; init;
        }

        [Name("Reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_NAME")]
        [ExtendedDescription("Specifies reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_DESCRIPTION")]
        [StoreOptionKey("FEE_TYPE")]
        [MessagePack.Key(9)]
        public ReservationFeeType FeeType
        {
            get; init;
        }

        [Name("Reservation fee", "SERVER_OPTION_RESERVATIONS_FEE_NAME")]
        [ExtendedDescription("Specifies reservation fee", "SERVER_OPTION_RESERVATIONS_FEE_DESCRIPTION")]
        [StoreOptionKey("FEE")]
        [MessagePack.Key(10)]
        public decimal Fee
        {
            get;
            init;
        }

        [Name("Reservation cancellation fee type", "SERVER_OPTION_RESERVATIONS_CANCELLATION_FEE_TYPE_NAME")]
        [ExtendedDescription("Specifies reservation cancellation fee type", "SERVER_OPTION_RESERVATIONS_CANCELLATION_FEE_TYPE_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_FEE_TYPE")]
        [MessagePack.Key(11)]
        public ReservationFeeType CancellationFeeType
        {
            get; init;
        }

        [Name("Reservation cancellation fee", "SERVER_OPTION_RESERVATIONS_FEE_NAME")]
        [ExtendedDescription("Specifies reservation cancellation fee", "SERVER_OPTION_RESERVATIONS_FEE_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_FEE")]
        [MessagePack.Key(12)]
        public decimal CancellationFee
        {
            get; init;
        }

        [Name("Reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_GRACE_PERIOD")]
        [DefaultValue(null)]
        [MessagePack.Key(13)]
        public int? CancellationGracePeriod
        {
            get; init;
        }

        [Name("Disable multiple hosts", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies if multiple hosts reservations should be disabled", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("DISABLE_MULTIPLE_HOSTS")]
        [DefaultValue(false)]
        [MessagePack.Key(14)]
        public bool MultiHostDisable
        {
            get; init;
        }

        [Name("Disable discounts", "SERVER_OPTION_RESERVATIONS_DISABLE_DISCOUNTS_NAME")]
        [ExtendedDescription("Specifies discounts should be disabled for reservations", "SERVER_OPTION_RESERVATIONS_DISABLE_DISCOUNTS_DESCRIPTION")]
        [StoreOptionKey("DISABLE_DISCOUNTS")]
        [DefaultValue(false)]
        [MessagePack.Key(15)]
        public bool DisableDiscounts
        {
            get; init;
        }

        [Name("Deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_NAME")]
        [ExtendedDescription("Specifies deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_DESCRIPTION")]
        [StoreOptionKey("DEFICIT_FACTOR")]
        [DefaultValue(null)]
        [MessagePack.Key(16)]
        public int? DeficitFactor
        {
            get; init;
        }


        ///add an option in minutes that will be effective only for billing profiles and set an expected time the user will be using pc and some other user will be able to book it
        ///

        //add maximum reservation time.
        //minimum reservation time should be global and not relate to allow custom time

    }
}
