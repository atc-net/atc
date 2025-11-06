namespace Atc.OpenApi.Tests.Extensions;

public class OpenApiDocumentExtensionsTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiDocumentExtensions.OpenApiPathItemData), MemberType = typeof(TestMemberDataForOpenApiDocumentExtensions))]
    public void GetPathsByBasePathSegmentName(
        int expectedCount,
        string basePathSegmentName,
        OpenApiDocument openApiDocument)
    {
        // Act
        var actual = openApiDocument.GetPathsByBasePathSegmentName(basePathSegmentName);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expectedCount, actual.Count);
    }
}