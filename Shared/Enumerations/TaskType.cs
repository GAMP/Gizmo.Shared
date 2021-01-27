namespace Gizmo
{
    /// <summary>
    /// Task types.
    /// </summary>
    public enum TaskType
    {
        /// <summary>
        /// Process.
        /// </summary>
        [Localized("TASK_PROCESS")]
        Process = 0,

        /// <summary>
        /// Script.
        /// </summary>
        [Localized("TASK_SCRIPT")]
        Script = 1,

        /// <summary>
        /// Notification.
        /// </summary>
        [Localized("TASK_NOTIFICATION")]
        Notification = 4,

        /// <summary>
        /// Junction.
        /// </summary>
        [Localized("TASK_JUNCTION")]
        Junction = 5
    }
}