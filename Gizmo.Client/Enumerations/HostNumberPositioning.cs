using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI.View.Constants
{
    /// <summary>
    /// Host number movement models
    /// </summary>
    public enum HostNumberPositioning
    {
        [Name("Clockwise", "HOST_NUMBER_POSITIONING_CLOCKWISE")]
        Clockwise = 0,

        [Name("Counterclockwise", "HOST_NUMBER_POSITIONING_COUNTERCLOCKWISE")]
        Counterclockwise = 1,

        [Name("Horizontal Top", "HOST_NUMBER_POSITIONING_HORIZONTAL_TOP")]
        HorizontalTop = 2,

        [Name("Horizontal Center", "HOST_NUMBER_POSITIONING_HORIZONTAL_CENTER")]
        HorizontalCenter = 3,

        [Name("Horizontal Bottom", "HOST_NUMBER_POSITIONING_HORIZONTAL_BOTTOM")]
        HorizontalBottom = 4,

        [Name("Vertical Left", "HOST_NUMBER_POSITIONING_VERTICAL_LEFT")]
        VerticalLeft = 5,

        [Name("Vertical Center", "HOST_NUMBER_POSITIONING_VERTICAL_CENTER")]
        VerticalCenter = 6,

        [Name("Vertical Right", "HOST_NUMBER_POSITIONING_VERTICAL_RIGHT")]
        VerticalRight = 7,

        [Name("Wall Bounce", "HOST_NUMBER_POSITIONING_WALL_BOUNCE")]
        WallBounce = 8,

        [Name("Fixed", "HOST_NUMBER_POSITIONING_FIXED")]
        Fixed = 9
    }
}
