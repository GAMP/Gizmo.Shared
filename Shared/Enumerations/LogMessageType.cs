using System;

namespace Gizmo
{
    /// <summary>
    /// Log message type.
    /// </summary>
    [Flags()]
    public enum LogMessageType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Information.
        /// </summary>
        Information = 1,
        /// <summary>
        /// Warning.
        /// </summary>
        Warning = 2,
        /// <summary>
        /// Error.
        /// </summary>
        Error = 4,
        /// <summary>
        /// Event.
        /// </summary>
        Event = 8
    }
}
