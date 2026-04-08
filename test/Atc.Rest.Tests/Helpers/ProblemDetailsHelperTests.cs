namespace Atc.Rest.Tests.Helpers;

public class ProblemDetailsHelperTests
{
    [Fact]
    public void TrySerializeToProblemDetails_ValidJson_ReturnsTrue()
    {
        // Arrange
        var json = """{"Status":400,"Title":"Bad Request","Detail":"Validation failed"}""";

        // Act
        var result = ProblemDetailsHelper.TrySerializeToProblemDetails(json, out var problemDetails);

        // Assert
        Assert.True(result);
        Assert.NotNull(problemDetails);
    }

    [Fact]
    public void TrySerializeToProblemDetails_MalformedJson_ReturnsFalse()
    {
        // Arrange
        var json = """{"Status":400,"Title":"Bad Request","Detail":INVALID}""";

        // Act
        var result = ProblemDetailsHelper.TrySerializeToProblemDetails(json, out var problemDetails);

        // Assert
        Assert.False(result);
        Assert.Null(problemDetails);
    }

    [Fact]
    public void TrySerializeToProblemDetails_NonProblemDetailsJson_ReturnsFalse()
    {
        // Arrange
        var json = """{"Name":"Test","Value":42}""";

        // Act
        var result = ProblemDetailsHelper.TrySerializeToProblemDetails(json, out var problemDetails);

        // Assert
        Assert.False(result);
        Assert.Null(problemDetails);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("not json at all")]
    public void TrySerializeToProblemDetails_InvalidInput_ReturnsFalse(
        string? json)
    {
        // Act
        var result = ProblemDetailsHelper.TrySerializeToProblemDetails(json!, out var problemDetails);

        // Assert
        Assert.False(result);
        Assert.Null(problemDetails);
    }
}