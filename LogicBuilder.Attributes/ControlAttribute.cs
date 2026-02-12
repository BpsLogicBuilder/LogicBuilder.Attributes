using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Control Attribute defines the control to be used in the business application
    /// </summary>
    /// <param name="controlName">Name of the control</param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ControlAttribute(string controlName) : Attribute
    {
        public string ControlName { get; } = controlName;
    }
}
