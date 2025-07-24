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
        TopRight,
    
        [Display(Name = "top-center")]
        TopCenter,
    
        [Display(Name = "top-left")]
        TopLeft,
    
        [Display(Name = "center-right")]
        CenterRight,
    
        [Display(Name = "center-screen")]
        CenterScreen,
    
        [Display(Name = "center-left")]
        CenterLeft,
    
        [Display(Name = "bottom-right")]
        BottomRight,
    
        [Display(Name = "bottom-center")]
        BottomCenter,
    
        [Display(Name = "bottom-left")]
        BottomLeft
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
