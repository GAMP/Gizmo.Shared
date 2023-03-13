using System;

namespace Gizmo
{
    /// <summary>
    /// Executable options.
    /// </summary>
    [Flags()]
    public enum ExecutableOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Auto launch.
        /// </summary>
        AutoLaunch = 1,
        /// <summary>
        /// Monitor children.
        /// </summary>
        MonitorChildren = 2,
        /// <summary>
        /// Multi run.
        /// </summary>
        MultiRun = 4,
        /// <summary>
        /// Kill children.
        /// </summary>
        KillChildren = 8,
        /// <summary>
        /// Count all instances.
        /// </summary>
        [Obsolete("We dont use this anywhere")]
        CountAllInstances = 16,
        /// <summary>
        /// Quick launch.
        /// </summary>
        QuickLaunch = 32,
        /// <summary>
        /// Shell execute.
        /// </summary>
        ShellExecute = 64,
        /// <summary>
        /// Ignore concurrent execution limit.
        /// </summary>
        IgnoreConcurrentExecutionLimit = 128,
    }
}
