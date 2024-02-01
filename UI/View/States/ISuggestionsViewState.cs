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

        /// <summary>
        /// Resets suggestions.
        /// </summary>
        /// <remarks>
        /// Since we dont have write access to <see cref="Suggestions"/> through the interface this method is required for clearing current suggestions.
        /// </remarks>
        void ResetSuggestions();
    }


    /// <summary>
    /// Typed suggestions view state interface.
    /// </summary>
    /// <typeparam name="TSuggestion">Suggestion view state type.</typeparam>
    public interface ISuggestionsViewState<TSuggestion> : ISuggestionsViewState where TSuggestion : ISuggestionViewState
    {
        /// <inheritdoc cref="ISuggestionsViewState.Suggestions"/>
        new IEnumerable<TSuggestion> Suggestions { get; }

        /// <summary>
        /// Sets current suggestions.
        /// </summary>
        /// <param name="suggestions">Suggestions.</param>
        void SetSuggestions(IEnumerable<TSuggestion> suggestions);
    }
}
