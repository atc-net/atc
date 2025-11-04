namespace Atc.CodeAnalysis.CSharp.Tests.Factories;

public class SuppressMessageAttributeFactoryTests
{
    [Theory]
    [InlineData(1062, "Design", "CA1062:Validate arguments of public methods")]
    [InlineData(1720, "Naming", "CA1720:Identifiers should not contain type names")]
    public void CreateCodeAnalysisSuppression_Should_Create_Valid_Suppression_For_Known_Rules(
        int checkId,
        string expectedCategory,
        string expectedCheckId)
    {
        // Arrange
        const string justification = "Custom justification";

        // Act
        var result = SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCategory, result.Category, StringComparer.Ordinal);
        Assert.Equal(expectedCheckId, result.CheckId, StringComparer.Ordinal);
        Assert.Equal(justification, result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateCodeAnalysisSuppression_Should_Use_Default_Justification_When_Null()
    {
        // Arrange
        const int checkId = 1062;

        // Act
        var result = SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("OK.", result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateCodeAnalysisSuppression_Should_Use_Default_Justification_When_Empty()
    {
        // Arrange
        const int checkId = 1062;

        // Act
        var result = SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, string.Empty);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("OK.", result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateCodeAnalysisSuppression_Should_Throw_For_Unknown_Rule()
    {
        // Arrange
        const int unknownCheckId = 9999;

        // Act & Assert
        var exception = Assert.Throws<NotImplementedException>(() =>
            SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(unknownCheckId, "Test"));
        Assert.Contains("CA9999", exception.Message, StringComparison.Ordinal);
        Assert.Contains("must be implemented", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateStyleCopSuppression_Should_Create_Valid_Suppression_For_Known_Rule()
    {
        // Arrange
        const int checkId = 1413;
        const string justification = "Custom justification";
        const string expectedCategory = "Maintainability Rules";
        const string expectedCheckId = "SA1413:Use trailing comma in multi-line initializers";

        // Act
        var result = SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCategory, result.Category, StringComparer.Ordinal);
        Assert.Equal(expectedCheckId, result.CheckId, StringComparer.Ordinal);
        Assert.Equal(justification, result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateStyleCopSuppression_Should_Use_Default_Justification_When_Null()
    {
        // Arrange
        const int checkId = 1413;

        // Act
        var result = SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("OK.", result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateStyleCopSuppression_Should_Use_Default_Justification_When_Empty()
    {
        // Arrange
        const int checkId = 1413;

        // Act
        var result = SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, string.Empty);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("OK.", result.Justification, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateStyleCopSuppression_Should_Throw_For_Unknown_Rule()
    {
        // Arrange
        const int unknownCheckId = 9999;

        // Act & Assert
        var exception = Assert.Throws<NotImplementedException>(() =>
            SuppressMessageAttributeFactory.CreateStyleCopSuppression(unknownCheckId, "Test"));
        Assert.Contains("SA9999", exception.Message, StringComparison.Ordinal);
        Assert.Contains("must be implemented", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateStyleCopSuppression_With_CheckId_And_Justification_Should_Create_Suppression()
    {
        // Arrange
        const int checkId = 1413;
        const string justification = "Test justification";

        // Act
        var result = SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Maintainability Rules", result.Category, StringComparer.Ordinal);
        Assert.Equal(justification, result.Justification, StringComparer.Ordinal);
    }
}