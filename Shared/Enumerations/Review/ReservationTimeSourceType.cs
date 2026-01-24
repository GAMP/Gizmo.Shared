namespace Gizmo
{
    /// <summary>
    /// Reservation time sources type.
    /// </summary>
    /// <remarks>
    /// Defines time types (sources) user can purchase when reserving.
    /// </remarks>
    public enum ReservationTimeSourceType
    {
        /// <summary>
        /// Time offer.
        /// </summary>
        TimeOffer = 0,

        /// <summary>
        /// Fixed time.
        /// </summary>
        FixedTime = 1,

        /// <summary>
        /// Time offer fixed time.
        /// </summary>
        TimeOfferFixedTime = 2,
    }
}
