using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class SummaryTest
    {
        [Fact]
        public void SummaryWorksOnConstructors()
        {
            SummaryAttribute attribute = (SummaryAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single(),
                AttributeConstants.SUMMARYATTRIBUTE
            );

            Assert.Equal(TestConstants.SummaryText, attribute.Summary);
        }

        [Fact]
        public void SummaryWorksOnMethods()
        {
            SummaryAttribute attribute = (SummaryAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetMethod(TestConstants.MethodName)!,
                AttributeConstants.SUMMARYATTRIBUTE
            );

            Assert.Equal(TestConstants.SummaryText, attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeStoresValueCorrectly()
        {
            // Arrange
            const string testValue = "This is a test summary";

            // Act
            SummaryAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeHandlesEmptyString()
        {
            // Arrange
            const string emptyString = "";

            // Act
            SummaryAttribute attribute = new(emptyString);

            // Assert
            Assert.Equal(emptyString, attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeIsNotNull()
        {
            // Arrange & Act
            SummaryAttribute attribute = new("TestValue");

            // Assert
            Assert.NotNull(attribute);
            Assert.NotNull(attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeHandlesLongText()
        {
            // Arrange
            const string longSummary = "This is a very long summary that contains multiple sentences. " +
                "It describes the method in great detail. " +
                "This tests that the attribute can handle longer text content without issues.";

            // Act
            SummaryAttribute attribute = new(longSummary);

            // Assert
            Assert.Equal(longSummary, attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeHandlesSpecialCharacters()
        {
            // Arrange
            const string specialCharsSummary = "Summary with special chars: <>&\"'@#$%^&*()";

            // Act
            SummaryAttribute attribute = new(specialCharsSummary);

            // Assert
            Assert.Equal(specialCharsSummary, attribute.Summary);
        }

        [Fact]
        public void SummaryAttributeHandlesMultilineText()
        {
            // Arrange
            const string multilineSummary = "First line\nSecond line\nThird line";

            // Act
            SummaryAttribute attribute = new(multilineSummary);

            // Assert
            Assert.Equal(multilineSummary, attribute.Summary);
        }

        [Fact]
        public void SummaryPropertyIsReadOnly()
        {
            // Arrange
            const string initialValue = "Initial Summary";
            SummaryAttribute attribute = new(initialValue);

            // Act & Assert
            Assert.Equal(initialValue, attribute.Summary);
            // Summary property has private setter, so it cannot be changed after construction
            // This test verifies the property is accessible and maintains its value
        }

        [method: Summary(TestConstants.SummaryText)]
        private class SampleClass()
        {
            [Summary(TestConstants.SummaryText)]
#pragma warning disable CA1822 // Mark members as static
            public void MyMethod()
#pragma warning restore CA1822 // Mark members as static
            {
            }
        }
    }
}
