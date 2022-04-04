namespace Gizmo.Web.Api.Messaging
{
    ///<inheritdoc/>
    public enum MessageTypeDiscriminator
    {
        /// <summary>
        /// Command message.
        /// </summary>
        Command = 0,

        /// <summary>
        /// Event message.
        /// </summary>
        Event = 1,

        /// <summary>
        /// Control message.
        /// </summary>
        Control = 2,
    }
}
