using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests
{
    public class OpenApiDocumentExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiDocumentExtensions.OpenApiPathItemData), MemberType = typeof(TestMemberDataForOpenApiDocumentExtensions))]
        public void GetPathsByBasePathSegmentName(string basePathSegmentName, int expectedCount, OpenApiDocument openApiDocument)
        {
            // Act
            var pathsByBasePathSegmentName = openApiDocument.GetPathsByBasePathSegmentName(basePathSegmentName);

            // Assert
            Assert.Equal(expectedCount, pathsByBasePathSegmentName.Count);
        }
    }
}