using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User profile change event args.
    /// </summary>
    public sealed class UserProfileChangeArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newProfile">New profile.</param>
        /// <param name="oldProfile">Old profile.</param>
        public UserProfileChangeArgs(Gizmo.IUserProfile newProfile, Gizmo.IUserProfile oldProfile)
        {
            NewProfile = newProfile ?? throw new ArgumentNullException(nameof(newProfile));
            OldProfile = oldProfile ?? throw new ArgumentNullException(nameof(oldProfile));
        }

        /// <summary>
        /// Gets old profile value.
        /// </summary>
        public Gizmo.IUserProfile OldProfile
        {
            get;
            init;
        }

        /// <summary>
        /// Gets new profile value.
        /// </summary>
        public Gizmo.IUserProfile NewProfile
        {
            get;
            init;
        }
    }
}
