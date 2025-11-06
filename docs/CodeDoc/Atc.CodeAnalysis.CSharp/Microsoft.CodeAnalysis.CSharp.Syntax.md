<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Microsoft.CodeAnalysis.CSharp.Syntax

<br />

## ClassDeclarationSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax`.

>```csharp
>public static class ClassDeclarationSyntaxExtensions
>```

### Static Methods

#### AddGeneratedCodeAttribute
>```csharp
>ClassDeclarationSyntax AddGeneratedCodeAttribute(this ClassDeclarationSyntax classDeclaration, string toolName, string version)
>```
><b>Summary:</b> Adds a `System.CodeDom.Compiler.GeneratedCodeAttribute` to the class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The class declaration to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`toolName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the code generation tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version of the code generation tool.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with the attribute added.
#### AddSuppressMessageAttribute
>```csharp
>ClassDeclarationSyntax AddSuppressMessageAttribute(this ClassDeclarationSyntax classDeclaration, SuppressMessageAttribute suppressMessage)
>```
><b>Summary:</b> Adds a `System.Diagnostics.CodeAnalysis.SuppressMessageAttribute` to the class declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`classDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The class declaration to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`suppressMessage`&nbsp;&nbsp;-&nbsp;&nbsp;The suppress message attribute to add.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax` with the attribute added.

<br />

## CompilationUnitSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax`.

>```csharp
>public static class CompilationUnitSyntaxExtensions
>```

### Static Methods

#### AddUsingStatements
>```csharp
>CompilationUnitSyntax AddUsingStatements(this CompilationUnitSyntax compilationUnit, string[] usingStatements)
>```
><b>Summary:</b> Adds using statements to the compilation unit and sorts them.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`compilationUnit`&nbsp;&nbsp;-&nbsp;&nbsp;The compilation unit to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`usingStatements`&nbsp;&nbsp;-&nbsp;&nbsp;The array of using statement strings to add.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax` with the using statements added and sorted.

<br />

## EnumDeclarationSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax`.

>```csharp
>public static class EnumDeclarationSyntaxExtensions
>```

### Static Methods

#### AddFlagAttribute
>```csharp
>EnumDeclarationSyntax AddFlagAttribute(this EnumDeclarationSyntax enumDeclaration)
>```
><b>Summary:</b> Adds a `System.FlagsAttribute` to the enum declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The enum declaration to modify.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax` with the attribute added.
#### AddSuppressMessageAttribute
>```csharp
>EnumDeclarationSyntax AddSuppressMessageAttribute(this EnumDeclarationSyntax enumDeclaration, SuppressMessageAttribute suppressMessage)
>```
><b>Summary:</b> Adds a `System.Diagnostics.CodeAnalysis.SuppressMessageAttribute` to the enum declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The enum declaration to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`suppressMessage`&nbsp;&nbsp;-&nbsp;&nbsp;The suppress message attribute to add.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax` with the attribute added.
#### HasAttributeOfAttributeType
>```csharp
>bool HasAttributeOfAttributeType(this EnumDeclarationSyntax enumDeclaration, Type attributeType)
>```
><b>Summary:</b> Determines whether the enum declaration has an attribute of the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The enum declaration to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`attributeType`&nbsp;&nbsp;-&nbsp;&nbsp;The type of attribute to search for.<br />
>
><b>Returns:</b> `true` if the enum has an attribute of the specified type; otherwise, `false`.

<br />

## InterfaceDeclarationSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax`.

>```csharp
>public static class InterfaceDeclarationSyntaxExtensions
>```

### Static Methods

#### AddGeneratedCodeAttribute
>```csharp
>InterfaceDeclarationSyntax AddGeneratedCodeAttribute(this InterfaceDeclarationSyntax interfaceDeclaration, string toolName, string version)
>```
><b>Summary:</b> Adds a `System.CodeDom.Compiler.GeneratedCodeAttribute` to the interface declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`interfaceDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The interface declaration to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`toolName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the code generation tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version of the code generation tool.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax` with the attribute added.

<br />

## MethodDeclarationSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax`.

>```csharp
>public static class MethodDeclarationSyntaxExtensions
>```

### Static Methods

#### AddSuppressMessageAttribute
>```csharp
>MethodDeclarationSyntax AddSuppressMessageAttribute(this MethodDeclarationSyntax methodDeclaration, SuppressMessageAttribute suppressMessage)
>```
><b>Summary:</b> Adds a `System.Diagnostics.CodeAnalysis.SuppressMessageAttribute` to the method declaration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodDeclaration`&nbsp;&nbsp;-&nbsp;&nbsp;The method declaration to modify.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`suppressMessage`&nbsp;&nbsp;-&nbsp;&nbsp;The suppress message attribute to add.<br />
>
><b>Returns:</b> A new `Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax` with the attribute added.

<br />

## SyntaxNodeExtensions
Extension methods for `Microsoft.CodeAnalysis.SyntaxNode`.

>```csharp
>public static class SyntaxNodeExtensions
>```

### Static Methods

#### GetUsedUsingStatements
>```csharp
>string[] GetUsedUsingStatements(this SyntaxNode syntaxNode)
>```
><b>Summary:</b> Gets all using directive statements from the syntax node.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxNode`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax node to search.<br />
>
><b>Returns:</b> An array of using directive strings.
#### GetUsedUsingStatementsWithoutAlias
>```csharp
>string[] GetUsedUsingStatementsWithoutAlias(this SyntaxNode syntaxNode)
>```
><b>Summary:</b> Gets all using directive statements from the syntax node, excluding those with aliases.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxNode`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax node to search.<br />
>
><b>Returns:</b> An array of using directive strings without aliases.
#### Select
>```csharp
>IEnumerable<T> Select(this SyntaxNode syntaxNode)
>```
><b>Summary:</b> Selects all descendant nodes of type `T` from the syntax node.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxNode`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax node to search.<br />
>
><b>Returns:</b> An enumerable collection of syntax nodes of type `T`.
#### SelectToArray
>```csharp
>T[] SelectToArray(this SyntaxNode syntaxNode)
>```
><b>Summary:</b> Selects all descendant nodes of type `T` from the syntax node and returns them as an array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`syntaxNode`&nbsp;&nbsp;-&nbsp;&nbsp;The syntax node to search.<br />
>
><b>Returns:</b> An array of syntax nodes of type `T`.

<br />

## UsingDirectiveSyntaxExtensions
Extension methods for `Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax`.

>```csharp
>public static class UsingDirectiveSyntaxExtensions
>```

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
