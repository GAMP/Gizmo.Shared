#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("TAX")]
    [StoreOptionsGroup("TAX")]
    public sealed class TaxOptions : IStoreOptions
    {
        [Name("Deposit vat rate", "SERVER_OPTION_TAX_DEPOSIT_VAT_RATE_NAME")]
        [ExtendedDescription("Specifies deposit VAT rate", "SERVER_OPTION_TAX_DEPOSIT_VAT_RATE_DESCRIPTION")]
        [StoreOptionKey("DEPOSIT_VAT_RATE")]
        [DefaultValue(null)]
        public VatRates? DepositVATRate
        {
            get;init;
        }

        [Name("Deposit advance payment type", "SERVER_OPTION_TAX_DEPOSIT_ADVANCE_PAYMENT_TYPE_NAME")]
        [ExtendedDescription("Specifies deposit advance payment type", "SERVER_OPTION_TAX_DEPOSIT_ADVANCE_PAYMENT_TYPE_DESCRIPTION")]
        [StoreOptionKey("DEPOIST_ADVANCE_PAYMENT_TYPE")]
        [DefaultValue(null)]
        public AdvancePaymentTypes? DepositAdvancePaymentType
        {
            get;init;
        }
    }
}
