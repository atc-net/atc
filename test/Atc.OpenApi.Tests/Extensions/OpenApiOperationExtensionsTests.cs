using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using FluentAssertions;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiOperationExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.GetOperationNameItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
        public void GetOperationName(string expected, OpenApiOperation openApiOperation)
        {
            // Act
            var actual = openApiOperation.GetOperationName();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.GetModelSchemaItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
        public void GetModelSchema(OpenApiSchema expected, OpenApiOperation openApiOperation)
        {
            // Act
            var actual = openApiOperation.GetModelSchema();

            // Assert
            expected.Should()
                .NotBeNull()
                .And.BeEquivalentTo(actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.HasParametersOrRequestBodyItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
        public void HasParametersOrRequestBody(bool expected, OpenApiOperation openApiOperation)
        {
            // Act
            var actual = openApiOperation.HasParametersOrRequestBody();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.IsOperationReferencingSchemaItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
        public void IsOperationReferencingSchema(bool expected, OpenApiOperation openApiOperation, string schemaKey)
        {
            // Act
            var actual = openApiOperation.IsOperationReferencingSchema(schemaKey);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.HasDataTypeFromSystemCollectionGenericNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
        public void HasDataTypeFromSystemCollectionGenericNamespace(bool expected, List<OpenApiOperation> openApiOperations)
        {
            // Act
            var actual = openApiOperations.HasDataTypeFromSystemCollectionGenericNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}