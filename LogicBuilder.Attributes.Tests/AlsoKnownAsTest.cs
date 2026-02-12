using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class AlsoKnownAsTest
    {
        [Fact]
        public void AlsoKnownAsWorksOnConstructors()
        {
            AlsoKnownAsAttribute attribute = (AlsoKnownAsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single(),
                AttributeConstants.ALSOKNOWNASATTRIBUTE
            );

            Assert.Equal(TestConstants.SampleClass_1, attribute.AlsoKnownAs);
        }

        [Fact]
        public void AlsoKnownAsWorksOnMethods()
        {
            AlsoKnownAsAttribute attribute = (AlsoKnownAsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetMethod(TestConstants.MethodName)!,
                AttributeConstants.ALSOKNOWNASATTRIBUTE
            );

            Assert.Equal(TestConstants.My_Method, attribute.AlsoKnownAs);
        }

        [Fact]
        public void AlsoKnownAsWorksOnProperties()
        {
            AlsoKnownAsAttribute attribute = (AlsoKnownAsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.ALSOKNOWNASATTRIBUTE
            );

            Assert.Equal(TestConstants.My_Property, attribute.AlsoKnownAs);
        }

        private class SampleClass
        {
            [AlsoKnownAs(TestConstants.SampleClass_1)]
            public SampleClass
            (
                int myProperty
            )
            {
                MyProperty = myProperty;
            }

            [AlsoKnownAs(TestConstants.My_Property)]
            public int MyProperty { get; set; }


            [AlsoKnownAs(TestConstants.My_Method)]
            public void MyMethod()
            {
            }
        }
    }
}
