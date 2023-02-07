using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client id change event args.
    /// </summary>
    /// <remarks>
    /// Client id represents client number.
    /// </remarks>
    public sealed class IdChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newId">New id.</param>
        /// <param name="oldId">Old id.</param>
        public IdChangeEventArgs(int newId, int oldId)
        {
            NewId = newId;
            OldId = oldId;
        }

        /// <summary>
        /// Gets new id.
        /// </summary>
        public int NewId
        {
            get;
            init;
        }

        /// <summary>
        /// Gets old id.
        /// </summary>
        public int OldId
        {
            get;
            init;
        }
    }
}
