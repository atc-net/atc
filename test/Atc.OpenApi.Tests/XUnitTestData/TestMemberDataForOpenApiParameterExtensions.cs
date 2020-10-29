using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiParameterExtensions
    {
        public static IEnumerable<object[]> HasFormatTypeOfUuidItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfByteItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfDateItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfDateTimeItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfTimeItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfTimestampItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfInt32ItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfInt64ItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfEmailItemData =>
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

        public static IEnumerable<object[]> HasFormatTypeOfUriItemData =>
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
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDate(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeFromDataAnnotationsNamespaceItemData =>
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
                        TestDataOpenApiParameterOfTypeFactory.CreateStringDate(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiParameter>
                    {
                        TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    },
                },
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