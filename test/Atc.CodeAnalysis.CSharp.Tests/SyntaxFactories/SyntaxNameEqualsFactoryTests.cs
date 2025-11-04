namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxNameEqualsFactoryTests
{
    [Fact]
    public void Create_Should_Create_NameEquals_Syntax()
    {
        // Arrange
        const string value = "TestName";

        // Act
        var result = SyntaxNameEqualsFactory.Create(value);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(value, result.Name.Identifier.Text, StringComparer.Ordinal);
    }
}