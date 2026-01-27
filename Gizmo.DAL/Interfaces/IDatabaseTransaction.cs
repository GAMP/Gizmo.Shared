using System;

namespace Gizmo.DAL
{
    /// <summary>
    /// Database transaction implementation interface.
    /// </summary>
    public interface IDatabaseTransaction : IDisposable
    {        
        /// <summary>
        /// Commits transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back transaction.
        /// </summary>
        void Rollback(); 
    }
}
