namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestDataOpenApiSchemaOfTypeFactory
{
    public static OpenApiSchema CreateString()
        => new()
        {
            Type = "string",
        };

    public static OpenApiSchema CreateInteger()
        => new()
        {
            Type = "integer",
        };

    public static OpenApiSchema CreateNumber()
        => new()
        {
            Type = "number",
        };

    public static OpenApiSchema CreateInt32()
        => new()
        {
            Type = "integer",
            Format = "int32",
        };

    public static OpenApiSchema CreateInt64()
        => new()
        {
            Type = "integer",
            Format = "int64",
        };

    public static OpenApiSchema CreateNumberFloat()
        => new()
        {
            Type = "number",
            Format = "float",
        };

    public static OpenApiSchema CreateStringByte()
        => new()
        {
            Type = "string",
            Format = "byte",
        };

    public static OpenApiSchema CreateStringBinary()
        => new()
        {
            Type = "string",
            Format = "binary",
        };

    public static OpenApiSchema CreateStringDate()
        => new()
        {
            Type = "string",
            Format = "date",
        };

    public static OpenApiSchema CreateStringDateTime()
        => new()
        {
            Type = "string",
            Format = "date-time",
        };

    public static OpenApiSchema CreateStringEmail()
        => new()
        {
            Type = "string",
            Format = "email",
        };

    public static OpenApiSchema CreateStringTime()
        => new()
        {
            Type = "string",
            Format = "time",
        };

    public static OpenApiSchema CreateStringTimestamp()
        => new()
        {
            Type = "string",
            Format = "timestamp",
        };

    public static OpenApiSchema CreateStringUri()
        => new()
        {
            Type = "string",
            Format = "uri",
        };

    public static OpenApiSchema CreateStringUuid()
        => new()
        {
            Type = "string",
            Format = "uuid",
        };

    public static OpenApiSchema CreateReferencePagination()
        => new()
        {
            Reference = new OpenApiReference
            {
                Id = NameConstants.Pagination,
            },
        };

    public static OpenApiSchema CreateListString()
        => new()
        {
            Type = "array",
            Items = CreateString(),
        };

    public static OpenApiSchema CreateListInteger()
        => new()
        {
            Type = "array",
            Items = CreateInteger(),
        };

    public static OpenApiSchema CreateListInt32()
        => new()
        {
            Type = "array",
            Items = CreateInt32(),
        };

    public static OpenApiSchema CreateListInt64()
        => new()
        {
            Type = "array",
            Items = CreateInt64(),
        };

    public static OpenApiSchema CreateListNumber()
        => new()
        {
            Type = "array",
            Items = CreateNumber(),
        };

    public static OpenApiSchema CreateListNumberFloat()
        => new()
        {
            Type = "array",
            Items = CreateNumberFloat(),
        };

    public static OpenApiSchema CreateListStringByte()
        => new()
        {
            Type = "array",
            Items = CreateStringByte(),
        };

    public static OpenApiSchema CreateListStringBinary()
        => new()
        {
            Type = "array",
            Items = CreateStringBinary(),
        };

    public static OpenApiSchema CreateListStringDate()
        => new()
        {
            Type = "array",
            Items = CreateStringDate(),
        };

    public static OpenApiSchema CreateListStringDateTime()
        => new()
        {
            Type = "array",
            Items = CreateStringDateTime(),
        };

    public static OpenApiSchema CreateListStringEmail()
        => new()
        {
            Type = "array",
            Items = CreateStringEmail(),
        };

    public static OpenApiSchema CreateListStringTime()
        => new()
        {
            Type = "array",
            Items = CreateStringTime(),
        };

    public static OpenApiSchema CreateListStringTimestamp()
        => new()
        {
            Type = "array",
            Items = CreateStringTimestamp(),
        };

    public static OpenApiSchema CreateListStringUri()
        => new()
        {
            Type = "array",
            Items = CreateStringUri(),
        };

    public static OpenApiSchema CreateListStringUuid()
        => new()
        {
            Type = "array",
            Items = CreateStringUuid(),
        };

    public static OpenApiSchema CreatePaginationString()
        => CreatePaginationWith(CreateListString());

    public static OpenApiSchema CreatePaginationInteger()
        => CreatePaginationWith(CreateListInteger());

    public static OpenApiSchema CreatePaginationInt32()
        => CreatePaginationWith(CreateListInt32());

    public static OpenApiSchema CreatePaginationInt64()
        => CreatePaginationWith(CreateListInt64());

    public static OpenApiSchema CreatePaginationNumber()
        => CreatePaginationWith(CreateListNumber());

    public static OpenApiSchema CreatePaginationNumberFloat()
        => CreatePaginationWith(CreateListNumberFloat());

    public static OpenApiSchema CreatePaginationStringByte()
        => CreatePaginationWith(CreateListStringByte());

    public static OpenApiSchema CreatePaginationStringBinary()
        => CreatePaginationWith(CreateListStringBinary());

    public static OpenApiSchema CreatePaginationStringDate()
        => CreatePaginationWith(CreateListStringDate());

    public static OpenApiSchema CreatePaginationStringDateTime()
        => CreatePaginationWith(CreateListStringDateTime());

    public static OpenApiSchema CreatePaginationStringEmail()
        => CreatePaginationWith(CreateListStringEmail());

    public static OpenApiSchema CreatePaginationStringTime()
        => CreatePaginationWith(CreateListStringTime());

    public static OpenApiSchema CreatePaginationStringTimestamp()
        => CreatePaginationWith(CreateListStringTimestamp());

    public static OpenApiSchema CreatePaginationStringUri()
        => CreatePaginationWith(CreateListStringUri());

    public static OpenApiSchema CreatePaginationStringUuid()
        => CreatePaginationWith(CreateListStringUuid());

    public static OpenApiSchema CreatePaginationWith(OpenApiSchema schema)
        => new()
        {
            AllOf = new List<OpenApiSchema>
            {
                CreateReferencePagination(),
                schema,
            },
        };

    public static OpenApiSchema WithMaxLength(OpenApiSchema schema)
    {
        schema.MaxLength = 255;
        return schema;
    }

    public static OpenApiSchema WithMinLength(OpenApiSchema schema)
    {
        schema.MinLength = 2;
        return schema;
    }

    public static OpenApiSchema WithMaximum(OpenApiSchema schema)
    {
        schema.Maximum = 10;
        return schema;
    }

    public static OpenApiSchema WithMinimum(OpenApiSchema schema)
    {
        schema.Minimum = 2;
        return schema;
    }

    /// <summary>
    /// Inline/anonymous object: type: object, no $ref.
    /// Expected model name: "object".
    /// </summary>
    public static OpenApiSchema CreateInlineObject()
        => new()
        {
            Type = "object",
            Reference = null,
        };

    /// <summary>
    /// Array of inline/anonymous objects: items.type: object, no $ref.
    /// Expected model name: "object".
    /// </summary>
    public static OpenApiSchema CreateListInlineObject()
        => new()
        {
            Type = "array",
            Items = new OpenApiSchema
            {
                Type = "object",
                Reference = null,
            },
        };
}