#nullable enable

namespace Gizmo.Client.Options
{
    [MessagePack.MessagePackObject()]
    public sealed class ClientNetworkOptions
    {
        /// <summary>
        /// Server Uri.
        /// </summary>
        [MessagePack.Key(0)]
        public string? ServerUri { get; set; }
    }
}
