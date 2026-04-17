using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Name field used in Logic Builder for function or variable configuration. Without the AlsoKnownAs attribute the default name is ClassName.MemberName.
    /// </summary>
    /// <param name="aka">Name field used in Logic Builder for a function or variable.</param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false)]
    public class AlsoKnownAsAttribute(string aka) : Attribute
    {
        public string AlsoKnownAs { get; private set; } = aka;
    }
}
