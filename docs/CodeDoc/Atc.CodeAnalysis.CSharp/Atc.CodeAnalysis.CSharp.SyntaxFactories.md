<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.CodeAnalysis.CSharp.SyntaxFactories

<br />

## SyntaxAccessorDeclarationFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax` nodes.

>```csharp
>public static class SyntaxAccessorDeclarationFactory
>```

### Static Methods

#### Get
>```csharp
>AccessorDeclarationSyntax Get(bool withSemicolon = True)
>```
><b>Summary:</b> Creates a get accessor declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withSemicolon`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes a semicolon token; otherwise, uses a missing token.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax` representing a get accessor.
#### Set
>```csharp
>AccessorDeclarationSyntax Set(bool withSemicolon = True)
>```
><b>Summary:</b> Creates a set accessor declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withSemicolon`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes a semicolon token; otherwise, uses a missing token.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax` representing a set accessor.

<br />

## SyntaxArgumentFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax` nodes.

>```csharp
>public static class SyntaxArgumentFactory
>```

### Static Methods

#### Create
>```csharp
>ArgumentSyntax Create(string argumentName)
>```
><b>Summary:</b> Creates an argument from an identifier name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the argument identifier.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax` node.

<br />

## SyntaxArgumentListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` nodes.

>```csharp
>public static class SyntaxArgumentListFactory
>```

### Static Methods

#### CreateWithOneArgumentItem
>```csharp
>ArgumentListSyntax CreateWithOneArgumentItem(ArgumentSyntax argument)
>```
><b>Summary:</b> Creates an argument list with a single argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument`&nbsp;&nbsp;-&nbsp;&nbsp;The argument to include.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing one argument.
#### CreateWithOneExpressionItem
>```csharp
>ArgumentListSyntax CreateWithOneExpressionItem(ExpressionSyntax argumentExpression1)
>```
><b>Summary:</b> Creates an argument list with a single argument from an expression.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression1`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing one argument.
#### CreateWithOneItem
>```csharp
>ArgumentListSyntax CreateWithOneItem(string argumentName)
>```
><b>Summary:</b> Creates an argument list with a single argument from an identifier name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the argument identifier.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing one argument.
#### CreateWithThreeArgumentItems
>```csharp
>ArgumentListSyntax CreateWithThreeArgumentItems(ArgumentSyntax argument1, ArgumentSyntax argument2, ArgumentSyntax argument3)
>```
><b>Summary:</b> Creates an argument list with three arguments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument1`&nbsp;&nbsp;-&nbsp;&nbsp;The first argument to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument2`&nbsp;&nbsp;-&nbsp;&nbsp;The second argument to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument3`&nbsp;&nbsp;-&nbsp;&nbsp;The third argument to include.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing three arguments.
#### CreateWithThreeExpressionItems
>```csharp
>ArgumentListSyntax CreateWithThreeExpressionItems(ExpressionSyntax argumentExpression1, ExpressionSyntax argumentExpression2, ExpressionSyntax argumentExpression3)
>```
><b>Summary:</b> Creates an argument list with three arguments from expressions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression1`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the first argument.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression2`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the second argument.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression3`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the third argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing three arguments.
#### CreateWithTwoArgumentItems
>```csharp
>ArgumentListSyntax CreateWithTwoArgumentItems(ArgumentSyntax argument1, ArgumentSyntax argument2)
>```
><b>Summary:</b> Creates an argument list with two arguments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument1`&nbsp;&nbsp;-&nbsp;&nbsp;The first argument to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argument2`&nbsp;&nbsp;-&nbsp;&nbsp;The second argument to include.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing two arguments.
#### CreateWithTwoExpressionItems
>```csharp
>ArgumentListSyntax CreateWithTwoExpressionItems(ExpressionSyntax argumentExpression1, ExpressionSyntax argumentExpression2)
>```
><b>Summary:</b> Creates an argument list with two arguments from expressions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression1`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the first argument.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentExpression2`&nbsp;&nbsp;-&nbsp;&nbsp;The expression to use as the second argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing two arguments.
#### CreateWithTwoItems
>```csharp
>ArgumentListSyntax CreateWithTwoItems(string argumentName1, string argumentName2)
>```
><b>Summary:</b> Creates an argument list with two arguments from identifier names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName1`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the first argument identifier.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName2`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the second argument identifier.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax` containing two arguments.

<br />

## SyntaxAssignmentExpressionFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax` nodes.

