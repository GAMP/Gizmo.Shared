namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class AppCategoryEventArgs : ModificationEventArgs
{
    public AppCategoryEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
