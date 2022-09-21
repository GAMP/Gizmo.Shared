using System.ComponentModel;

namespace Gizmo.Server.Exceptions
{
    /// <summary>
    /// Web api error codes.
    /// </summary>
    /// <remarks>
    /// The purpose of the error codes is to map known errors/exception and be provided as an error code value to the caller.
    /// </remarks>
    [DefaultValue(Unknown)]
    public enum ExceptionCode
    {
        /// <summary>
        /// Default code.
        /// </summary>
        /// <remarks>
        /// This will be used in case of system exceptions that dont map to web api error code directly.
        /// </remarks>
        Unknown = 0,
        /// <summary>
        /// Invalid property error code.
        /// </summary>
        InvalidProperty = 1,
        /// <summary>
        /// Non unique entity error code.
        /// </summary>
        NonUniqueEntityValue = 2,
        /// <summary>
        /// Entity not found entity error code.
        /// </summary>
        EntityNotFound = 3,
        /// <summary>
        /// Entity in use error code.
        /// </summary>
        EntityInUse = 4,
        /// <summary>
        /// Entity already referenced error code.
        /// </summary>
        EntityAlreadyReferenced = 5,
        /// <summary>
        /// Entity not referenced error code.
        /// </summary>
        EntityNotReferenced = 6,
        /// <summary>
        /// Asset error code.
        /// </summary>
        Asset = 7,
        /// <summary>
        /// Billing profile error code.
        /// </summary>
        BillingProfile = 8,
        /// <summary>
        /// Deposit error code.
        /// </summary>
        Deposit = 9,
        /// <summary>
        /// Host reservation error code.
        /// </summary>
        HostReservation = 10,
        /// <summary>
        /// Invoice error code.
        /// </summary>
        Invoice = 11,
        /// <summary>
        /// Invoice payment error code.
        /// </summary>
        InvoicePayment = 12,
        /// <summary>
        /// Order status error code.
        /// </summary>
        OrderStatus = 13,
        /// <summary>
        /// Payment error code.
        /// </summary>
        Payment = 14,
        /// <summary>
        /// Points error code.
        /// </summary>
        Points = 15,
        /// <summary>
        /// Product error code.
        /// </summary>
        Product = 16,
        /// <summary>
        /// Shift error code.
        /// </summary>
        Shift = 17,
        /// <summary>
        /// Stock error code.
        /// </summary>
        Stock = 18,
        /// <summary>
        /// User group error code.
        /// </summary>
        UserGroup = 19,
        /// <summary>
        /// Waiting line error code.
        /// </summary>
        WaitingLine = 20,
        /// <summary>
        /// Model state validation error.
        /// </summary>
        ValidationError = 21,
        /// <summary>
        /// Fiscal printer.
        /// </summary>
        FiscalPrinter= 22,
        PaymentRequest =23,
        PaymentProvider=24,
    }
}