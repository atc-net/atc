<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.CodeAnalysis.CSharp.SyntaxFactories

<br />


## SyntaxAccessorDeclarationFactory

```csharp
public static class SyntaxAccessorDeclarationFactory
```

### Static Methods


#### Get

```csharp
AccessorDeclarationSyntax Get(bool withSemicolon = True)
```
#### Set

```csharp
AccessorDeclarationSyntax Set(bool withSemicolon = True)
```

<br />


## SyntaxArgumentFactory

```csharp
public static class SyntaxArgumentFactory
```

### Static Methods


#### Create

```csharp
ArgumentSyntax Create(string argumentName)
```

<br />


## SyntaxArgumentListFactory

```csharp
public static class SyntaxArgumentListFactory
```

### Static Methods


#### CreateWithOneItem

```csharp
ArgumentListSyntax CreateWithOneItem(string argumentName)
```

<br />


## SyntaxAssignmentExpressionFactory

```csharp
public static class SyntaxAssignmentExpressionFactory
```

### Static Methods


#### CreateSimple

```csharp
AssignmentExpressionSyntax CreateSimple(string toIdentifierName, string fromIdentifierName)
```

<br />


## SyntaxAttributeArgumentFactory

```csharp
public static class SyntaxAttributeArgumentFactory
```

### Static Methods


#### Create

```csharp
AttributeArgumentSyntax Create(string attributeValue)
```
#### Create

```csharp
AttributeArgumentSyntax Create(int attributeValue)
```
#### Create

```csharp
AttributeArgumentSyntax Create(object attributeValue)
```
#### CreateWithNameEquals

```csharp
AttributeArgumentSyntax CreateWithNameEquals(string attributeName, string attributeValue)
```
#### CreateWithNameEquals

```csharp
AttributeArgumentSyntax CreateWithNameEquals(string attributeName, int attributeValue)
```

<br />


## SyntaxAttributeArgumentListFactory

```csharp
public static class SyntaxAttributeArgumentListFactory
```

### Static Methods


#### CreateWithOneItemWithNameEquals

```csharp
AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, string attributeValue)
```
#### CreateWithOneItemWithNameEquals

```csharp
AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, int attributeValue)
```

<br />


## SyntaxAttributeFactory
Syntax Attribute Factory.

<p><b>Remarks:</b> List of ValidationAttribute's:
            https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/ValidationAttribute.cs.</p>


```csharp
public static class SyntaxAttributeFactory
```

### Static Methods


#### Create

```csharp
AttributeSyntax Create(string attributeName)
```
#### CreateFromValidationAttribute

```csharp
AttributeSyntax CreateFromValidationAttribute(ValidationAttribute validationAttribute)
```
#### CreateWithOneItemWithOneArgument

```csharp
AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
```
#### CreateWithOneItemWithOneArgument

```csharp
AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, int argumentValue)
```
#### CreateWithOneItemWithTwoArgument

```csharp
AttributeSyntax CreateWithOneItemWithTwoArgument(string attributeName, object argumentValue1, object argumentValue2)
```
#### RemoveSuffix

```csharp
string RemoveSuffix(string attributeName)
```

<br />


## SyntaxAttributeListFactory

```csharp
public static class SyntaxAttributeListFactory
```

### Static Methods


#### Create

```csharp
AttributeListSyntax Create(string attributeName)
```
#### Create

```csharp
AttributeListSyntax Create(string attributeName, AttributeArgumentListSyntax attributeArgumentList)
```
#### CreateWithOneItemWithOneArgument

```csharp
AttributeListSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
```
#### CreateWithOneItemWithOneArgumentWithNameEquals

```csharp
AttributeListSyntax CreateWithOneItemWithOneArgumentWithNameEquals(string attributeName, string argumentName, string argumentValue)
```

<br />


## SyntaxClassDeclarationFactory

```csharp
public static class SyntaxClassDeclarationFactory
```

### Static Methods


#### Create

```csharp
ClassDeclarationSyntax Create(string classTypeName)
```
#### CreateAsInternalStatic

```csharp
ClassDeclarationSyntax CreateAsInternalStatic(string classTypeName)
```
#### CreateAsPublicStatic

```csharp
ClassDeclarationSyntax CreateAsPublicStatic(string classTypeName)
```
#### CreateWithInterface

