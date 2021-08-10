using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiMediaTypeExtensions
    {
        public static IEnumerable<object[]> GetSchemaItemData =>
            new List<object[]>
            {
                new object[] { OpenApiDataTypeConstants.Array, CreateContent(OpenApiDataTypeConstants.Array) },
            };

        public static IEnumerable<object[]> GetSchemaByFirstMediaTypeItemData =>
            new List<object[]>
            {
                new object[] { OpenApiDataTypeConstants.Array, CreateMultipleContents(OpenApiDataTypeConstants.Array, OpenApiDataTypeConstants.Object) },
            };

        public static IEnumerable<object[]> GetSchemaContentTypeItemData =>
            new List<object[]>
            {
                new object[] { OpenApiDataTypeConstants.Array, MediaTypeNames.Application.Json, CreateContent(OpenApiDataTypeConstants.Array) },
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
}