>```csharp
>public static class SyntaxAssignmentExpressionFactory
>```

### Static Methods

#### CreateSimple
>```csharp
>AssignmentExpressionSyntax CreateSimple(string toIdentifierName, string fromIdentifierName)
>```
><b>Summary:</b> Creates a simple assignment expression (e.g., `toIdentifierName = fromIdentifierName`).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`toIdentifierName`&nbsp;&nbsp;-&nbsp;&nbsp;The identifier name on the left side of the assignment.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fromIdentifierName`&nbsp;&nbsp;-&nbsp;&nbsp;The identifier name on the right side of the assignment.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax` node representing the simple assignment.

<br />

## SyntaxAttributeArgumentFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` nodes.

>```csharp
>public static class SyntaxAttributeArgumentFactory
>```

### Static Methods

#### Create
>```csharp
>AttributeArgumentSyntax Create(string attributeValue)
>```
><b>Summary:</b> Creates an attribute argument from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` node.
#### Create
>```csharp
>AttributeArgumentSyntax Create(int attributeValue)
>```
><b>Summary:</b> Creates an attribute argument from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` node.
#### Create
>```csharp
>AttributeArgumentSyntax Create(object attributeValue)
>```
><b>Summary:</b> Creates an attribute argument from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` node.
#### CreateWithNameEquals
>```csharp
>AttributeArgumentSyntax CreateWithNameEquals(string attributeName, string attributeValue)
>```
><b>Summary:</b> Creates an attribute argument with a name-equals syntax from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute property.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` node with a name-equals clause.
#### CreateWithNameEquals
>```csharp
>AttributeArgumentSyntax CreateWithNameEquals(string attributeName, int attributeValue)
>```
><b>Summary:</b> Creates an attribute argument with a name-equals syntax from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute property.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax` node with a name-equals clause.

<br />

## SyntaxAttributeArgumentListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax` nodes.

>```csharp
>public static class SyntaxAttributeArgumentListFactory
>```

### Static Methods

#### CreateWithOneItemWithNameEquals
>```csharp
>AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, string attributeValue)
>```
><b>Summary:</b> Creates an attribute argument list with a single named argument from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute property.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax` containing one named argument.
#### CreateWithOneItemWithNameEquals
>```csharp
>AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, int attributeValue)
>```
><b>Summary:</b> Creates an attribute argument list with a single named argument from a string value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute property.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the attribute argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax` containing one named argument.

<br />

## SyntaxAttributeFactory
Syntax Attribute Factory.
><b>Remarks:</b> List of ValidationAttribute's: https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/ValidationAttribute.cs.

>```csharp
>public static class SyntaxAttributeFactory
>```

### Static Methods

