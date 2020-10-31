using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiFactory
    {
        public static OpenApiComponents CreateComponents()
        {
            return new OpenApiComponents
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
        }

        public static OpenApiOperation CreateOperationWithRequestBodyAddress()
        {
            return new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaAddress(),
                        },
                    },
                },
            };
        }

        public static OpenApiOperation CreateOperationWithRequestBodyCountry()
        {
            return new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaCountry(),
                        },
                    },
                },
            };
        }

        public static OpenApiOperation CreateOperationWithRequestBodyPet()
        {
            return new OpenApiOperation
            {
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPet(),
                        },
                    },
                },
            };
        }

        public static OpenApiOperation CreateOperationWithResponseOkAddress()
        {
            return new OpenApiOperation
            {
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = CreateSchemaAddress(),
                            },
                        },
                    },
                },
            };
        }

        public static OpenApiOperation CreateOperationWithResponseOkCountry()
        {
            return new OpenApiOperation
            {
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Ok",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = CreateSchemaCountry(),
                            },
                        },
                    },
                },
            };
        }

        public static OpenApiOperation CreateOperationWithResponseOkPet()
        {
            return new OpenApiOperation
            {
                Responses = CreateResponsesOkPet(),
            };
        }

        public static OpenApiOperation CreateOperationWithResponseOkPets()
        {
            return new OpenApiOperation
            {
                Responses = CreateResponsesOkPets(),
            };
        }

        public static OpenApiParameter CreateParameterTags()
        {
            return new OpenApiParameter
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
        }

        public static OpenApiParameter CreateParameterLimit()
        {
            return new OpenApiParameter
            {
                Name = "limit",
                In = ParameterLocation.Query,
                Description = "Maximum number of results to return",
                Required = false,
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
            };
        }

        public static OpenApiPaths CreatePaths()
        {
            return new OpenApiPaths
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
        }

        public static OpenApiPathItem CreatePathItemWithOperationResponseOkPet()
        {
            return new OpenApiPathItem
            {
                Summary = "Get a pet",
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            };
        }

        public static KeyValuePair<string, OpenApiPathItem> CreatePathItemWithOperationResponseOkPet(string path)
        {
            return new KeyValuePair<string, OpenApiPathItem>(
                        path,
                        new OpenApiPathItem
                        {
                            Summary = "Get a pet",
                            Operations = new Dictionary<OperationType, OpenApiOperation>
                            {
                                [OperationType.Get] = CreateOperationWithResponseOkPet(),
                            },
                        });
        }

        public static OpenApiPathItem CreatePathItemWithOperationResponseOkPetWithParameters(List<OpenApiParameter> parameters)
        {
            return new OpenApiPathItem
            {
                Summary = "Get a pet",
                Parameters = parameters,
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = CreateOperationWithResponseOkPet(),
                },
            };
        }

        public static OpenApiResponses CreateResponsesOkPet()
        {
            return new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPet(),
                        },
                    },
                },
            };
        }

        public static OpenApiResponses CreateResponsesOkPets()
        {
            return new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Ok",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = CreateSchemaPets(),
                        },
                    },
                },
            };
        }

        public static OpenApiSchema CreateSchemaAddress()
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "address",
                },
                Title = "Address",
                Properties = new Dictionary<string, OpenApiSchema>
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
                Required = new HashSet<string>
                {
                    "name",
                    "alpha2Code",
                    "alpha3Code",
                },
            };
        }

        public static OpenApiSchema CreateSchemaCountry()
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "country",
                },
                Title = "Country",
                Properties = new Dictionary<string, OpenApiSchema>
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
                Required = new HashSet<string>
                {
                    "name",
                    "alpha2Code",
                    "alpha3Code",
                },
            };
        }

        public static OpenApiSchema CreateSchemaPet()
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "pet",
                },
                Title = "MyPet",
                Properties = new Dictionary<string, OpenApiSchema>
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
                Required = new HashSet<string>
                {
                    "id",
                    "name",
                },
            };
        }

        public static OpenApiSchema CreateSchemaPets()
        {
            return new OpenApiSchema
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
        }

        public static OpenApiSchema CreateSchemaNewPet()
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "newPet",
                },
                Properties = new Dictionary<string, OpenApiSchema>
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
                Required = new HashSet<string>
                {
                    "name",
                },
            };
        }

        public static OpenApiSchema CreateSchemaColorType()
        {
            return new OpenApiSchema
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
        }

        public static OpenApiSchema CreateSchemaColorEnum()
        {
            return new OpenApiSchema
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
        }

        public static OpenApiSchema CreateSchemaErrorModel()
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.Schema,
                    Id = "errorModel",
                },
                Properties = new Dictionary<string, OpenApiSchema>
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
                Required = new HashSet<string>
                {
                    "code",
                    "message",
                },
            };
        }
    }
}