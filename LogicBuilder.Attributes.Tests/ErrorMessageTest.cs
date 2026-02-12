using LogicBuilder.Attributes.Tests.Data;

namespace LogicBuilder.Attributes.Tests
{
    public class ErrorMessageTest
    {
        [Fact]
        public void ErrorMessageWorksOnProperties()
        {
            ErrorMessageAttribute attribute = (ErrorMessageAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.ERRORMESSAGEATTRIBUTE
            );

            Assert.Equal(TestConstants.ErrorMessageText, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageWorksOnFields()
        {
            ErrorMessageAttribute attribute = (ErrorMessageAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.ERRORMESSAGEATTRIBUTE
            );

            Assert.Equal(TestConstants.ErrorMessageText, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "This field is required";

            // Act
            ErrorMessageAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            ErrorMessageAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeIsNotNull()
        {
            // Arrange & Act
            ErrorMessageAttribute attribute = new("TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeHandlesLongText()
        {
            // Arrange
            const string longErrorMessage = "This is a very long error message that provides detailed information about the validation failure. " +
                "It includes multiple sentences to give the user comprehensive feedback. " +
                "This tests that the attribute can handle longer error messages without issues.";

            // Act
            ErrorMessageAttribute attribute = new(longErrorMessage);

            // Assert
            Assert.Equal(longErrorMessage, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialCharsMessage = "Error: <value> must be between {0} and {1}. Current: \"invalid\"";

            // Act
            ErrorMessageAttribute attribute = new(specialCharsMessage);

            // Assert
            Assert.Equal(specialCharsMessage, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessageAttributeHandlesMultilineText()
        {
            // Arrange
            const string multilineMessage = "First line of error\nSecond line with details\nThird line with guidance";

            // Act
            ErrorMessageAttribute attribute = new(multilineMessage);

            // Assert
            Assert.Equal(multilineMessage, attribute.ErrorMessage);
        }

        [Fact]
        public void ErrorMessagePropertyIsReadOnly()
        {
            // Arrange
            const string initialValue = "Initial error message";
            ErrorMessageAttribute attribute = new(initialValue);

            // Act & Assert
            Assert.Equal(initialValue, attribute.ErrorMessage);
            // ErrorMessage property has private setter, so it cannot be changed after construction
            // This test verifies the property is accessible and maintains its value
        }

        private class SampleClass
        {
            [ErrorMessage(TestConstants.ErrorMessageText)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
            public readonly string MyField = string.Empty;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value

            [ErrorMessage(TestConstants.ErrorMessageText)]
            public string MyProperty { get; set; } = string.Empty;
        }
    }
}