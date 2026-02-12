using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// BPS Logic Builder function category.
    /// </summary>
    /// <param name="functionGroup"></param>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FunctionGroupAttribute(FunctionGroup functionGroup) : Attribute
    {
        public FunctionGroup FunctionGroup { get; } = functionGroup;
    }
}
