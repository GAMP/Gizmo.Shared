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
        [Name("Enable login block before", "SERVER_OPTION_RESERVATIONS_ENABLE_LOGIN_BLOCK_BEFORE_NAME")]
        [ExtendedDescription("Specifies if login block before reservation is enabled", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_BEFORE_DESCRIPTION")]
        [StoreOptionKey("ENABLE_LOGIN_BLOCK_BEFORE")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool EnableLoginBlockBefore
        {
            get; init;
        }

        [Name("Login block before time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_BEFORE_TIME_NAME")]
        [ExtendedDescription("Specifies time to block logins before reservation", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_BEFORE_TIME_DESCRIPTION")]
        [StoreOptionKey("LOGIN_BLOCK_BEFORE_TIME")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(1)]
        public int LoginBlockBeforeTime
        {
            get; init;
        }

        [Name("Enable login block after", "SERVER_OPTION_RESERVATIONS_ENABLE_LOGIN_BLOCK_AFTER_NAME")]
        [ExtendedDescription("Specifies if login block before reservation is enabled", "SERVER_OPTION_RESERVATIONS_ENABLE_LOGIN_BLOCK_AFTER_DESCRIPTION")]
        [StoreOptionKey("ENABLE_LOGIN_BLOCK_AFTER")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool EnableLoginBlockAfter
        {
            get; init;
        }

        [Name("Login block after time", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_AFTER_TIME_NAME")]
        [ExtendedDescription("Specifies time to block logins after reservation", "SERVER_OPTION_RESERVATIONS_LOGIN_BLOCK_AFTER_TIME_DESCRIPTION")]
        [StoreOptionKey("LOGIN_BLOCK_AFTER_TIME")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(3)]
        public int LoginBlockAfterTime
        {
            get; init;
        }

        [Name("Enable reservation expiration", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_NAME")]
        [ExtendedDescription("Specifies if reservation expiration is enabled", "SERVER_OPTION_RESERVATIONS_LOGIN_TIMEOUT_DESCRIPTION")]
        [StoreOptionKey("ENABLE_EXPIRATION")]
        [DefaultValue(false)]
        [MessagePack.Key(4)]
        public bool EnableExpiration
        {
            get; init;
        }

        [Name("Reservation expire after time", "SERVER_OPTION_RESERVATIONS_EXPIRE_AFTER_NAME")]
        [ExtendedDescription("Specifies reservation expire after time", "SERVER_OPTION_RESERVATIONS_EXPIRE_AFTER_DESCRIPTION")]
        [StoreOptionKey("EXPIRE_AFTER")]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        [MessagePack.Key(5)]
        public int ExpireAfter
        {
            get; init;
        }

        [Name("Allowed time source type", "SERVER_OPTION_RESERVATIONS_TIME_SOURCE_TYPE_NAME")]
        [ExtendedDescription("Specifies allowed time source type", "SERVER_OPTION_RESERVATIONS_TIME_SOURCE_TYPE_DESCRIPTION")]
        [StoreOptionKey("TIME_SOURCE_TYPE")]
        [DefaultValue(ReservationTimeSourceType.TimeOffer)]
        [MessagePack.Key(6)]
        public ReservationTimeSourceType TimeSourceType
        {
            get; init;
        }

        [Name("Minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_NAME")]
        [ExtendedDescription("Specifies minimum reservation time", "SERVER_OPTION_RESERVATIONS_MINIMUM_TIME_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_TIME")]
        [DefaultValue(null)]
        [MessagePack.Key(7)]
        public int? MinimumTime
        {
            get; init;
        }

        [Name("Maximum reservation time", "SERVER_OPTION_RESERVATIONS_MAXIMUM_TIME_NAME")]
        [ExtendedDescription("Specifies minimum reservation time", "SERVER_OPTION_RESERVATIONS_MAXIMUM_TIME_DESCRIPTION")]
        [StoreOptionKey("MAXIMUM_TIME")]
        [DefaultValue(null)]
        [MessagePack.Key(8)]
        public int? MaximumTime 
        {
            get;
            init;
        }

        [Name("Reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_NAME")]
        [ExtendedDescription("Specifies reservation fee type", "SERVER_OPTION_RESERVATIONS_FEE_TYPE_DESCRIPTION")]
        [StoreOptionKey("FEE_TYPE")]
        [MessagePack.Key(9)]
        public ReservationFeeType FeeType
        {
            get;
            init;
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

        [Name("Reservation minimum payment percentage", "SERVER_OPTION_RESERVATIONS_MINIMUM_PAYMENT_PERCENTAGE_NAME")]
        [ExtendedDescription("Specifies reservation minimum payment percentage", "SERVER_OPTION_RESERVATIONS_MINIMUM_PAYMENT_PERCENTAGE_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_PAYMENT_PERCENTAGE")]
        [DefaultValue(100)]
        [Range(0, 100)]
        [MessagePack.Key(11)]
        public decimal MinimumPaymentPercentage
        {
            get;init;
        }

        [Name("Reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies reservation cancellation grace period", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_GRACE_PERIOD")]
        [DefaultValue(null)]
        [MessagePack.Key(12)]
        public int? CancellationGracePeriod
        {
            get;
            init;
        }

        [Name("Reservation cancellation refund percentage", "SERVER_OPTION_RESERVATIONS_CANCELLATION_REFUND_PERCENTAGE_NAME")]
        [ExtendedDescription("Specifies reservation cancellation refund percentage", "SERVER_OPTION_RESERVATIONS_CANCELLATION_REFUND_PERCENTAGE_DESCRIPTION")]
        [StoreOptionKey("CANCELLATION_REFUND_PERCENTAGE")]
        [DefaultValue(0)]
        [MessagePack.Key(13)]
        public decimal CancellationRefundPercentage
        {
            get;
            init;
        }

        [Name("Disable multiple hosts", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_NAME")]
        [ExtendedDescription("Specifies if multiple hosts reservations should be disabled", "SERVER_OPTION_RESERVATIONS_CANCELLATION_GRACE_PERIOD_DESCRIPTION")]
        [StoreOptionKey("DISABLE_MULTIPLE_HOSTS")]
        [DefaultValue(false)]
        [MessagePack.Key(14)]
        public bool MultiHostDisable
        {
            get; 
            init;
        }

        [Name("Disable purchase discounts", "SERVER_OPTION_RESERVATIONS_PURCHASE_DISABLE_DISCOUNTS_NAME")]
        [ExtendedDescription("Specifies discounts should be disabled for reservations", "SERVER_OPTION_RESERVATIONS_PURCHASE_DISABLE_DISCOUNTS_DESCRIPTION")]
        [StoreOptionKey("PURCHASE_DISABLE_DISCOUNTS")]
        [DefaultValue(false)]
        [MessagePack.Key(15)]
        public bool PurchaseDisableDiscounts
        {
            get; 
            init;
        }
 
        [Name("Deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_NAME")]
        [ExtendedDescription("Specifies deficit factor", "SERVER_OPTION_RESERVATIONS_DEFICIT_FACTOR_DESCRIPTION")]
        [StoreOptionKey("DEFICIT_FACTOR")]
        [DefaultValue(null)]
        [Range(0, 100)]
        [MessagePack.Key(16)]
        public int? DeficitFactor
        {
            get; 
            init;
        }

        [Name("Average session time", "SERVER_OPTION_RESERVATIONS_EXPECTED_AVERAGE_SESSION_TIME_NAME")]
        [StoreOptionKey("EXPECTED_AVERAGE_SESSION_TIME")]
        [DefaultValue(null)]
        [MessagePack.Key(17)]
        public int? ExpectedAverageSessionDuration
        {
            get;
            init;
        }

        [Name("Client reservation alert time", "SERVER_OPTION_RESERVATIONS_CLIENT_ALERT_BEFORE_TIME_NAME")]
        [StoreOptionKey("CLIENT_ALERT_BEFORE_TIME")]
        [DefaultValue(30)]
        [MessagePack.Key(18)]
        public int? ClientAlertBeforeTime
        {
            get;
            init;
        }

        [Name("Manager reservation alert time", "SERVER_OPTION_RESERVATIONS_MANAGER_ALERT_BEFORE_TIME_NAME")]
        [StoreOptionKey("MANAGER_ALERT_BEFORE_TIME")]
        [DefaultValue(30)]
        [MessagePack.Key(19)]
        public int? ManagerAlertBeforeTime
        {
            get;
            init;
        }
    }
}
