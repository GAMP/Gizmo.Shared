#nullable enable

namespace Gizmo.UI.View.States
{
    /// <summary>
    /// Suggestion view state interface.
    /// </summary>
    public interface ISuggestionViewState : IViewState
    {
        /// <summary>
        /// Gets default value that represents this suggestion.
        /// </summary>
        /// <remarks>
        /// This value will be displayed in the selection list.
        /// </remarks>
        /// <returns>Default value.</returns>
        public object GetDisplayValue();

        /// <summary>
        /// Gets selection value.
        /// </summary>
        /// <remarks>
        /// This value will be forwarded to the model upon selection.
        /// </remarks>
        /// <returns></returns>
        public object GetSelectionValue();

        /// <summary>
        /// Tries to obtain named value from the current suggestion.
        /// </summary>
        /// <typeparam name="TValue">Expected value type.</typeparam>
        /// <param name="propertyName">Value name.</param>
        /// <param name="value">Found value.</param>
        /// <returns>True if value is found, otherwise false.</returns>
        bool TryGetValue<TValue>(string propertyName, TValue? value);
    }
}
