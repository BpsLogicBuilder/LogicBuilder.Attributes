using LogicBuilder.Attributes.Tests.Data;
using System.Linq;

namespace LogicBuilder.Attributes.Tests
{
    public class ListControlTest
    {
        [Fact]
        public void ListEditorControlWorksOnFields()
        {
            ListEditorControlAttribute attribute = (ListEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetField(TestConstants.FieldName)!,
                AttributeConstants.LISTEDITORCONTROLATTRIBUTE
            );

            Assert.Equal(ListControlType.ListForm, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlWorksOnProperties()
        {
            ListEditorControlAttribute attribute = (ListEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetProperty(TestConstants.PropertyName)!,
                AttributeConstants.LISTEDITORCONTROLATTRIBUTE
            );

            Assert.Equal(ListControlType.ListForm, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlWorksOnParameters()
        {
            ListEditorControlAttribute attribute = (ListEditorControlAttribute)Helper.GetAttribute
            (
                typeof(SampleClass).GetConstructors().Single().GetParameters()[0],
                AttributeConstants.LISTEDITORCONTROLATTRIBUTE
            );

            Assert.Equal(ListControlType.ListForm, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlAttributeStoresListFormValueCorrectly()
        {
            // Arrange
            const ListControlType testValue = ListControlType.ListForm;

            // Act
            ListEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlAttributeStoresHashSetFormValue()
        {
            // Arrange
            const ListControlType testValue = ListControlType.HashSetForm;

            // Act
            ListEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlAttributeStoresConnectorsValue()
        {
            // Arrange
            const ListControlType testValue = ListControlType.Connectors;

            // Act
            ListEditorControlAttribute attribute = new(testValue);

            // Assert
            Assert.Equal(testValue, attribute.ControlType);
        }

        [Fact]
        public void ListEditorControlAttributeIsNotNull()
        {
            // Arrange & Act
            ListEditorControlAttribute attribute = new(ListControlType.ListForm);

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void ControlTypePropertyIsReadOnly()
        {
            // Arrange
            const ListControlType initialValue = ListControlType.HashSetForm;
            ListEditorControlAttribute attribute = new(initialValue);

            // Act & Assert
            // The ControlType property should have a private setter and cannot be changed after initialization
            Assert.Equal(initialValue, attribute.ControlType);
            
            // Verify the property doesn't have a public setter
            var propertyInfo = typeof(ListEditorControlAttribute).GetProperty(nameof(ListEditorControlAttribute.ControlType));
            Assert.NotNull(propertyInfo);
            Assert.True(propertyInfo!.CanRead);
            Assert.False(propertyInfo.SetMethod?.IsPublic ?? false);
        }

        [Fact]
        public void ListEditorControlAttributeHasCorrectAttributeUsage()
        {
            // Arrange
            var attributeUsageAttribute = (System.AttributeUsageAttribute)typeof(ListEditorControlAttribute)
                .GetCustomAttributes(typeof(System.AttributeUsageAttribute), false)
                .Single();

            // Assert
            Assert.Equal(System.AttributeTargets.Parameter | System.AttributeTargets.Field | System.AttributeTargets.Property, attributeUsageAttribute.ValidOn);
            Assert.False(attributeUsageAttribute.AllowMultiple);
        }

        private class SampleClass([ListEditorControl(ListControlType.ListForm)] int myProperty)
        {
            [ListEditorControl(ListControlType.ListForm)]
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value 0
            public int MyField;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value 0

            [ListEditorControl(ListControlType.ListForm)]
            public int MyProperty { get; set; } = myProperty;
        }
    }
}