#### Create
>```csharp
>AttributeSyntax Create(string attributeName)
>```
><b>Summary:</b> Creates an attribute from a name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute (with or without "Attribute" suffix).<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax` node.
#### CreateFromValidationAttribute
>```csharp
>AttributeSyntax CreateFromValidationAttribute(ValidationAttribute validationAttribute)
>```
><b>Summary:</b> Creates an attribute syntax from a `System.ComponentModel.DataAnnotations.ValidationAttribute` instance.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;The validation attribute to convert.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax` node representing the validation attribute.
#### CreateWithOneItemWithOneArgument
>```csharp
>AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
>```
><b>Summary:</b> Creates an attribute with a single string argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute (with or without "Attribute" suffix).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax` node with one argument.
#### CreateWithOneItemWithOneArgument
>```csharp
>AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, int argumentValue)
>```
><b>Summary:</b> Creates an attribute with a single string argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute (with or without "Attribute" suffix).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax` node with one argument.
#### CreateWithOneItemWithTwoArgument
>```csharp
>AttributeSyntax CreateWithOneItemWithTwoArgument(string attributeName, object argumentValue1, object argumentValue2)
>```
><b>Summary:</b> Creates an attribute with two arguments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute (with or without "Attribute" suffix).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue1`&nbsp;&nbsp;-&nbsp;&nbsp;The first argument value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue2`&nbsp;&nbsp;-&nbsp;&nbsp;The second argument value.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax` node with two arguments.
#### RemoveSuffix
>```csharp
>string RemoveSuffix(string attributeName)
>```
><b>Summary:</b> Removes the "Attribute" suffix from an attribute name if present.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The attribute name to process.<br />
>
><b>Returns:</b> The attribute name without the "Attribute" suffix.

<br />

## SyntaxAttributeListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax` nodes.

>```csharp
>public static class SyntaxAttributeListFactory
>```

### Static Methods

#### Create
>```csharp
>AttributeListSyntax Create(string attributeName)
>```
><b>Summary:</b> Creates an attribute list with a single attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax` containing one attribute.
#### Create
>```csharp
>AttributeListSyntax Create(string attributeName, AttributeArgumentListSyntax attributeArgumentList)
>```
><b>Summary:</b> Creates an attribute list with a single attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax` containing one attribute.
#### CreateWithOneItemWithOneArgument
>```csharp
>AttributeListSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
>```
><b>Summary:</b> Creates an attribute list with a single attribute and one string argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax` containing one attribute with one argument.
#### CreateWithOneItemWithOneArgumentWithNameEquals
>```csharp
>AttributeListSyntax CreateWithOneItemWithOneArgumentWithNameEquals(string attributeName, string argumentName, string argumentValue)
>```
><b>Summary:</b> Creates an attribute list with a single attribute and one named argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the attribute.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the argument property.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string value for the argument.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax` containing one attribute with a named argument.

<br />

## SyntaxBaseListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax` nodes.

>```csharp
>public static class SyntaxBaseListFactory
>```

### Static Methods

#### CreateOneSimpleBaseType
>```csharp
>BaseListSyntax CreateOneSimpleBaseType(string typeName)
>```
><b>Summary:</b> Creates a base list with a single base type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base type.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax` containing one base type.
#### CreateTwoSimpleBaseTypes
>```csharp
>BaseListSyntax CreateTwoSimpleBaseTypes(string typeName1, string typeName2)
>```
><b>Summary:</b> Creates a base list with two base types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName1`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the first base type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName2`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the second base type.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax` containing two base types.

<br />

## SyntaxClassDeclarationFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` nodes.

>```csharp
>public static class SyntaxClassDeclarationFactory
>```

### Static Methods

