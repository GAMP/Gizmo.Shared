namespace Gizmo.Client
{
    /// <summary>
    /// Shared Module activity enumeration.
    /// </summary>
    public enum ClientStartupActivity
    {
        /// <summary>
        /// Default state.
        /// </summary>
        None = 0,
        /// <summary>
        /// Starting UI.
        /// </summary>
        /// <remarks>
        /// This is state when client is starting UI (shell).
        /// </remarks>
        [Localized("EN_SMA_STARTING_UI")]
        StartingUserInterface = 1,
        /// <summary>
        /// Initiating server connection.
        /// </summary>
        /// <remarks>
        /// This the state when client initiates connection to the server.
        /// </remarks>
        [Localized("EN_SMA_INITIATING_CONNECTION")]
        InitiatingConnection = 2,
        /// <summary>
        /// Checking system drivers.
        /// </summary>
        /// <remarks>
        /// This the state when initialize kernel drivers.
        /// </remarks>
        [Localized("EN_SMA_CHECKING_DRIVER")]
        InitializingSystemDriver = 3,
        /// <summary>
        /// Processing tasks.
        /// </summary>
        [Localized("EN_SMA_PROCESSING_TASKS")]
        ProcessingTasks = 4,
        /// <summary>
        /// Initializing plugins.
        /// </summary>
        [Localized("EN_SMA_INITIALIZING_PLUGINS")]
        InitializingPlugins = 5,
        /// <summary>
        /// Resolving server ip.
        /// </summary>
        [Localized("EN_SMA_RESOLVING_SERVER_IP")]
        ResolvingServerIp = 6,
        /// <summary>
        /// Mapping drives.
        /// </summary>
        [Localized("EN_SMA_PROCESSING_DRIVE_MAPPINGS")]
        MappingDrives = 7,
    }
}
