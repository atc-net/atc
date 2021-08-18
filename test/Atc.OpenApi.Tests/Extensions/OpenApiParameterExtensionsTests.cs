using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiParameterExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeUuidItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeUuid(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeByteItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeByte(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeDateItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeDate(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeDateTime(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeTimeItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeTime(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeTimestamp(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeInt32(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeInt64(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeEmailItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeEmail(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiParameterExtensions.HasFormatTypeUriItemData), MemberType = typeof(TestMemberDataForOpenApiParameterExtensions))]
        public void HasFormatTypeUri(bool expected, IList<OpenApiParameter> openApiParameters)
        {
            // Act
            var actual = openApiParameters.HasFormatTypeUri();

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