using Gizmo.UI.View.States;
using System.Threading.Tasks;

namespace Gizmo.UI.View.Services
{
    /// <summary>
    /// Suggestion service.
    /// </summary>
    /// <remarks>
    /// Implemented by services providing suggestions for selection.
    /// </remarks>
    public interface ISuggestionService : IViewService
    {
        /// <summary>
        /// Sets current suggestion pattern.
        /// </summary>
        /// <param name="pattern">Pattern.</param>
        public Task SetSuggestionPatternAsync(string pattern);

        /// <summary>
        /// Gets suggestion view state.
        /// </summary>
        /// <param name="value">Suggestion value.</param>
        /// <returns></returns>
        public ISuggestionViewState GetSuggestionViewState(object value);

        /// <summary>
        /// Gets suggestions view state.
        /// </summary>
        public ISuggestionsViewState ViewState { get; }
    }
}
