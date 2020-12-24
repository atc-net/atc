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

        public static IEnumerable<object[]> GetSchemaContentTypeItemData =>
            new List<object[]>
            {
                new object[] { OpenApiDataTypeConstants.Array, MediaTypeNames.Application.Json, CreateContent(OpenApiDataTypeConstants.Array) },
            };

        private static IDictionary<string, OpenApiMediaType> CreateContent(string typeName)
        {
            return new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
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
        }
    }
}