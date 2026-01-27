#nullable enable

using System.Collections.Generic;
using Gizmo.UI.View.Services;

namespace Gizmo.UI
{
    /// <inheritdoc/>
    public sealed class ViewServiceCommand : IViewServiceCommand
    {
        public string Key { get; init; } = null!;
        public string Name { get; set; } = null!;
        public ViewServiceCommandType Type { get; init; }
        public Dictionary<string, object>? Params { get; init; }
    }
}