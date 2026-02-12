using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Used to define additional name and valyue pairs useful to the field or property.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Value"></param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = true)]
    public class NameValueAttribute(string Name, string Value) : Attribute
    {
        public string Name { get; } = Name;
        public string Value { get; } = Value;
    }
}
