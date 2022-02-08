namespace Atc.OpenApi.Tests.Extensions;

public class OpenApiResponsesExtensionsTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetHttpStatusCodesItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void GetHttpStatusCodes(List<HttpStatusCode> expected, OpenApiResponses openApiResponses)
    {
        // Act
        var actual = openApiResponses.GetHttpStatusCodes();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaTypeArrayItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void HasSchemaTypeArray(bool expected, OpenApiResponses openApiResponses)
    {
        // Act
        var actual = openApiResponses.HasSchemaTypeArray();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaHttpStatusCodeUsingSystemNetItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void HasSchemaHttpStatusCodeUsingSystemNet(bool expected, OpenApiResponses openApiResponses)
    {
        // Act
        var actual = openApiResponses.HasSchemaHttpStatusCodeUsingSystemNet();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.HasSchemaHttpStatusCodeUsingAspNetCoreHttpItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void HasSchemaHttpStatusCodeUsingAspNetCoreHttp(bool expected, OpenApiResponses openApiResponses)
    {
        // Act
        var actual = openApiResponses.HasSchemaHttpStatusCodeUsingAspNetCoreHttp();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetSchemaForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void GetSchemaForStatusCode(OpenApiSchema expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.GetSchemaForStatusCode(httpStatusCode);

        // Assert
        actual.Should().NotBeNull();
        actual!.Properties.Should().BeEquivalentTo(expected.Properties);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetSchemaForStatusCodeContentTypeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void GetSchemaForStatusCode_ContentType(OpenApiSchema expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode, string contentType)
    {
        // Act
        var actual = openApiResponses.GetSchemaForStatusCode(httpStatusCode, contentType);

        // Assert
        actual.Should().NotBeNull();
        actual!.Properties.Should().BeEquivalentTo(expected.Properties);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetModelNameForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void GetModelNameForStatusCode(string expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.GetModelNameForStatusCode(httpStatusCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.GetDataTypeForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void GetDataTypeForStatusCode(string expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.GetDataTypeForStatusCode(httpStatusCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypeArrayForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void IsSchemaTypeArrayForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.IsSchemaTypeArrayForStatusCode(httpStatusCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypePaginationForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void IsSchemaTypePaginationForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.IsSchemaTypePaginationForStatusCode(httpStatusCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaTypeProblemDetailsForStatusCodeItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void IsSchemaTypeProblemDetailsForStatusCode(bool expected, OpenApiResponses openApiResponses, HttpStatusCode httpStatusCode)
    {
        // Act
        var actual = openApiResponses.IsSchemaTypeProblemDetailsForStatusCode(httpStatusCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiResponsesExtensions.IsSchemaUsingBinaryFormatForOkResponseItemData), MemberType = typeof(TestMemberDataForOpenApiResponsesExtensions))]
    public void IsSchemaUsingBinaryFormatForOkResponse(bool expected, OpenApiResponses openApiResponses)
    {
        // Act
        var actual = openApiResponses.IsSchemaUsingBinaryFormatForOkResponse();

        // Assert
        Assert.Equal(expected, actual);
    }
}