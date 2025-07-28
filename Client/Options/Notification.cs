#nullable enable

namespace Gizmo.Client.Options
{
    [MessagePack.MessagePackObject()]
    public sealed class Notification
    {
        [MessagePack.Key(0)]
        public int Type { get; set; }

        [MessagePack.Key(1)]
        public int FocusType { get; set; }

        [MessagePack.Key(2)]
        public int Minute { get; set; }

        [MessagePack.Key(3)]
        public string? Message { get; set; }
    }
}
