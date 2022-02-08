# Atc.CodeDocumentation

This library contains helpers classes which can help with generating code documentation as Markdown (`.md files`) from an assembly.
The content is based on assembly reflection combined with a assembly-documentation xml file.

## Usage

Example runs from a  unit-test, to ensure updated `CodeDoc` folder with Markdown files.

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
