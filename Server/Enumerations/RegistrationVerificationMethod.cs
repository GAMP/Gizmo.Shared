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
        [Name("None", "REGISTRATION_VERIFICATION_METHOD_NONE")]
        None = 0,

        /// <summary>
        /// Email verification.
        /// </summary>
        [Name("Email", "REGISTRATION_VERIFICATION_METHOD_EMAIL")]
        Email = 1,

        /// <summary>
        /// Mobile phone verification.
        /// </summary>
        [Name("Mobile Phone", "REGISTRATION_VERIFICATION_METHOD_MOBILE_PHONE")]
        MobilePhone = 2,
    }
}
