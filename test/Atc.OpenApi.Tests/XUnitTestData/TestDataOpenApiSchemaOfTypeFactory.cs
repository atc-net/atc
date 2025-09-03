namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestDataOpenApiSchemaOfTypeFactory
{
    public static OpenApiSchema CreateString()
    {
        return new OpenApiSchema
        {
            Type = "string",
        };
    }

    public static OpenApiSchema CreateInteger()
    {
        return new OpenApiSchema
        {
            Type = "integer",
        };
    }

    public static OpenApiSchema CreateNumber()
    {
        return new OpenApiSchema
        {
            Type = "number",
        };
    }

    public static OpenApiSchema CreateInt32()
    {
        return new OpenApiSchema
        {
            Type = "integer",
            Format = "int32",
        };
    }

    public static OpenApiSchema CreateInt64()
    {
        return new OpenApiSchema
        {
            Type = "integer",
            Format = "int64",
        };
    }

    public static OpenApiSchema CreateNumberFloat()
    {
        return new OpenApiSchema
        {
            Type = "number",
            Format = "float",
        };
    }

    public static OpenApiSchema CreateStringByte()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "byte",
        };
    }

    public static OpenApiSchema CreateStringBinary()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "binary",
        };
    }

    public static OpenApiSchema CreateStringDate()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "date",
        };
    }

    public static OpenApiSchema CreateStringDateTime()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "date-time",
        };
    }

    public static OpenApiSchema CreateStringEmail()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "email",
        };
    }

    public static OpenApiSchema CreateStringTime()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "time",
        };
    }

    public static OpenApiSchema CreateStringTimestamp()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "timestamp",
        };
    }

    public static OpenApiSchema CreateStringUri()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "uri",
        };
    }

    public static OpenApiSchema CreateStringUuid()
    {
        return new OpenApiSchema
        {
            Type = "string",
            Format = "uuid",
        };
    }

    public static OpenApiSchema CreateReferencePagination()
    {
        return new OpenApiSchema
        {
            Reference = new OpenApiReference
            {
                Id = NameConstants.Pagination,
            },
        };
    }

    public static OpenApiSchema CreateListString()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateString(),
        };
    }

    public static OpenApiSchema CreateListInteger()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateInteger(),
        };
    }

    public static OpenApiSchema CreateListInt32()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateInt32(),
        };
    }

    public static OpenApiSchema CreateListInt64()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateInt64(),
        };
    }

    public static OpenApiSchema CreateListNumber()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateNumber(),
        };
    }

    public static OpenApiSchema CreateListNumberFloat()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateNumberFloat(),
        };
    }

    public static OpenApiSchema CreateListStringByte()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringByte(),
        };
    }

    public static OpenApiSchema CreateListStringBinary()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringBinary(),
        };
    }

    public static OpenApiSchema CreateListStringDate()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringDate(),
        };
    }

    public static OpenApiSchema CreateListStringDateTime()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringDateTime(),
        };
    }

    public static OpenApiSchema CreateListStringEmail()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringEmail(),
        };
    }

    public static OpenApiSchema CreateListStringTime()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringTime(),
        };
    }

    public static OpenApiSchema CreateListStringTimestamp()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringTimestamp(),
        };
    }

    public static OpenApiSchema CreateListStringUri()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringUri(),
        };
    }

    public static OpenApiSchema CreateListStringUuid()
    {
        return new OpenApiSchema
        {
            Type = "array",
            Items = CreateStringUuid(),
        };
    }

    public static OpenApiSchema CreatePaginationString() => CreatePaginationWith(CreateListString());

    public static OpenApiSchema CreatePaginationInteger() => CreatePaginationWith(CreateListInteger());

    public static OpenApiSchema CreatePaginationInt32() => CreatePaginationWith(CreateListInt32());

    public static OpenApiSchema CreatePaginationInt64() => CreatePaginationWith(CreateListInt64());

    public static OpenApiSchema CreatePaginationNumber() => CreatePaginationWith(CreateListNumber());

    public static OpenApiSchema CreatePaginationNumberFloat() => CreatePaginationWith(CreateListNumberFloat());

    public static OpenApiSchema CreatePaginationStringByte() => CreatePaginationWith(CreateListStringByte());

    public static OpenApiSchema CreatePaginationStringBinary() => CreatePaginationWith(CreateListStringBinary());

    public static OpenApiSchema CreatePaginationStringDate() => CreatePaginationWith(CreateListStringDate());

    public static OpenApiSchema CreatePaginationStringDateTime() => CreatePaginationWith(CreateListStringDateTime());

    public static OpenApiSchema CreatePaginationStringEmail() => CreatePaginationWith(CreateListStringEmail());

    public static OpenApiSchema CreatePaginationStringTime() => CreatePaginationWith(CreateListStringTime());

    public static OpenApiSchema CreatePaginationStringTimestamp() => CreatePaginationWith(CreateListStringTimestamp());

    public static OpenApiSchema CreatePaginationStringUri() => CreatePaginationWith(CreateListStringUri());

    public static OpenApiSchema CreatePaginationStringUuid() => CreatePaginationWith(CreateListStringUuid());

    public static OpenApiSchema CreatePaginationWith(OpenApiSchema schema)
    {
        return new OpenApiSchema
        {
            AllOf = new List<OpenApiSchema>
            {
                CreateReferencePagination(),
                schema,
            },
        };
    }

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