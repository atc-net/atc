<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.CodeAnalysis.CSharp](Atc.CodeAnalysis.CSharp.md)

- [AtcCodeAnalysisCSharpTypeInitializer](Atc.CodeAnalysis.CSharp.md#atccodeanalysiscsharptypeinitializer)
- [ClassDeclarationSyntaxExtensions](Atc.CodeAnalysis.CSharp.md#classdeclarationsyntaxextensions)
  -  Static Methods
     - AddSuppressMessageAttribute(this ClassDeclarationSyntax classDeclaration, SuppressMessageAttribute suppressMessage)

## [Atc.CodeAnalysis.CSharp.Factories](Atc.CodeAnalysis.CSharp.Factories.md)

- [SuppressMessageAttributeFactory](Atc.CodeAnalysis.CSharp.Factories.md#suppressmessageattributefactory)
  -  Static Methods
     - Create(int checkId, string justification)

## [Atc.CodeAnalysis.CSharp.SyntaxFactories](Atc.CodeAnalysis.CSharp.SyntaxFactories.md)

- [SyntaxAccessorDeclarationFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxaccessordeclarationfactory)
  -  Static Methods
     - Get(bool withSemicolon = True)
     - Set(bool withSemicolon = True)
- [SyntaxArgumentFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxargumentfactory)
  -  Static Methods
     - Create(string argumentName)
- [SyntaxArgumentListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxargumentlistfactory)
  -  Static Methods
     - CreateWithOneItem(string argumentName)
- [SyntaxAssignmentExpressionFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxassignmentexpressionfactory)
  -  Static Methods
     - CreateSimple(string toIdentifierName, string fromIdentifierName)
- [SyntaxAttributeArgumentFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxattributeargumentfactory)
  -  Static Methods
     - Create(string attributeValue)
     - Create(int attributeValue)
     - Create(object attributeValue)
     - CreateWithNameEquals(string attributeName, string attributeValue)
     - CreateWithNameEquals(string attributeName, int attributeValue)
- [SyntaxAttributeArgumentListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxattributeargumentlistfactory)
  -  Static Methods
     - CreateWithOneItemWithNameEquals(string attributeName, string attributeValue)
     - CreateWithOneItemWithNameEquals(string attributeName, int attributeValue)
- [SyntaxAttributeFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxattributefactory)
  -  Static Methods
     - Create(string attributeName)
     - CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
     - CreateWithOneItemWithOneArgument(string attributeName, int argumentValue)
     - CreateWithOneItemWithTwoArgument(string attributeName, object argumentValue1, object argumentValue2)
     - CreateFromValidationAttribute(ValidationAttribute validationAttribute)
     - RemoveSuffix(string attributeName)
- [SyntaxAttributeListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxattributelistfactory)
  -  Static Methods
     - Create(string attributeName, AttributeArgumentListSyntax attributeArgumentList)
     - CreateWithOneItem(string attributeName)
     - CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
     - CreateWithOneItemWithOneArgumentWithNameEquals(string attributeName, string argumentName, string argumentValue)
- [SyntaxClassDeclarationFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxclassdeclarationfactory)
  -  Static Methods
     - Create(string classTypeName)
     - CreateAsInternalStatic(string classTypeName)
     - CreateWithSuppressMessageAttribute(string classTypeName, SuppressMessageAttribute suppressMessage)
     - CreateWithSuppressMessageAttributeByCheckId(string classTypeName, int checkId, string justification = )
- [SyntaxIfStatementFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxifstatementfactory)
  -  Static Methods
     - CreateParameterArgumentNullCheck(string parameterName)
- [SyntaxInterfaceDeclarationFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxinterfacedeclarationfactory)
  -  Static Methods
     - Create(string interfaceTypeName)
- [SyntaxInterpolatedFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxinterpolatedfactory)
  -  Static Methods
     - StringText(string value)
     - StringTextColon()
     - StringTextComma()
     - StringTextDotCountColon()
     - StringTextColonAndParenthesesStart()
     - StringTextParenthesesEnd()
     - CreateNameOf(string argumentName)
- [SyntaxLiteralExpressionFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxliteralexpressionfactory)
  -  Static Methods
     - Create(string value, SyntaxKind syntaxKind = StringLiteralExpression)
     - Create(int value)
- [SyntaxMemberAccessExpressionFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxmemberaccessexpressionfactory)
  -  Static Methods
     - Create(string memberTypeName, string memberName)
- [SyntaxNameEqualsFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxnameequalsfactory)
  -  Static Methods
     - Create(string value)
- [SyntaxObjectCreationExpressionFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxobjectcreationexpressionfactory)
  -  Static Methods
     - Create(string identifierName)
- [SyntaxParameterFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxparameterfactory)
  -  Static Methods
     - Create(string parameterTypeName, string parameterName, string genericListTypeName = null)
     - CreateWithAttribute(string attributeTypeName, string parameterTypeName, string parameterName)
- [SyntaxParameterListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxparameterlistfactory)
  -  Static Methods
     - CreateWithOneItem(string parameterTypeName, string parameterName, string genericListTypeName = null)
- [SyntaxTokenFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxtokenfactory)
  -  Static Methods
     - Token(SyntaxKind syntaxKind)
     - TokenWithTrailingSpace(SyntaxKind syntaxKind)
     - TokenWithTrailing(SyntaxKind syntaxKind, SyntaxTrivia syntaxTrivia)
     - LineFeed()
     - CarriageReturnLineFeed()
     - Comma(bool withTrailingSpace = True)
     - Semicolon(bool withTrailingSpace = False)
     - Equals(bool withTrailingSpace = True)
     - EqualsGreaterThan(bool withTrailingSpace = True)
     - PublicKeyword(bool withTrailingSpace = True)
     - PrivateKeyword(bool withTrailingSpace = True)
     - OverrideKeyword(bool withTrailingSpace = True)
     - InternalKeyword(bool withTrailingSpace = True)
     - StaticKeyword(bool withTrailingSpace = True)
     - AsyncKeyword(bool withTrailingSpace = True)
     - ReadOnlyKeyword(bool withTrailingSpace = True)
     - NewKeyword(bool withTrailingSpace = True)
     - DefaultKeyword(bool withTrailingSpace = True)
     - ImplicitKeyword(bool withTrailingSpace = True)
     - OperatorKeyword(bool withTrailingSpace = True)
     - StringKeyword(bool withTrailingSpace = True)
     - IntKeyword(bool withTrailingSpace = True)
     - DoubleKeyword(bool withTrailingSpace = True)
- [SyntaxTokenListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxtokenlistfactory)
  -  Static Methods
     - PublicStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
     - PublicOverrideKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
     - InternalStaticKeyword(bool withLeadingLineFeed = False, bool withTrailingSpace = True)
     - PrivateReadonlyKeyword(bool withTrailingSpace = True)
- [SyntaxTypeArgumentListFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxtypeargumentlistfactory)
  -  Static Methods
     - CreateWithOneItem(string dataType)
- [SyntaxVariableDeclarationFactory](Atc.CodeAnalysis.CSharp.SyntaxFactories.md#syntaxvariabledeclarationfactory)
  -  Static Methods
     - Create(string identifierTypeName, string identifierName)

## [Microsoft.CodeAnalysis.CSharp.Syntax](Microsoft.CodeAnalysis.CSharp.Syntax.md)

- [CompilationUnitSyntaxExtensions](Microsoft.CodeAnalysis.CSharp.Syntax.md#compilationunitsyntaxextensions)
  -  Static Methods
     - AddUsingStatements(this CompilationUnitSyntax compilationUnit, string[] usingStatements)
- [UsingDirectiveSyntaxExtensions](Microsoft.CodeAnalysis.CSharp.Syntax.md#usingdirectivesyntaxextensions)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

