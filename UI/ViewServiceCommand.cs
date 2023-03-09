#nullable enable

using System.Collections.Generic;
using Gizmo.UI.View.Services;

namespace Gizmo.UI;

/// <inheritdoc/>
public sealed class ViewServiceCommand : IViewServiceCommand
{
    public string Name { get; init; } = null!;
    public string Subject { get; init; } = null!;
    public ViewServiceCommandType Type { get; init; }
    public Dictionary<string, object>? Params { get; init; }
}
