namespace Gizmo
{
    /// <summary>
    /// Confirmation code delivery method.
    /// </summary>
    public enum ConfirmationCodeDeliveryMethod
    {
        /// <summary>
        /// Undetermined.
        /// </summary>
        /// <remarks>
        /// This value will be set in cases we dont have information on how the confirmation code would be sent, example if you dont have SMS provider configured.
        /// This will be also set if we have not passed input validation.
        /// </remarks>
        Undetermined=0,
        /// <summary>
        /// Confirmation code was delivered by SMS.
        /// </summary>
        SMS=1,
        /// <summary>
        /// Confirmation code was delivered by flash call.
        /// </summary>
        FlashCall=2,
    }
}
