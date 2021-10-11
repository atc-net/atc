using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1509:OpeningBracesMustNotBePrecededByBlankLine", Justification = "OK.")]
    public static class TestMemberDataForOpenApiSchemaExtensions
    {
        public static TheoryData<bool, List<OpenApiSchema>> HasDataTypeListItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static TheoryData<bool, OpenApiSchema> HasDataTypeFromSystemCollectionGenericNamespaceItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasDataTypeFromSystemCollectionGenericNamespaceListItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeUuidItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeByteItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringByte(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeDateItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDate(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeDateTimeItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeTimeItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringTime(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeTimestampItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeInt32ItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeInt64ItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateInt64(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeEmailItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                    }
                },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeUriItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                {
                    false,
                    new List<OpenApiSchema>()
                },
                {
                    false,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
                    }
                },
                {
                    true,
                    new List<OpenApiSchema>
                    {
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
                        TestDataOpenApiSchemaOfTypeFactory.CreateStringUri(),
                    }
                },
            };

        public static TheoryData<bool, OpenApiSchema> HasFormatTypeFromSystemNamespaceItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeFromSystemNamespaceListItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                { false, new List<OpenApiSchema>() },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },

                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
            };

        public static TheoryData<bool, OpenApiSchema> HasFormatTypeFromDataAnnotationsNamespaceItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeFromDataAnnotationsNamespaceListItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                { false, new List<OpenApiSchema>() },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },
            };

        public static TheoryData<bool, OpenApiSchema> HasFormatTypeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema, string> HasModelNameOrAnyPropertiesWithModelNameItemData
            => new TheoryData<bool, OpenApiSchema, string>
            {
                { false, TestDataOpenApiFactory.CreateSchemaPet(), "MyPet" },
                { true, TestDataOpenApiFactory.CreateSchemaPet(), "Pet" },
                { false, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), "MyPet" },
                { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), "Pet" },
            };

        public static TheoryData<bool, OpenApiSchema> HasItemsWithSimpleDataTypeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> HasArrayItemsWithSimpleDataTypeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> HasPaginationItemsWithSimpleDataTypeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> HasItemsWithFormatTypeBinaryItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
                { false, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray() },
                { false, TestDataOpenApiFactory.CreateSchemaPets() },
                { true, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
            };

        public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiFactory.CreateSchemaPet() },
            };

        public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesWithFormatTypeBinaryItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
            };

        public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesAsArrayWithFormatTypeBinaryItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
                { false, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
                { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithBinaryArray() },
            };

        public static TheoryData<bool, OpenApiSchema> HasAnythingAsFormatTypeBinaryItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
                { true, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
                { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithBinaryArray() },
            };

        public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesFormatTypeFromSystemNamespaceItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid() },
            };

        public static TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>> HasAnyPropertiesFormatTypeFromSystemNamespaceWithComponentSchemasItemData
            => new TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
                { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
            };

        public static TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>> HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceItemData
            => new TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
                { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
            };

        public static TheoryData<bool, OpenApiSchema> HasFormatTypeFromAspNetCoreHttpNamespaceItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeFromAspNetCoreHttpNamespaceListItemData
            => new TheoryData<bool, List<OpenApiSchema>>
            {
                { false, new List<OpenApiSchema>() },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() } },
                { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() } },
                { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() } },
            };

        public static TheoryData<bool, OpenApiSchema> IsTypeArrayItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsTypePaginationItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsTypeArrayOrPaginationItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },

                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeUuidItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeDateItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeTimeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeTimestampItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeDateTimeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeByteItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeBinaryItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeInt32ItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeInt64ItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeEmailItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsFormatTypeUriItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsSimpleDataTypeItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsRuleValidationStringItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMaxLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMinLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
            };

        public static TheoryData<bool, OpenApiSchema> IsRuleValidationNumberItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMaxLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                { false, TestDataOpenApiSchemaOfTypeFactory.WithMinLength(TestDataOpenApiSchemaOfTypeFactory.CreateString()) },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateInteger()) },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMaximum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
                { true, TestDataOpenApiSchemaOfTypeFactory.WithMinimum(TestDataOpenApiSchemaOfTypeFactory.CreateNumber()) },
            };

        public static TheoryData<bool, OpenApiSchema> IsObjectReferenceTypeDeclaredItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsArrayReferenceTypeDeclaredItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },

                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
                { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
            };

        public static TheoryData<bool, OpenApiSchema> IsSchemaEnumItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiFactory.CreateSchemaPet() },
                { false, TestDataOpenApiFactory.CreateSchemaColorType() },
                { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
            };

        public static TheoryData<bool, OpenApiSchema> IsSchemaEnumOrPropertyEnumItemData
            => new TheoryData<bool, OpenApiSchema>
            {
                { false, TestDataOpenApiFactory.CreateSchemaPet() },
                { true, TestDataOpenApiFactory.CreateSchemaColorType() },
                { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
            };

        public static TheoryData<bool, OpenApiSchema, OpenApiComponents> IsSharedContractItemData
            => new TheoryData<bool, OpenApiSchema, OpenApiComponents>
            {
                {
                    false,
                    TestDataOpenApiSchemaOfTypeFactory.CreateString(),
                    TestDataOpenApiFactory.CreateComponents()
                },
            };

        public static TheoryData<string, OpenApiSchema> GetModelNameItemData
            => new TheoryData<string, OpenApiSchema>
            {
                { "Pet", TestDataOpenApiFactory.CreateSchemaPet() },
                { string.Empty,  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { string.Empty,  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            };

        public static TheoryData<string, OpenApiSchema, bool> GetModelNameEnsureFirstCharacterToUpperItemData
            => new TheoryData<string, OpenApiSchema, bool>
            {
                {
                    "pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    false
                },
                {
                    "Pet",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    true
                },
            };

        public static TheoryData<string, OpenApiSchema> GetModelTypeItemData
            => new TheoryData<string, OpenApiSchema>
            {
                { "object", TestDataOpenApiFactory.CreateSchemaPet() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { "array",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            };

        public static TheoryData<string, OpenApiSchema> GetDataTypeItemData
            => new TheoryData<string, OpenApiSchema>
            {
                { "Pet", TestDataOpenApiFactory.CreateSchemaPet() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
                { "Array",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            };

        public static TheoryData<string, OpenApiSchema> GetSimpleDataTypeFromArrayItemData
            => new TheoryData<string, OpenApiSchema>
            {
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
                { "int",  TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
                { "int",  TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
                { "long",  TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
                { "double",  TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
                { "double",  TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
            };

        public static TheoryData<string, OpenApiSchema> GetSimpleDataTypeFromPaginationItemData
            => new TheoryData<string, OpenApiSchema>
            {
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
                { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
                { "IFormFile",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
                { "int",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
                { "int",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
                { "long",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
                { "double",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
                { "double",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
                { "Guid",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
                { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
                { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
                { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
                { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
                { "Uri",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
            };

        public static TheoryData<string?, OpenApiSchema, string> GetTitleFromPropertyByPropertyKeyItemData
            => new TheoryData<string?, OpenApiSchema, string>
            {
                {
                    "MyTag",
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    "tag"
                },
                {
                    null,
                    TestDataOpenApiFactory.CreateSchemaPet(),
                    "name"
                },
            };

        public static TheoryData<Tuple<string, int>, OpenApiSchema> GetEnumSchemaItemData
            => new TheoryData<Tuple<string, int>, OpenApiSchema>
            {
                {
                    new Tuple<string, int>("colorType", 5),
                    TestDataOpenApiFactory.CreateSchemaColorType()
                },
            };

        public static TheoryData<OpenApiSchema, Dictionary<string, OpenApiSchema>, string> GetSchemaByModelNameItemData
            => new TheoryData<OpenApiSchema, Dictionary<string, OpenApiSchema>, string>
            {
                {
                    TestDataOpenApiFactory.CreateSchemaColorType(),
                    new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal)
                    {
                        ["pets"] = TestDataOpenApiFactory.CreateSchemaPets(),
                        ["colorType"] = TestDataOpenApiFactory.CreateSchemaColorType(),
                        ["newPet"] = TestDataOpenApiFactory.CreateSchemaNewPet(),
                    },
                    "colorType"
                },
            };

        public static TheoryData<string, OpenApiSchema> ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinaryItemData
            => new TheoryData<string, OpenApiSchema>
            {
                {
                    "Pets",
                    TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray()
                },
                {
                    string.Empty,
                    TestDataOpenApiFactory.CreateSchemaPet()
                },
            };
    }
}