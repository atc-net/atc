# Atc.CodeAnalysis.CSharp

This library contains common extensions and factories for C# syntax.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeAnalysis.CSharp/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeAnalysis.CSharp/IndexExtended.md)

## `SyntaxArgumentFactory` examples

### Using `Create(..)` to create argument identifier

```csharp
var syntax = SyntaxArgumentFactory.Create("hallo");
```

As normalized text:

```csharp
"hallo"
```

## `SyntaxClassDeclarationFactory` examples

### Using `CreateAsPublicPartial(..)` to create a public partial class syntax-declaration

```csharp
var syntax = SyntaxClassDeclarationFactory.CreateAsPublicPartial("TestClass");
```

As normalized text:

```csharp
public partial class TestClass { }
```
