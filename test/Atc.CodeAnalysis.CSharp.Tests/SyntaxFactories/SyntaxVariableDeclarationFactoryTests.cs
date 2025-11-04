namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxVariableDeclarationFactoryTests
{
    [Fact]
    public void Create_Should_Create_Variable_Declaration()
    {
        // Arrange
        const string identifierTypeName = "string";
        const string identifierName = "testVariable";

        // Act
        var result = SyntaxVariableDeclarationFactory.Create(identifierTypeName, identifierName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(identifierTypeName, result.Type.ToString().Trim(), StringComparer.Ordinal);
        Assert.Single(result.Variables);
        Assert.Equal(identifierName, result.Variables[0].Identifier.Text, StringComparer.Ordinal);
    }
}