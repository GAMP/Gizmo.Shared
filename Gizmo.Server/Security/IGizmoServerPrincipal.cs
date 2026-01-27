namespace Gizmo.Server.Security
{
    public interface IGizmoServerPrincipal
    {
        /// <summary>
        /// Gets current user role.
        /// </summary>
        /// <remarks>Will return <see cref="Gizmo.Server.UserRoles.None"/> when <see cref="UserId"/> is <see langword="null"/>.</remarks>
        public Gizmo.Server.UserRoles Role { get; }

        /// <summary>
        /// Gets current user id.
        /// </summary>
        /// <remarks>Will be equal to <see langword="null"/> if no user identity attached to calling thread.</remarks>
        public int? UserId { get; }
    }
}
