namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxInterfaceDeclarationFactoryTests
{
    [Fact]
    public void Create_Should_Throw_When_InterfaceTypeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxInterfaceDeclarationFactory.Create(null!));
    }

    [Fact]
    public void Create_Should_Create_Public_Interface()
    {
        // Arrange
        const string interfaceTypeName = "ITestInterface";

        // Act
        var result = SyntaxInterfaceDeclarationFactory.Create(interfaceTypeName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(interfaceTypeName, result.Identifier.Text, StringComparer.Ordinal);
        Assert.Contains(result.Modifiers, m => m.IsKind(SyntaxKind.PublicKeyword));
    }
}