namespace Atc.OpenApi.Tests.XUnitTestData;

public static class TestMemberDataForOpenApiResponsesExtensions
{
    public static TheoryData<List<HttpStatusCode>, OpenApiResponses> GetHttpStatusCodesItemData
        => new TheoryData<List<HttpStatusCode>, OpenApiResponses>
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
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new OpenApiMediaType
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
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new OpenApiMediaType
                            {
                                Schema = TestDataOpenApiFactory.CreateSchemaAddress(),
                            },
                        },
                    },
                    ["404"] = new OpenApiResponse
                    {
                        Description = "Not found",
                    },
                }
            },
        };

    public static TheoryData<bool, OpenApiResponses> HasSchemaTypeArrayItemData
        => new TheoryData<bool, OpenApiResponses>
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
        => new TheoryData<bool, OpenApiResponses>
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
        };

    public static TheoryData<bool, OpenApiResponses> HasSchemaHttpStatusCodeUsingAspNetCoreHttpItemData
        => new TheoryData<bool, OpenApiResponses>
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet()
            },
        };

    public static TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode> GetSchemaForStatusCodeItemData
        => new TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode>
        {
            {
                TestDataOpenApiFactory.CreateSchemaPet(),
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode, string> GetSchemaForStatusCodeContentTypeItemData
        => new TheoryData<OpenApiSchema, OpenApiResponses, HttpStatusCode, string>
        {
            {
                TestDataOpenApiFactory.CreateSchemaPet(),
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK,
                MediaTypeNames.Application.Json
            },
        };

    public static TheoryData<string, OpenApiResponses, HttpStatusCode> GetModelNameForStatusCodeItemData
        => new TheoryData<string, OpenApiResponses, HttpStatusCode>
        {
            {
                "Pet",
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<string, OpenApiResponses, HttpStatusCode> GetDataTypeForStatusCodeItemData
        => new TheoryData<string, OpenApiResponses, HttpStatusCode>
        {
            {
                "Pet",
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses, HttpStatusCode> IsSchemaTypeArrayForStatusCodeItemData
        => new TheoryData<bool, OpenApiResponses, HttpStatusCode>
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
        => new TheoryData<bool, OpenApiResponses, HttpStatusCode>
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses, HttpStatusCode> IsSchemaTypeProblemDetailsForStatusCodeItemData
        => new TheoryData<bool, OpenApiResponses, HttpStatusCode>
        {
            {
                false,
                TestDataOpenApiFactory.CreateResponsesOkPet(),
                HttpStatusCode.OK
            },
        };

    public static TheoryData<bool, OpenApiResponses> IsSchemaUsingBinaryFormatForOkResponseItemData
        => new TheoryData<bool, OpenApiResponses>
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