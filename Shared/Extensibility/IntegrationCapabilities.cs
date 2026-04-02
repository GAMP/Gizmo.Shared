using System;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Well-known capability GUIDs for integration types.
    /// Each GUID corresponds to an interface decorated with
    /// <see cref="Abstractions.IntegrationCapabilityAttribute"/> and identifies a specific
    /// functionality that an integration plugin can provide.
    /// </summary>
    public static class IntegrationCapabilities
    {
        /// <summary>
        /// The integration can handle user authentication.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IUserAuthenticationHandler"/>
        public static readonly Guid UserAuthentication = Guid.Parse("0ABC95C6-6441-4A64-ABCA-4BED0BEE2914");

        /// <summary>
        /// The integration can handle user balance calculations.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IUserBalanceHandler"/>
        public static readonly Guid UserBalance = Guid.Parse("11DB6DAE-D6FD-42A9-90D6-2C046E4B3AB5");

        /// <summary>
        /// The integration can handle user session billing.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.ISessionBillingHandler"/>
        public static readonly Guid SessionBilling = Guid.Parse("FE77731E-8F39-4639-9B1C-410FB7D2E7A0");

        /// <summary>
        /// The integration can handle redirect-based verification (deep links, OAuth).
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IVerificationRedirectHandler"/>
        public static readonly Guid VerificationRedirect = Guid.Parse("35D7F06E-2839-4F9F-8691-B67A9A916863");

        /// <summary>
        /// The integration can dispatch confirmation codes to known recipients.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IVerificationCodeDispatchHandler"/>
        public static readonly Guid VerificationCodeDispatch = Guid.Parse("B179770C-1CC7-4129-B5A4-6A5DB5C52453");

        /// <summary>
        /// The integration can provide a verified phone number.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.ICanProvidePhone"/>
        public static readonly Guid ProvidePhone = Guid.Parse("06C4D84C-843D-43BB-BB84-14FD560C962A");

        /// <summary>
        /// The integration can provide a verified email address.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.ICanProvideEmail"/>
        public static readonly Guid ProvideEmail = Guid.Parse("1E8A2E58-D0E4-41E2-A834-C4BC595DD04E");
    }
}
