using System.Collections.Generic;
using System.Net;
using Atc.OpenApi.Tests.XUnitTestData;
using FluentAssertions;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiResponsesExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetHttpStatusCodesItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void GetHttpStatusCodes(List<HttpStatusCode> expected, OpenApiResponses openApiResponses)
        {
            // Act
            var actual = openApiResponses.GetHttpStatusCodes();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaTypeOfArrayItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void HasSchemaTypeOfArray(bool expected, OpenApiResponses openApiResponses)
        {
            // Act
            var actual = openApiResponses.HasSchemaTypeOfArray();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaTypeOfHttpStatusCodeUsingSystemNetItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void HasSchemaTypeOfHttpStatusCodeUsingSystemNet(bool expected, OpenApiResponses openApiResponses)
        {
            // Act
            var actual = openApiResponses.HasSchemaTypeOfHttpStatusCodeUsingSystemNet();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttpItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp(bool expected, OpenApiResponses openApiResponses)
        {
            // Act
            var actual = openApiResponses.HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetSchemaForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void GetSchemaForStatusCode(OpenApiSchema expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.GetSchemaForStatusCode(httpStatusCode);

            // Assert
            actual.Should().NotBeNull();
            actual!.Properties.Should().BeEquivalentTo(expected.Properties);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetSchemaForStatusCodeContentTypeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void GetSchemaForStatusCode_ContentType(OpenApiSchema expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode, string contentType)
        {
            // Act
            var actual = openApiResponses.GetSchemaForStatusCode(httpStatusCode, contentType);

            // Assert
            actual.Should().NotBeNull();
            actual!.Properties.Should().BeEquivalentTo(expected.Properties);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetModelNameForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void GetModelNameForStatusCode(string expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.GetModelNameForStatusCode(httpStatusCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetDataTypeForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void GetDataTypeForStatusCode(string expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.GetDataTypeForStatusCode(httpStatusCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypeArrayForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void IsSchemaTypeArrayForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.IsSchemaTypeArrayForStatusCode(httpStatusCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypePaginationForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void IsSchemaTypePaginationForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.IsSchemaTypePaginationForStatusCode(httpStatusCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypeProblemDetailsForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void IsSchemaTypeProblemDetailsForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
        {
            // Act
            var actual = openApiResponses.IsSchemaTypeProblemDetailsForStatusCode(httpStatusCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaUsingBinaryFormatForOkResponseItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
        public void IsSchemaUsingBinaryFormatForOkResponse(bool expected, OpenApiResponses openApiResponses)
        {
            // Act
            var actual = openApiResponses.IsSchemaUsingBinaryFormatForOkResponse();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}