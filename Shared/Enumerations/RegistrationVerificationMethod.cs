using System;

namespace Gizmo
{
    /// <summary>
    /// Registration verification methods.
    /// </summary>
    [Flags()]
    public enum RegistrationVerificationMethod
    {
        /// <summary>
        /// No verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_NONE")]
        None = 0,
        /// <summary>
        /// Email verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_EMAIL_ADDRESS")]
        Email = 1,
        /// <summary>
        /// Mobile phone verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_MOBILE_PHONE")]
        MobilePhone = 2,
    }
}