```csharp
ClassDeclarationSyntax CreateWithInterface(string classTypeName, string interfaceTypeName)
```
#### CreateWithSuppressMessageAttribute

```csharp
ClassDeclarationSyntax CreateWithSuppressMessageAttribute(string classTypeName, SuppressMessageAttribute suppressMessage)
```
#### CreateWithSuppressMessageAttributeByCheckId

```csharp
ClassDeclarationSyntax CreateWithSuppressMessageAttributeByCheckId(string classTypeName, int checkId, string justification = )
```

<br />


## SyntaxIfStatementFactory

```csharp
public static class SyntaxIfStatementFactory
```

### Static Methods


#### CreateParameterArgumentNullCheck

```csharp
StatementSyntax CreateParameterArgumentNullCheck(string parameterName, bool includeSystem = True)
```

<br />


## SyntaxInterfaceDeclarationFactory

```csharp
public static class SyntaxInterfaceDeclarationFactory
```

### Static Methods


#### Create

```csharp
InterfaceDeclarationSyntax Create(string interfaceTypeName)
```

<br />


## SyntaxInterpolatedFactory

```csharp
public static class SyntaxInterpolatedFactory
```

### Static Methods


#### CreateNameOf

```csharp
InterpolatedStringContentSyntax CreateNameOf(string argumentName)
```
#### StringText

```csharp
InterpolatedStringContentSyntax StringText(string value)
```
#### StringTextColon

```csharp
InterpolatedStringContentSyntax StringTextColon()
```
#### StringTextColonAndParenthesesStart

```csharp
InterpolatedStringContentSyntax StringTextColonAndParenthesesStart()
```
#### StringTextComma

```csharp
InterpolatedStringContentSyntax StringTextComma()
```
#### StringTextDotCountColon

```csharp
InterpolatedStringContentSyntax StringTextDotCountColon()
```
#### StringTextParenthesesEnd

```csharp
InterpolatedStringContentSyntax StringTextParenthesesEnd()
```

<br />


## SyntaxLiteralExpressionFactory

```csharp
public static class SyntaxLiteralExpressionFactory
```

### Static Methods


#### Create

```csharp
LiteralExpressionSyntax Create(string value, SyntaxKind syntaxKind = StringLiteralExpression)
```
#### Create

```csharp
LiteralExpressionSyntax Create(int value)
```

<br />


## SyntaxMemberAccessExpressionFactory

```csharp
public static class SyntaxMemberAccessExpressionFactory
```

### Static Methods


#### Create

```csharp
MemberAccessExpressionSyntax Create(string memberTypeName, string memberName)
```

<br />


## SyntaxNameEqualsFactory

```csharp
public static class SyntaxNameEqualsFactory
```

### Static Methods


#### Create

```csharp
NameEqualsSyntax Create(string value)
```

<br />


## SyntaxObjectCreationExpressionFactory

```csharp
public static class SyntaxObjectCreationExpressionFactory
```

### Static Methods


#### Create

```csharp
ObjectCreationExpressionSyntax Create(string identifierName)
```
#### Create

```csharp
ObjectCreationExpressionSyntax Create(string namespaceName, string identifierName)
```

<br />


## SyntaxParameterFactory

```csharp
public static class SyntaxParameterFactory
```

### Static Methods


#### Create

```csharp
ParameterSyntax Create(string parameterTypeName, string parameterName, string genericListTypeName = null)
```
#### CreateWithAttribute

```csharp
ParameterSyntax CreateWithAttribute(string attributeTypeName, string parameterTypeName, string parameterName)
```

<br />


## SyntaxParameterListFactory

```csharp
public static class SyntaxParameterListFactory
```

### Static Methods


#### CreateWithOneItem

```csharp
ParameterListSyntax CreateWithOneItem(string parameterTypeName, string parameterName, string genericListTypeName = null)
```

<br />


## SyntaxThrowStatementFactory

```csharp
public static class SyntaxThrowStatementFactory
```

### Static Methods


#### CreateArgumentNullException

```csharp
ThrowStatementSyntax CreateArgumentNullException(string parameterName, bool includeSystem = True)
```
#### CreateNotImplementedException

```csharp
ThrowStatementSyntax CreateNotImplementedException(bool includeSystem = True)
```

<br />


## SyntaxTokenFactory

```csharp
public static class SyntaxTokenFactory
```

### Static Methods


#### AbstractKeyword

