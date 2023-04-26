namespace Gizmo.Client.UI
{
    public sealed class UserLoginOptions
    {
        /// <summary>
        /// Indicates if user login is enbaled.
        /// </summary>
        /// <remarks>
        /// This will disable manual user login from host. True by default.
        /// </remarks>
        public bool Enabled { get; init; } = true;
    }
}
