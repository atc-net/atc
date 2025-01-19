namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestMemberDataForOpenApiParameterExtensions
{
    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeUuidItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringUuid(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeByteItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringByte(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeDateItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringDate(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeDateTimeItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeTimeItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringTime(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeTimestampItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeInt32ItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateInt32(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeInt64ItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateInt64(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeEmailItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeUriItemData
        => new()
        {
            {
                false,
                new List<OpenApiParameter>()
            },
            {
                false,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat(),
                }
            },
            {
                true,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateStringEmail(),
                    TestDataOpenApiParameterOfTypeFactory.CreateStringUri(),
                }
            },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeFromSystemNamespaceItemData
        => new()
        {
            { false, new List<OpenApiParameter>() },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateString() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringEmail() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringByte() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt32() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt64() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUuid() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDate() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTime() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUri() } },
        };

    public static TheoryData<bool, List<OpenApiParameter>> HasFormatTypeFromDataAnnotationsNamespaceItemData
        => new()
        {
            { false, new List<OpenApiParameter>() },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateString() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringEmail() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringByte() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt32() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateInt64() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateNumberFloat() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUuid() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDate() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringDateTime() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTime() } },
            { false, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringTimestamp() } },
            { true, new List<OpenApiParameter> { TestDataOpenApiParameterOfTypeFactory.CreateStringUri() } },
        };

    public static TheoryData<int, List<OpenApiParameter>> GetAllFromRouteItemData
        => new()
        {
            {
                0,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                }
            },
            {
                1,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                }
            },
            {
                2,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteString("Hallo"),
                }
            },
        };

    public static TheoryData<int, List<OpenApiParameter>> GetAllFromHeaderItemData
        => new()
        {
            {
                0,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                }
            },
            {
                1,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                }
            },
            {
                2,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderString("Hallo"),
                }
            },
        };

    public static TheoryData<int, List<OpenApiParameter>> GetAllFromQueryItemData
        => new()
        {
            {
                0,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                }
            },
            {
                1,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                }
            },
            {
                2,
                new List<OpenApiParameter>
                {
                    TestDataOpenApiParameterOfTypeFactory.CreateRouteIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateHeaderIntId(),
                    TestDataOpenApiParameterOfTypeFactory.CreateQueryString("Hallo"),
                }
            },
        };
}