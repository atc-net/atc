using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiDocumentExtensions
    {
        public static IEnumerable<object[]> OpenApiPathItemData =>
            new List<object[]>
            {
                new object[] { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem() } } },
                new object[] { 2, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/todos/"] = new OpenApiPathItem() } } },
                new object[] { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                new object[] { 1, "user", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                new object[] { 1, "users", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
            };
    }
}