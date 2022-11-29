namespace Atc.OpenApi.Tests.XUnitTestData;

public static class TestMemberDataForOpenApiMediaTypeExtensions
{
    public static TheoryData<string, IDictionary<string, OpenApiMediaType>> GetSchemaItemData
        => new()
        {
            { OpenApiDataTypeConstants.Array, CreateContent(OpenApiDataTypeConstants.Array) },
        };

    public static TheoryData<string, IDictionary<string, OpenApiMediaType>> GetSchemaByFirstMediaTypeItemData
        => new()
        {
            { OpenApiDataTypeConstants.Array, CreateMultipleContents(OpenApiDataTypeConstants.Array, OpenApiDataTypeConstants.Object) },
        };

    public static TheoryData<string, string, IDictionary<string, OpenApiMediaType>> GetSchemaContentTypeItemData
        => new()
        {
            { OpenApiDataTypeConstants.Array, MediaTypeNames.Application.Json, CreateContent(OpenApiDataTypeConstants.Array) },
        };

    private static IDictionary<string, OpenApiMediaType> CreateContent(string typeName)
        => new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
        {
            {
                MediaTypeNames.Application.Json,
                new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = typeName,
                    },
                }
            },
        };

    private static IDictionary<string, OpenApiMediaType> CreateMultipleContents(string typeName1, string typeName2)
        => new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
        {
            {
                MediaTypeNames.Application.Json,
                new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = typeName1,
                    },
                }
            },
            {
                MediaTypeNames.Application.Octet,
                new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = typeName2,
                    },
                }
            },
        };
}