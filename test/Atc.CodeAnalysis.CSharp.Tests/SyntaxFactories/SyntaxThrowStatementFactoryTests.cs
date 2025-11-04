namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxThrowStatementFactoryTests
{
    [Fact]
    public void CreateNotImplementedException_Should_Create_NotImplementedException_With_System_Namespace()
    {
        // Act
        var result = SyntaxThrowStatementFactory.CreateNotImplementedException(includeSystem: true);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.Contains("System.NotImplementedException", code, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateNotImplementedException_Should_Create_NotImplementedException_Without_System_Namespace()
    {
        // Act
        var result = SyntaxThrowStatementFactory.CreateNotImplementedException(includeSystem: false);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.DoesNotContain("System.NotImplementedException", code, StringComparison.Ordinal);
        Assert.Contains("NotImplementedException", code, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateArgumentNullException_Should_Create_ArgumentNullException_With_System_Namespace()
    {
        // Arrange
        const string parameterName = "testParameter";

        // Act
        var result = SyntaxThrowStatementFactory.CreateArgumentNullException(parameterName, includeSystem: true);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.Contains("System.ArgumentNullException", code, StringComparison.Ordinal);
        Assert.Contains($"nameof({parameterName})", code, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateArgumentNullException_Should_Create_ArgumentNullException_Without_System_Namespace()
    {
        // Arrange
        const string parameterName = "testParameter";

        // Act
        var result = SyntaxThrowStatementFactory.CreateArgumentNullException(parameterName, includeSystem: false);

        // Assert
        Assert.NotNull(result);
        var code = result.ToString();
        Assert.DoesNotContain("System.ArgumentNullException", code, StringComparison.Ordinal);
        Assert.Contains("ArgumentNullException", code, StringComparison.Ordinal);
        Assert.Contains($"nameof({parameterName})", code, StringComparison.Ordinal);
    }
}