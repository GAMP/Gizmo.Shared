using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Gizmo.Client
{
    /// <summary>
    /// Host number positions
    /// </summary>
    public enum HostNumberFixedPosition
    {
        [Name("Top Right", "HOST_NUMBER_FIXED_POSITION_TOP_RIGHT")]
        [Display(Name = "top-right")]
        TopRight = 0,

        [Name("Top Center", "HOST_NUMBER_FIXED_POSITION_TOP_CENTER")]
        [Display(Name = "top-center")]
        TopCenter = 1,

        [Name("Top Left", "HOST_NUMBER_FIXED_POSITION_TOP_LEFT")]
        [Display(Name = "top-left")]
        TopLeft = 2,

        [Name("Center Right", "HOST_NUMBER_FIXED_POSITION_CENTER_RIGHT")]
        [Display(Name = "center-right")]
        CenterRight = 3,

        [Name("Center Screen", "HOST_NUMBER_FIXED_POSITION_CENTER_SCREEN")]
        [Display(Name = "center-screen")]
        CenterScreen = 4,

        [Name("Center Left", "HOST_NUMBER_FIXED_POSITION_CENTER_LEFT")]
        [Display(Name = "center-left")]
        CenterLeft = 5,

        [Name("Bottom Right", "HOST_NUMBER_FIXED_POSITION_BOTTOM_RIGHT")]
        [Display(Name = "bottom-right")]
        BottomRight = 6,

        [Name("Bottom Center", "HOST_NUMBER_FIXED_POSITION_BOTTOM_CENTER")]
        [Display(Name = "bottom-center")]
        BottomCenter = 7,

        [Name("Bottom Left", "HOST_NUMBER_FIXED_POSITION_BOTTOM_LEFT")]
        [Display(Name = "bottom-left")]
        BottomLeft = 8
    }

    public static class HostNumberFixedPositionExtensions
    {
        public static string ToStringValue(this HostNumberFixedPosition model)
        {
            return model.GetType()
                .GetMember(model.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?
                .Name ?? model.ToString().ToLower();
        }
    }
}
