namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class InterfaceDeclarationSyntaxExtensionsTests
{
    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_InterfaceDeclaration_Is_Null()
    {
        // Arrange
        InterfaceDeclarationSyntax interfaceDeclaration = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            interfaceDeclaration.AddGeneratedCodeAttribute("Tool", "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_ToolName_Is_Null()
    {
        // Arrange
        var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration("ITestInterface");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            interfaceDeclaration.AddGeneratedCodeAttribute(null!, "1.0"));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Throw_When_Version_Is_Null()
    {
        // Arrange
        var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration("ITestInterface");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            interfaceDeclaration.AddGeneratedCodeAttribute("Tool", null!));
    }

    [Fact]
    public void AddGeneratedCodeAttribute_Should_Add_Attribute_With_ToolName_And_Version()
    {
        // Arrange
        var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration("ITestInterface");
        const string toolName = "MyCodeGenerator";
        const string version = "1.2.3";

        // Act
        var result = interfaceDeclaration.AddGeneratedCodeAttribute(toolName, version);

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