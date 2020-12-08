using System.Collections.Generic;
using Microsoft.OpenApi.Models;

// ReSharper disable StringLiteralTypo
namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiOperationExtensions
    {
        public static IEnumerable<object[]> GetOperationNameItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "GetOrderById",
                    new OpenApiOperation
                    {
                        OperationId = "GetOrderById",
                    },
                },
                new object[]
                {
                    "GetOrderById",
                    new OpenApiOperation
                    {
                        OperationId = "getOrderById",
                    },
                },
                new object[]
                {
                    "GetOrderById",
                    new OpenApiOperation
                    {
                        OperationId = "get-order-by-id",
                    },
                },
                new object[]
                {
                    "GetOrderById",
                    new OpenApiOperation
                    {
                        OperationId = "GET-ORDER-BY-ID",
                    },
                },
            };

        public static IEnumerable<object[]> GetModelSchemaFromResponseItemData =>
            new List<object[]>
            {
                new object[]
                {
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                },
                new object[]
                {
                    null,
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyPet(),
                },
            };

        public static IEnumerable<object[]> GetModelSchemaFromRequestItemData =>
            new List<object[]>
            {
                new object[]
                {
                    null,
                    TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                },
                new object[]
                {
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyPet(),
                },
            };

        public static IEnumerable<object[]> HasParametersOrRequestBodyItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        Parameters = new List<OpenApiParameter>
                        {
                            TestDataOpenApiFactory.CreateParameterLimit(),
                        },
                    },
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyPet(),
                },
            };

        public static IEnumerable<object[]> IsOperationReferencingSchemaItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyPet(),
                    "myKey",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyCountry(),
                    "country",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateOperationWithRequestBodyAddress(),
                    "country",
                },
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                    "myKey",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateOperationWithResponseOkCountry(),
                    "country",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateOperationWithResponseOkAddress(),
                    "country",
                },
            };

        public static IEnumerable<object[]> IsOperationNamePluralizedItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "getOrder",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "getOrders",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "getOrderById",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "getOrdersById",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "Order",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "Orders",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "gettOrders",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "getOrderByMachineIds",
                    },
                    OperationType.Get,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "deleteOrder",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "deleteOrders",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "deleteOrderById",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "deleteOrdersById",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "Order",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "Orders",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    true,
                    new OpenApiOperation
                    {
                        OperationId = "deletetOrders",
                    },
                    OperationType.Delete,
                },
                new object[]
                {
                    false,
                    new OpenApiOperation
                    {
                        OperationId = "deleteOrderByMachineIds",
                    },
                    OperationType.Delete,
                },
            };

        public static IEnumerable<object[]> HasDataTypeFromSystemCollectionGenericNamespaceItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiOperation>
                    {
                        TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                    },
                },
            };
    }
}