using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiFactory
    {
        private static readonly List<OpenApiParameter> Parameters = new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "tags",
                In = ParameterLocation.Query,
                Description = "Tags to filter by",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "array",
                    Items = new OpenApiSchema
                    {
                        Type = "string",
                    },
                },
            },
            new OpenApiParameter
            {
                Name = "limit",
                In = ParameterLocation.Query,
                Description = "Maximum number of results to return",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int32",
                },
            },
        };

        private static readonly OpenApiComponents Components = new OpenApiComponents
        {
            Schemas = new Dictionary<string, OpenApiSchema>
            {
                ["pet"] = new OpenApiSchema
                {
                    Type = "object",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.Schema,
                        Id = "pet",
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
                        "id",
                        "name",
                    },
                },
                ["newPet"] = new OpenApiSchema
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
                },
                ["address"] = new OpenApiSchema
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
                },
                ["country"] = new OpenApiSchema
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
                },
                ["errorModel"] = new OpenApiSchema
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
                },
            },
        };

        public static OpenApiOperation CreateOperationWithRequestBodyAddress()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                    }));
        }

        public static OpenApiOperation CreateOperationWithRequestBodyCountry()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                    }));
        }

        public static OpenApiOperation CreateOperationWithRequestBodyPet()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                    }));
        }

        public static OpenApiOperation CreateOperationWithResponseOkAddress()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                    }));
        }

        public static OpenApiOperation CreateOperationWithResponseOkCountry()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                    }));
        }

        public static OpenApiOperation CreateOperationWithResponseOkPet()
        {
            return JsonConvert.DeserializeObject<OpenApiOperation>(
                JsonConvert.SerializeObject(
                    new OpenApiOperation
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
                                        Schema = CreateSchemaPet(),
                                    },
                                },
                            },
                        },
                    }));
        }

        public static OpenApiParameter CreateParameterTags()
        {
            return JsonConvert.DeserializeObject<OpenApiParameter>(
                JsonConvert.SerializeObject(
                    Parameters.Single(x => x.Name == "tags")));
        }

        public static OpenApiParameter CreateParameterLimit()
        {
            return JsonConvert.DeserializeObject<OpenApiParameter>(
                JsonConvert.SerializeObject(
                    Parameters.Single(x => x.Name == "limit")));
        }

        public static OpenApiSchema CreateSchemaAddress()
        {
            return JsonConvert.DeserializeObject<OpenApiSchema>(
                JsonConvert.SerializeObject(
                    Components.Schemas["address"]));
        }

        public static OpenApiSchema CreateSchemaCountry()
        {
            return JsonConvert.DeserializeObject<OpenApiSchema>(
                JsonConvert.SerializeObject(
                    Components.Schemas["country"]));
        }

        public static OpenApiSchema CreateSchemaPet()
        {
            return JsonConvert.DeserializeObject<OpenApiSchema>(
                JsonConvert.SerializeObject(
                    Components.Schemas["pet"]));
        }

        public static OpenApiSchema CreateSchemaNewPet()
        {
            return JsonConvert.DeserializeObject<OpenApiSchema>(
                JsonConvert.SerializeObject(
                    Components.Schemas["newPet"]));
        }

        public static OpenApiSchema CreateSchemaErrorModel()
        {
            return JsonConvert.DeserializeObject<OpenApiSchema>(
                JsonConvert.SerializeObject(
                    Components.Schemas["errorModel"]));
        }
    }
}