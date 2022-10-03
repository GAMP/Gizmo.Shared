namespace Gizmo
{
    /// <summary>
    /// Payment intent state.
    /// </summary>
    public enum PaymentIntentState
    {
        /// <summary>
        /// The intent is pending.
        /// </summary>
        Pending = 0,
        /// <summary>
        /// The intent is completed.
        /// </summary>
        Completed = 1,
        /// <summary>
        /// The intent is failed.
        /// </summary>
        Failed = 2,
    }
}
