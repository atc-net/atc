namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxIfStatementFactoryTests
{
    [Fact]
    public void CreateParameterArgumentNullCheck_Should_Create_Null_Check_Statement()
    {
        // Arrange
        const string parameterName = "testParameter";

        // Act
        var result = SyntaxIfStatementFactory.CreateParameterArgumentNullCheck(parameterName);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<IfStatementSyntax>(result);
        var ifStatement = (IfStatementSyntax)result;
        Assert.NotNull(ifStatement.Condition);
        Assert.NotNull(ifStatement.Statement);
    }

    [Fact]
    public void CreateParameterArgumentNullCheck_Should_Create_Null_Check_Statement_With_System_Namespace()
    {
        // Arrange
        const string parameterName = "testParameter";

        // Act
        var result = SyntaxIfStatementFactory.CreateParameterArgumentNullCheck(parameterName, includeSystem: true);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.Contains("System.ArgumentNullException", code, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateParameterArgumentNullCheck_Should_Create_Null_Check_Statement_Without_System_Namespace()
    {
        // Arrange
        const string parameterName = "testParameter";

        // Act
        var result = SyntaxIfStatementFactory.CreateParameterArgumentNullCheck(parameterName, includeSystem: false);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.DoesNotContain("System.ArgumentNullException", code, StringComparison.Ordinal);
        Assert.Contains("ArgumentNullException", code, StringComparison.Ordinal);
    }
}