#### Create
>```csharp
>ClassDeclarationSyntax Create(string classTypeName)
>```
><b>Summary:</b> Creates a public class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with public modifier.
#### CreateAsInternalStatic
>```csharp
>ClassDeclarationSyntax CreateAsInternalStatic(string classTypeName)
>```
><b>Summary:</b> Creates an internal static class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with internal and static modifiers.
#### CreateAsPublicPartial
>```csharp
>ClassDeclarationSyntax CreateAsPublicPartial(string classTypeName)
>```
><b>Summary:</b> Creates a public partial class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with public and partial modifiers.
#### CreateAsPublicStatic
>```csharp
>ClassDeclarationSyntax CreateAsPublicStatic(string classTypeName)
>```
><b>Summary:</b> Creates a public static class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with public and static modifiers.
#### CreateWithInheritClassAndInterface
>```csharp
>ClassDeclarationSyntax CreateWithInheritClassAndInterface(string classTypeName, string inheritClassTypeName, string interfaceTypeName)
>```
><b>Summary:</b> Creates a public class declaration that inherits from a base class and implements an interface.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritClassTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base class to inherit from.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`interfaceTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the interface to implement.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with inheritance and interface implementation.
#### CreateWithInheritClassType
>```csharp
>ClassDeclarationSyntax CreateWithInheritClassType(string classTypeName, string inheritClassTypeName)
>```
><b>Summary:</b> Creates a public class declaration that inherits from a base class.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritClassTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base class to inherit from.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with inheritance.
#### CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId
>```csharp
>ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId(string classTypeName, string inheritClassTypeName, int checkId, string justification = )
>```
><b>Summary:</b> Creates a public class declaration with inheritance and a Code Analysis suppress message attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritClassTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base class to inherit from.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkId`&nbsp;&nbsp;-&nbsp;&nbsp;The Code Analysis check ID to suppress.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`justification`&nbsp;&nbsp;-&nbsp;&nbsp;The justification for suppressing the check.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with inheritance and the suppress message attribute.
#### CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId
>```csharp
>ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId(string classTypeName, string inheritClassTypeName, int checkId, string justification = )
>```
><b>Summary:</b> Creates a public class declaration with inheritance and a StyleCop suppress message attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritClassTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base class to inherit from.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkId`&nbsp;&nbsp;-&nbsp;&nbsp;The StyleCop check ID to suppress.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`justification`&nbsp;&nbsp;-&nbsp;&nbsp;The justification for suppressing the check.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with inheritance and the suppress message attribute.
#### CreateWithInterface
>```csharp
>ClassDeclarationSyntax CreateWithInterface(string classTypeName, string interfaceTypeName)
>```
><b>Summary:</b> Creates a public class declaration that implements an interface.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`interfaceTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the interface to implement.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with interface implementation.
#### CreateWithSuppressMessageAttribute
>```csharp
>ClassDeclarationSyntax CreateWithSuppressMessageAttribute(string classTypeName, SuppressMessageAttribute suppressMessage)
>```
><b>Summary:</b> Creates a public class declaration with a suppress message attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`suppressMessage`&nbsp;&nbsp;-&nbsp;&nbsp;The suppress message attribute to add.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with the suppress message attribute.
#### CreateWithSuppressMessageAttributeByCodeAnalysisCheckId
>```csharp
>ClassDeclarationSyntax CreateWithSuppressMessageAttributeByCodeAnalysisCheckId(string classTypeName, int checkId, string justification = )
>```
><b>Summary:</b> Creates a public class declaration with a Code Analysis suppress message attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkId`&nbsp;&nbsp;-&nbsp;&nbsp;The Code Analysis check ID to suppress.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`justification`&nbsp;&nbsp;-&nbsp;&nbsp;The justification for suppressing the check.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with the suppress message attribute.
#### CreateWithSuppressMessageAttributeByStyleCopCheckId
>```csharp
>ClassDeclarationSyntax CreateWithSuppressMessageAttributeByStyleCopCheckId(string classTypeName, int checkId, string justification = )
>```
><b>Summary:</b> Creates a public class declaration with a StyleCop suppress message attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the class.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkId`&nbsp;&nbsp;-&nbsp;&nbsp;The StyleCop check ID to suppress.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`justification`&nbsp;&nbsp;-&nbsp;&nbsp;The justification for suppressing the check.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with the suppress message attribute.

<br />

## SyntaxIfStatementFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.IfStatementSyntax` nodes.

>```csharp
>public static class SyntaxIfStatementFactory
>```

### Static Methods

