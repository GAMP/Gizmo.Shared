#nullable enable

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Temporary options for TCP network settings.
    /// </summary>
    public sealed class ServerTCPNetworkOptions
    {
        /// <summary>
        /// TCP server bind IP address.
        /// </summary>
        public string? BindIpAddress { get; set; }

        /// <summary>
        /// Client port to bind the server to.
        /// </summary>
        public int BindPort { get; set; }

        /// <summary>
        /// Connection backlog size.
        /// </summary>
        public int Backlog { get; set; }

        /// <summary>
        /// Enable or disable TCP keep-alive.
        /// </summary>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// Keep-alive time in seconds.
        /// </summary>
        public int KeepAliveTime { get; set; }

        /// <summary>
        /// Keep-alive interval in seconds.
        /// </summary>
        public int KeepAliveInterval { get; set; }

        /// <summary>
        /// Keep-alive retry count.
        /// </summary>
        public int KeepAliveRetryCount { get; set; }
    }
}
