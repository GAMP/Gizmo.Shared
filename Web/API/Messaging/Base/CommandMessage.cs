using MessagePack;
using System;
using System.Runtime.Serialization;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Command message.
    /// </summary>
    [DataContract()]
    [MessagePackObject()]
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
        [DataMember(Order = 2, IsRequired = false)]
        [Key(1)]
        public Guid CorrelationId
        {
            get; set;
        }

        /// <summary>
        /// Gets server timeout.
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        [Key(2)]
        public int? ServerTimeout
        {
            get; set;
        }

        #endregion

        public static TResponseMessage CreateResponseMessage<TInputMessage, TResponseMessage>(TInputMessage inputMessage)
            where TInputMessage : ICorrelationMessage
            where TResponseMessage : ICorrelationMessage, new()
        {
            if (inputMessage == null)
                throw new ArgumentNullException(nameof(inputMessage));

            return new() { CorrelationId = inputMessage.CorrelationId };
        }
    }
}