#### CreateParameterArgumentNullCheck
>```csharp
>StatementSyntax CreateParameterArgumentNullCheck(string parameterName, bool includeSystem = True)
>```
><b>Summary:</b> Creates an if statement that checks if a parameter is null and throws `System.ArgumentNullException`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the parameter to check for null.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeSystem`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the System namespace prefix for ArgumentNullException.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax` representing the null check.

<br />

## SyntaxInterfaceDeclarationFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax` nodes.

>```csharp
>public static class SyntaxInterfaceDeclarationFactory
>```

### Static Methods

#### Create
>```csharp
>InterfaceDeclarationSyntax Create(string interfaceTypeName)
>```
><b>Summary:</b> Creates a public interface declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`interfaceTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the interface.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax` with public modifier.

<br />

## SyntaxInterpolatedFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` nodes for interpolated strings.

>```csharp
>public static class SyntaxInterpolatedFactory
>```

### Static Methods

#### CreateNameOf
>```csharp
>InterpolatedStringContentSyntax CreateNameOf(string argumentName)
>```
><b>Summary:</b> Creates an interpolated content node containing a nameof expression.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the argument to use in the nameof expression.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing nameof(argumentName).
#### StringText
>```csharp
>InterpolatedStringContentSyntax StringText(string value)
>```
><b>Summary:</b> Creates an interpolated string text content from a value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The text value to include in the interpolated string.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing the text.
#### StringTextColon
>```csharp
>InterpolatedStringContentSyntax StringTextColon()
>```
><b>Summary:</b> Creates interpolated string text for a colon and space (": ").
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing ": ".
#### StringTextColonAndParenthesesStart
>```csharp
>InterpolatedStringContentSyntax StringTextColonAndParenthesesStart()
>```
><b>Summary:</b> Creates interpolated string text for ": (".
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing ": (".
#### StringTextComma
>```csharp
>InterpolatedStringContentSyntax StringTextComma()
>```
><b>Summary:</b> Creates interpolated string text for a comma and space (", ").
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing ", ".
#### StringTextDotCountColon
>```csharp
>InterpolatedStringContentSyntax StringTextDotCountColon()
>```
><b>Summary:</b> Creates interpolated string text for ".Count: ".
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing ".Count: ".
#### StringTextParenthesesEnd
>```csharp
>InterpolatedStringContentSyntax StringTextParenthesesEnd()
>```
><b>Summary:</b> Creates interpolated string text for ")".
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax` representing ")".

<br />

## SyntaxLiteralExpressionFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax` nodes.

>```csharp
>public static class SyntaxLiteralExpressionFactory
>```

### Static Methods

#### Create
>```csharp
>LiteralExpressionSyntax Create(string value, SyntaxKind syntaxKind = StringLiteralExpression)
>```
><b>Summary:</b> Creates a literal expression from a string value with the specified syntax kind.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value for the literal expression.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxKind`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax kind for the literal (string or numeric).<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax` node.
#### Create
>```csharp
>LiteralExpressionSyntax Create(int value)
>```
><b>Summary:</b> Creates a literal expression from a string value with the specified syntax kind.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value for the literal expression.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxKind`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax kind for the literal (string or numeric).<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax` node.

<br />

## SyntaxMemberAccessExpressionFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax` nodes.

>```csharp
>public static class SyntaxMemberAccessExpressionFactory
>```

### Static Methods

#### Create
>```csharp
>MemberAccessExpressionSyntax Create(string memberTypeName, string memberName)
>```
><b>Summary:</b> Creates a simple member access expression (e.g., `memberName.memberTypeName`).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the member being accessed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the object containing the member.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax` node.

<br />

## SyntaxNameEqualsFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax` nodes.

>```csharp
>public static class SyntaxNameEqualsFactory
>```

### Static Methods

#### Create
>```csharp
>NameEqualsSyntax Create(string value)
>```
><b>Summary:</b> Creates a name-equals syntax node (used in attribute named arguments and object initializers).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The identifier name for the name-equals clause.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax` node.

<br />

## SyntaxObjectCreationExpressionFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax` nodes.

