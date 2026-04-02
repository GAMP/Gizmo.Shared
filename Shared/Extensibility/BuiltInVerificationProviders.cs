using System;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Well-known public IDs for built-in verification providers that are not
    /// registered as integration plugins.
    /// </summary>
    public static class BuiltInVerificationProviders
    {
        /// <summary>
        /// SMS gateway provider.
        /// </summary>
        public static readonly Guid Sms = Guid.Parse("6794CB03-8A6F-4860-8D8C-58D2629CE0B8");

        /// <summary>
        /// SMS flash call provider.
        /// </summary>
        public static readonly Guid FlashCall = Guid.Parse("C0D3D1AA-CD52-4D98-AEF1-26A5B6B82BB4");

        /// <summary>
        /// SMTP email provider.
        /// </summary>
        public static readonly Guid Email = Guid.Parse("8A30563C-48CF-4946-96F5-4CF69D2EA89C");
    }
}
