using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class NameValueTest
    {
        [Fact]
        public void NameValueWorksOnFields()
        {
            NameValueAttribute attribute = (NameValueAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.NAMEVALUEATTRIBUTE
            );

            Assert.Equal(TestConstants.NameValueName, attribute.Name);
            Assert.Equal(TestConstants.NameValueValue, attribute.Value);
        }

        [Fact]
        public void NameValueWorksOnProperties()
        {
            NameValueAttribute attribute = (NameValueAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.NAMEVALUEATTRIBUTE
            );

            Assert.Equal(TestConstants.NameValueName, attribute.Name);
            Assert.Equal(TestConstants.NameValueValue, attribute.Value);
        }

        [Fact]
        public void NameValueWorksOnParameters()
        {
            NameValueAttribute attribute = (NameValueAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single().GetParameters()[0],
                AttributeConstants.NAMEVALUEATTRIBUTE
            );

            Assert.Equal(TestConstants.NameValueName, attribute.Name);
            Assert.Equal(TestConstants.NameValueValue, attribute.Value);
        }

        [Fact]
        public void NameValueAttributeStoresValuesCorrectly()
        {
            // Arrange
            const string testName = "TestName";
            const string testValue = "TestValue";

            // Act
            NameValueAttribute attribute = new(testName, testValue);

            // Assert
            Assert.Equal(testName, attribute.Name);
            Assert.Equal(testValue, attribute.Value);
        }

        [Fact]
        public void NameValueAttributeHandlesEmptyStrings()
        {
            // Arrange
            const string emptyString = "";

            // Act
            NameValueAttribute attribute = new(emptyString, emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.Name);
            Assert.Equal(emptyString, attribute.Value);
        }

        [Fact]
        public void NameValueAttributeIsNotNull()
        {
            // Arrange & Act
            NameValueAttribute attribute = new("TestName", "TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.Name);
            Assert.NotNull(attribute.Value);
        }

        [Fact]
        public void NameValueAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialName = "Name<>&\"'@#$%";
            const string specialValue = "Value<>&\"'@#$%";

            // Act
            NameValueAttribute attribute = new(specialName, specialValue);

            // Assert
            Assert.Equal(specialName, attribute.Name);
            Assert.Equal(specialValue, attribute.Value);
        }

        [Fact]
        public void NameValueAttributeHandlesLongStrings()
        {
            // Arrange
            const string longName = "This is a very long name that contains multiple words and sentences for testing purposes";
            const string longValue = "This is a very long value that contains multiple words and sentences for testing purposes";

            // Act
            NameValueAttribute attribute = new(longName, longValue);

            // Assert
            Assert.Equal(longName, attribute.Name);
            Assert.Equal(longValue, attribute.Value);
        }

        [Fact]
        public void NameValuePropertiesAreReadOnly()
        {
            // Arrange
            const string initialName = "InitialName";
            const string initialValue = "InitialValue";
            NameValueAttribute attribute = new(initialName, initialValue);

            // Act & Assert
            Assert.Equal(initialName, attribute.Name);
            Assert.Equal(initialValue, attribute.Value);
            // Name and Value properties have private setters, so they cannot be changed after construction
            // This test verifies the properties are accessible and maintain their values
        }

        [Fact]
        public void NameValueAttributeSupportsMultipleInstances()
        {
            // Arrange & Act
            var attributes = typeof(SampleClass)
                .GetProperty(nameof(SampleClass.PropertyWithMultipleNameValues))!
                .GetCustomAttributes(typeof(NameValueAttribute), false)
                .Cast<NameValueAttribute>()
                .ToArray();

            // Assert
            Assert.Equal(2, attributes.Length);
            Assert.Contains(attributes, a => a.Name == "FirstName" && a.Value == "FirstValue");
            Assert.Contains(attributes, a => a.Name == "SecondName" && a.Value == "SecondValue");
        }

        private class SampleClass([NameValue(TestConstants.NameValueName, TestConstants.NameValueValue)] int myProperty)
        {
            [NameValue(TestConstants.NameValueName, TestConstants.NameValueValue)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [NameValue(TestConstants.NameValueName, TestConstants.NameValueValue)]
            public int MyProperty { get; set; } = myProperty;

            [NameValue("FirstName", "FirstValue")]
            [NameValue("SecondName", "SecondValue")]
            public int PropertyWithMultipleNameValues { get; set; }
        }
    }
}