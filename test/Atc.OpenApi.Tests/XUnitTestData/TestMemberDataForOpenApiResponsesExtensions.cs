using System.Collections.Generic;
using System.Net;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiResponsesExtensions
    {
        public static IEnumerable<object[]> GetHttpStatusCodesItemData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<HttpStatusCode>(),
                    new OpenApiResponses(),
                },
                new object[]
                {
                    new List<HttpStatusCode>()
                    {
                        HttpStatusCode.OK,
                    },
                    new OpenApiResponses
                    {
                        ["200"] = new OpenApiResponse
                        {
                            Description = "Ok",
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = TestDataOpenApiFactory.CreateSchemaAddress(),
                                },
                            },
                        },
                    },
                },
                new object[]
                {
                    new List<HttpStatusCode>()
                    {
                        HttpStatusCode.OK,
                        HttpStatusCode.NotFound,
                    },
                    new OpenApiResponses
                    {
                        ["200"] = new OpenApiResponse
                        {
                            Description = "Ok",
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = TestDataOpenApiFactory.CreateSchemaAddress(),
                                },
                            },
                        },
                        ["404"] = new OpenApiResponse
                        {
                            Description = "Not found",
                        },
                    },
                },
            };

        public static IEnumerable<object[]> HasSchemaTypeOfArrayItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateResponsesOkPets(),
                },
            };

        public static IEnumerable<object[]> HasSchemaTypeOfHttpStatusCodeUsingSystemNetItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                },
            };

        public static IEnumerable<object[]> HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttpItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                },
            };

        public static IEnumerable<object[]> GetSchemaForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
            };

        public static IEnumerable<object[]> GetSchemaForStatusCodeContentTypeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                    "application/json",
                },
            };

        public static IEnumerable<object[]> GetModelNameForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
            };

        public static IEnumerable<object[]> GetDataTypeForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
            };

        public static IEnumerable<object[]> IsSchemaTypeArrayForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreateResponsesOkPets(),
                    HttpStatusCode.OK,
                },
            };

        public static IEnumerable<object[]> IsSchemaTypePaginationForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
            };

        public static IEnumerable<object[]> IsSchemaTypeProblemDetailsForStatusCodeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreateResponsesOkPet(),
                    HttpStatusCode.OK,
                },
            };
    }
}