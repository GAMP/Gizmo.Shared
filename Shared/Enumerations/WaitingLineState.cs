namespace Gizmo
{
    /// <summary>
    /// Waiting line states.
    /// </summary>
    public enum WaitingLineState
    {
        /// <summary>
        /// Active.
        /// </summary>
        [Localized("WAITING_LINE_SATE_ACTIVE")]
        Active = 0,
        /// <summary>
        /// Processed.
        /// </summary>
        [Localized("WAITING_LINE_SATE_PROCESSED")]
        Processed = 2,
        /// <summary>
        /// Cancel.
        /// </summary>
        [Localized("WAITING_LINE_SATE_CANCEL")]
        Cancel = 1,
    }
}
