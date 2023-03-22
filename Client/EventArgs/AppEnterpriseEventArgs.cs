namespace Gizmo.Client;

/// <summary>
/// Server data change args.
/// </summary>
public sealed class AppEnterpriseEventArgs : ModificationEventArgs
{
    public AppEnterpriseEventArgs(int entityId, ModificationType modificationType) : base(entityId, modificationType)
    {
    }
}
