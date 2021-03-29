namespace Gizmo.Server.Web.Api
{
    /// <summary>
    /// Web api exception error codes.
    /// </summary>
    public enum WebApiErrorCode
    {
        Unknown=0,
        InvalidProperty=1,
        NonUniqueEntityValue=2,
        EntityNotFound=3,
        EntityInUse=4,
        EntityAlreadyReferenced=5,
        EntityNotReferenced=6,
        Asset=7,
        BillingProfile=8,
        Deposit=9,
        HostReservation=10,
        Invoice=11,
        InvoicePayment=12,
        OrderStatus=13,
        Payment=14,
        Points=15,
        Product=16,
        Shift=17,
        Stock=18,
        UserGroup=19,
        WaitingLine=20,
        ValidationError=21,
    }    
}