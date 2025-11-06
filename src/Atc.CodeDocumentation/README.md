# Atc.CodeDocumentation

**Target Framework:** `net9.0`

Markdown documentation generator for .NET assemblies. Automatically generates comprehensive API documentation in Markdown format from assembly reflection and XML documentation comments.

## Why Use This Library?

Maintaining up-to-date API documentation is challenging and time-consuming. Atc.CodeDocumentation automates this process by:

- **Generating Markdown Documentation**: Creates Markdown files from assemblies
- **XML Documentation Integration**: Combines reflection with XML documentation comments
- **Automated Updates**: Generate docs as part of your build/test process
- **GitHub-Ready**: Output is optimized for GitHub documentation
- **Type Discovery**: Documents all public types, methods, properties, and more
- **Organized Output**: Creates structured index and reference files

Perfect for:
- Open source projects requiring API documentation
- Libraries shared across teams
- Maintaining docs in sync with code
- Generating documentation for NuGet packages
- Creating developer-friendly API references

## Installation

```bash
dotnet add package Atc.CodeDocumentation
```

## Target Framework

- .NET 9.0

## Key Features

- `MarkdownCodeDocGenerator` for generating documentation
- Support for classes, interfaces, enums, structs, and delegates
- Documentation of methods, properties, fields, and events
- XML comment extraction and formatting
- Index file generation with type listings
- Extended reference documentation
- Customizable output directory structure

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- XML documentation file generated during build

## Key Dependencies

- Atc (foundation library)

## Main Components

### MarkdownCodeDocGenerator

The primary class for generating documentation:
- `Run(Assembly, DirectoryInfo)`: Generates documentation for an assembly

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeDocumentation/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.CodeDocumentation/IndexExtended.md)

### Using `Run(..)` to generate code documentation in markdown files

The following example will show how to run from a unit-test, to ensure updated `CodeDoc` folder with Markdown files generated with `MarkdownCodeDocGenerator.Run`.

```csharp
public class CodeDocumentationTests
{
    [Fact]
    [SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "OK. This \"Test\" generates our Markdown files.")]
    public void RunMarkdownCodeDocGenerator()
    {
        // Arrange
        var sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
        var codeDocDirectory = new DirectoryInfo(@"c:\code\myproject\CodeDoc");

        // Act
        MarkdownCodeDocGenerator.Run(sourceAssembly, codeDocDirectory);
    }
}
```

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
