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
            get; init;
        }

        [Name("Login block after time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_AFTER_NAME")]
        [ExtendedDescription("Specifies login block after time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_AFTER_DESCRIPTION")]
        [StoreOptionKey("LOGIN_BLOCK_AFTER")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(1)]
        public int LoginBlockAfter
        {
            get; init;
        }

        [Name("Enable reservation expiration", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_NAME")]
        [ExtendedDescription("Specifies if reservation expiration is enabled", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_DESCRIPTION")]
        [StoreOptionKey("ENABLE_EXPIRATION")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool EnableExpiration
        {
            get; init;
        }

        [Name("Reservation expire after time", "SERVER_OPTION_RESERVATIONS_EXPIRE_AFTER_NAME")]
        [ExtendedDescription("Specifies reservation expire after time", "SERVER_OPTION_RESERVATIONS_EXPIRE_AFTER_DESCRIPTION")]
        [StoreOptionKey("EXPIRE_AFTER")]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        [MessagePack.Key(3)]
        public int ExpireAfter
        {
            get; init;
        }

        [Name("Enable custom reservation time", "SERVER_OPTION_RESERVATIONS_CUSTOM_TIME_ENABLE_NAME")]
        [ExtendedDescription("Specifies if custom time is enabled for reservations", "SERVER_OPTION_RESERVATIONS_CUSTOM_TIME_ENABLE_DESCRIPTION")]
        [StoreOptionKey("CUSTOM_TIME_ENABLE")]
        [DefaultValue(false)]
        [MessagePack.Key(4)]
        public bool CustomTimeEnable
        {
            get; init;
        }

        [Name("Minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_NAME")]
        [ExtendedDescription("Specifies minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_TIME")]
        [DefaultValue(null)]
        [MessagePack.Key(5)]
        public int? MinimumTime
        {
            get; init;
        }

        [Name("Maximum reservation time", "SERVER_OPTION_RESERVATIONS_MAXIMUM_TIME_NAME")]
        [ExtendedDescription("Specifies minimum reservation time", "SERVER_OPTION_RESERVATIONS_MAXIMUM_TIME_DESCRIPTION")]
        [StoreOptionKey("MAXIMUM_TIME")]
        [DefaultValue(null)]
        [MessagePack.Key(6)]
        public int? MaximumTime 
        {
            get;
            init;
        }

        [Name("Reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_NAME")]
        [ExtendedDescription("Specifies reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_DESCRIPTION")]
        [StoreOptionKey("FEE_TYPE")]
        [MessagePack.Key(7)]
        public ReservationFeeType FeeType
        {
            get;
            init;
        }

        [Name("Reservation fee", "SERVER_OPTION_RESERVATIONS_FEE_NAME")]
        [ExtendedDescription("Specifies reservation fee", "SERVER_OPTION_RESERVATIONS_FEE_DESCRIPTION")]
        [StoreOptionKey("FEE")]
        [MessagePack.Key(8)]
        public decimal Fee
        {
            get;
            init;
        }

        [Name("Reservation minimum payment percentage", "SERVER_OPTION_RESERVATIONS_MINIMUM_PAYMENT_PERCENTAGE_NAME")]
        [ExtendedDescription("Specifies reservation minimum payment percentage", "SERVER_OPTION_RESERVATIONS_MINIMUM_PAYMENT_PERCENTAGE_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_PAYMENT_PERCENTAGE")]
        [DefaultValue(100)]
        [MessagePack.Key(9)]
        public decimal MinimumPaymentPercentage
        {
            get;init;
        }

        [Name("Reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_GRACE_PERIOD")]
        [DefaultValue(null)]
        [MessagePack.Key(10)]
        public int? CancellationGracePeriod
        {
            get;
            init;
        }

        [Name("Reservation cancellation refund percentage", "SERVER_OPTION_RESERVATIONS_CANCELLATION_REFUND_PERCENTAGE_NAME")]
        [ExtendedDescription("Specifies reservation cancellation refund percentage", "SERVER_OPTION_RESERVATIONS_CANCELLATION_REFUND_PERCENTAGE_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_REFUND_PERCENTAGE")]
        [MessagePack.Key(11)]
        public decimal CancellationRefundPercentage
        {
            get;
            init;
        }

        [Name("Disable multiple hosts", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies if multiple hosts reservations should be disabled", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("DISABLE_MULTIPLE_HOSTS")]
        [DefaultValue(false)]
        public bool MultiHostDisable
        {
            get; 
            init;
        }

        [Name("Disable time products purchase", "SERVER_OPTION_RESERVATIONS_PURCHASE_TIME_PRODUCTS_DISABLE_NAME")]
        [ExtendedDescription("Specifies if time product purchase disabled for reservations", "SERVER_OPTION_RESERVATIONS_PURCHASE_TIME_PRODUCTS_DISABLE_DESCRIPTION")]
        [StoreOptionKey("PURCHASE_TIME_PRODUCTS_DISABLE")]
        [DefaultValue(false)]
        public bool PurchaseTimeProductsDisable
        {
            get; 
            init;
        }

        [Name("Disable purchase discounts", "SERVER_OPTION_RESERVATIONS_PURCHASE_DISABLE_DISCOUNTS_NAME")]
        [ExtendedDescription("Specifies discounts should be disabled for reservations", "SERVER_OPTION_RESERVATIONS_PURCHASE_DISABLE_DISCOUNTS_DESCRIPTION")]
        [StoreOptionKey("PURCHASE_DISABLE_DISCOUNTS")]
        [DefaultValue(false)]
        public bool PurchaseDisableDiscounts
        {
            get; 
            init;
        }
 
        [Name("Deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_NAME")]
        [ExtendedDescription("Specifies deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_DESCRIPTION")]
        [StoreOptionKey("DEFICIT_FACTOR")]
        [DefaultValue(null)]
        public int? DeficitFactor
        {
            get; 
            init;
        }

        [StoreOptionKey("EXPECTED_AVERAGE_SESSION_TIME")]
        [DefaultValue(null)]
        public int? ExpectedAverageSessionDuration
        {
            get;
            init;
        }
    }
}