>```csharp
>public static class SyntaxObjectCreationExpressionFactory
>```

### Static Methods

#### Create
>```csharp
>ObjectCreationExpressionSyntax Create(string identifierName)
>```
><b>Summary:</b> Creates an object creation expression for a type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`identifierName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the type to instantiate.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax` node.
#### Create
>```csharp
>ObjectCreationExpressionSyntax Create(string namespaceName, string identifierName)
>```
><b>Summary:</b> Creates an object creation expression for a type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`identifierName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the type to instantiate.<br />
>
><b>Returns:</b> An `Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax` node.

<br />

## SyntaxParameterFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax` nodes.

>```csharp
>public static class SyntaxParameterFactory
>```

### Static Methods

#### Create
>```csharp
>ParameterSyntax Create(string parameterTypeName, string parameterName, string genericListTypeName = null)
>```
><b>Summary:</b> Creates a parameter with an optional generic list type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The type name of the parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`genericListTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The generic list type name (e.g., "List", "IEnumerable").<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax` node.
#### CreateWithAttribute
>```csharp
>ParameterSyntax CreateWithAttribute(string attributeTypeName, string parameterTypeName, string parameterName)
>```
><b>Summary:</b> Creates a parameter with an attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The type name of the attribute to apply.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The type name of the parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the parameter.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax` node with an attribute.

<br />

## SyntaxParameterListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax` nodes.

>```csharp
>public static class SyntaxParameterListFactory
>```

### Static Methods

#### CreateWithOneItem
>```csharp
>ParameterListSyntax CreateWithOneItem(string parameterTypeName, string parameterName, string genericListTypeName = null)
>```
><b>Summary:</b> Creates a parameter list with a single parameter.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The type name of the parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`genericListTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The generic list type name (e.g., "List", "IEnumerable").<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax` containing one parameter.
#### CreateWithOneParameterItem
>```csharp
>ParameterListSyntax CreateWithOneParameterItem(ParameterSyntax parameter)
>```
><b>Summary:</b> Creates a parameter list with one parameter.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter`&nbsp;&nbsp;-&nbsp;&nbsp;The parameter to include.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax` containing one parameter.
#### CreateWithThreeParameterItems
>```csharp
>ParameterListSyntax CreateWithThreeParameterItems(ParameterSyntax parameter1, ParameterSyntax parameter2, ParameterSyntax parameter3)
>```
><b>Summary:</b> Creates a parameter list with three parameters.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter1`&nbsp;&nbsp;-&nbsp;&nbsp;The first parameter to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter2`&nbsp;&nbsp;-&nbsp;&nbsp;The second parameter to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter3`&nbsp;&nbsp;-&nbsp;&nbsp;The third parameter to include.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax` containing three parameters.
#### CreateWithTwoParameterItems
>```csharp
>ParameterListSyntax CreateWithTwoParameterItems(ParameterSyntax parameter1, ParameterSyntax parameter2)
>```
><b>Summary:</b> Creates a parameter list with two parameters.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter1`&nbsp;&nbsp;-&nbsp;&nbsp;The first parameter to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameter2`&nbsp;&nbsp;-&nbsp;&nbsp;The second parameter to include.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax` containing two parameters.

<br />

## SyntaxSimpleBaseTypeFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax` nodes.

>```csharp
>public static class SyntaxSimpleBaseTypeFactory
>```

### Static Methods

#### Create
>```csharp
>SimpleBaseTypeSyntax Create(string typeName)
>```
><b>Summary:</b> Creates a simple base type from a type name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the base type.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax` node.

<br />

## SyntaxThrowStatementFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax` nodes.

>```csharp
>public static class SyntaxThrowStatementFactory
>```

### Static Methods

