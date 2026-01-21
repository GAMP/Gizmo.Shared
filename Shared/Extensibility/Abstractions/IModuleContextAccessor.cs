namespace Gizmo.Extensibility.Abstractions
{
    public interface IModuleContextAccessor { ModuleContext Context { get; } }

    public sealed class ModuleContextAccessor : IModuleContextAccessor
    {
        public ModuleContextAccessor(ModuleContext ctx) => Context = ctx;
        public ModuleContext Context { get; }
    }
}
