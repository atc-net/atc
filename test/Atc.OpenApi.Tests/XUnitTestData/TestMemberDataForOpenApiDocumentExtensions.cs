using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiDocumentExtensions
    {
        public static TheoryData<int, string, OpenApiDocument> OpenApiPathItemData
            => new TheoryData<int, string, OpenApiDocument>
            {
                { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem() } } },
                { 2, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/todos/"] = new OpenApiPathItem() } } },
                { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                { 1, "user", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
                { 1, "users", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new OpenApiPathItem(), ["/users/"] = new OpenApiPathItem() } } },
            };
    }
}