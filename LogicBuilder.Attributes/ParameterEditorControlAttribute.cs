using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Control to be used in BPS Logic Builder for the parameter.
    /// </summary>
    /// <param name="controlType"></param>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ParameterEditorControlAttribute(ParameterControlType controlType) : Attribute
    {
        public ParameterControlType ControlType { get; } = controlType;
    }
}
