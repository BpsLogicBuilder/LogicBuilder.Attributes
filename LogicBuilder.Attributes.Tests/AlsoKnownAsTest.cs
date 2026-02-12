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

        [Fact]
        public void AlsoKnownAsWorksOnFields()
        {
            AlsoKnownAsAttribute attribute = (AlsoKnownAsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.ALSOKNOWNASATTRIBUTE
            );

            Assert.Equal(TestConstants.My_Field, attribute.AlsoKnownAs);
        }

        [Fact]
        public void AlsoKnownAsAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "TestAlias";

            // Act
            AlsoKnownAsAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.AlsoKnownAs);
        }

        [Fact]
        public void AlsoKnownAsAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            AlsoKnownAsAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.AlsoKnownAs);
        }

        [Fact]
        public void AlsoKnownAsAttributeIsNotNull()
        {
            // Arrange & Act
            AlsoKnownAsAttribute attribute = new("TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.AlsoKnownAs);
        }

        [method: AlsoKnownAs(TestConstants.SampleClass_1)]
        private class SampleClass(int myProperty)
        {
            [AlsoKnownAs(TestConstants.My_Field)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [AlsoKnownAs(TestConstants.My_Property)]
            public int MyProperty { get; set; } = myProperty;


            [AlsoKnownAs(TestConstants.My_Method)]
#pragma warning disable CA1822 // Mark members as static
            public void MyMethod()
#pragma warning restore CA1822 // Mark members as static
            {
            }
        }
    }
}
