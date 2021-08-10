using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestMemberDataForOpenApiSchemaExtensions
    {
        public static IEnumerable<object[]> HasDataTypeOfListItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static IEnumerable<object[]> HasFormatTypeOfUuidItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfByteItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringByte(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfDateItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDate(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfDateTimeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfTimeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringTime(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfTimestampItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfInt32ItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfInt64ItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateInt64(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfEmailItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeOfUriItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    new List<OpenApiSchema>(),
                },
                new object[]
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    },
                },
                new object[]
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringUri(),
                    },
                },
            };

        public static IEnumerable<object[]> HasFormatTypeFromSystemNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> HasFormatTypeFromSystemNamespaceListItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiSchema>() },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static IEnumerable<object[]> HasDataTypeFromSystemCollectionGenericNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> HasDataTypeFromSystemCollectionGenericNamespaceListItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static IEnumerable<object[]> HasFormatTypeFromDataAnnotationsNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> HasFormatTypeFromDataAnnotationsNamespaceListItemData =>
            new List<object[]>
            {
                new object[] { false, new List<OpenApiSchema>() },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                new object[] { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                new object[] { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },
            };

        public static IEnumerable<object[]> HasFormatTypeItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> HasAnyPropertiesItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaPet() },
            };

        public static IEnumerable<object[]> HasAnyPropertiesFormatTypeFromSystemNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid() },
            };

        public static IEnumerable<object[]> HasAnyPropertiesFormatTypeFromSystemNamespaceWithComponentSchemasItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
            };

        public static IEnumerable<object[]> HasAnyPropertiesFormatFromSystemCollectionGenericNamespaceItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
            };

        public static IEnumerable<object[]> IsDataTypeOfListItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfUuidItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfDateItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfTimeItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfTimestampItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfDateTimeItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfByteItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfInt32ItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfInt64ItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfEmailItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsFormatTypeOfUriItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsSimpleDataTypeItemData =>
            new List<object[]>
            {
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static IEnumerable<object[]> IsRuleValidationStringItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMaxLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMinLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
            };

        public static IEnumerable<object[]> IsRuleValidationNumberItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMaxLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.WithMinLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
            };

        public static IEnumerable<object[]> IsObjectReferenceTypeDeclaredItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> IsArrayReferenceTypeDeclaredItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> IsItemsOfSimpleDataTypeItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                new object[] { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                new object[] { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static IEnumerable<object[]> IsSchemaEnumItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiFactory.CreateSchemaPet() },
                new object[] { false, TestDataOpenApiFactory.CreateSchemaColorType() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
            };

        public static IEnumerable<object[]> IsSchemaEnumOrPropertyEnumItemData =>
            new List<object[]>
            {
                new object[] { false, TestDataOpenApiFactory.CreateSchemaPet() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaColorType() },
                new object[] { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
            };

        public static IEnumerable<object[]> IsSharedContractItemData =>
            new List<object[]>
            {
                new object[]
                {
                    false,
                    TestDataOpenApiSchemaOfTypeFactory.CreateString(),
                    TestDataOpenApiFactory.CreateComponents(),
                },
            };

        public static IEnumerable<object[]> GetModelNameItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                },
            };

        public static IEnumerable<object[]> GetModelNameEnsureFirstCharacterToUpperItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    false,
                },
                new object[]
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    true,
                },
            };

        public static IEnumerable<object[]> GetModelTypeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "object",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                },
            };

        public static IEnumerable<object[]> GetDataTypeItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                },
            };

        public static IEnumerable<object[]> GetTitleFromPropertyByPropertyKeyItemData =>
            new List<object[]>
            {
                new object[]
                {
                    "MyTag",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    "tag",
                },
                new object[]
                {
                    null,
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    "name",
                },
            };

        public static IEnumerable<object[]> GetEnumSchemaItemData =>
            new List<object[]>
            {
                new object[]
                {
                    new Tuple<string, int>("colorType", 5),
                    TestDataOpenApiFactory.CreateSchemaColorType(),
                },
            };

        public static IEnumerable<object[]> GetSchemaByModelNameItemData =>
            new List<object[]>
            {
                new object[]
                {
                    TestDataOpenApiFactory.CreateSchemaColorType(),
                    new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                    {
                        ["pets"] = TestDataOpenApiFactory.CreateSchemaPets(),
                        ["colorType"] = TestDataOpenApiFactory.CreateSchemaColorType(),
                        ["newPet"] = TestDataOpenApiFactory.CreateSchemaNewPet(),
                    },
                    "colorType",
                },
            };
    }
}