#nullable enable

namespace Gizmo.Client.UI
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
