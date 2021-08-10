using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiMediaTypeExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiMediaTypeExtensions.GetSchemaItemData), MemberType = typeof(TestMemberDataForOpenApiMediaTypeExtensions))]
        public void GetSchema(string expectedType, IDictionary<string, OpenApiMediaType> content)
        {
            // Act
            var actual = content.GetSchema();

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Type);
            Assert.Equal(expectedType, actual.Type);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiMediaTypeExtensions.GetSchemaByFirstMediaTypeItemData), MemberType = typeof(TestMemberDataForOpenApiMediaTypeExtensions))]
        public void GetSchemaByFirstMediaType(string expectedType, IDictionary<string, OpenApiMediaType> content)
        {
            // Act
            var actual = content.GetSchemaByFirstMediaType();

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Type);
            Assert.Equal(expectedType, actual.Type);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiMediaTypeExtensions.GetSchemaContentTypeItemData), MemberType = typeof(TestMemberDataForOpenApiMediaTypeExtensions))]
        public void GetSchema_ContentType(string expectedType, string contentType, IDictionary<string, OpenApiMediaType> content)
        {
            // Act
            var actual = content.GetSchema(contentType);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Type);
            Assert.Equal(expectedType, actual.Type);
        }
    }
}