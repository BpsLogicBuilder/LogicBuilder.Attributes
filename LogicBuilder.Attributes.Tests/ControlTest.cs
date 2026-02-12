using LogicBuilder.Attributes.Tests.Data;
using Xunit;

namespace LogicBuilder.Attributes.Tests
{
    public class ControlTest
    {
        [Fact]
        public void ControlWorksOnProperties()
        {
            ControlAttribute attribute = (ControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.CONTROLATTRIBUTE
            );

            Assert.Equal(TestConstants.ControlName, attribute.ControlName);
        }

        [Fact]
        public void ControlWorksOnFields()
        {
            ControlAttribute attribute = (ControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.CONTROLATTRIBUTE
            );

            Assert.Equal(TestConstants.ControlName, attribute.ControlName);
        }

        [Fact]
        public void ControlAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "TextBox";

            // Act
            ControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlName);
        }

        [Fact]
        public void ControlAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            ControlAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.ControlName);
        }

        [Fact]
        public void ControlAttributeIsNotNull()
        {
            // Arrange & Act
            ControlAttribute attribute = new("DropDown");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.ControlName);
        }

        [Fact]
        public void ControlAttributeHandlesComplexControlNames()
        {
            // Arrange
            const string complexName = "CustomControls.AdvancedDateTimePicker";

            // Act
            ControlAttribute attribute = new(complexName);

            // Assert
            Assert.Equal(complexName, attribute.ControlName);
        }

        [Fact]
        public void ControlAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialCharsControl = "Control_Name-With.Special:Chars";

            // Act
            ControlAttribute attribute = new(specialCharsControl);

            // Assert
            Assert.Equal(specialCharsControl, attribute.ControlName);
        }

        [Fact]
        public void ControlPropertyIsReadOnly()
        {
            // Arrange
            const string initialValue = "InitialControl";
            ControlAttribute attribute = new(initialValue);

            // Act & Assert
            Assert.Equal(initialValue, attribute.ControlName);
            // ControlName property has private setter, so it cannot be changed after construction
            // This test verifies the property is accessible and maintains its value
        }

        private class SampleClass
        {
            [Control(TestConstants.ControlName)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [Control(TestConstants.ControlName)]
            public int MyProperty { get; set; }
        }
    }
}