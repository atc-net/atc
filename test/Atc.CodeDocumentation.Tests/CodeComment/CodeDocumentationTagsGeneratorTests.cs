namespace Atc.CodeDocumentation.Tests.CodeComment;

public class CodeDocumentationTagsGeneratorTests
{
    [Fact]
    public void GenerateTags_With_Code_Emits_Code_Tag()
    {
        // Arrange
        var sut = new CodeDocumentationTagsGenerator();
        var tags = new CodeDocumentationTags(
            summary: "Demo summary.",
            parameters: null,
            remark: null,
            code: "var x = 1;",
            example: null,
            exceptions: null,
            @return: null);

        // Act
        var actual = sut.GenerateTags(indentSpaces: 0, tags);

        // Assert
        Assert.Contains("/// <code>", actual, StringComparison.Ordinal);
        Assert.Contains("/// var x = 1;.", actual, StringComparison.Ordinal);
        Assert.Contains("/// </code>", actual, StringComparison.Ordinal);
    }

    [Fact]
    public void GenerateTags_With_Example_Emits_Example_Tag()
    {
        // Arrange
        var sut = new CodeDocumentationTagsGenerator();
        var tags = new CodeDocumentationTags(
            summary: "Demo summary.",
            parameters: null,
            remark: null,
            code: null,
            example: "MyClass.MyMethod()",
            exceptions: null,
            @return: null);

        // Act
        var actual = sut.GenerateTags(indentSpaces: 0, tags);

        // Assert
        Assert.Contains("/// <example>", actual, StringComparison.Ordinal);
        Assert.Contains("/// MyClass.MyMethod().", actual, StringComparison.Ordinal);
        Assert.Contains("/// </example>", actual, StringComparison.Ordinal);
    }

    [Fact]
    public void GenerateTags_With_Exceptions_Emits_Exception_Tags()
    {
        // Arrange
        var sut = new CodeDocumentationTagsGenerator();
        var exceptions = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["ArgumentNullException"] = "Thrown when input is null",
            ["InvalidOperationException"] = "Thrown when state is invalid",
        };
        var tags = new CodeDocumentationTags(
            summary: "Demo summary.",
            parameters: null,
            remark: null,
            code: null,
            example: null,
            exceptions: exceptions,
            @return: null);

        // Act
        var actual = sut.GenerateTags(indentSpaces: 0, tags);

        // Assert
        Assert.Contains(
            "/// <exception cref=\"ArgumentNullException\">Thrown when input is null.</exception>",
            actual,
            StringComparison.Ordinal);
        Assert.Contains(
            "/// <exception cref=\"InvalidOperationException\">Thrown when state is invalid.</exception>",
            actual,
            StringComparison.Ordinal);
    }
}