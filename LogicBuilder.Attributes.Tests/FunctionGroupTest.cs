using LogicBuilder.Attributes.Tests.Data;
using System.Linq;
using Xunit;

namespace LogicBuilder.Attributes.Tests
{
    public class FunctionGroupTest
    {
        [Fact]
        public void FunctionGroupWorksOnMethods()
        {
            FunctionGroupAttribute attribute = (FunctionGroupAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetMethod(TestConstants.MethodName)!,
                AttributeConstants.FUNCTIONGROUPATTRIBUTE
            );

            Assert.Equal(FunctionGroup.DialogForm, attribute.FunctionGroup);
        }

        [Fact]
        public void FunctionGroupAttributeStoresValueCorrectly()
        {
            // Arrange
            const FunctionGroup testValue = FunctionGroup.Standard;

            // Act
            FunctionGroupAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.FunctionGroup);
        }

        [Fact]
        public void FunctionGroupAttributeStoresDialogFormValue()
        {
            // Arrange
            const FunctionGroup testValue = FunctionGroup.DialogForm;

            // Act
            FunctionGroupAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.FunctionGroup);
        }

        [Fact]
        public void FunctionGroupAttributeIsNotNull()
        {
            // Arrange & Act
            FunctionGroupAttribute attribute = new(FunctionGroup.Standard);

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void FunctionGroupPropertyIsReadOnly()
        {
            // Arrange
            const FunctionGroup initialValue = FunctionGroup.Standard;
            FunctionGroupAttribute attribute = new(initialValue);

            // Act & Assert
            // The FunctionGroup property should have a private setter and cannot be changed after initialization
            Assert.Equal(initialValue, attribute.FunctionGroup);
            
            // Verify the property doesn't have a public setter
            var propertyInfo = typeof(FunctionGroupAttribute).GetProperty(nameof(FunctionGroupAttribute.FunctionGroup));
            Assert.NotNull(propertyInfo);
            Assert.True(propertyInfo!.CanRead);
            Assert.False(propertyInfo.SetMethod?.IsPublic ?? false);
        }

        [Fact]
        public void FunctionGroupAttributeHasCorrectAttributeUsage()
        {
            // Arrange
            var attributeUsageAttribute = (System.AttributeUsageAttribute)typeof(FunctionGroupAttribute)
                .GetCustomAttributes(typeof(System.AttributeUsageAttribute), false)
                .Single();

            // Assert
            Assert.Equal(System.AttributeTargets.Method, attributeUsageAttribute.ValidOn);
            Assert.False(attributeUsageAttribute.AllowMultiple);
        }

        private class SampleClass
        {
            [FunctionGroup(FunctionGroup.DialogForm)]
#pragma warning disable CA1822 // Mark members as static
            public void MyMethod()
#pragma warning restore CA1822 // Mark members as static
            {
            }
        }
    }
}