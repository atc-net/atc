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

    [Fact]
    public void IsFormatJsonAndProblemDetailsModel_RejectsStringContent_ThatLooksLikeProblemDetails()
    {
        // Arrange — plain object whose VALUE contains the substrings "Status"/"Title"/"Detail",
        // but the property names are completely different. The old substring check would
        // false-positive on this; the JsonDocument-based check should correctly reject it.
        var json = """{"description":"Status of the operation. Title and Detail are not available."}""";

        // Act
        var result = ProblemDetailsHelper.IsFormatJsonAndProblemDetailsModel(json);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFormatJsonAndProblemDetailsModel_AcceptsCamelCaseProblemDetails()
    {
        // Arrange — RFC 7807 in camelCase (the System.Text.Json default) should be accepted.
        var json = """{"status":404,"title":"Not Found","detail":"Resource was not found"}""";

        // Act
        var result = ProblemDetailsHelper.IsFormatJsonAndProblemDetailsModel(json);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFormatJsonAndProblemDetailsModel_RejectsJsonArray()
    {
        // Arrange — the root must be an object, not an array.
        var json = """[{"Status":400,"Title":"x","Detail":"y"}]""";

        // Act
        var result = ProblemDetailsHelper.IsFormatJsonAndProblemDetailsModel(json);

        // Assert
        Assert.False(result);
    }
}