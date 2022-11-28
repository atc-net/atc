namespace Atc.OpenApi.Tests.XUnitTestData;

public static class TestMemberDataForOpenApiDocumentExtensions
{
    public static TheoryData<int, string, OpenApiDocument> OpenApiPathItemData
        => new()
        {
            { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new() } } },
            { 2, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new(), ["/todos/"] = new() } } },
            { 1, "todo", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new(), ["/users/"] = new() } } },
            { 1, "user", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new(), ["/users/"] = new() } } },
            { 1, "users", new OpenApiDocument { Paths = new OpenApiPaths { ["/todos/{id}/"] = new(), ["/users/"] = new() } } },
        };
}