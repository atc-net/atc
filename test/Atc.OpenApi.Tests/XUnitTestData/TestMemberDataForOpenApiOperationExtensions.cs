// ReSharper disable StringLiteralTypo
namespace Atc.OpenApi.Tests.XUnitTestData;

public static class TestMemberDataForOpenApiOperationExtensions
{
    public static TheoryData<string, OpenApiOperation> GetOperationNameItemData
        => new TheoryData<string, OpenApiOperation>
        {
            {
                "GetOrderById",
                new OpenApiOperation
                {
                    OperationId = "GetOrderById",
                }
            },
            {
                "GetOrderById",
                new OpenApiOperation
                {
                    OperationId = "getOrderById",
                }
            },
            {
                "GetOrderById",
                new OpenApiOperation
                {
                    OperationId = "get-order-by-id",
                }
            },
            {
                "GetOrderById",
                new OpenApiOperation
                {
                    OperationId = "GET-ORDER-BY-ID",
                }
            },
        };

    public static TheoryData<OpenApiSchema?, OpenApiOperation> GetModelSchemaFromResponseItemData
        => new TheoryData<OpenApiSchema?, OpenApiOperation>
        {
            { TestDataOpenApiFactory.CreateSchemaPet(), TestDataOpenApiFactory.CreateOperationWithResponseOkPet() },
            { null, TestDataOpenApiFactory.CreateOperationWithRequestBodyPet() },
        };

    public static TheoryData<OpenApiSchema?, OpenApiOperation> GetModelSchemaFromRequestItemData
        => new TheoryData<OpenApiSchema?, OpenApiOperation>
        {
            { null, TestDataOpenApiFactory.CreateOperationWithResponseOkPet() },
            { TestDataOpenApiFactory.CreateSchemaPet(), TestDataOpenApiFactory.CreateOperationWithRequestBodyPet() },
        };

    public static TheoryData<bool, OpenApiOperation> HasParametersOrRequestBodyItemData
        => new TheoryData<bool, OpenApiOperation>
        {
            { false, TestDataOpenApiFactory.CreateOperationWithResponseOkPet() },
            {
                true,
                new OpenApiOperation
                {
                    Parameters = new List<OpenApiParameter>
                    {
                        TestDataOpenApiFactory.CreateParameterLimit(),
                    },
                }
            },
            { true, TestDataOpenApiFactory.CreateOperationWithRequestBodyPet() },
        };

    public static TheoryData<bool, OpenApiOperation> HasRequestBodyWithAnythingAsFormatTypeBinaryItemData
        => new TheoryData<bool, OpenApiOperation>
        {
            { false, TestDataOpenApiFactory.CreateOperationWithRequestBodyAddress() },
            { true, TestDataOpenApiFactory.CreateOperationWithRequestBodyPetWithBinary() },
            { true, TestDataOpenApiFactory.CreateOperationWithRequestBodyPetsWithBinaryArray() },
            { true, TestDataOpenApiFactory.CreateOperationWithRequestBodyPetsAsObjectWithBinaryArray() },
        };

    public static TheoryData<bool, OpenApiOperation, string> IsOperationReferencingSchemaItemData
        => new TheoryData<bool, OpenApiOperation, string>
        {
            {
                false,
                TestDataOpenApiFactory.CreateOperationWithRequestBodyPet(),
                "myKey"
            },
            {
                true,
                TestDataOpenApiFactory.CreateOperationWithRequestBodyCountry(),
                "country"
            },
            {
                true,
                TestDataOpenApiFactory.CreateOperationWithRequestBodyAddress(),
                "country"
            },
            {
                false,
                TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                "myKey"
            },
            {
                true,
                TestDataOpenApiFactory.CreateOperationWithResponseOkCountry(),
                "country"
            },
            {
                true,
                TestDataOpenApiFactory.CreateOperationWithResponseOkAddress(),
                "country"
            },
        };

    public static TheoryData<bool, OpenApiOperation, OperationType> IsOperationNamePluralizedItemData
        => new TheoryData<bool, OpenApiOperation, OperationType>
        {
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "getOrder",
                },
                OperationType.Get
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "getOrdersById",
                },
                OperationType.Get
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "getLookupListsByGroupId",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "getLookupListByGroupId",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "getLookupListByGroupById",
                },
                OperationType.Get
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "getLookupListsByGroupById",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "getByLookupListsByGroupById",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "Order",
                },
                OperationType.Get
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "Orders",
                },
                OperationType.Get
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "gettOrders",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "getOrderByMachineIds",
                },
                OperationType.Get
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "deleteOrder",
                },
                OperationType.Delete
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "deleteOrders",
                },
                OperationType.Delete
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "deleteOrderById",
                },
                OperationType.Delete
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "deleteOrdersById",
                },
                OperationType.Delete
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "Order",
                },
                OperationType.Delete
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "Orders",
                },
                OperationType.Delete
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "deletetOrders",
                },
                OperationType.Delete
            },
            {
                false,
                new OpenApiOperation
                {
                    OperationId = "deleteOrderByMachineIds",
                },
                OperationType.Delete
            },
            {
                true,
                new OpenApiOperation
                {
                    OperationId = "getSubscriptionsStatus",
                },
                OperationType.Get
            },
        };

    public static TheoryData<bool, List<OpenApiOperation>> HasDataTypeFromSystemCollectionGenericNamespaceItemData
        => new TheoryData<bool, List<OpenApiOperation>>
        {
            {
                false,
                new List<OpenApiOperation>
                {
                    TestDataOpenApiFactory.CreateOperationWithResponseOkPet(),
                }
            },
        };
}