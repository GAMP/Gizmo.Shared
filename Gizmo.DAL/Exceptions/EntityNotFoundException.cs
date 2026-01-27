using System;
using Gizmo.Server.Exceptions;

namespace Gizmo.DAL
{
    /// <summary>
    /// Entity not found exception.
    /// </summary>
    /// <remarks>
    /// Thrown when trying to query database entity by id for non existing record.
    /// </remarks>
    [ExceptionFilterCode(ExceptionCode.EntityNotFound)]
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="entityKey">Entity key.</param>
        /// <param name="entityType">Entity type.</param>
        public EntityNotFoundException(int entityKey, Type entityType)
        {
            EntityKey = entityKey;
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="keys">Entity keys.</param>
        /// <param name="entityType">Entity type.</param>
        public EntityNotFoundException(object[] keys, Type entityType)
        {
            Keys = keys ?? throw new ArgumentNullException(nameof(keys));
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        public override string Message => $"Specified entity Id {EntityKey}, type {EntityType} not found.";

        /// <summary>
        /// Gets entity id.
        /// </summary>
        public int? EntityKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        public Type EntityType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity keys.
        /// </summary>
        public object[] Keys
        {
            get; set;
        } = Array.Empty<object>();
    }
}
