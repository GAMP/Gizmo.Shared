namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// API Message type descriminator.
    /// </summary>
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
