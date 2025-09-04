namespace Atc.OpenApi.Tests.XUnitTestData;

[SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1509:OpeningBracesMustNotBePrecededByBlankLine", Justification = "OK.")]
internal static class TestMemberDataForOpenApiSchemaExtensions
{
    public static TheoryData<bool, List<OpenApiSchema>> HasDataTypeListItemData
        => new()
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

    public static TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>> HasDataTypeFromSystemCollectionGenericNamespaceItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringByte(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateInteger(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt32(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateInt64(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumber(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },

            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListString(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInteger(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt32(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListInt64(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumber(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri(), new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
        };

    public static TheoryData<bool, List<OpenApiSchema>, IDictionary<string, OpenApiSchema>> HasDataTypeFromSystemCollectionGenericNamespaceListItemData
        => new()
        {
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateString() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringByte() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInteger() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt32() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateInt64() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumber() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { false, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },

            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListString() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringBinary() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() }, new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal) },
        };

    public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeUuidItemData
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
        };

    public static TheoryData<bool, List<OpenApiSchema>> HasFormatTypeFromSystemNamespaceListItemData
        => new()
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
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() } },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() } },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() } },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() } },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() } },
            { true, new List<OpenApiSchema> { TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() } },
        };

    public static TheoryData<bool, OpenApiSchema> HasFormatTypeFromDataAnnotationsNamespaceItemData
        => new()
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
        => new()
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
        => new()
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
        => new()
        {
            { false, TestDataOpenApiFactory.CreateSchemaPet(), "MyPet" },
            { true, TestDataOpenApiFactory.CreateSchemaPet(), "Pet" },
            { false, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), "MyPet" },
            { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), "Pet" },
        };

    public static TheoryData<bool, OpenApiSchema> HasItemsWithSimpleDataTypeItemData
        => new()
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
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDate() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringDateTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringTimestamp() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUri() },
        };

    public static TheoryData<bool, OpenApiSchema> HasArrayItemsWithSimpleDataTypeItemData
        => new()
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
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateListStringUuid() },
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
        => new()
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
            { true, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
        };

    public static TheoryData<bool, OpenApiSchema> HasItemsWithFormatTypeBinaryItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringBinary() },
            { false, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
            { false, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray() },
            { false, TestDataOpenApiFactory.CreateSchemaPets() },
            { true, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
        };

    public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { true, TestDataOpenApiFactory.CreateSchemaPet() },
        };

    public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesWithFormatTypeBinaryItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { true, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
        };

    public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesAsArrayWithFormatTypeBinaryItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { false, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
            { false, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
            { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithBinaryArray() },
        };

    public static TheoryData<bool, OpenApiSchema> HasAnythingAsFormatTypeBinaryItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { true, TestDataOpenApiFactory.CreateSchemaPetWithBinary() },
            { true, TestDataOpenApiFactory.CreateSchemaPetsWithBinaryArray() },
            { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithBinaryArray() },
        };

    public static TheoryData<bool, OpenApiSchema> HasAnyPropertiesFormatTypeFromSystemNamespaceItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid() },
        };

    public static TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>> HasAnyPropertiesFormatTypeFromSystemNamespaceWithComponentSchemasItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
            { true, TestDataOpenApiFactory.CreateSchemaPetWithGuid(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
        };

    public static TheoryData<bool, OpenApiSchema, IDictionary<string, OpenApiSchema>> HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceItemData
        => new()
        {
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateString(), TestDataOpenApiFactory.CreateComponentSchemasWithOnePet() },
            { true, TestDataOpenApiFactory.CreateSchemaPetsAsObjectWithArray(), TestDataOpenApiFactory.CreateComponentSchemasWithDifferentPets() },
        };

    public static TheoryData<bool, OpenApiSchema> HasFormatTypeFromAspNetCoreHttpNamespaceItemData
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
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
            { true, TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDate() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTime() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp() },
            { false, TestDataOpenApiSchemaOfTypeFactory.CreateStringUri() },
        };

    public static TheoryData<bool, OpenApiSchema> IsRuleValidationStringItemData
        => new()
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
        => new()
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
        => new()
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
        => new()
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
        => new()
        {
            { false, TestDataOpenApiFactory.CreateSchemaPet() },
            { false, TestDataOpenApiFactory.CreateSchemaColorType() },
            { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
        };

    public static TheoryData<bool, OpenApiSchema> IsSchemaEnumOrPropertyEnumItemData
        => new()
        {
            { false, TestDataOpenApiFactory.CreateSchemaPet() },
            { true, TestDataOpenApiFactory.CreateSchemaColorType() },
            { true, TestDataOpenApiFactory.CreateSchemaColorEnum() },
        };

    public static TheoryData<bool, OpenApiSchema, OpenApiComponents> IsSharedContractItemData
        => new()
        {
            {
                false,
                TestDataOpenApiSchemaOfTypeFactory.CreateString(),
                TestDataOpenApiFactory.CreateComponents()
            },
        };

    public static TheoryData<string, OpenApiSchema> GetModelNameItemData
        => new()
        {
            { "Pet", TestDataOpenApiFactory.CreateSchemaPet() },
            { string.Empty,  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { string.Empty,  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo World") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo_World_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo.World_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("HalloWorld_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("HalloWorld.") },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateInlineObject() },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateListInlineObject() },
        };

    public static TheoryData<string, OpenApiSchema, bool> GetModelNameEnsureFirstCharacterToUpperItemData
        => new()
        {
            { "pet", TestDataOpenApiFactory.CreateSchemaPet(), false },
            { "Pet", TestDataOpenApiFactory.CreateSchemaPet(), true },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateInlineObject(), false },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateInlineObject(), true },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateListInlineObject(), false },
            { "object", TestDataOpenApiSchemaOfTypeFactory.CreateListInlineObject(), true },
        };

    public static TheoryData<string, OpenApiSchema> GetModelTypeItemData
        => new()
        {
            { "object", TestDataOpenApiFactory.CreateSchemaPet() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { "array",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
        };

    public static TheoryData<string, OpenApiSchema> GetDataTypeItemData
        => new()
        {
            { "Pet", TestDataOpenApiFactory.CreateSchemaPet() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateString() },
            { "Array",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo World") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo_World_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("Hallo.World_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("HalloWorld_") },
            { "HalloWorld",  TestDataOpenApiFactory.CreateSchemaWithModelName("HalloWorld.") },
        };

    public static TheoryData<string, OpenApiSchema> GetSimpleDataTypeFromArrayItemData
        => new()
        {
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListString() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListStringEmail() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreateListStringByte() },
            { "int",  TestDataOpenApiSchemaOfTypeFactory.CreateListInteger() },
            { "int",  TestDataOpenApiSchemaOfTypeFactory.CreateListInt32() },
            { "long",  TestDataOpenApiSchemaOfTypeFactory.CreateListInt64() },
            { "double",  TestDataOpenApiSchemaOfTypeFactory.CreateListNumber() },
            { "float",  TestDataOpenApiSchemaOfTypeFactory.CreateListNumberFloat() },
        };

    public static TheoryData<string, OpenApiSchema> GetSimpleDataTypeFromPaginationItemData
        => new()
        {
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationString() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringEmail() },
            { "string",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringByte() },
            { "IFormFile",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringBinary() },
            { "int",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInteger() },
            { "int",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt32() },
            { "long",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationInt64() },
            { "double",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumber() },
            { "float",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationNumberFloat() },
            { "Guid",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUuid() },
            { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDate() },
            { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringDateTime() },
            { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTime() },
            { "DateTimeOffset",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringTimestamp() },
            { "Uri",  TestDataOpenApiSchemaOfTypeFactory.CreatePaginationStringUri() },
        };

    public static TheoryData<string?, OpenApiSchema, string> GetTitleFromPropertyByPropertyKeyItemData
        => new()
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
        => new()
        {
            {
                new Tuple<string, int>("colorType", 5),
                TestDataOpenApiFactory.CreateSchemaColorType()
            },
        };

    public static TheoryData<OpenApiSchema, Dictionary<string, OpenApiSchema>, string> GetSchemaByModelNameItemData
        => new()
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
        => new()
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