```csharp
SyntaxToken AbstractKeyword(bool withTrailingSpace = True)
```
#### AsyncKeyword

```csharp
SyntaxToken AsyncKeyword(bool withTrailingSpace = True)
```
#### CarriageReturnLineFeed

```csharp
SyntaxToken CarriageReturnLineFeed()
```
#### Comma

```csharp
SyntaxToken Comma(bool withTrailingSpace = True)
```
#### DefaultKeyword

```csharp
SyntaxToken DefaultKeyword(bool withTrailingSpace = True)
```
#### DoubleKeyword

```csharp
SyntaxToken DoubleKeyword(bool withTrailingSpace = True)
```
#### Equals

```csharp
SyntaxToken Equals(bool withTrailingSpace = True)
```
#### EqualsGreaterThan

```csharp
SyntaxToken EqualsGreaterThan(bool withTrailingSpace = True)
```
#### ImplicitKeyword

```csharp
SyntaxToken ImplicitKeyword(bool withTrailingSpace = True)
```
#### InternalKeyword

```csharp
SyntaxToken InternalKeyword(bool withTrailingSpace = True)
```
#### IntKeyword

```csharp
SyntaxToken IntKeyword(bool withTrailingSpace = True)
```
#### LineFeed

```csharp
SyntaxToken LineFeed()
```
#### NewKeyword

```csharp
SyntaxToken NewKeyword(bool withTrailingSpace = True)
```
#### OperatorKeyword

```csharp
SyntaxToken OperatorKeyword(bool withTrailingSpace = True)
```
#### OverrideKeyword

```csharp
SyntaxToken OverrideKeyword(bool withTrailingSpace = True)
```
#### PrivateKeyword

```csharp
SyntaxToken PrivateKeyword(bool withTrailingSpace = True)
```
#### ProtectedKeyword

```csharp
SyntaxToken ProtectedKeyword(bool withTrailingSpace = True)
```
#### PublicKeyword

```csharp
SyntaxToken PublicKeyword(bool withTrailingSpace = True)
```
#### ReadOnlyKeyword

```csharp
SyntaxToken ReadOnlyKeyword(bool withTrailingSpace = True)
```
#### Semicolon

```csharp
SyntaxToken Semicolon(bool withTrailingSpace = False)
```
#### StaticKeyword

```csharp
SyntaxToken StaticKeyword(bool withTrailingSpace = True)
```
#### StringKeyword

```csharp
SyntaxToken StringKeyword(bool withTrailingSpace = True)
```
#### Token

```csharp
SyntaxToken Token(SyntaxKind syntaxKind)
```
#### TokenWithTrailing

```csharp
SyntaxToken TokenWithTrailing(SyntaxKind syntaxKind, SyntaxTrivia syntaxTrivia)
```
#### TokenWithTrailingSpace

```csharp
SyntaxToken TokenWithTrailingSpace(SyntaxKind syntaxKind)
```

<br />


## SyntaxTokenListFactory

```csharp
public static class SyntaxTokenListFactory
```

### Static Methods


#### InternalStaticKeyword

```csharp
SyntaxTokenList InternalStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PrivateAsyncKeyword

```csharp
SyntaxTokenList PrivateAsyncKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PrivateReadonlyKeyword

```csharp
SyntaxTokenList PrivateReadonlyKeyword(bool withTrailingSpace = True)
```
#### ProtectedReadOnlyKeyword

```csharp
SyntaxTokenList ProtectedReadOnlyKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### ProtectedStaticKeyword

```csharp
SyntaxTokenList ProtectedStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PublicAsyncKeyword

```csharp
SyntaxTokenList PublicAsyncKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PublicKeyword

```csharp
SyntaxTokenList PublicKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PublicOverrideKeyword

```csharp
SyntaxTokenList PublicOverrideKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```
#### PublicStaticKeyword

```csharp
SyntaxTokenList PublicStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
```

<br />


## SyntaxTypeArgumentListFactory

```csharp
public static class SyntaxTypeArgumentListFactory
```

### Static Methods


#### CreateWithOneItem

```csharp
TypeArgumentListSyntax CreateWithOneItem(string dataType)
```

<br />


## SyntaxVariableDeclarationFactory

```csharp
public static class SyntaxVariableDeclarationFactory
```

### Static Methods


#### Create

```csharp
VariableDeclarationSyntax Create(string identifierTypeName, string identifierName)
```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
