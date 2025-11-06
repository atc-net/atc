namespace Atc.OpenApi.Tests.Extensions;

public class OpenApiOperationExtensionsTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.GetOperationNameItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void GetOperationName(
        string expected,
        OpenApiOperation openApiOperation)
    {
        // Act
        var actual = openApiOperation.GetOperationName();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.GetModelSchemaFromResponseItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void GetModelSchemaFromResponse(
        OpenApiSchema? expected,
        OpenApiOperation openApiOperation)
    {
        // Act
        var actual = openApiOperation.GetModelSchemaFromResponse();

        // Assert
        if (expected is null)
        {
            actual.Should()
                .BeNull();
        }
        else
        {
            actual.Should()
                .NotBeNull()
                .And.BeEquivalentTo(expected);
        }
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.GetModelSchemaFromRequestItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void GetModelSchemaFromRequest(
        OpenApiSchema? expected,
        OpenApiOperation openApiOperation)
    {
        // Act
        var actual = openApiOperation.GetModelSchemaFromRequest();

        // Assert
        if (expected is null)
        {
            actual.Should()
                .BeNull();
        }
        else
        {
            actual.Should()
                .NotBeNull()
                .And.BeEquivalentTo(expected);
        }
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.HasParametersOrRequestBodyItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void HasParametersOrRequestBody(
        bool expected,
        OpenApiOperation openApiOperation)
    {
        // Act
        var actual = openApiOperation.HasParametersOrRequestBody();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.HasRequestBodyWithAnythingAsFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void HasRequestBodyWithAnythingAsFormatTypeBinary(
        bool expected,
        OpenApiOperation openApiOperation)
    {
        // Act
        var actual = openApiOperation.HasRequestBodyWithAnythingAsFormatTypeBinary();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.IsOperationReferencingSchemaItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void IsOperationReferencingSchema(
        bool expected,
        OpenApiOperation openApiOperation,
        string schemaKey)
    {
        // Act
        var actual = openApiOperation.IsOperationReferencingSchema(schemaKey);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory] // Same test-data-set as IsOperationNamePluralizedItemData
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.IsOperationNamePluralizedItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void IsOperationIdPluralized(
        bool expected,
        OpenApiOperation openApiOperation,
        OperationType operationType)
    {
        // Act
        var actual = openApiOperation.IsOperationIdPluralized(operationType);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.IsOperationNamePluralizedItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void IsOperationNamePluralized(
        bool expected,
        OpenApiOperation openApiOperation,
        OperationType operationType)
    {
        // Act
        var actual = openApiOperation.IsOperationNamePluralized(operationType);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForOpenApiOperationExtensions.HasDataTypeFromSystemCollectionGenericNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiOperationExtensions))]
    public void HasDataTypeFromSystemCollectionGenericNamespace(
        bool expected,
        List<OpenApiOperation> openApiOperations)
    {
        // Act
        var actual = openApiOperations.HasDataTypeFromSystemCollectionGenericNamespace();

        // Assert
        Assert.Equal(expected, actual);
    }
}