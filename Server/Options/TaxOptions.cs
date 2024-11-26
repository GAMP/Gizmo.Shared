#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("TAX")]
    [StoreOptionsGroup("TAX")]
    [MessagePack.MessagePackObject()]
    public sealed class TaxOptions : IStoreOptions
    {
        /// <summary>
        /// Gets or sets the default tax system for fiscalization.
        /// </summary>
        [Name("Tax system", "SERVER_OPTION_TAX_TAX_SYSTEM_NAME")]
        [ExtendedDescription("Specifies tax system", "SERVER_OPTION_TAX_TAX_SYSTEM_NAME_DESCRIPTION")]
        [StoreOptionKey("TAX_SYSTEM")]
        [DefaultValue(null)]
        [MessagePack.Key(0)]
        public int? TaxSystem { get; init; }

        /// <summary>
        /// Gets or sets the tax system applicable to goods.
        /// </summary>
        [Name("Goods tax system", "SERVER_OPTION_TAX_GOODS_TAX_SYSTEM_NAME")]
        [ExtendedDescription("Specifies goods tax system", "SERVER_OPTION_TAX_GOODS_TAX_SYSTEM_DESCRIPTION")]
        [StoreOptionKey("GOODS_TAX_SYSTEM")]
        [DefaultValue(null)]
        [MessagePack.Key(1)]
        public int? GoodsTaxSystem { get; init; }

        /// <summary>
        /// Gets or sets the tax system applicable to services.
        /// </summary>
        [Name("Services tax system", "SERVER_OPTION_TAX_SERVICES_TAX_SYSTEM_NAME")]
        [ExtendedDescription("Specifies services tax system", "SERVER_OPTION_TAX_SERVICES_TAX_SYSTEM_DESCRIPTION")]
        [StoreOptionKey("SERVICES_TAX_SYSTEM")]
        [DefaultValue(null)]
        [MessagePack.Key(2)]
        public int? ServicesTaxSystem { get; init; }

        /// <summary>
        /// Gets or sets whether deposits should be treated as a service.
        /// </summary>
        [Name("Treat deposits as service", "SERVER_OPTION_TAX_TREAT_DEPOISTS_AS_SERVICE_NAME")]
        [ExtendedDescription("Specifies if deposits should be treated as service", "SERVER_OPTION_TAX_TREAT_DEPOISTS_AS_SERVICE_DESCRIPTION")]
        [StoreOptionKey("TREAT_DEPOISTS_AS_SERVICE")]
        [MessagePack.Key(3)]
        public bool TreatDepositsAsServices { get; init; }

        /// <summary>
        /// Gets or sets the name of the service used for deposit transactions.
        /// </summary>
        [Name("Deposit service description", "SERVER_OPTION_TAX_DEPOSIT_SERVICE_DESCRIPTION_NAME")]
        [ExtendedDescription("Specifies if deposits should be treated as service", "SERVER_OPTION_TAX_DEPOSIT_SERVICE_DESCRIPTION_DESCRIPTION")]
        [StoreOptionKey("DEPOSIT_SERVICE_DESCRIPTION")]
        [StringLength(255,MinimumLength =1)]
        [DefaultValue(null)]
        [MessagePack.Key(4)]       
        public string? DepositServiceDescription { get; init; }

        /// <summary>
        /// Gets or sets the VAT rate for time-based services.
        /// </summary>
        [Name("Time based service vat rate", "SERVER_OPTION_TAX_TIME_BASED_SERVICE_VAT_RATE_NAME")]
        [ExtendedDescription("Specifies time based service vat rate", "SERVER_OPTION_TAX_TIME_BASED_SERVICE_VAT_RATE_DESCRIPTION")]
        [StoreOptionKey("TIME_BASED_SERVICE_VAT_RATE")]
        [Range(0,100)]
        [DefaultValue(null)]
        [MessagePack.Key(5)]
        public decimal? TimeBasedServiceVATRate { get; init; }

        [Name("Deposit vat rate", "SERVER_OPTION_TAX_DEPOSIT_VAT_RATE_NAME")]
        [ExtendedDescription("Specifies deposit VAT rate", "SERVER_OPTION_TAX_DEPOSIT_VAT_RATE_DESCRIPTION")]
        [StoreOptionKey("DEPOSIT_VAT_RATE")]
        [DefaultValue(null)]
        [MessagePack.Key(6)]
        public VatRates? DepositVATRate
        {
            get;init;
        }

        [Name("Deposit advance payment type", "SERVER_OPTION_TAX_DEPOSIT_ADVANCE_PAYMENT_TYPE_NAME")]
        [ExtendedDescription("Specifies deposit advance payment type", "SERVER_OPTION_TAX_DEPOSIT_ADVANCE_PAYMENT_TYPE_DESCRIPTION")]
        [StoreOptionKey("DEPOIST_ADVANCE_PAYMENT_TYPE")]
        [DefaultValue(null)]
        [MessagePack.Key(7)]
        public AdvancePaymentTypes? DepositAdvancePaymentType
        {
            get;init;
        }
    }
}
