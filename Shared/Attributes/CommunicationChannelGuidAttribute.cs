using System;

namespace Gizmo
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CommunicationChannelGuidAttribute : Attribute
    {
        public CommunicationChannelGuidAttribute(Guid guid)
        {
            Guid = guid;
        }

        public CommunicationChannelGuidAttribute(string guid)
        {
            Guid = Guid.Parse(guid);
        }

        public Guid Guid
        {
            get;
        }
    }
}
