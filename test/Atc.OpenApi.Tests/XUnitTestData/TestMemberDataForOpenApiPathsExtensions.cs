using System.Collections.Generic;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiPathsExtensions
    {
        public static IEnumerable<object[]> GetPathsStartingWithSegmentName =>
            new List<object[]>
            {
                new object[]
                {
                    0,
                    TestDataOpenApiFactory.CreatePaths(),
                    "myPets",
                },
                new object[]
                {
                    2,
                    TestDataOpenApiFactory.CreatePaths(),
                    "pets",
                },
            };
    }
}