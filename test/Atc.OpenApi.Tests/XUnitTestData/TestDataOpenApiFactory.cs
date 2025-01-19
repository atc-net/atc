namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestDataOpenApiFactory
{
    public static OpenApiComponents CreateComponents()
        => new()
        {
            Schemas =
            {
                ["Address"] = CreateSchemaAddress(),
                ["Country"] = CreateSchemaCountry(),
                ["Pet"] = CreateSchemaPet(),
                ["Pets"] = CreateSchemaPets(),
                ["NewPet"] = CreateSchemaNewPet(),
                ["ColorType"] = CreateSchemaColorType(),
                ["ErrorModel"] = CreateSchemaErrorModel(),
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyAddress()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaAddress(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyCountry()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaCountry(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyPet()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPet(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyPetWithBinary()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPetWithBinary(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyPetsWithBinaryArray()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPetsWithBinaryArray(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithRequestBodyPetsAsObjectWithBinaryArray()
        => new()
        {
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPetsAsObjectWithBinaryArray(),
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithResponseOkAddress()
        => new()
        {
            Responses = new OpenApiResponses
            {
                ["200"] = new()
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new()
                        {
                            Schema = CreateSchemaAddress(),
                        },
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithResponseOkCountry()
        => new()
        {
            Responses = new OpenApiResponses
            {
                ["200"] = new()
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new()
                        {
                            Schema = CreateSchemaCountry(),
                        },
                    },
                },
            },
        };

    public static OpenApiOperation CreateOperationWithResponseOkPet()
        => new()
        {
            Responses = CreateResponsesOkPet(),
        };

    public static OpenApiOperation CreateOperationWithResponseOkPets()
        => new()
        {
            Responses = CreateResponsesOkPets(),
        };

    public static OpenApiParameter CreateParameterTags()
        => new()
        {
            Name = "tags",
            In = ParameterLocation.Query,
            Description = "Tags to filter by",
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "array",
                Items = TestDataOpenApiSchemaOfTypeFactory.CreateString(),
            },
        };

    public static OpenApiParameter CreateParameterLimit()
        => new()
        {
            Name = "limit",
            In = ParameterLocation.Query,
            Description = "Maximum number of results to return",
            Required = false,
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
        };

    public static OpenApiPaths CreatePaths()
        => new()
        {
            ["/pets"] = new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPets(),
                },
            },
            ["/pets/{petId}"] = new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            },
        };

    public static OpenApiPathItem CreatePathItemWithOperationResponseOkPet()
        => new()
        {
            Summary = "Get a pet",
            Operations = new Dictionary<OperationType, OpenApiOperation>
            {
                [OperationType.Get] = CreateOperationWithResponseOkPet(),
            },
        };

    public static KeyValuePair<string, OpenApiPathItem> CreatePathItemWithOperationResponseOkPet(string path)
        => new(
            path,
            new OpenApiPathItem
            {
                Summary = "Get a pet",
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            });

    public static OpenApiPathItem CreatePathItemWithOperationResponseOkPetWithParameters(List<OpenApiParameter> parameters)
        => new()
        {
            Summary = "Get a pet",
            Parameters = parameters,
            Operations = new Dictionary<OperationType, OpenApiOperation>
            {
                [OperationType.Get] = CreateOperationWithResponseOkPet(),
            },
        };

    public static OpenApiResponses CreateResponsesOkPet()
        => new()
        {
            ["200"] = new OpenApiResponse
            {
                Description = "Ok",
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPet(),
                    },
                },
            },
        };

    public static OpenApiResponses CreateResponsesOkWithBinary()
        => new()
        {
            ["200"] = new OpenApiResponse
            {
                Description = "Ok",
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Octet] = new()
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = OpenApiDataTypeConstants.String,
                            Format = OpenApiFormatTypeConstants.Binary,
                        },
                    },
                },
            },
        };

    public static OpenApiResponses CreateResponsesOkPets()
        => new()
        {
            ["200"] = new OpenApiResponse
            {
                Description = "Ok",
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = CreateSchemaPets(),
                    },
                },
            },
        };

    public static OpenApiSchema CreateSchemaAddress()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "address",
            },
            Title = "Address",
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["streetName"] = new()
                {
                    Type = "string",
                },
                ["streetNumber"] = new()
                {
                    Type = "string",
                },
                ["postalCode"] = new()
                {
                    Type = "string",
                },
                ["cityName"] = new()
                {
                    Type = "string",
                },
                ["country"] = new()
                {
                    Type = "string",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.Schema,
                        Id = "country",
                    },
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "name",
                "alpha2Code",
                "alpha3Code",
            },
        };

    public static OpenApiSchema CreateSchemaCountry()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "country",
            },
            Title = "Country",
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["name"] = new()
                {
                    Type = "string",
                },
                ["alpha2Code"] = new()
                {
                    Type = "string",
                    MinLength = 2,
                    MaxLength = 2,
                },
                ["alpha3Code"] = new()
                {
                    Type = "string",
                    MinLength = 3,
                    MaxLength = 3,
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "name",
                "alpha2Code",
                "alpha3Code",
            },
        };

    public static OpenApiSchema CreateSchemaPet()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "pet",
            },
            Title = "MyPet",
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["id"] = new()
                {
                    Type = "integer",
                    Format = "int64",
                },
                ["name"] = new()
                {
                    Type = "string",
                },
                ["tag"] = new()
                {
                    Type = "string",
                    Title = "MyTag",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "id",
                "name",
            },
        };

    public static OpenApiSchema CreateSchemaNewPet()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "newPet",
            },
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["id"] = new()
                {
                    Type = "integer",
                    Format = "int64",
                },
                ["name"] = new()
                {
                    Type = "string",
                },
                ["tag"] = new()
                {
                    Type = "string",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "name",
            },
        };

    public static OpenApiSchema CreateSchemaPetWithGuid()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "petWithGuid",
            },
            Title = "MyPet",
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["id"] = new()
                {
                    Type = "string",
                    Format = "uuid",
                },
                ["name"] = new()
                {
                    Type = "string",
                },
                ["tag"] = new()
                {
                    Type = "string",
                    Title = "MyTag",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "id",
                "name",
            },
        };

    public static OpenApiSchema CreateSchemaPetWithBinary()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "petWithBinary",
            },
            Title = "MyPet",
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["id"] = new()
                {
                    Type = "string",
                    Format = "uuid",
                },
                ["name"] = new()
                {
                    Type = "string",
                    Format = "binary",
                },
                ["tag"] = new()
                {
                    Type = "string",
                    Title = "MyTag",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "id",
                "name",
            },
        };

    public static OpenApiSchema CreateSchemaPets()
        => new()
        {
            Type = "array",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "pets",
            },
            Items = new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "pet",
                },
            },
        };

    public static OpenApiSchema CreateSchemaPetsWithBinaryArray()
        => new()
        {
            Type = "array",
            Items = new OpenApiSchema
            {
                Type = "string",
                Format = "binary",
            },
        };

    public static OpenApiSchema CreateSchemaPetsAsObjectWithArray()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "animals",
            },
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["pets"] = new()
                {
                    Type = "array",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.Schema,
                        Id = "pet",
                    },
                },
            },
        };

    public static OpenApiSchema CreateSchemaPetsAsObjectWithBinaryArray()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "animals",
            },
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["petFiles"] = new()
                {
                    Type = "array",
                    Items = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary",
                    },
                },
            },
        };

    public static OpenApiSchema CreateSchemaColorType()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "colorType",
            },
            Title = "Color type",
            Properties =
            {
                ["color"] = CreateSchemaColorEnum(),
            },
        };

    public static OpenApiSchema CreateSchemaColorEnum()
        => new()
        {
            Type = "string",
            Description = "The color type",
            Enum =
            {
                new OpenApiString("unknown = 0"),
                new OpenApiString("black = 1"),
                new OpenApiString("white = 2"),
                new OpenApiString("yellow = 4"),
                new OpenApiString("red = 8"),
            },
        };

    public static OpenApiSchema CreateSchemaErrorModel()
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = "errorModel",
            },
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["code"] = new()
                {
                    Type = "integer",
                    Format = "int32",
                },
                ["message"] = new()
                {
                    Type = "string",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "code",
                "message",
            },
        };

    public static OpenApiSchema CreateSchemaPagination()
        => new()
        {
            Type = "object",
            Title = NameConstants.Pagination,
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["pageSize"] = new()
                {
                    Type = "number",
                    Description = "The number of items to request.",
                },
                ["pageIndex"] = new()
                {
                    Type = "number",
                    Nullable = true,
                    Description = "The given page index starting with 0.",
                },
                ["queryString"] = new()
                {
                    Type = "string",
                    Nullable = true,
                    Description = "The query to filter items by.",
                },
                ["continuationToken"] = new()
                {
                    Type = "string",
                    Nullable = true,
                    Description = "Token to indicate next result set.",
                },
                ["count"] = new()
                {
                    Type = "number",
                    Description = "Items count in result set.",
                },
                ["totalCount"] = new()
                {
                    Type = "number",
                    Nullable = true,
                    Description = "Total items count.",
                },
                ["totalPages"] = new()
                {
                    Type = "number",
                    Nullable = true,
                    Description = "Total pages.",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "pageSize",
                "count",
            },
        };

    public static OpenApiSchema CreateSchemaWithModelName(string name)
        => new()
        {
            Type = "object",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.Schema,
                Id = name,
            },
            Title = "My" + name,
            Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
            {
                ["id"] = new()
                {
                    Type = "integer",
                    Format = "int64",
                },
                ["name"] = new()
                {
                    Type = "string",
                },
                ["tag"] = new()
                {
                    Type = "string",
                    Title = "MyTag",
                },
            },
            Required = new HashSet<string>(StringComparer.Ordinal)
            {
                "id",
                "name",
            },
        };

    public static IDictionary<string, OpenApiSchema> CreateComponentSchemasWithOnePet()
        => new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
        {
            ["Pet"] = CreateSchemaPet(),
        };

    public static IDictionary<string, OpenApiSchema> CreateComponentSchemasWithDifferentPets()
        => new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
        {
            ["Pet"] = CreateSchemaPet(),
            ["PetWithGuid"] = CreateSchemaPetWithGuid(),
        };
}