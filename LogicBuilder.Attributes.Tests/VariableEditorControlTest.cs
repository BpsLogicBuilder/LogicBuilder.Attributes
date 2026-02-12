using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class VariableEditorControlTest
    {
        [Fact]
        public void VariableEditorControlWorksOnFields()
        {
            VariableEditorControlAttribute attribute = (VariableEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(nameof(SampleClass.MyField))!,
                AttributeConstants.VARIABLEEDITORCONTROLATTRIBUTE
            );

            Assert.Equal(VariableControlType.TypeAutoComplete, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlWorksOnProperties()
        {
            VariableEditorControlAttribute attribute = (VariableEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(nameof(SampleClass.MyProperty))!,
                AttributeConstants.VARIABLEEDITORCONTROLATTRIBUTE
            );

            Assert.Equal(VariableControlType.DomainAutoComplete, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresSingleLineTextBoxValueCorrectly()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.SingleLineTextBox;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresMultipleLineTextBoxValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.MultipleLineTextBox;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresDropDownValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.DropDown;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresTypeAutoCompleteValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.TypeAutoComplete;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresDomainAutoCompleteValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.DomainAutoComplete;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresPropertyInputValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.PropertyInput;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeStoresFormValue()
        {
            // Arrange
            const VariableControlType testValue = VariableControlType.Form;

            // Act
            VariableEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void VariableEditorControlAttributeIsNotNull()
        {
            // Arrange & Act
            VariableEditorControlAttribute attribute = new(VariableControlType.TypeAutoComplete);

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void ControlTypePropertyIsReadOnly()
        {
            // Arrange
            const VariableControlType initialValue = VariableControlType.TypeAutoComplete;
            VariableEditorControlAttribute attribute = new(initialValue);

            // Act & Assert
            // The ControlType property should have a private setter and cannot be changed after initialization
            Assert.Equal(initialValue, attribute.ControlType);
            
            // Verify the property doesn't have a public setter
            var propertyInfo = typeof(VariableEditorControlAttribute).GetProperty(nameof(VariableEditorControlAttribute.ControlType));
            Assert.NotNull(propertyInfo);
            Assert.True(propertyInfo!.CanRead);
            Assert.False(propertyInfo.SetMethod?.IsPublic ?? false);
        }

        [Fact]
        public void VariableEditorControlAttributeHasCorrectAttributeUsage()
        {
            // Arrange
            var attributeUsageAttribute = (System.AttributeUsageAttribute)typeof(VariableEditorControlAttribute)
                .GetCustomAttributes(typeof(System.AttributeUsageAttribute), false)
                .Single();

            // Assert
            Assert.Equal(System.AttributeTargets.Field | System.AttributeTargets.Property, attributeUsageAttribute.ValidOn);
            Assert.False(attributeUsageAttribute.AllowMultiple);
        }

        private class SampleClass
        {
            [VariableEditorControl(VariableControlType.TypeAutoComplete)]
            public int MyField;

            [VariableEditorControl(VariableControlType.DomainAutoComplete)]
            public string MyProperty { get; set; } = string.Empty;
        }
    }
}