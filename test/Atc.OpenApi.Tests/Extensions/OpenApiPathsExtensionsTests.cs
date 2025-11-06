namespace Atc.OpenApi.Tests.Extensions;

public class OpenApiPathsExtensionsTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiPathsExtensions.GetPathsStartingWithSegmentName), MemberType = typeof(TestMemberDataForOpenApiPathsExtensions))]
    public void GetPathsStartingWithSegmentName(
        int expected,
        OpenApiPaths urlPath,
        string segmentName)
    {
        // Act
        var actual = urlPath.GetPathsStartingWithSegmentName(segmentName);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.Count);
    }
}