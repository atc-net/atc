namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestMemberDataForOpenApiResponsesExtensions
{
    public static TheoryData<List<HttpStatusCode>, OpenApiResponses> GetHttpStatusCodesItemData
        => new()
        {
            {
                new List<HttpStatusCode>(),
                new OpenApiResponses()
            },
            {
                new List<HttpStatusCode>
                {
                    HttpStatusCode.OK,
                },
                new OpenApiResponses
                {
                    ["200"] = new()
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new()
                            {
                                Schema = TestDataOpenApiFactory.CreateSchemaAddress(),
                            },
                        },
                    },
                }
            },
            {
                new List<HttpStatusCode>
                {
                    HttpStatusCode.OK,
                    HttpStatusCode.NotFound,
                },
                new OpenApiResponses
                {
                    ["200"] = new()
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new()
                            {
                                Schema = TestDataOpenApiFactory.CreateSchemaAddress(),
                            },
                        },
                    },
                    ["404"] = new()
                    {
                        Description = "Not found",
                    },
                }
            },
        };

    public static TheoryData<bool, OpenApiResponses> HasSchemaTypeArrayItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
            {
                true,
                TestDataOpenApiFactory.CreateResponsesOkPets()
            },
        };

    public static TheoryData<bool, OpenApiResponses> HasSchemaHttpStatusCodeUsingSystemNetItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
        };

    public static TheoryData<bool, OpenApiResponses> HasSchemaHttpStatusCodeUsingAspNetCoreHttpItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
        };

    public static TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode> GetSchemaForStatusCodeItemData
        => new()
        {
            {
                TestDataOpenApiFactory.CreateSchemaPet(),
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode, string> GetSchemaForStatusCodeContentTypeItemData
        => new()
        {
            {
                TestDataOpenApiFactory.CreateSchemaPet(),
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK,
                MediaTypeNames.Application.Json
            },
        };

    public static TheoryData<string, OpenApiResponses, HttpStatusCode> GetModelNameForStatusCodeItemData
        => new()
        {
            {
                "Pet",
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<string, OpenApiResponses, HttpStatusCode> GetDataTypeForStatusCodeItemData
        => new()
        {
            {
                "Pet",
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses, HttpStatusCode> IsSchemaTypeArrayForStatusCodeItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
            {
                true,
                TestDataOpenApiFactory.CreateResponsesOkPets(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses, HttpStatusCode> IsSchemaTypePaginationForStatusCodeItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses, HttpStatusCode> IsSchemaTypeProblemDetailsForStatusCodeItemData
        => new()
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses> IsSchemaUsingBinaryFormatForOkResponseItemData
        => new()
        {
            {
                true,
                TestDataOpenApiFactory.CreateResponsesOkWithBinary()
            },
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
        };
}