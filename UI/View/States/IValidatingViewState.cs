namespace Gizmo.UI.View.States
{
    /// <summary>
    /// Validating view state interface.
    /// </summary>
    public interface IValidatingViewState : IViewState
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets if model is valid. 
        /// </summary>
        /// <remarks>
        /// Null indicates unvalidated state (validation pending).
        /// </remarks>
        bool? IsValid { get; set; }

        /// <summary>
        /// Gets if model is being validated.
        /// </summary>
        /// <remarks>
        /// This can be used as a hint if async validation being done in background.
        /// </remarks>
        bool IsValidating { get; set; } 

        #endregion
    }
}