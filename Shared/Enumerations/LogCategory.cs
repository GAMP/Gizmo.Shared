using System;

namespace Gizmo
{
    /// <summary>
    /// Log categories.
    /// </summary>
    [Flags()]
    public enum LogCategory
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Generic.
        /// </summary>
        Generic = 1,
        /// <summary>
        /// Network.
        /// </summary>
        Network = 2,
        /// <summary>
        /// Database.
        /// </summary>
        Database = 4,
        /// <summary>
        /// File system.
        /// </summary>
        FileSystem = 8,
        /// <summary>
        /// Task.
        /// </summary>
        Task = 16,
        /// <summary>
        /// Dispatcher.
        /// </summary>
        Dispatcher = 32,
        /// <summary>
        /// Command.
        /// </summary>
        Command = 64,
        /// <summary>
        /// Operation.
        /// </summary>
        Operation = 128,
        /// <summary>
        /// User interface.
        /// </summary>
        UserInterface = 256,
        /// <summary>
        /// Configuration.
        /// </summary>
        Configuration = 512,
        /// <summary>
        /// Subscription.
        /// </summary>
        Subscription = 1024,
        /// <summary>
        /// Trace.
        /// </summary>
        Trace = 2048,
        /// <summary>
        /// User.
        /// </summary>
        User = 4096,
    }
}
