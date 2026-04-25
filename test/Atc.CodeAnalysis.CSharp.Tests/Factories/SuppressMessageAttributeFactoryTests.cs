namespace Atc.CodeAnalysis.CSharp.Tests.Factories;

public class SuppressMessageAttributeFactoryTests
{
    [Theory]
    [InlineData(1062, "Design", "CA1062:Validate arguments of public methods")]
    [InlineData(1720, "Naming", "CA1720:Identifiers should not contain type names")]
    [InlineData(1031, "Design", "CA1031:Do not catch general exception types")]
    [InlineData(1822, "Performance", "CA1822:Mark members as static")]
    [InlineData(2000, "Reliability", "CA2000:Dispose objects before losing scope")]
    [InlineData(1305, "Globalization", "CA1305:Specify IFormatProvider")]
    [InlineData(2227, "Usage", "CA2227:Collection properties should be read only")]
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
    public void CreateCodeAnalysisSuppression_Should_Fallback_For_Unknown_Rule()
    {
        // Arrange
        const int unknownCheckId = 9999;

        // Act
        var result = SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(unknownCheckId, "Test");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Microsoft.Design", result.Category, StringComparer.Ordinal);
        Assert.Equal("CA9999", result.CheckId, StringComparer.Ordinal);
        Assert.Equal("Test", result.Justification, StringComparer.Ordinal);
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
    public void CreateStyleCopSuppression_Should_Fallback_For_Unknown_Rule()
    {
        // Arrange
        const int unknownCheckId = 9999;

        // Act
        var result = SuppressMessageAttributeFactory.CreateStyleCopSuppression(unknownCheckId, "Test");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("StyleCop.CSharp.MaintainabilityRules", result.Category, StringComparer.Ordinal);
        Assert.Equal("SA9999", result.CheckId, StringComparer.Ordinal);
        Assert.Equal("Test", result.Justification, StringComparer.Ordinal);
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