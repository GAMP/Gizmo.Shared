namespace Gizmo.Server.Web.Api
{
    /// <summary>
    /// Web api error codes.
    /// </summary>
    /// <remarks>
    /// The purpose of the error codes is to map known errors/exception and be provided as an error code value to the caller.
    /// </remarks>
    public enum WebApiErrorCode
    {
        /// <summary>
        /// Default code.
        /// </summary>
        Unknown=0,
        /// <summary>
        /// Invalid property error code, maps to <see cref="InvalidPropertyException"/>
        /// </summary>
        InvalidProperty = 1,
        /// <summary>
        /// Non unique entity error code, maps to <see cref="NonUniqueEntityValueException"/>
        /// </summary>
        NonUniqueEntityValue = 2,
        /// <summary>
        /// Entity not found entity error code, maps to <see cref="EntityNotFoundException"/>
        /// </summary>
        EntityNotFound = 3,
        /// <summary>
        /// Entity in use error code, maps to <see cref="EntityInUseException"/>
        /// </summary>
        EntityInUse = 4,
        /// <summary>
        /// Entity already referenced error code, maps to <see cref="EntityAlreadyReferencedException"/>
        /// </summary>
        EntityAlreadyReferenced = 5,
        /// <summary>
        /// Entity not referenced error code, maps to <see cref="EntityNotReferencedException"/>
        /// </summary>
        EntityNotReferenced = 6,
        /// <summary>
        /// Asset error code.
        /// </summary>
        Asset=7,
        /// <summary>
        /// Billing profile error code.
        /// </summary>
        BillingProfile=8,
        /// <summary>
        /// Deposit error code.
        /// </summary>
        Deposit=9,
        /// <summary>
        /// Host reservation error code.
        /// </summary>
        HostReservation=10,
        /// <summary>
        /// Invoice error code.
        /// </summary>
        Invoice=11,
        /// <summary>
        /// Invoice payment error code.
        /// </summary>
        InvoicePayment=12,
        /// <summary>
        /// Order status error code.
        /// </summary>
        OrderStatus=13,
        /// <summary>
        /// Payment error code.
        /// </summary>
        Payment=14,
        /// <summary>
        /// Points error code.
        /// </summary>
        Points=15,
        /// <summary>
        /// Product error code.
        /// </summary>
        Product=16,
        /// <summary>
        /// Shift error code.
        /// </summary>
        Shift=17,
        /// <summary>
        /// Stock error code.
        /// </summary>
        Stock=18,
        /// <summary>
        /// User group error code.
        /// </summary>
        UserGroup=19,
        /// <summary>
        /// Waiting line error code.
        /// </summary>
        WaitingLine=20,
        /// <summary>
        /// Model state validation error.
        /// </summary>
        ValidationError=21,
    }    
}