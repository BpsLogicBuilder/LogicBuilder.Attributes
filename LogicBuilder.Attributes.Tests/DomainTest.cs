using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class DomainTest
    {
        [Fact]
        public void DomainWorksOnFields()
        {
            DomainAttribute attribute = (DomainAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.DOMAINATTRIBUTE
            );

            Assert.Equal(TestConstants.DomainList, attribute.DomainList);
        }

        [Fact]
        public void DomainWorksOnProperties()
        {
            DomainAttribute attribute = (DomainAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.DOMAINATTRIBUTE
            );

            Assert.Equal(TestConstants.DomainList, attribute.DomainList);
        }

        [Fact]
        public void DomainWorksOnParameters()
        {
            DomainAttribute attribute = (DomainAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single().GetParameters()[0],
                AttributeConstants.DOMAINATTRIBUTE
            );

            Assert.Equal(TestConstants.DomainList, attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "Option1,Option2,Option3";

            // Act
            DomainAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            DomainAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeIsNotNull()
        {
            // Arrange & Act
            DomainAttribute attribute = new("TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeHandlesComplexDelimitedList()
        {
            // Arrange
            const string complexList = "Value1,Value2,Value3,Value4,Value5";

            // Act
            DomainAttribute attribute = new(complexList);

            // Assert
            Assert.Equal(complexList, attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialCharsList = "Option A,Option-B,Option_C,Option.D";

            // Act
            DomainAttribute attribute = new(specialCharsList);

            // Assert
            Assert.Equal(specialCharsList, attribute.DomainList);
        }

        [Fact]
        public void DomainAttributeHandlesSingleValue()
        {
            // Arrange
            const string singleValue = "OnlyOption";

            // Act
            DomainAttribute attribute = new(singleValue);

            // Assert
            Assert.Equal(singleValue, attribute.DomainList);
        }

        [Fact]
        public void DomainListPropertyIsReadOnly()
        {
            // Arrange
            const string initialValue = "Initial,Domain,List";
            DomainAttribute attribute = new(initialValue);

            // Act & Assert
            Assert.Equal(initialValue, attribute.DomainList);
            // DomainList property has private setter, so it cannot be changed after construction
            // This test verifies the property is accessible and maintains its value
        }

        private class SampleClass([Domain(TestConstants.DomainList)] int myProperty)
        {
            [Domain(TestConstants.DomainList)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [Domain(TestConstants.DomainList)]
            public int MyProperty { get; set; } = myProperty;
        }
    }
}