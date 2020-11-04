using System;
using System.Collections.Generic;
using Atc.OpenApi.Tests.XUnitTestData;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.Extensions
{
    public class OpenApiSchemaExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasDataTypeOfListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasDataTypeOfList(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasDataTypeOfList();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfUuidItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfUuid(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfByteItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfByte(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfDateItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfDate(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfDateTime(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfTime(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfTimestamp(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfInt32(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfInt64(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfEmailItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfEmail(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasFormatTypeOfUriItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasFormatTypeOfUri(bool expected, IList<OpenApiSchema> openApiSchemas)
        {
            // Act
            var actual = openApiSchemas.HasFormatTypeOfUri();

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
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.HasAnyPropertiesItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void HasAnyProperties(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.HasAnyProperties();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsDataTypeOfListItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsDataTypeOfList(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsDataTypeOfList();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfUuidItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfUuid(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfUuid();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfDateItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfDate(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfDate();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfTime(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfTimestampItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfTimestamp(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfTimestamp();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfDateTimeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfDateTime(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfDateTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfByteItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfByte(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfInt32ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfInt32(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfInt32();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfInt64ItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfInt64(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfInt64();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfEmailItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfEmail(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatTypeOfUriItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatTypeOfUri(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatTypeOfUri();

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
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsItemsOfSimpleDataTypeItemData), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsItemsOfSimpleDataType(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsItemsOfSimpleDataType();

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
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatStringValidation), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatStringValidation(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatStringValidation();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForOpenApiSchemaExtensions.IsFormatIntegerValidation), MemberType = typeof(TestMemberDataForOpenApiSchemaExtensions))]
        public void IsFormatIntegerValidation(bool expected, OpenApiSchema openApiSchema)
        {
            // Act
            var actual = openApiSchema.IsFormatIntegerValidation();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}