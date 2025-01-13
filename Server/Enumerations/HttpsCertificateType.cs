namespace Gizmo.Server
{
    /// <summary>
    /// Https certificate type.
    /// </summary>
    public enum HttpsCertificateType
    {
        /// <summary>
        /// Self signed certificate.
        /// </summary>
        SelfSigned = 0,

        /// <summary>
        /// User defined certificate.
        /// </summary>
        UserDefined = 1,
    }
}
