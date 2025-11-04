# Atc.CodeAnalysis.CSharp

**Target Frameworks:** `netstandard2.0`, `net9.0`

Roslyn-based utilities for programmatically working with C# code. This library provides factories and extensions for generating C# syntax trees, making it easier to create code generators, analyzers, and source generators. Multi-targeting enables use in .NET Framework 4.6.1+ projects and modern .NET applications.

## Why Use This Library?

When building source generators, code generators, or code analysis tools, you often need to programmatically create C# syntax trees using Roslyn. This library simplifies that process by providing:

- **Syntax Factories**: Easy-to-use factory methods for creating common C# syntax nodes
- **Extensions**: Helper methods for working with existing syntax trees
- **Type-Safe API**: Strongly-typed methods that reduce boilerplate code
- **Fluent Interface**: Chain operations together for cleaner code generation

Perfect for:
- Source generators
- Code migration tools
- API client generators
- Code analysis tools
- Custom Roslyn analyzers

## Installation

```bash
dotnet add package Atc.CodeAnalysis.CSharp
```

## Code Documentation

- [API References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeAnalysis.CSharp/Index.md)
- [Extended References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeAnalysis.CSharp/IndexExtended.md)

## Examples

### Creating Class Declarations

#### Public Partial Class

```csharp
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

var classDeclaration = SyntaxClassDeclarationFactory.CreateAsPublicPartial("MyClass");
```

**Output:**
```csharp
public partial class MyClass
{
}
```

#### Class with Base Type and Interface

```csharp
var classDeclaration = SyntaxClassDeclarationFactory.Create(
    "MyClass",
    "BaseClass",
    new[] { "IMyInterface", "IDisposable" });
```

**Output:**
```csharp
public class MyClass : BaseClass, IMyInterface, IDisposable
{
}
```

### Creating Attributes

#### Simple Attribute

```csharp
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

var attribute = SyntaxAttributeFactory.Create("Obsolete");
```

**Output:**
```csharp
[Obsolete]
```

#### Attribute with Arguments

```csharp
var attribute = SyntaxAttributeFactory.Create(
    "GeneratedCode",
    SyntaxArgumentFactory.Create("MyGenerator"),
    SyntaxArgumentFactory.Create("1.0.0"));
```

**Output:**
```csharp
[GeneratedCode("MyGenerator", "1.0.0")]
```

#### SuppressMessage Attribute

```csharp
using Atc.CodeAnalysis.CSharp.Factories;

var attribute = SuppressMessageAttributeFactory.Create(
    "Design",
    "CA1034:NestedTypesShouldNotBeVisible",
    "Justification for suppression");
```

**Output:**
```csharp
[SuppressMessage("Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Justification for suppression")]
```

### Creating Parameters

```csharp
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

var parameter = SyntaxParameterFactory.Create("string", "name");
```

**Output:**
```csharp
string name
```

#### Parameter with Default Value

```csharp
var parameter = SyntaxParameterFactory.CreateWithDefaultValue(
    "int",
    "count",
    SyntaxLiteralExpressionFactory.Create(10));
```

**Output:**
```csharp
int count = 10
```

### Creating Literal Expressions

```csharp
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

// String literal
var stringLiteral = SyntaxLiteralExpressionFactory.Create("Hello World");

// Integer literal
var intLiteral = SyntaxLiteralExpressionFactory.Create(42);

// Boolean literal
var boolLiteral = SyntaxLiteralExpressionFactory.CreateTrue();

// Null literal
var nullLiteral = SyntaxLiteralExpressionFactory.CreateNull();
```

### Complete Example: Generating a Simple Class

```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

// Create a compilation unit
var compilationUnit = SyntaxFactory.CompilationUnit();

// Add using directives
compilationUnit = compilationUnit.AddUsings(
    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));

// Create namespace
var @namespace = SyntaxFactory.NamespaceDeclaration(
    SyntaxFactory.ParseName("MyNamespace"));

// Create class with attributes
var classDeclaration = SyntaxClassDeclarationFactory
    .CreateAsPublicPartial("MyGeneratedClass")
    .AddAttributeLists(
        SyntaxAttributeListFactory.Create(
            SyntaxAttributeFactory.Create("GeneratedCode",
                SyntaxArgumentFactory.Create("MyGenerator"),
                SyntaxArgumentFactory.Create("1.0.0"))));

// Add the class to the namespace
@namespace = @namespace.AddMembers(classDeclaration);

// Add the namespace to the compilation unit
compilationUnit = compilationUnit.AddMembers(@namespace);

// Output the code
var code = compilationUnit.NormalizeWhitespace().ToFullString();
Console.WriteLine(code);
```

**Output:**
```csharp
using System;

namespace MyNamespace
{
    [GeneratedCode("MyGenerator", "1.0.0")]
    public partial class MyGeneratedClass
    {
    }
}
```

### Working with Interpolated Strings

```csharp
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

var interpolated = SyntaxInterpolatedFactory.Create(
    "The value is: ",
    "myVariable");
```

**Output:**
```csharp
$"The value is: {myVariable}"
```

## Advanced Usage

### Extending Class Declarations

The library's extension methods make it easy to work with existing syntax trees:

```csharp
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Atc.CodeAnalysis.CSharp.Extensions;

ClassDeclarationSyntax classDecl = /* existing class declaration */;

// Check if class has a specific attribute
bool hasAttribute = classDecl.HasAttribute("Obsolete");

// Get all public methods
var publicMethods = classDecl.GetPublicMethods();
```

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
