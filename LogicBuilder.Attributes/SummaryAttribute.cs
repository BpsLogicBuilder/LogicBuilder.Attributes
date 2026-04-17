using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Comments about the function.
    /// </summary>
    /// <param name="summary">Comments about the function.</param>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false)]
    public class SummaryAttribute(string summary) : Attribute
    {
        public string Summary { get; private set; } = summary;
    }
}
