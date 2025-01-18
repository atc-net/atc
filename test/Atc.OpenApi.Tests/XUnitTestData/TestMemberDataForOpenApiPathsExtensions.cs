namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestMemberDataForOpenApiPathsExtensions
{
    public static TheoryData<int, OpenApiPaths, string> GetPathsStartingWithSegmentName
        => new()
        {
            {
                0,
                TestDataOpenApiFactory.CreatePaths(),
                "myPets"
            },
            {
                2,
                TestDataOpenApiFactory.CreatePaths(),
                "pets"
            },
        };
}