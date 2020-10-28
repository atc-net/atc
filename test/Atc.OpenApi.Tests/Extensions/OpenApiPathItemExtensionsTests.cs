using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiPathItemExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiPathItemExtensions.IsPathStartingSegmentNameItemData), MemberType = typeof(TestMemberDataForOpenApiPathItemExtensions))]
        public void IsPathStartingSegmentName(bool expected, KeyValuePair<string, OpenApiPathItem> urlPath, string segmentName)
        {
            // Act
            var actual = urlPath.IsPathStartingSegmentName(segmentName);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiPathItemExtensions.HasParametersItemData), MemberType = typeof(TestMemberDataForOpenApiPathItemExtensions))]
        public void HasParameters(bool expected, OpenApiPathItem openApiPathItem)
        {
            // Act
            var actual = openApiPathItem.HasParameters();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}