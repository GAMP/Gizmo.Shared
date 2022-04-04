using MessagePack;
using System;
using System.Runtime.Serialization;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Control message.
    /// </summary>
    [DataContract()]
    [MessagePackObject()]
    public abstract class ControlMessage : SerializationTypeMessage , IControlMessage
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ControlMessage(Type serializationType) : base(serializationType)
        { } 
        #endregion
    }
}
