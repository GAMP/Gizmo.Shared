using MessagePack;
using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Serialization type message.
    /// </summary>
    /// <remarks>
    /// Used for providing type information to be used during serialization of the message.
    /// </remarks>
    public abstract class SerializationTypeMessage : MessageBase, ISerializationType
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SerializationTypeMessage(Type serializationType) : base()
        {
            SerializationType = serializationType;
        }
        #endregion        

        #region PROPERTIES

        /// <summary>
        /// Gets serialization type.
        /// </summary>
        [JsonIgnore()]
        [IgnoreMember()]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Type SerializationType { get; protected set; } 

        #endregion
    }
}
