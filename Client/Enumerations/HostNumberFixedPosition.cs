using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Gizmo.Shared.Client.Enumerations
{
    /// <summary>
    /// Host number positions
    /// </summary>
    public enum HostNumberFixedPosition
    {
        [Display(Name = "top-right")]
        TopRight = 0,
    
        [Display(Name = "top-center")]
        TopCenter = 1,
    
        [Display(Name = "top-left")]
        TopLeft = 2,
    
        [Display(Name = "center-right")]
        CenterRight = 3,
    
        [Display(Name = "center-screen")]
        CenterScreen = 4,
    
        [Display(Name = "center-left")]
        CenterLeft = 5,
    
        [Display(Name = "bottom-right")]
        BottomRight = 6,
    
        [Display(Name = "bottom-center")]
        BottomCenter = 7,
    
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
