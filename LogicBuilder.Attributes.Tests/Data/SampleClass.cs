namespace LogicBuilder.Attributes.Tests.Data
{
    [method: AlsoKnownAs(TestConstants.SampleClass_1)]
    [method: Summary(TestConstants.SummaryText)]
    internal class SampleClass(int myProperty)
    {
        [AlsoKnownAs(TestConstants.My_Property)]
        public int MyProperty { get; set; } = myProperty;


        [AlsoKnownAs(TestConstants.My_Method)]
        [Summary(TestConstants.SummaryText)]
#pragma warning disable CA1822 // Mark members as static
        public void MyMethod()
#pragma warning restore CA1822 // Mark members as static
        {
        }
    }


}
