# LogicBuilder.Attributes

[![NuGet](https://img.shields.io/nuget/v/LogicBuilder.Attributes.svg)](https://www.nuget.org/packages/LogicBuilder.Attributes)

LogicBuilder.Attributes is a .NET Standard 2.0 library that provides declarative attributes for automatic configuration of methods, fields, properties, and constructor parameters in [LogicBuilder](https://github.com/BpsLogicBuilder/LogicBuilder) applications.

## Overview

This library enables developers to annotate their C# code with metadata that LogicBuilder uses to dynamically generate client-side and server-side workflows. By applying these attributes to your domain model, you can control how properties, methods, and parameters are presented and validated in the LogicBuilder visual designer.

## Installation
dotnet add package LogicBuilder.Attributes

## Attributes

### CommentsAttribute
Provides descriptive comments for variables that appear in the LogicBuilder designer.

**Applies to:** Fields, Properties, Parameters
`[Comments("User's email address for notifications")] public string Email { get; set; }`

### ControlAttribute
Defines the UI control to be used in the business application for a field or property.

**Applies to:** Fields, Properties

`[Control("EmailInput")] public string Email { get; set; }`

### DomainAttribute
Specifies a comma-delimited list of valid values for a field, property, or parameter.

**Applies to:** Fields, Properties, Parameters

`[Domain("Active,Inactive,Pending")] public string Status { get; set; }`

### ErrorMessageAttribute
Configures a generic error message for field or property validation.

**Applies to:** Fields, Properties

`[ErrorMessage("Email address is required")] public string Email { get; set; }`

### FunctionGroupAttribute
Categorizes methods into functional groups within LogicBuilder.

**Applies to:** Methods

**Values:** `FunctionGroup.Standard`, `FunctionGroup.DialogForm`

`[FunctionGroup(FunctionGroup.Standard)] public void ProcessOrder(Order order) { }`

### ListEditorControlAttribute
Specifies the control type for editing list parameters in LogicBuilder.

**Applies to:** Parameters, Fields, Properties

**Values:** `ListControlType.ListForm`, `ListControlType.HashSetForm`, `ListControlType.Connectors`

`[ListEditorControl(ListControlType.HashSetForm)] public HashSet<string> Tags { get; set; }`

### ParameterEditorControlAttribute
Defines the editor control for method parameters in LogicBuilder.

**Applies to:** Parameters

**Values:** 
- `ParameterControlType.SingleLineTextBox`
- `ParameterControlType.MultipleLineTextBox`
- `ParameterControlType.DropDown`
- `ParameterControlType.TypeAutoComplete`
- `ParameterControlType.DomainAutoComplete`
- `ParameterControlType.PropertyInput`
- `ParameterControlType.ParameterSourcedPropertyInput`
- `ParameterControlType.ParameterSourceOnly`
- `ParameterControlType.Form`

`public void UpdateProfile([ParameterEditorControl(ParameterControlType.MultipleLineTextBox)] string bio) { }`

### VariableEditorControlAttribute
Specifies the editor control for fields and properties in LogicBuilder.

**Applies to:** Fields, Properties

**Values:**
- `VariableControlType.SingleLineTextBox`
- `VariableControlType.MultipleLineTextBox`
- `VariableControlType.DropDown`
- `VariableControlType.TypeAutoComplete`
- `VariableControlType.DomainAutoComplete`
- `VariableControlType.PropertyInput`
- `VariableControlType.Form`

`[VariableEditorControl(VariableControlType.DropDown)] [Domain("Small,Medium,Large")] public string Size { get; set; }`


### NameValueAttribute
Defines additional custom name-value pairs for fields, properties, or parameters. This attribute can be applied multiple times.

**Applies to:** Fields, Properties, Parameters

`[NameValue("MinLength", "5")] [NameValue("MaxLength", "100")] public string Username { get; set; }`

## Example Usage

```csharp
using LogicBuilder.Attributes;
public class User { [Comments("Unique identifier for the user")] [VariableEditorControl(VariableControlType.SingleLineTextBox)] public string UserId { get; set; }

    [Comments("User's email address")]
    [ErrorMessage("A valid email address is required")]
    [VariableEditorControl(VariableControlType.SingleLineTextBox)]
    [NameValue("ValidationPattern", "^[^@]+@[^@]+\\.[^@]+$")]
    public string Email { get; set; }

    [Comments("Current account status")]
    [Domain("Active,Inactive,Suspended")]
    [VariableEditorControl(VariableControlType.DropDown)]
    public string Status { get; set; }

    [FunctionGroup(FunctionGroup.Standard)]
    public void ActivateAccount(
        [Comments("Activation code sent to user")]
        [ParameterEditorControl(ParameterControlType.SingleLineTextBox)]
        string activationCode)
    {
        // Implementation
    }

}

```

## Target Framework

- .NET Standard 2.0

## Related Projects

- [LogicBuilder](https://github.com/BpsLogicBuilder/LogicBuilder) - The visual workflow designer that consumes these attributes

## Contributing

Contributions are welcome!