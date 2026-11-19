using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI.View.Constants
{
    /// <summary>
    /// Login rotator media transition.
    /// </summary>
    public enum LoginRotatorTransition
    {
        [Name("Left to right", "LOGIN_ROTATOR_TRANSITION_LEFT_TO_RIGHT")]
        LeftToRight = 0,

        [Name("Top to bottom", "LOGIN_ROTATOR_TRANSITION_TOP_TO_BOTTOM")]
        TopToBottom = 1,

        [Name("Right to left", "LOGIN_ROTATOR_TRANSITION_RIGHT_TO_LEFT")]
        RightToLeft = 2,

        [Name("Bottom to top", "LOGIN_ROTATOR_TRANSITION_BOTTOM_TO_TOP")]
        BottomToTop = 3,

        [Name("In sequence", "LOGIN_ROTATOR_TRANSITION_SEQUENTIAL")]
        Sequential = 4
    }
}
