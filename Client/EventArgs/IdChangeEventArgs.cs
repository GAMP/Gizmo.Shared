using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client id changed event args.
    /// </summary>
    public sealed class IdChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
        #endregion

        #region PROPERTIES

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

        #endregion
    }
}
