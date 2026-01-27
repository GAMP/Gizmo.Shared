using System;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Serialization type interface.
    /// </summary>
    public interface ISerializationType
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets desired type to use for serialization.
        /// </summary>
        Type SerializationType { get; } 

        #endregion
    }
}
