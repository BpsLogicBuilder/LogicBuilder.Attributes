using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class ParameterEditorControlTest
    {
        [Fact]
        public void ParameterEditorControlWorksOnParameters()
        {
            ParameterEditorControlAttribute attribute = (ParameterEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single().GetParameters()[0],
                AttributeConstants.PARAMETEREDITORCONTROLATTRIBUTE
            );

            Assert.Equal(ParameterControlType.TypeAutoComplete, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresSingleLineTextBoxValueCorrectly()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.SingleLineTextBox;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresMultipleLineTextBoxValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.MultipleLineTextBox;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresDropDownValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.DropDown;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresTypeAutoCompleteValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.TypeAutoComplete;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresDomainAutoCompleteValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.DomainAutoComplete;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresPropertyInputValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.PropertyInput;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresParameterSourcedPropertyInputValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.ParameterSourcedPropertyInput;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresParameterSourceOnlyValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.ParameterSourceOnly;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeStoresFormValue()
        {
            // Arrange
            const ParameterControlType testValue = ParameterControlType.Form;

            // Act
            ParameterEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ParameterEditorControlAttributeIsNotNull()
        {
            // Arrange & Act
            ParameterEditorControlAttribute attribute = new(ParameterControlType.TypeAutoComplete);

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void ControlTypePropertyIsReadOnly()
        {
            // Arrange
            const ParameterControlType initialValue = ParameterControlType.TypeAutoComplete;
            ParameterEditorControlAttribute attribute = new(initialValue);

            // Act & Assert
            // The ControlType property should have a private setter and cannot be changed after initialization
            Assert.Equal(initialValue, attribute.ControlType);
            
            // Verify the property doesn't have a public setter
            var propertyInfo = typeof(ParameterEditorControlAttribute).GetProperty(nameof(ParameterEditorControlAttribute.ControlType));
            Assert.NotNull(propertyInfo);
            Assert.True(propertyInfo!.CanRead);
            Assert.False(propertyInfo.SetMethod?.IsPublic ?? false);
        }

        [Fact]
        public void ParameterEditorControlAttributeHasCorrectAttributeUsage()
        {
            // Arrange
            var attributeUsageAttribute = (System.AttributeUsageAttribute)typeof(ParameterEditorControlAttribute)
                .GetCustomAttributes(typeof(System.AttributeUsageAttribute), false)
                .Single();

            // Assert
            Assert.Equal(System.AttributeTargets.Parameter, attributeUsageAttribute.ValidOn);
            Assert.False(attributeUsageAttribute.AllowMultiple);
        }

        private class SampleClass([ParameterEditorControl(ParameterControlType.TypeAutoComplete)] int myParameter)
        {
            public int MyParameter { get; set; } = myParameter;
        }
    }
}