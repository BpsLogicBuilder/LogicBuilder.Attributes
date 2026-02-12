using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Comments about the variable.
    /// </summary>
    /// <param name="comments">Comments about the variable.</param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CommentsAttribute(string comments) : Attribute
    {
        public string Comments { get; } = comments;
    }
}
