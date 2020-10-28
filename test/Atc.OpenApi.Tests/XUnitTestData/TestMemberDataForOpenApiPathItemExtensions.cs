using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiPathItemExtensions
    {
        public static IEnumerable<object[]> IsPathStartingSegmentNameItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("myPets"),
                    "pets",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("pets"),
                    "pets",
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("pets/{petId}"),
                    "pets",
                },
            };

        public static IEnumerable<object[]> HasParametersItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet(),
                },
                new object[]
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPetWithParameters(
                        new List<OpenApiParameter>
                        {
                            TestDataOpenApiFactory.CreateParameterLimit(),
                        }),
                },
            };
    }
}