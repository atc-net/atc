namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestMemberDataForOpenApiPathItemExtensions
{
    public static TheoryData<bool, KeyValuePair<string, OpenApiPathItem>, string> IsPathStartingSegmentNameItemData
        => new()
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
        => new()
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