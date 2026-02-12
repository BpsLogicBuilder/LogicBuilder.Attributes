using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Control to be used in BPS Logic Builder for the field or property.
    /// </summary>
    /// <param name="controlType"></param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class VariableEditorControlAttribute(VariableControlType controlType) : Attribute
    {
        public VariableControlType ControlType { get; } = controlType;
    }
}
