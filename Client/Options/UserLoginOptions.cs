using MessagePack;

namespace Gizmo.Client.UI
{
    [MessagePackObject()]
    public sealed class UserLoginOptions
    {
        /// <summary>
        /// Indicates if user login is enbaled.
        /// </summary>
        /// <remarks>
        /// This will disable manual user login from host. True by default.
        /// </remarks>
        [Key(0)]
        public bool Enabled { get; init; } = true;
    }
}
