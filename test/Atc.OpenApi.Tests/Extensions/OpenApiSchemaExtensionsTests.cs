using System;
using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using FluentAssertions;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiSchemaExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasDataTypeListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasDataTypeList(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasDataTypeList();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeUuidItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeUuid(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeByteItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeByte(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeDateItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeDate(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeDateTime(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeTime(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeTimestamp(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeInt32(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeInt64(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeEmailItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeEmail(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeUriItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeUri(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeUri();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromSystemNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromSystemNamespace(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasFormatTypeFromSystemNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromSystemNamespaceListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromSystemNamespace_List(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeFromSystemNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasDataTypeFromSystemCollectionGenericNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasDataTypeFromSystemCollectionGenericNamespace(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasDataTypeFromSystemCollectionGenericNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasDataTypeFromSystemCollectionGenericNamespaceListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasDataTypeFromSystemCollectionGenericNamespace_List(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasDataTypeFromSystemCollectionGenericNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromDataAnnotationsNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromDataAnnotationsNamespace(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasFormatTypeFromDataAnnotationsNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromDataAnnotationsNamespaceListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromDataAnnotationsNamespace_List(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeFromDataAnnotationsNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatType(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasFormatType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasItemsWithSimpleDataTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasItemsWithSimpleDataType(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasItemsWithSimpleDataType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasItemsWithFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasItemsWithFormatTypeBinary(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasItemsWithFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyProperties(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnyProperties();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesWithFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyPropertiesWithFormatTypeBinary(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnyPropertiesWithFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesAsArrayWithFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyPropertiesAsArrayWithFormatTypeBinary(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnyPropertiesAsArrayWithFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnythingAsFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnythingAsFormatTypeBinary(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnythingAsFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesFormatTypeFromSystemNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyPropertiesFormatTypeFromSystemNamespace(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnyPropertiesFormatTypeFromSystemNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesFormatTypeFromSystemNamespaceWithComponentSchemasItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyPropertiesFormatTypeFromSystemNamespaceWithComponentSchemas(bool expected, OpenApiSchema openApiSchema, IDictionary<string, OpenApiSchema> componentSchemas)
        {
            // Act
            var actual = openApiSchema.HasAnyPropertiesFormatTypeFromSystemNamespace(componentSchemas);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(bool expected, OpenApiSchema openApiSchema, IDictionary<string, OpenApiSchema> componentSchemas)
        {
            // Act
            var actual = openApiSchema.HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(componentSchemas);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromAspNetCoreHttpNamespaceItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromAspNetCoreHttpNamespace(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasFormatTypeFromAspNetCoreHttpNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeFromAspNetCoreHttpNamespaceListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeFromAspNetCoreHttpNamespace_List(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeFromAspNetCoreHttpNamespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsTypeArrayItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsTypeArray(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsTypeArray();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeUuidItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeUuid(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeDateItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeDate(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeTime(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeTimestamp(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeDateTime(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeByteItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeByte(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeBinary(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeInt32(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeInt64(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeEmailItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeEmail(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeUriItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeUri(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeUri();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsSimpleDataTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsSimpleDataType(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsSimpleDataType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsObjectReferenceTypeDeclaredItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsObjectReferenceTypeDeclared(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsObjectReferenceTypeDeclared();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsArrayReferenceTypeDeclaredItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsArrayReferenceTypeDeclared(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsArrayReferenceTypeDeclared();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsSchemaEnumItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsSchemaEnum(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsSchemaEnum();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsSchemaEnumOrPropertyEnumItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsSchemaEnumOrPropertyEnum(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsSchemaEnumOrPropertyEnum();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsSharedContractItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsSharedContract(bool expected, OpenApiSchema openApiSchema, OpenApiComponents openApiComponents)
        {
            // Act
            var actual = openApiSchema.IsSharedContract(openApiComponents);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetModelNameItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetModelName(string expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.GetModelName();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetModelNameEnsureFirstCharacterToUpperItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetModelName_EnsureFirstCharacterToUpper(string expected, OpenApiSchema openApiSchema, bool ensureFirstCharacterToUpper)
        {
            // Act
            var actual = openApiSchema.GetModelName(ensureFirstCharacterToUpper);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetModelTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetModelType(string expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.GetModelType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetDataTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetDataType(string expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.GetDataType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetTitleFromPropertyByPropertyKeyItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetTitleFromPropertyByPropertyKey(string expected, OpenApiSchema openApiSchema, string propertyKey)
        {
            // Act
            var actual = openApiSchema.GetTitleFromPropertyByPropertyKey(propertyKey);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetEnumSchemaItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetEnumSchema(Tuple<string, int> expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.GetEnumSchema();

            // Assert
            Assert.Equal(expected.Item1, actual.Item1);
            Assert.Equal(expected.Item2, actual.Item2.Enum.Count);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsRuleValidationStringItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsRuleValidationString(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsRuleValidationString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsRuleValidationNumberItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsRuleValidationNumber(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsRuleValidationNumber();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.GetSchemaByModelNameItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void GetSchemaByModelName(OpenApiSchema expected, IDictionary<string, OpenApiSchema> componentSchemas, string modelName)
        {
            // Act
            var actual = componentSchemas.GetSchemaByModelName(modelName);

            // Assert
            actual
                .Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinaryItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary(string expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}