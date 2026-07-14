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

        /// <summary>
        /// The integration can send SMS messages composed by the system.
        /// </summary>
        /// <seealso cref="Gizmo.SmsProviders.ISmsProvider"/>
        public static readonly Guid SmsSend = Guid.Parse("D2F8A6C1-4E7B-4A93-B5D8-1C6E9F3A7B24");

        /// <summary>
        /// The integration can deliver a verification code via flash call.
        /// The code is derived from the calling number and is returned by the provider.
        /// </summary>
        /// <seealso cref="Gizmo.SmsProviders.IFlashCallProvider"/>
        public static readonly Guid FlashCall = Guid.Parse("6B3D9E47-8A2C-4F15-9D6B-4E8A1C5F2D73");

        /// <summary>
        /// The integration can send email messages composed by the system.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IEmailSendHandler"/>
        public static readonly Guid EmailSend = Guid.Parse("4A7C1E92-5B8D-4F36-A1C4-9E2B6D5F8A17");

        /// <summary>
        /// The integration can verify a user by an incoming call — the user calls a
        /// provider-supplied phone number to prove possession of their phone.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IWaitCallHandler"/>
        public static readonly Guid WaitCall = Guid.Parse("8D5F3B29-6E4A-4C71-9B2D-5A8E1F6C4D93");
    }
}
