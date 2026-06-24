namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class RecordDeclarationSyntaxExtensionsTests
{
    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_RecordDeclaration_Is_Null()
    {
        // Arrange
        RecordDeclarationSyntax recordDeclaration = null!;
        var suppressMessage = new SuppressMessageAttribute("category", "checkId") { Justification = "OK." };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            recordDeclaration.AddSuppressMessageAttribute(suppressMessage));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_SuppressMessage_Is_Null()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            recordDeclaration.AddSuppressMessageAttribute(null!));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_Justification_Is_Empty()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");
        var suppressMessage = new SuppressMessageAttribute("category", "checkId");

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            recordDeclaration.AddSuppressMessageAttribute(suppressMessage));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Add_Attribute()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1002") { Justification = "OK." };

        // Act
        var result = recordDeclaration.AddSuppressMessageAttribute(suppressMessage);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.AttributeLists);
        var attribute = result.AttributeLists[0].Attributes[0];
        Assert.Equal("SuppressMessage", attribute.Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_RecordDeclaration_Is_Null()
    {
        // Arrange
        RecordDeclarationSyntax recordDeclaration = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            recordDeclaration.AddGeneratedCodeAttribute("Tool", "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_ToolName_Is_Null()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            recordDeclaration.AddGeneratedCodeAttribute(null!, "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_Version_Is_Null()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            recordDeclaration.AddGeneratedCodeAttribute("Tool", null!));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Add_Attribute_With_ToolName_And_Version()
    {
        // Arrange
        var recordDeclaration = SyntaxFactory.RecordDeclaration(SyntaxFactory.Token(SyntaxKind.RecordKeyword), "TestRecord");
        const string toolName = "MyCodeGenerator";
        const string version = "1.2.3";

        // Act
        var result = recordDeclaration.AddGeneratedCodeAttribute(toolName, version);

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