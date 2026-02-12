using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Use this attribute to configure a generic error message for the field or property.
    /// </summary>
    /// <param name="errorMessage">Error message.</param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ErrorMessageAttribute(string errorMessage) : Attribute
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
