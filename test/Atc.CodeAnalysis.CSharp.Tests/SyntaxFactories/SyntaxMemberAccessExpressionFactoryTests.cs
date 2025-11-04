namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxMemberAccessExpressionFactoryTests
{
    [Fact]
    public void Create_Should_Create_Member_Access_Expression()
    {
        // Arrange
        const string memberTypeName = "TypeName";
        const string memberName = "MemberName";

        // Act
        var result = SyntaxMemberAccessExpressionFactory.Create(memberTypeName, memberName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.SimpleMemberAccessExpression, result.Kind());
        Assert.Equal(memberName, result.Expression.ToString(), StringComparer.Ordinal);
        Assert.Equal(memberTypeName, result.Name.ToString(), StringComparer.Ordinal);
    }
}