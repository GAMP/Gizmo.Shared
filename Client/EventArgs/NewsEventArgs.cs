namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class NewsEventArgs : ModificationEventArgs
{
    public NewsEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
