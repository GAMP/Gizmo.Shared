namespace Gizmo
{
    /// <summary>
    /// Reservation status.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// Reservation is waiting.
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// Reservation is canceled by user or operator.
        /// </summary>
        Canceled = 1,

        /// <summary>
        /// Reservation is active.
        /// </summary>
        Active = 2,

        /// <summary>
        /// Reservation is expired.
        /// </summary>
        Expired = 3,

        /// <summary>
        /// Reservation is completed.
        /// </summary>
        Completed = 4,

        /// <summary>
        /// Reservation is released.
        /// </summary>
        Released = 5,

        /// <summary>
        /// Reservation moved.
        /// </summary>
        Moved = 6,
    }
}
