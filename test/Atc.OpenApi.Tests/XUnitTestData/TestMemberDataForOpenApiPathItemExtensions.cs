using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiPathItemExtensions
    {
        public static TheoryData<bool, KeyValuePair<string, OpenApiPathItem>, string> IsPathStartingSegmentNameItemData
            => new TheoryData<bool, KeyValuePair<string, OpenApiPathItem>, string>
            {
                {
                    false,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("myPets"),
                    "pets"
                },
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("pets"),
                    "pets"
                },
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet("pets/{petId}"),
                    "pets"
                },
            };

        public static TheoryData<bool, OpenApiPathItem> HasParametersItemData
            => new TheoryData<bool, OpenApiPathItem>
            {
                {
                    false,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPet()
                },
                {
                    true,
                    TestDataOpenApiFactory.CreatePathItemWithOperationResponseOkPetWithParameters(
                        new List<OpenApiParameter>
                        {
                            TestDataOpenApiFactory.CreateParameterLimit(),
                        })
                },
            };
    }
}