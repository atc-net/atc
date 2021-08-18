using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiFactory
    {
        public static OpenApiComponents CreateComponents()
            => new OpenApiComponents
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
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaAddress(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithRequestBodyCountry()
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaCountry(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithRequestBodyPet()
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPet(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithRequestBodyPetWithBinary()
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPetWithBinary(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithRequestBodyPetsWithBinaryArray()
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPetsWithBinaryArray(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithRequestBodyPetsAsObjectWithBinaryArray()
            => new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPetsAsObjectWithBinaryArray(),
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithResponseOkAddress()
            => new OpenApiOperation
            {
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new OpenApiMediaType
                            {
                                Schema = CreateSchemaAddress(),
                            },
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithResponseOkCountry()
            => new OpenApiOperation
            {
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                        {
                            [MediaTypeNames.Application.Json] = new OpenApiMediaType
                            {
                                Schema = CreateSchemaCountry(),
                            },
                        },
                    },
                },
            };

        public static OpenApiOperation CreateOperationWithResponseOkPet()
            => new OpenApiOperation
            {
                Responses = CreateResponsesOkPet(),
            };

        public static OpenApiOperation CreateOperationWithResponseOkPets()
            => new OpenApiOperation
            {
                Responses = CreateResponsesOkPets(),
            };

        public static OpenApiParameter CreateParameterTags()
            => new OpenApiParameter
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
            => new OpenApiParameter
            {
                Name = "limit",
                In = ParameterLocation.Query,
                Description = "Maximum number of results to return",
                Required = false,
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
            };

        public static OpenApiPaths CreatePaths()
            => new OpenApiPaths
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
            => new OpenApiPathItem
            {
                Summary = "Get a pet",
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            };

        public static KeyValuePair<string, OpenApiPathItem> CreatePathItemWithOperationResponseOkPet(string path)
            => new KeyValuePair<string, OpenApiPathItem>(
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
            => new OpenApiPathItem
            {
                Summary = "Get a pet",
                Parameters = parameters,
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            };

        public static OpenApiResponses CreateResponsesOkPet()
            => new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPet(),
                        },
                    },
                },
            };

        public static OpenApiResponses CreateResponsesOkWithBinary()
            => new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Octet] = new OpenApiMediaType
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
            => new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPets(),
                        },
                    },
                },
            };

        public static OpenApiSchema CreateSchemaAddress()
            => new OpenApiSchema
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
                    ["streetName"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["streetNumber"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["postalCode"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["cityName"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["country"] = new OpenApiSchema
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
            => new OpenApiSchema
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
                    ["name"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["alpha2Code"] = new OpenApiSchema
                    {
                        Type = "string",
                        MinLength = 2,
                        MaxLength = 2,
                    },
                    ["alpha3Code"] = new OpenApiSchema
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
            => new OpenApiSchema
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
                    ["id"] = new OpenApiSchema
                    {
                        Type = "integer",
                        Format = "int64",
                    },
                    ["name"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["tag"] = new OpenApiSchema
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
            => new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "newPet",
                },
                Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                {
                    ["id"] = new OpenApiSchema
                    {
                        Type = "integer",
                        Format = "int64",
                    },
                    ["name"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["tag"] = new OpenApiSchema
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
            => new OpenApiSchema
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
                    ["id"] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "uuid",
                    },
                    ["name"] = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    ["tag"] = new OpenApiSchema
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
            => new OpenApiSchema
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
                    ["id"] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "uuid",
                    },
                    ["name"] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary",
                    },
                    ["tag"] = new OpenApiSchema
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
            => new OpenApiSchema
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
            => new OpenApiSchema
            {
                Type = "array",
                Items = new OpenApiSchema
                {
                    Type = "string",
                    Format = "binary",
                },
            };

        public static OpenApiSchema CreateSchemaPetsAsObjectWithArray()
            => new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "animals",
                },
                Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                {
                    ["pets"] = new OpenApiSchema
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
            => new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "animals",
                },
                Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                {
                    ["petFiles"] = new OpenApiSchema
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
            => new OpenApiSchema
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
            => new OpenApiSchema
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
            => new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "errorModel",
                },
                Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                {
                    ["code"] = new OpenApiSchema
                    {
                        Type = "integer",
                        Format = "int32",
                    },
                    ["message"] = new OpenApiSchema
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
}