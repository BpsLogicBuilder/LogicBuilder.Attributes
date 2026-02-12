using System;

namespace LogicBuilder.Attributes
{
    /// <summary>
    /// Domain Attribute
    /// </summary>
    /// <param name="domainList">Comma delimited list of items</param>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DomainAttribute(string domainList) : Attribute
    {
        public string DomainList { get; } = domainList;
    }
}
