using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiParameterExtensions
    {
        public static IEnumerable<object[]> HasFormatTypeUuidItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringUuid(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeByteItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringByte(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeDateItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDate(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeDateTimeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeTimeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringTime(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeTimestampItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeInt32ItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateInt32(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeInt64ItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateInt64(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeEmailItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeUriItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiParameter>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiParameterOfTypeFactory.CreateStringUri(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeFromSystemNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiParameter>() },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateString() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUuid() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDate() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTime() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUri() } },
            };

        public static IEnumerable<object[]> HasFormatTypeFromDataAnnotationsNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiParameter>() },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateString() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUuid() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDate() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTime() } },
                new object[] { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp() } },
                new object[] { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUri() } },
            };

        public static IEnumerable<object[]> GetAllFromRouteItemData =>
            new List<object[]>
            {
                new object[]
                {
                    0,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    },
                },
                new object[]
                {
                    1,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    },
                },
                new object[]
                {
                    2,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteString("Hallo"),
                    },
                },
            };

        public static IEnumerable<object[]> GetAllFromHeaderItemData =>
            new List<object[]>
            {
                new object[]
                {
                    0,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    },
                },
                new object[]
                {
                    1,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    },
                },
                new object[]
                {
                    2,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderString("Hallo"),
                    },
                },
            };

        public static IEnumerable<object[]> GetAllFromQueryItemData =>
            new List<object[]>
            {
                new object[]
                {
                    0,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    },
                },
                new object[]
                {
                    1,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    },
                },
                new object[]
                {
                    2,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                        TestDataOpenApiParameterOfTypeFactory.CreateQueryString("Hallo"),
                    },
                },
            };
    }
}