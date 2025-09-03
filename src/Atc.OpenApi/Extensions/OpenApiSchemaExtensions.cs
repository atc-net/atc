// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable TailRecursiveCall
// ReSharper disable UseDeconstruction
// ReSharper disable UseDeconstructionOnParameter
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;
//// https://swagger.io/docs/specification/data-models/
//// https://swagger.io/docs/specification/data-models/data-types/-> "String Formats"

public static class OpenApiSchemaExtensions
{
    private static readonly char[] ModelNameSeparators = { ' ', '-', '_', '.' };

    public static bool HasDataTypeList(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsTypeArray());
    }

    public static bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.IsTypeArray())
        {
            return true;
        }

        return schema.OneOf.Count > 0 &&
               schema.OneOf.Any(x => x.HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(componentSchemas));
    }

    public static bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasDataTypeFromSystemCollectionGenericNamespace(componentSchemas));
    }

    public static bool HasFormatTypeUuid(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeUuid());
    }

    public static bool HasFormatTypeDate(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeDate());
    }

    public static bool HasFormatTypeTime(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeTime());
    }

    public static bool HasFormatTypeTimestamp(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeTimestamp());
    }

    public static bool HasFormatTypeDateTime(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeDateTime());
    }

    public static bool HasFormatTypeByte(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeByte());
    }

    public static bool HasFormatTypeInt32(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeInt32());
    }

    public static bool HasFormatTypeInt64(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeInt64());
    }

    public static bool HasFormatTypeEmail(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeEmail());
    }

    public static bool HasFormatTypeUri(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeUri());
    }

    public static bool HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsFormatTypeUuid() ||
               schema.IsFormatTypeDate() ||
               schema.IsFormatTypeDateTime() ||
               schema.IsFormatTypeTime() ||
               schema.IsFormatTypeTimestamp() ||
               schema.IsFormatTypeUri() ||
               (schema.IsTypeArray() && HasFormatTypeFromSystemNamespace(schema.Items));
    }

    public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromSystemNamespace());
    }

    public static bool HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsFormatTypeEmail() ||
               schema.IsFormatTypeUri() ||
               schema.IsRuleValidationString() ||
               schema.IsRuleValidationNumber();
    }

    public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromDataAnnotationsNamespace());
    }

    public static bool HasFormatType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return !string.IsNullOrEmpty(schema.Format);
    }

    public static bool HasModelNameOrAnyPropertiesWithModelName(this OpenApiSchema schema, string modelName)
    {
        if (modelName is null)
        {
            throw new ArgumentNullException(nameof(modelName));
        }

        var name = schema.GetModelName();
        if (!string.IsNullOrEmpty(name) &&
            modelName.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (!schema.HasAnyProperties())
        {
            return false;
        }

        foreach (var schemaProperty in schema.Properties)
        {
            if (name == schemaProperty.Value.GetModelName())
            {
                continue;
            }

            if (schemaProperty.Value.HasModelNameOrAnyPropertiesWithModelName(modelName))
            {
                return true;
            }

            if (schemaProperty.Value.OneOf is not null &&
                schemaProperty.Value.OneOf.Count > 0 &&
                schemaProperty.Value.OneOf.Any(x => x.HasModelNameOrAnyPropertiesWithModelName(modelName)))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasItemsWithSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Items is not null && schema.Items.IsSimpleDataType();
    }

    public static bool HasArrayItemsWithSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() && schema.HasItemsWithSimpleDataType();
    }

    public static bool HasPaginationItemsWithSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (!schema.IsTypePagination())
        {
            return false;
        }

        return
            (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) &&
             schema.AllOf[1].Items.IsSimpleDataType()) ||
            (NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase) &&
             schema.AllOf[0].Items.IsSimpleDataType());
    }

    public static bool HasItemsWithFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Items is not null && schema.Items.IsFormatTypeBinary();
    }

    public static bool HasAnyProperties(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.OneOf is not null &&
            schema.OneOf.Count == 1 &&
            schema.OneOf[0].Properties.Count > 0)
        {
            return true;
        }

        return schema.Properties.Count > 0;
    }

    public static bool HasAnyPropertiesWithFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (!schema.HasAnyProperties())
        {
            return false;
        }

        foreach (var schemaProperty in schema.Properties)
        {
            if (schemaProperty.Value.IsFormatTypeBinary())
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasAnyPropertiesAsArrayWithFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.Items is null && schema.HasAnyProperties())
        {
            foreach (var (_, value) in schema.Properties)
            {
                if (!value.IsTypeArray())
                {
                    continue;
                }

                if (value.HasItemsWithFormatTypeBinary())
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool HasAnythingAsFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return
            schema.IsFormatTypeBinary() ||
            schema.HasItemsWithFormatTypeBinary() ||
            schema.HasAnyPropertiesWithFormatTypeBinary() ||
            schema.HasAnyPropertiesAsArrayWithFormatTypeBinary();
    }

    public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema)
    {
        return schema.HasAnyProperties() &&
               schema.Properties.Any(x => x.Value.HasFormatTypeFromSystemNamespace());
    }

    public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (!schema.HasAnyProperties())
        {
            return false;
        }

        foreach (var schemaProperty in schema.Properties)
        {
            if (schema.GetModelName() == schemaProperty.Value.GetModelName())
            {
                continue;
            }

            if (schemaProperty.Value.HasFormatTypeFromSystemNamespace())
            {
                return true;
            }

            if (HasAnyPropertiesFormatTypeFromSystemNamespaceHelper(schemaProperty, componentSchemas))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (!schema.HasAnyProperties())
        {
            return false;
        }

        foreach (var schemaProperty in schema.Properties)
        {
            if (schemaProperty.Value.IsTypeArray())
            {
                return true;
            }

            if (schema.GetModelName() == schemaProperty.Value.GetModelName())
            {
                continue;
            }

            if (schemaProperty.Value.HasDataTypeFromSystemCollectionGenericNamespace(componentSchemas))
            {
                return true;
            }

            if (HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceHelper(schemaProperty, componentSchemas))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsFormatTypeBinary() || schema.HasItemsWithFormatTypeBinary();
    }

    public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromAspNetCoreHttpNamespace());
    }

    public static bool IsTypeArray(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return !string.IsNullOrEmpty(schema.Type) && schema.Type.Equals(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsTypePagination(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.AllOf.Count == 2 &&
               (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase));
    }

    public static bool IsTypeArrayOrPagination(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() || schema.IsTypePagination();
    }

    public static bool IsFormatTypeUuid(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uuid, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeDate(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Date, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeTime(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Time, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeTimestamp(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Timestamp, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeDateTime(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.DateTime, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeByte(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Byte, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Binary, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeInt32(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int32, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeInt64(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int64, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeEmail(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Email, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsFormatTypeUri(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uri, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsRuleValidationString(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.MinLength is not null ||
               schema.MaxLength is not null;
    }

    public static bool IsRuleValidationNumber(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Minimum is not null ||
               schema.Maximum is not null;
    }

    public static bool IsSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.Type is null)
        {
            return false;
        }

        var dataType = schema.GetDataType();

        return string.Equals(dataType, OpenApiDataTypeConstants.Boolean, StringComparison.Ordinal) ||
               string.Equals(dataType, "bool", StringComparison.Ordinal) ||
               string.Equals(dataType, "double", StringComparison.Ordinal) ||
               string.Equals(dataType, "float", StringComparison.Ordinal) ||
               string.Equals(dataType, OpenApiFormatTypeConstants.Uuid, StringComparison.Ordinal) ||
               string.Equals(dataType, "Guid", StringComparison.Ordinal) ||
               string.Equals(dataType, OpenApiDataTypeConstants.Integer, StringComparison.Ordinal) ||
               string.Equals(dataType, "int", StringComparison.Ordinal) ||
               string.Equals(dataType, "long", StringComparison.Ordinal) ||
               string.Equals(dataType, OpenApiDataTypeConstants.Number, StringComparison.Ordinal) ||
               string.Equals(dataType, OpenApiDataTypeConstants.String, StringComparison.Ordinal);
    }

    public static bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Reference is not null;
    }

    public static bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() &&
               schema.Items?.Reference is not null;
    }

    public static bool IsSchemaEnum(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Enum is not null && schema.Enum.Any();
    }

    public static bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsSchemaEnum() ||
               (schema.Properties.Any(x => x.Value.Enum.Any()) && schema.Properties.Count == 1);
    }

    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static bool IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (openApiComponents is null)
        {
            throw new ArgumentNullException(nameof(openApiComponents));
        }

        var referencedSchemaSet = new List<Tuple<string, string>>();

        foreach (var itemSchema in openApiComponents.Schemas.Values)
        {
            foreach (var itemPropertySchema in itemSchema.Properties.Values)
            {
                if (itemPropertySchema.Reference is null)
                {
                    continue;
                }

                var schemaReference = itemPropertySchema.Reference.Id;
                if (!string.Equals(schema.Title, schemaReference, StringComparison.Ordinal) || itemPropertySchema.IsSchemaEnum())
                {
                    continue;
                }

                if (!referencedSchemaSet.Any(x => string.Equals(x.Item1, itemSchema.Title, StringComparison.Ordinal) && string.Equals(x.Item2, schemaReference, StringComparison.Ordinal)))
                {
                    referencedSchemaSet.Add(Tuple.Create(itemSchema.Title, schemaReference));
                }

                if (referencedSchemaSet.Any(x => !string.Equals(x.Item1, itemSchema.Title, StringComparison.Ordinal) && string.Equals(x.Item2, schemaReference, StringComparison.Ordinal)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static string GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = true)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        // Special-case: pagination wrapper composed via allOf
        if (schema.AllOf?.Count == 2 &&
            (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
             NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase)))
        {
            if (!NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase))
            {
                return schema.AllOf[0].GetModelName(ensureFirstCharacterToUpper);
            }

            if (!NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase))
            {
                return schema.AllOf[1].GetModelName(ensureFirstCharacterToUpper);
            }
        }

        // If it's an array, only accept arrays of objects; otherwise we don't produce a model name.
        if (schema.Items is not null &&
            !string.Equals(schema.Items.Type, OpenApiDataTypeConstants.Object, StringComparison.Ordinal))
        {
            return string.Empty;
        }

        // Use the item schema for arrays; otherwise the schema itself.
        var target = schema.Items ?? schema;

        // If we have a $ref, use it as the model name (optionally PascalCased)
        if (target.Reference is not null)
        {
            var dataType = target.Reference.Id;

            if (!ensureFirstCharacterToUpper)
            {
                return dataType;
            }

            // Preserve "string" as-is; otherwise PascalCase the model name.
            return string.Equals(dataType, OpenApiDataTypeConstants.String, StringComparison.Ordinal)
                ? dataType
                : dataType.PascalCase(ModelNameSeparators, removeSeparators: true);
        }

        // Inline object (anonymous object) => "object"
        if (string.Equals(target.Type, OpenApiDataTypeConstants.Object, StringComparison.Ordinal))
        {
            return OpenApiDataTypeConstants.Object;
        }

        // Primitive or array without object items => no model name
        return string.Empty;
    }

    public static string? GetModelType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.AllOf.Count == 2 &&
            (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
             NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase)))
        {
            if (!NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase))
            {
                return schema.AllOf[0].GetModelType();
            }

            if (!NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase))
            {
                return schema.AllOf[1].GetModelType();
            }
        }

        return schema.Type;
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public static string GetDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        var dataType = schema.Type;

        switch (schema.Type)
        {
            case OpenApiDataTypeConstants.Number:
                return "double";
            case OpenApiDataTypeConstants.Integer:
                return string.Equals(schema.Format, OpenApiFormatTypeConstants.Int64, StringComparison.Ordinal)
                    ? "long"
                    : "int";
            case OpenApiDataTypeConstants.Boolean:
                return "bool";
            case OpenApiDataTypeConstants.Array:
                return "Array";
        }

        if (!string.IsNullOrEmpty(schema.Format))
        {
            switch (schema.Format)
            {
                case OpenApiFormatTypeConstants.Uuid:
                    return "Guid";
                case OpenApiFormatTypeConstants.Date:
                case OpenApiFormatTypeConstants.Time:
                case OpenApiFormatTypeConstants.Timestamp:
                case OpenApiFormatTypeConstants.DateTime:
                    return "DateTimeOffset";
                case OpenApiFormatTypeConstants.Byte:
                    return "string";
                case OpenApiFormatTypeConstants.Binary:
                    return "IFormFile";
                case OpenApiFormatTypeConstants.Int32:
                    return "int";
                case OpenApiFormatTypeConstants.Int64:
                    return "long";
                case OpenApiFormatTypeConstants.Email:
                    return "string";
                case OpenApiFormatTypeConstants.Uri:
                    return "Uri";
            }
        }

        if (schema.Reference?.Id is not null)
        {
            dataType = schema.Reference.Id;
        }
        else if (schema.OneOf is not null &&
                 schema.OneOf.Count == 1 &&
                 schema.OneOf[0].Reference?.Id is not null)
        {
            dataType = schema.OneOf[0].Reference.Id;
        }

        if (dataType is null &&
            schema.AllOf is not null &&
            schema.AllOf.Count > 0)
        {
            foreach (var apiSchema in schema.AllOf)
            {
                dataType = apiSchema.GetDataType();
                if (!string.IsNullOrEmpty(dataType))
                {
                    break;
                }
            }
        }

        if (dataType is null)
        {
            return string.Empty;
        }

        return string.Equals(dataType, OpenApiDataTypeConstants.String, StringComparison.Ordinal)
            ? dataType
            : dataType.PascalCase(ModelNameSeparators, removeSeparators: true);
    }

    public static string GetSimpleDataTypeFromArray(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (!schema.IsTypeArray() ||
            !schema.HasItemsWithSimpleDataType())
        {
            return string.Empty;
        }

        return schema.Items.GetDataType();
    }

    public static string GetSimpleDataTypeFromPagination(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (!schema.IsTypePagination())
        {
            return string.Empty;
        }

        return NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase)
            ? schema.AllOf[1].Items.GetDataType()
            : schema.AllOf[0].Items.GetDataType();
    }

    public static string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (propertyKey is null)
        {
            throw new ArgumentNullException(nameof(propertyKey));
        }

        foreach (var property in schema.Properties)
        {
            if (string.Equals(property.Key, propertyKey, StringComparison.Ordinal))
            {
                return property.Value.Title;
            }
        }

        throw new ItemNotFoundException($"Can't find property title by property-key: {propertyKey}");
    }

    public static Tuple<string, OpenApiSchema> GetEnumSchema(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        if (schema.Enum is not null && schema.Enum.Any())
        {
            return Tuple.Create(schema.Reference.Id, schema);
        }

        foreach (var schemaProperty in schema.Properties)
        {
            if (!schemaProperty.Value.Enum.Any())
            {
                continue;
            }

            var enumName = schemaProperty.Value.Reference?.Id ?? schema.Reference.Id;
            return Tuple.Create(enumName, schemaProperty.Value);
        }

        throw new ItemNotFoundException("Schema does not contain an enum!");
    }

    public static OpenApiSchema GetSchemaByModelName(this IDictionary<string, OpenApiSchema> componentSchemas, string modelName)
        => componentSchemas.First(x => x.Key.Equals(modelName, StringComparison.OrdinalIgnoreCase)).Value;

    public static string ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary(this OpenApiSchema apiSchema)
    {
        if (apiSchema is null)
        {
            throw new ArgumentNullException(nameof(apiSchema));
        }

        foreach (var (key, value) in apiSchema.Properties)
        {
            if (value.IsTypeArray())
            {
                return key.EnsureFirstCharacterToUpper();
            }
        }

        return string.Empty;
    }

    private static bool HasAnyPropertiesFormatTypeFromSystemNamespaceHelper(KeyValuePair<string, OpenApiSchema> schema, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (schema.Value is null)
        {
            return false;
        }

        var modelName = schema.Value.GetModelName();
        if (string.IsNullOrEmpty(modelName))
        {
            return false;
        }

        var componentSchema = componentSchemas.FirstOrDefault(x => x.Key == modelName);
        return !string.IsNullOrEmpty(componentSchema.Key) &&
               componentSchema.Value.HasAnyPropertiesFormatTypeFromSystemNamespace(componentSchemas);
    }

    private static bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceHelper(KeyValuePair<string, OpenApiSchema> schema, IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (schema.Value is null)
        {
            return false;
        }

        var modelName = schema.Value.GetModelName();
        if (string.IsNullOrEmpty(modelName))
        {
            return false;
        }

        var componentSchema = componentSchemas.FirstOrDefault(x => x.Key == modelName);
        return !string.IsNullOrEmpty(componentSchema.Key) &&
               componentSchema.Value.HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(componentSchemas);
    }
}