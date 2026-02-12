using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Control to be used in BPS Logic Builder for the list parameter.
    /// </summary>
    /// <param name="controlType"></param>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ListEditorControlAttribute(ListControlType controlType) : Attribute
    {
        public ListControlType ControlType { get; } = controlType;
    }
}
