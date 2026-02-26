using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Marks a controller class inside a plugin assembly as a module controller.
    /// Only controllers decorated with this attribute are discovered by MVC;
    /// all other controllers in plugin assemblies are filtered out.
    /// Routes are automatically prefixed with <c>/modules/{moduleName}/</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ModuleControllerAttribute : Attribute { }
}
