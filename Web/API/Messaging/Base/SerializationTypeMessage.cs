using MessagePack;
using System;
using System.Runtime.Serialization;
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

        #region READ ONLY FIELDS

        /// <summary>
        /// Event message type.
        /// </summary>
        public static readonly Type IEventMessage = typeof(IEventMessage);

        /// <summary>
        /// Command message type.
        /// </summary>
        public static readonly Type ICommandMessage = typeof(ICommandMessage);

        /// <summary>
        /// Control message type.
        /// </summary>
        public static readonly Type IControlMessage = typeof(IControlMessage);

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets serialization type.
        /// </summary>
        [JsonIgnore()]
        [IgnoreDataMember()]
        [IgnoreMember()]
        public Type SerializationType { get; protected set; } 

        #endregion
    }
}
