using System;

namespace Gizmo.UI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DialogItemAttribute : Attribute
    {
        public DialogItemAttribute(Type dialogType)
        {
            DialogItemType = dialogType;
        }
    
        public Type DialogItemType { get; set; }
    }
}
