namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Lightweight module-level information available to module controllers.
    /// Unlike <see cref="ModuleContext"/> (which is per-integration-instance),
    /// this represents the module assembly itself and is shared across all
    /// integration instances within the same plugin DLL.
    /// </summary>
    /// <param name="ModuleName">Module name (DLL file name without extension).</param>
    /// <param name="BaseDirectory">Directory containing the module assembly and its private dependencies.</param>
    public sealed record ModuleInfo(string ModuleName, string BaseDirectory);
}
