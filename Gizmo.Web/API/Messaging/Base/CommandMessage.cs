using System;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Command message.
    /// </summary>
    public abstract class CommandMessage : SerializationTypeMessage, ICommandMessage
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public CommandMessage(Type serializationType) : base(serializationType)
        { }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets command correlation id.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyOrder(0)]
        [MessagePack.Key(1)]
        public Guid CorrelationId
        {
            get; set;
        }

        /// <summary>
        /// Gets server timeout.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyOrder(1)]
        [MessagePack.Key(2)]
        public int? ServerTimeout
        {
            get; set;
        }

        #endregion
    }
}
