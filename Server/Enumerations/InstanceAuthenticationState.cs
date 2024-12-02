namespace Gizmo.Server
{
    /// <summary>
    /// Instance authentication state.
    /// </summary>
    /// <remarks>
    /// This combines previous and current authentication state of the server instance.
    /// </remarks>
    public enum InstanceAuthenticationState
    {
        /// <summary>
        /// Successfully authenticated.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Unauthorized.
        /// </summary>
        Unauthorized = 1,
        
        /// <summary>
        /// Network error during authentication.
        /// </summary>
        NetworkError = 2,
        
        /// <summary>
        /// Error during authentication.
        /// </summary>
        Error = 3,
    }
}
