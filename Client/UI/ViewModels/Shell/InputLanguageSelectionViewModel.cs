using Gizmo.Shared.ViewModels;

namespace Gizmo.Client.UI.ViewModels
{
    /// <summary>
    /// Input language selection view model.
    /// </summary>
    public class InputLanguageSelectionViewModel : SingleSelectionViewModel<InputLanguageViewModel>
    {
        protected override void OnSelectedChanged(InputLanguageViewModel current, InputLanguageViewModel previous)
        {
            base.OnSelectedChanged(current, previous);
        }
    }
}
