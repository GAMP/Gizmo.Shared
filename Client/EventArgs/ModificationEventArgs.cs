using System;

namespace Gizmo.Client;

/// <summary>
/// Modification Event Args.
/// </summary>
public abstract class ModificationEventArgs : EventArgs
{
    protected ModificationEventArgs(int entityId, ModificationType modificationType)
    {
        EntityId = entityId;
        ModificationType = modificationType;
    }

    public int EntityId { get; init; }
    public ModificationType ModificationType { get; init; }
}
