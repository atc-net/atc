using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiParameterExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfUuidItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfUuid(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfByteItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfByte(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfDateItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfDate(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfDateTime(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfTimeItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfTime(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfTimestamp(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfInt32(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfInt64(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfEmailItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfEmail(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeOfUriItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeOfUri(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeOfUri();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeFromSystemNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeFromSystemNamespace(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeFromSystemNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeFromDataAnnotationsNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeFromDataAnnotationsNamespace(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeFromDataAnnotationsNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.GetAllFromRouteItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void GetAllFromRoute(int expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.GetAllFromRoute();

            // Assert
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.GetAllFromHeaderItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void GetAllFromHeader(int expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.GetAllFromHeader();

            // Assert
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.GetAllFromQueryItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void GetAllFromQuery(int expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.GetAllFromQuery();

            // Assert
            Assert.Equal(expected, actual.Count);
        }
    }
}