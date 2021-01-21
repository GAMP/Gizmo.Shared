namespace Gizmo
{
    /// <summary>
    /// Billing rate step actions.
    /// </summary>
    public enum BillingRateStepAction
    {
        /// <summary>
        /// Charge.
        /// </summary>
        [Localized("STEP_ACTION_CHARGE")]
        Charge = 0,
        /// <summary>
        /// Loop to.
        /// </summary>
        [Localized("STEP_ACTION_LOOP_TO")]
        LoopTo = 1,
    }
}