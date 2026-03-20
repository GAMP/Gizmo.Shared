using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Declares the communication channel type(s) supported by a messenger handler.
    /// <para>
    /// The channel GUID must match a value from <see cref="Gizmo.CommunicationChannels"/>.
    /// Multiple attributes can be applied to support more than one channel type.
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class MessengerChannelAttribute : Attribute
    {
        public MessengerChannelAttribute(string channelGuid)
        {
            ChannelGuid = Guid.Parse(channelGuid);
        }

        /// <summary>
        /// The communication channel type GUID.
        /// </summary>
        public Guid ChannelGuid { get; }
    }
}
