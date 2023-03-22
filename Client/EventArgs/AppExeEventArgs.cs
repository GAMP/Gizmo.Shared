namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class AppExeEventArgs : ModificationEventArgs
{
    public AppExeEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
