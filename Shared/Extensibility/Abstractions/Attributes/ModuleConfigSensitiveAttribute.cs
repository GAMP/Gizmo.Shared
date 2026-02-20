using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Marks a module configuration property as sensitive (e.g. passwords, API keys, tokens).
    /// </summary>
    /// <remarks>
    /// The Manager UI will mask the value of any property carrying this attribute.
    /// The value is stored as-is in <c>ConfigJson</c> — this attribute only affects presentation.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ModuleConfigSensitiveAttribute : Attribute
    {
    }
}
