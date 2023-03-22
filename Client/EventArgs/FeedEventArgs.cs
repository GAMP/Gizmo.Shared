namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class FeedEventArgs : ModificationEventArgs
{
    public FeedEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
