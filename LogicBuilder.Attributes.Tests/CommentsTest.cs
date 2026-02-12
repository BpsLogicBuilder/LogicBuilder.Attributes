using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class CommentsTest
    {
        [Fact]
        public void CommentsWorksOnFields()
        {
            CommentsAttribute attribute = (CommentsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.COMMENTSATTRIBUTE
            );

            Assert.Equal(TestConstants.CommentsText, attribute.Comments);
        }

        [Fact]
        public void CommentsWorksOnProperties()
        {
            CommentsAttribute attribute = (CommentsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.COMMENTSATTRIBUTE
            );

            Assert.Equal(TestConstants.CommentsText, attribute.Comments);
        }

        [Fact]
        public void CommentsWorksOnParameters()
        {
            CommentsAttribute attribute = (CommentsAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single().GetParameters().First(),
                AttributeConstants.COMMENTSATTRIBUTE
            );

            Assert.Equal(TestConstants.CommentsText, attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "This is a test comment";

            // Act
            CommentsAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            CommentsAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeIsNotNull()
        {
            // Arrange & Act
            CommentsAttribute attribute = new("TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeHandlesLongText()
        {
            // Arrange
            const string longComment = "This is a very long comment that contains multiple sentences. " +
                "It describes the variable in great detail. " +
                "This tests that the attribute can handle longer text content without issues.";

            // Act
            CommentsAttribute attribute = new(longComment);

            // Assert
            Assert.Equal(longComment, attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialCharsComment = "Comment with special chars: <>&\"'@#$%^&*()";

            // Act
            CommentsAttribute attribute = new(specialCharsComment);

            // Assert
            Assert.Equal(specialCharsComment, attribute.Comments);
        }

        [Fact]
        public void CommentsAttributeHandlesMultilineText()
        {
            // Arrange
            const string multilineComment = "First line\nSecond line\nThird line";

            // Act
            CommentsAttribute attribute = new(multilineComment);

            // Assert
            Assert.Equal(multilineComment, attribute.Comments);
        }

        [Fact]
        public void CommentsPropertyIsReadOnly()
        {
            // Arrange
            const string initialValue = "Initial Comment";
            CommentsAttribute attribute = new(initialValue);

            // Act & Assert
            Assert.Equal(initialValue, attribute.Comments);
            // Comments property has private setter, so it cannot be changed after construction
            // This test verifies the property is accessible and maintains its value
        }

        private class SampleClass([Comments(TestConstants.CommentsText)] int myProperty)
        {
            [Comments(TestConstants.CommentsText)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [Comments(TestConstants.CommentsText)]
            public int MyProperty { get; set; } = myProperty;
        }
    }
}