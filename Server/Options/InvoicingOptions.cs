using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("INVOICING")]
    [StoreOptionsGroup("INVOICING")]
    [MessagePack.MessagePackObject()]
    public sealed class InvoicingOptions : IStoreOptions
    {
        [Name("Auto invoice member", "SERVER_OPTION_INVOICING_AUTO_INVOICE_MEMBER_NAME")]
        [ExtendedDescription("Defines if members should be invoiced automatically", "SERVER_OPTION_INVOICING_AUTO_INVOICE_MEMBER_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_MEMBER")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool AutoInvoiceMember { get; init; }

        [Name("Auto invoice time", "SERVER_OPTION_INVOICING_AUTO_INVOICE_MEMBER_NAME")]
        [ExtendedDescription("Defines the duration after which a member will be invoiced", "SERVER_OPTION_INVOICING_AUTO_INVOICE_MEMBER_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_MEMBER_TIME")]
        [DefaultValue(false)]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(1)]
        public bool AutoInvoiceMemberTime { get; init; }

        [Name("Auto invoice payment", "SERVER_OPTION_INVOICING_AUTO_INVOICE_PAYMENT_MEMBER_NAME")]
        [ExtendedDescription("Defines if invoices should be paid automatically", "SERVER_OPTION_INVOICING_AUTO_INVOICE_PAYMENT_MEMBER_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_PAYMENT_MEMBER")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool AutoInvoicePaymentMember { get; init; }

        [Name("Auto invoice guest", "SERVER_OPTION_INVOICING_AUTO_INVOICE_GUEST_NAME")]
        [ExtendedDescription("Defines if users should be invoiced automatically", "SERVER_OPTION_INVOICING_AUTO_INVOICE_GUEST_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_GUEST")]
        [DefaultValue(false)]
        [MessagePack.Key(3)]
        public bool AutoInvoiceGuest { get; init; }

        [Name("Auto invoice time", "SERVER_OPTION_INVOICING_AUTO_INVOICE_GUEST_TIME_NAME")]
        [ExtendedDescription("Defines the duration after which a guest will be invoiced", "SERVER_OPTION_INVOICING_AUTO_INVOICE_GUEST_TIME_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_GUEST_TIME")]
        [Range(0, int.MaxValue)]
        [MessagePack.Key(4)]
        public int AutoInvoiceGuestTime { get; init; }

        [Name("Auto invoice payment", "SERVER_OPTION_INVOICING_AUTO_INVOICE_PAYMENT_GUEST_NAME")]
        [ExtendedDescription("Defines if invoices should be paid automatically", "SERVER_OPTION_INVOICING_AUTO_INVOICE_PAYMENT_GUEST_DESCRIPTION")]
        [StoreOptionKey("AUTO_INVOICE_PAYMENT_GUEST")]
        [DefaultValue(false)]
        [MessagePack.Key(5)]
        public bool AutoInvoicePaymentGuest { get; init; }
    }
}
