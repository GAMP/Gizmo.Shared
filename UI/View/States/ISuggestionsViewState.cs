#nullable enable

using System.Collections.Generic;

namespace Gizmo.UI.View.States
{
    /// <summary>
    /// Generic suggestions view state interface.
    /// </summary>
    public interface ISuggestionsViewState : IValidatingViewState
    {
        /// <summary>
        /// Gets current pattern.
        /// </summary>
        public string? Pattern { get; set; }

        /// <summary>
        /// Gets current suggestions results.
        /// </summary>
        IEnumerable<ISuggestionViewState> Suggestions { get; }
    }


    /// <summary>
    /// Typed suggestions view state interface.
    /// </summary>
    /// <typeparam name="TSuggestion">Suggestion view state type.</typeparam>
    public interface ISuggestionsViewState<TSuggestion> : ISuggestionsViewState where TSuggestion : ISuggestionViewState
    {
        /// <inheritdoc cref="ISuggestionsViewState.Suggestions"/>
        new IEnumerable<TSuggestion> Suggestions { get; }
    }
}
