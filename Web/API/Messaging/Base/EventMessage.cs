using System;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Event base message.
    /// </summary>
    public abstract class EventMessage : SerializationTypeMessage, IEventMessage
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public EventMessage(Type serializationType) : base(serializationType)
        { }

        #endregion
    }  
}
