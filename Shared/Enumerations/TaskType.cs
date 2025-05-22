using System.ComponentModel.DataAnnotations;

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
        [Name("Process", "TASK_TYPE_PROCESS")]
        Process = 0,

        /// <summary>
        /// Script.
        /// </summary>
        [Localized("TASK_SCRIPT")]
        [Name("Script", "TASK_TYPE_SCRIPT")]
        Script = 1,

        /// <summary>
        /// Notification.
        /// </summary>
        [Localized("TASK_NOTIFICATION")]
        [Name("Notification", "TASK_TYPE_NOTIFICATION")]
        Notification = 4,

        /// <summary>
        /// Junction.
        /// </summary>
        [Localized("TASK_JUNCTION")]
        [Name("Junction", "TASK_TYPE_JUNCTION")]
        Junction = 5
    }
}
