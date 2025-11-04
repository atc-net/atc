namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class ClassDeclarationSyntaxExtensionsTests
{
    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_ClassDeclaration_Is_Null()
    {
        // Arrange
        ClassDeclarationSyntax classDeclaration = null!;
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            classDeclaration.AddSuppressMessageAttribute(suppressMessage));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_SuppressMessage_Is_Null()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            classDeclaration.AddSuppressMessageAttribute(null!));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_Justification_Is_Null()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            classDeclaration.AddSuppressMessageAttribute(suppressMessage));
        Assert.Contains("Justification is invalid", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Add_Attribute_With_Justification()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000")
        {
            Justification = "Test justification",
        };

        // Act
        var result = classDeclaration.AddSuppressMessageAttribute(suppressMessage);

        // Assert
        Assert.NotNull(result);
        var attributeLists = result.AttributeLists;
        Assert.Single(attributeLists);
        var attribute = attributeLists[0].Attributes[0];
        Assert.Equal("SuppressMessage", attribute.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(attribute.ArgumentList);
        Assert.Equal(3, attribute.ArgumentList.Arguments.Count);
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_ClassDeclaration_Is_Null()
    {
        // Arrange
        ClassDeclarationSyntax classDeclaration = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            classDeclaration.AddGeneratedCodeAttribute("Tool", "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_ToolName_Is_Null()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            classDeclaration.AddGeneratedCodeAttribute(null!, "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_Version_Is_Null()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            classDeclaration.AddGeneratedCodeAttribute("Tool", null!));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Add_Attribute_With_ToolName_And_Version()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");
        const string toolName = "MyCodeGenerator";
        const string version = "1.2.3";

        // Act
        var result = classDeclaration.AddGeneratedCodeAttribute(toolName, version);

        // Assert
        Assert.NotNull(result);
        var attributeLists = result.AttributeLists;
        Assert.Single(attributeLists);
        var attribute = attributeLists[0].Attributes[0];
        Assert.Equal("GeneratedCode", attribute.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(attribute.ArgumentList);
        Assert.Equal(2, attribute.ArgumentList.Arguments.Count);
    }
}