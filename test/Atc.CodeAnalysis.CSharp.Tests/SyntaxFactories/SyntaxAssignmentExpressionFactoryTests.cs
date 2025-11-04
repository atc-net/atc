namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAssignmentExpressionFactoryTests
{
    [Fact]
    public void CreateSimple_Should_Create_Assignment_Expression()
    {
        // Arrange
        const string toIdentifier = "result";
        const string fromIdentifier = "value";

        // Act
        var result = SyntaxAssignmentExpressionFactory.CreateSimple(toIdentifier, fromIdentifier);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.SimpleAssignmentExpression, result.Kind());
        Assert.Equal(toIdentifier, result.Left.ToString(), StringComparer.Ordinal);
        Assert.Equal(fromIdentifier, result.Right.ToString(), StringComparer.Ordinal);
    }
}