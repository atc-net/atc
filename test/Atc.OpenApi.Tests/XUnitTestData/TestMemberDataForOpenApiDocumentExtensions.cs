using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiDocumentExtensions
    {
        public static IEnumerable<object[]> OpenApiPathItemData =>
            new List<object[]>
            {
                new object[] { "todo", 1, new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem() } } },
                new object[] { "todo", 2, new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/todos/"] = new OpenApiPathItem() } } },
                new object[] { "todo", 1, new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                new object[] { "user", 1, new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                new object[] { "users", 1, new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
            };
    }
}