#### CreateArgumentNullException
>```csharp
>ThrowStatementSyntax CreateArgumentNullException(string parameterName, bool includeSystem = True)
>```
><b>Summary:</b> Creates a throw statement for `System.ArgumentNullException` with a parameter name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameterName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the null parameter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeSystem`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the System namespace prefix.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax` node throwing ArgumentNullException.
#### CreateNotImplementedException
>```csharp
>ThrowStatementSyntax CreateNotImplementedException(bool includeSystem = True)
>```
><b>Summary:</b> Creates a throw statement for `System.NotImplementedException`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeSystem`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the System namespace prefix.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax` node throwing NotImplementedException.

<br />

## SyntaxTokenFactory
SyntaxTokenFactory - for base methods.

>```csharp
>public static class SyntaxTokenFactory
>```

### Static Methods

#### AbstractKeyword
>```csharp
>SyntaxToken AbstractKeyword(bool withTrailingSpace = True)
>```
#### AsyncKeyword
>```csharp
>SyntaxToken AsyncKeyword(bool withTrailingSpace = True)
>```
#### ByteKeyword
>```csharp
>SyntaxToken ByteKeyword(bool withTrailingSpace = True)
>```
#### CarriageReturnLineFeed
>```csharp
>SyntaxToken CarriageReturnLineFeed()
>```
#### Colon
>```csharp
>SyntaxToken Colon(bool withTrailingSpace = False)
>```
#### Comma
>```csharp
>SyntaxToken Comma(bool withTrailingSpace = True)
>```
#### DefaultKeyword
>```csharp
>SyntaxToken DefaultKeyword(bool withTrailingSpace = True)
>```
#### DoubleKeyword
>```csharp
>SyntaxToken DoubleKeyword(bool withTrailingSpace = True)
>```
#### Equals
>```csharp
>SyntaxToken Equals(bool withTrailingSpace = True)
>```
#### EqualsGreaterThan
>```csharp
>SyntaxToken EqualsGreaterThan(bool withTrailingSpace = True)
>```
#### ImplicitKeyword
>```csharp
>SyntaxToken ImplicitKeyword(bool withTrailingSpace = True)
>```
#### IntKeyword
>```csharp
>SyntaxToken IntKeyword(bool withTrailingSpace = True)
>```
#### InternalKeyword
>```csharp
>SyntaxToken InternalKeyword(bool withTrailingSpace = True)
>```
#### LineFeed
>```csharp
>SyntaxToken LineFeed()
>```
#### NewKeyword
>```csharp
>SyntaxToken NewKeyword(bool withTrailingSpace = True)
>```
#### ObjectKeyword
>```csharp
>SyntaxToken ObjectKeyword(bool withTrailingSpace = True)
>```
#### OperatorKeyword
>```csharp
>SyntaxToken OperatorKeyword(bool withTrailingSpace = True)
>```
#### OverrideKeyword
>```csharp
>SyntaxToken OverrideKeyword(bool withTrailingSpace = True)
>```
#### PartialKeyword
>```csharp
>SyntaxToken PartialKeyword(bool withTrailingSpace = True)
>```
#### PrivateKeyword
>```csharp
>SyntaxToken PrivateKeyword(bool withTrailingSpace = True)
>```
#### ProtectedKeyword
>```csharp
>SyntaxToken ProtectedKeyword(bool withTrailingSpace = True)
>```
#### PublicKeyword
>```csharp
>SyntaxToken PublicKeyword(bool withTrailingSpace = True)
>```
#### ReadOnlyKeyword
>```csharp
>SyntaxToken ReadOnlyKeyword(bool withTrailingSpace = True)
>```
#### Semicolon
>```csharp
>SyntaxToken Semicolon(bool withTrailingSpace = False)
>```
#### StaticKeyword
>```csharp
>SyntaxToken StaticKeyword(bool withTrailingSpace = True)
>```
#### StringKeyword
>```csharp
>SyntaxToken StringKeyword(bool withTrailingSpace = True)
>```
#### Token
>```csharp
>SyntaxToken Token(SyntaxKind syntaxKind)
>```
><b>Summary:</b> Creates a syntax token of the specified kind.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxKind`&nbsp;&nbsp;-&nbsp;&nbsp;The kind of token to create.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.SyntaxToken`.
#### TokenWithTrailing
>```csharp
>SyntaxToken TokenWithTrailing(SyntaxKind syntaxKind, SyntaxTrivia syntaxTrivia)
>```
><b>Summary:</b> Creates a syntax token with trailing trivia.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxKind`&nbsp;&nbsp;-&nbsp;&nbsp;The kind of token to create.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxTrivia`&nbsp;&nbsp;-&nbsp;&nbsp;The trailing trivia to add.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.SyntaxToken` with the specified trailing trivia.
#### TokenWithTrailingSpace
>```csharp
>SyntaxToken TokenWithTrailingSpace(SyntaxKind syntaxKind)
>```
><b>Summary:</b> Creates a syntax token with a trailing space.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxKind`&nbsp;&nbsp;-&nbsp;&nbsp;The kind of token to create.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.SyntaxToken` with trailing space trivia.
#### VoidKeyword
>```csharp
>SyntaxToken VoidKeyword(bool withTrailingSpace = True)
>```

<br />

## SyntaxTokenListFactory
Factory for creating `Microsoft.CodeAnalysis.SyntaxTokenList` modifier lists.

>```csharp
>public static class SyntaxTokenListFactory
>```

### Static Methods

#### InternalStaticKeyword
>```csharp
>SyntaxTokenList InternalStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### PrivateAsyncKeyword
>```csharp
>SyntaxTokenList PrivateAsyncKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### PrivateReadonlyKeyword
>```csharp
>SyntaxTokenList PrivateReadonlyKeyword(bool withTrailingSpace = True)
>```
#### ProtectedReadOnlyKeyword
>```csharp
>SyntaxTokenList ProtectedReadOnlyKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### ProtectedStaticKeyword
>```csharp
>SyntaxTokenList ProtectedStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### PublicAsyncKeyword
>```csharp
>SyntaxTokenList PublicAsyncKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### PublicKeyword
>```csharp
>SyntaxTokenList PublicKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
><b>Summary:</b> Creates a token list with the public keyword.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withLeadingLineFeed`&nbsp;&nbsp;-&nbsp;&nbsp;If true, adds a leading line feed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withTrailingSpace`&nbsp;&nbsp;-&nbsp;&nbsp;If true, adds a trailing space.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.SyntaxTokenList` containing the public modifier.
#### PublicOverrideKeyword
>```csharp
>SyntaxTokenList PublicOverrideKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```
#### PublicStaticKeyword
>```csharp
>SyntaxTokenList PublicStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
>```

<br />

## SyntaxTypeArgumentListFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax` nodes.

>```csharp
>public static class SyntaxTypeArgumentListFactory
>```

### Static Methods

#### CreateWithOneItem
>```csharp
>TypeArgumentListSyntax CreateWithOneItem(string typeName)
>```
><b>Summary:</b> Creates a type argument list with a single type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the type argument.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax` containing one type.
#### CreateWithTwoItems
>```csharp
>TypeArgumentListSyntax CreateWithTwoItems(string typeName1, string typeName2)
>```
><b>Summary:</b> Creates a type argument list with two types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName1`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the first type argument.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName2`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the second type argument.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax` containing two types.

<br />

## SyntaxVariableDeclarationFactory
Factory for creating `Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax` nodes.

>```csharp
>public static class SyntaxVariableDeclarationFactory
>```

### Static Methods

#### Create
>```csharp
>VariableDeclarationSyntax Create(string identifierTypeName, string identifierName)
>```
><b>Summary:</b> Creates a variable declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`identifierTypeName`&nbsp;&nbsp;-&nbsp;&nbsp;The type name of the variable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`identifierName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the variable.<br />
>
><b>Returns:</b> A `Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax` node.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
