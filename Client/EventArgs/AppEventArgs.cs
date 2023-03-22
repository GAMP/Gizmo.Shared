namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class AppEventArgs : ModificationEventArgs
{
    public AppEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
