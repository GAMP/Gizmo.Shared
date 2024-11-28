#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("PAYMENTPROCESSING")]
    [StoreOptionsGroup("PAYMENT_PROCESSING")]
    [MessagePack.MessagePackObject()]
    public sealed class PaymentProcessingOptions : IStoreOptions
    {
        [Name("Payment success url", "SERVER_OPTION_PAYMENT_PROCESSING_SUCCESS_URL_NAME")]
        [ExtendedDescription("Specifies payment success url", "SERVER_OPTION_PAYMENT_PROCESSING_SUCCESS_URL_DESCRIPTION")]
        [StoreOptionKey("PAYMENT_SUCCESS_URL")]
        [StringLength(255)]   
        [DefaultValue("https://www.gizmopowered.net/payment/success")]
        [MessagePack.Key(0)]
        public string? PaymentSuccessUrl
        {
            get; set;
        }

        [Name("Payment cancel url", "SERVER_OPTION_PAYMENT_PROCESSING_CANCEL_URL_NAME")]
        [ExtendedDescription("Specifies payment cancel url", "SERVER_OPTION_PAYMENT_PROCESSING_CANCEL_URL_DESCRIPTION")]
        [StoreOptionKey("PAYMENT_CANCEL_URL")]
        [StringLength(255)]  
        [DefaultValue("https://www.gizmopowered.net/payment/failure")]
        [MessagePack.Key(1)]
        public string? PaymentCancelUrl
        {
            get; set;
        }
    }
}
