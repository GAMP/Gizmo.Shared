using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Server
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
        [Name("None", "REGISTRATION_VERIFICATION_METHOD_NONE")]
        None = 0,

        /// <summary>
        /// Email verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_EMAIL_ADDRESS")]
        [Name("Email", "REGISTRATION_VERIFICATION_METHOD_EMAIL")]
        Email = 1,

        /// <summary>
        /// Mobile phone verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_MOBILE_PHONE")]
        [Name("Mobile Phone", "REGISTRATION_VERIFICATION_METHOD_MOBILE_PHONE")]
        MobilePhone = 2,
    }
}
