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
        public static readonly Guid UserAuthentication = Guid.Parse("A1B2C3D4-1001-4000-8000-000000000001");

        /// <summary>
        /// The integration can handle user balance calculations.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.IUserBalanceHandler"/>
        public static readonly Guid UserBalance = Guid.Parse("A1B2C3D4-1001-4000-8000-000000000002");

        /// <summary>
        /// The integration can handle user session billing.
        /// </summary>
        /// <seealso cref="Gizmo.Server.Extensibility.ISessionBillingHandler"/>
        public static readonly Guid SessionBilling = Guid.Parse("A1B2C3D4-1001-4000-8000-000000000003");
    }
}
