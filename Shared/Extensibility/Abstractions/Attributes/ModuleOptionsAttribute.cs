using System;

namespace Gizmo.Extensibility.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ModuleOptionsAttribute : Attribute
    {
        public ModuleOptionsAttribute(Type optionsType, string sectionName)
        {
            OptionsType = optionsType;
            SectionName = sectionName;
        }

        public Type OptionsType { get; }

        public string SectionName { get; }
    }
}
