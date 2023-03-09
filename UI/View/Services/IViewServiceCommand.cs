#nullable enable

using System.Collections.Generic;

namespace Gizmo.UI.View.Services;

/// <summary>
/// Command for the Gizmo.Client.UI from a URL
/// </summary>
public interface IViewServiceCommand
{
    string Name { get; init; }
    string Subject { get; init; }
    ViewServiceCommandType Type { get; init; }
    Dictionary<string, object>? Params { get; init; }
}
