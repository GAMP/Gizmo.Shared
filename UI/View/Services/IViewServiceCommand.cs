#nullable enable

using System.Collections.Generic;

namespace Gizmo.UI.View.Services;

/// <summary>
/// Command from URL.
/// </summary>
public interface IViewServiceCommand
{
    /// <summary>
    /// Path of the URL without command but with host name.
    /// </summary>
    string Key { get; init; }
    /// <summary>
    /// The full path of the URL with host name.
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// Enum command type from URL path.
    /// </summary>
    ViewServiceCommandType Type { get; init; }
    /// <summary>
    /// Params from URL query params.
    /// </summary>
    Dictionary<string, object>? Params { get; init; }
}
