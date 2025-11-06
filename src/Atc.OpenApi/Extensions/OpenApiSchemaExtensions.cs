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

/// <summary>
/// Extension methods for <see cref="OpenApiSchema"/>.
/// Provides utilities for working with OpenAPI schemas including type checking, format validation,
/// model name extraction, and data type conversion.
/// See: https://swagger.io/docs/specification/data-models/
/// </summary>
public static class OpenApiSchemaExtensions
{
    private static readonly char[] ModelNameSeparators = { ' ', '-', '_', '.' };

    /// <summary>
    /// Determines whether any schema in the collection has an array data type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema is an array type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasDataTypeList(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsTypeArray());
    }

    /// <summary>
    /// Determines whether the schema uses data types from the System.Collections.Generic namespace.
    /// This includes array types and oneOf compositions with collection properties.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="componentSchemas">The dictionary of component schemas from the OpenAPI document.</param>
    /// <returns>True if the schema uses System.Collections.Generic types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasDataTypeFromSystemCollectionGenericNamespace(
        this OpenApiSchema schema,
        IDictionary<string, OpenApiSchema> componentSchemas)
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

    /// <summary>
    /// Determines whether any schema in the collection uses data types from the System.Collections.Generic namespace.
    /// This includes array types and oneOf compositions with collection properties.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="componentSchemas">The dictionary of component schemas from the OpenAPI document.</param>
    /// <returns>True if any schema uses System.Collections.Generic types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasDataTypeFromSystemCollectionGenericNamespace(
        this IList<OpenApiSchema> schemas,
        IDictionary<string, OpenApiSchema> componentSchemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasDataTypeFromSystemCollectionGenericNamespace(componentSchemas));
    }

    /// <summary>
    /// Determines whether any schema in the collection has a UUID format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has UUID format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeUuid(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeUuid());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a date format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has date format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeDate(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeDate());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a time format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeTime(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeTime());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a timestamp format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has timestamp format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeTimestamp(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeTimestamp());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a date-time format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has date-time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeDateTime(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeDateTime());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a byte format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has byte format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeByte(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeByte());
    }

    /// <summary>
    /// Determines whether any schema in the collection has an int32 format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has int32 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeInt32(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeInt32());
    }

    /// <summary>
    /// Determines whether any schema in the collection has an int64 format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has int64 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeInt64(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeInt64());
    }

    /// <summary>
    /// Determines whether any schema in the collection has an email format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has email format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeEmail(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeEmail());
    }

    /// <summary>
    /// Determines whether any schema in the collection has a URI format type.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema has URI format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeUri(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.IsFormatTypeUri());
    }

    /// <summary>
    /// Determines whether the schema uses format types from the System namespace.
    /// This includes UUID (Guid), date/time types, URI, and arrays containing such types.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema uses System namespace format types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether any schema in the collection uses format types from the System namespace.
    /// This includes UUID (Guid), date/time types, URI, and arrays containing such types.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema uses System namespace format types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromSystemNamespace());
    }

    /// <summary>
    /// Determines whether the schema uses format types or validation rules from the System.ComponentModel.DataAnnotations namespace.
    /// This includes email format, URI format, string validation rules (length), and number validation rules (min/max).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema uses DataAnnotations format types or validation rules; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether any schema in the collection uses format types or validation rules from the System.ComponentModel.DataAnnotations namespace.
    /// This includes email format, URI format, string validation rules (length), and number validation rules (min/max).
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema uses DataAnnotations format types or validation rules; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromDataAnnotationsNamespace());
    }

    /// <summary>
    /// Determines whether the schema has a format type specified.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has a format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasFormatType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return !string.IsNullOrEmpty(schema.Format);
    }

    /// <summary>
    /// Determines whether the schema itself or any of its properties (including nested properties and oneOf compositions) has the specified model name.
    /// This method recursively searches through the schema hierarchy to find matching model names.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="modelName">The model name to search for.</param>
    /// <returns>True if the schema or any of its properties has the specified model name; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="modelName"/> is null.</exception>
    public static bool HasModelNameOrAnyPropertiesWithModelName(
        this OpenApiSchema schema,
        string modelName)
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

    /// <summary>
    /// Determines whether the schema has items with simple data types.
    /// Simple data types include primitives like boolean, integer, number, and string.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has items with simple data types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasItemsWithSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Items is not null && schema.Items.IsSimpleDataType();
    }

    /// <summary>
    /// Determines whether the schema is an array type with simple data type items.
    /// Simple data types include primitives like boolean, integer, number, and string.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an array with simple data type items; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasArrayItemsWithSimpleDataType(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() && schema.HasItemsWithSimpleDataType();
    }

    /// <summary>
    /// Determines whether the schema is a pagination type with simple data type items.
    /// Pagination schemas are composed using allOf with a Pagination reference and an items schema.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is a pagination type with simple data type items; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema has items with binary format type.
    /// Binary format is typically used for file uploads and binary data.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has items with binary format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasItemsWithFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Items is not null && schema.Items.IsFormatTypeBinary();
    }

    /// <summary>
    /// Determines whether the schema has any properties defined.
    /// This includes properties in the schema itself or in a single oneOf composition.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has any properties; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema has any properties with binary format type.
    /// Binary format is typically used for file uploads and binary data.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any property has binary format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema has any properties that are arrays with binary format type items.
    /// This is used to detect array properties containing file uploads or binary data.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any property is an array with binary format type items; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema has any binary format type in itself, its items, its properties, or array properties.
    /// This comprehensive check covers all possible locations where binary format could appear in the schema.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any aspect of the schema has binary format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema has any properties with format types from the System namespace.
    /// This includes UUID (Guid), date/time types, and URI types.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any property has a System namespace format type; otherwise, false.</returns>
    public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema)
    {
        return schema.HasAnyProperties() &&
               schema.Properties.Any(x => x.Value.HasFormatTypeFromSystemNamespace());
    }

    /// <summary>
    /// Determines whether the schema has any properties with format types from the System namespace,
    /// recursively checking nested schemas using component schemas for reference resolution.
    /// This includes UUID (Guid), date/time types, and URI types.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="componentSchemas">The dictionary of component schemas from the OpenAPI document.</param>
    /// <returns>True if any property has a System namespace format type; otherwise, false.</returns>
    public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(
        this OpenApiSchema schema,
        IDictionary<string, OpenApiSchema> componentSchemas)
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

    /// <summary>
    /// Determines whether the schema has any properties with format types from the System.Collections.Generic namespace,
    /// recursively checking nested schemas using component schemas for reference resolution.
    /// This includes array types and collection properties.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="componentSchemas">The dictionary of component schemas from the OpenAPI document.</param>
    /// <returns>True if any property uses System.Collections.Generic types; otherwise, false.</returns>
    public static bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(
        this OpenApiSchema schema,
        IDictionary<string, OpenApiSchema> componentSchemas)
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

    /// <summary>
    /// Determines whether the schema uses format types from the Microsoft.AspNetCore.Http namespace.
    /// This includes binary format types that map to IFormFile for file uploads.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema uses AspNetCore.Http format types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsFormatTypeBinary() || schema.HasItemsWithFormatTypeBinary();
    }

    /// <summary>
    /// Determines whether any schema in the collection uses format types from the Microsoft.AspNetCore.Http namespace.
    /// This includes binary format types that map to IFormFile for file uploads.
    /// </summary>
    /// <param name="schemas">The collection of <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if any schema uses AspNetCore.Http format types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schemas"/> is null.</exception>
    public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this IList<OpenApiSchema> schemas)
    {
        if (schemas is null)
        {
            throw new ArgumentNullException(nameof(schemas));
        }

        return schemas.Any(x => x.HasFormatTypeFromAspNetCoreHttpNamespace());
    }

    /// <summary>
    /// Determines whether the schema is an array type.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an array type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsTypeArray(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return !string.IsNullOrEmpty(schema.Type) && schema.Type.Equals(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema is a pagination type.
    /// Pagination schemas are composed using allOf with exactly two elements, one of which references the Pagination schema.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is a pagination type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema is either an array type or a pagination type.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an array or pagination type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsTypeArrayOrPagination(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() || schema.IsTypePagination();
    }

    /// <summary>
    /// Determines whether the schema has a UUID format type, which maps to System.Guid in .NET.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has UUID format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeUuid(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uuid, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a date format type (full-date per RFC 3339).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has date format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeDate(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Date, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a time format type (partial-time per RFC 3339).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeTime(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Time, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a timestamp format type.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has timestamp format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeTimestamp(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Timestamp, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a date-time format type (date-time per RFC 3339).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has date-time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeDateTime(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.DateTime, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a byte format type (base64 encoded characters).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has byte format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeByte(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Byte, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a binary format type (any sequence of octets).
    /// This typically maps to IFormFile in ASP.NET Core for file uploads.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has binary format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeBinary(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Binary, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has an int32 format type (signed 32-bit integer).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has int32 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeInt32(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int32, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has an int64 format type (signed 64-bit integer).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has int64 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeInt64(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int64, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has an email format type (email address per RFC 5322).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has email format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeEmail(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Email, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has a URI format type (URI per RFC 3986).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has URI format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsFormatTypeUri(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uri, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the schema has string validation rules (minimum or maximum length).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has string validation rules; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsRuleValidationString(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.MinLength is not null ||
               schema.MaxLength is not null;
    }

    /// <summary>
    /// Determines whether the schema has number validation rules (minimum or maximum value).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema has number validation rules; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsRuleValidationNumber(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Minimum is not null ||
               schema.Maximum is not null;
    }

    /// <summary>
    /// Determines whether the schema represents a simple (primitive) data type.
    /// Simple data types include boolean, integer, number, string, and their .NET equivalents (bool, int, long, double, float, Guid).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is a simple data type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the schema is an object reference type (has a $ref).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is a reference type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Reference is not null;
    }

    /// <summary>
    /// Determines whether the schema is an array type with items that are reference types (have a $ref).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an array with reference type items; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsTypeArray() &&
               schema.Items?.Reference is not null;
    }

    /// <summary>
    /// Determines whether the schema is an enumeration type (has enum values defined).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an enum type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsSchemaEnum(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.Enum is not null && schema.Enum.Any();
    }

    /// <summary>
    /// Determines whether the schema is an enumeration type or has a single property that is an enum.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <returns>True if the schema is an enum or has a single enum property; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    public static bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
    {
        if (schema is null)
        {
            throw new ArgumentNullException(nameof(schema));
        }

        return schema.IsSchemaEnum() ||
               (schema.Properties.Any(x => x.Value.Enum.Any()) && schema.Properties.Count == 1);
    }

    /// <summary>
    /// Determines whether the schema is a shared contract, meaning it is referenced by multiple different schemas in the OpenAPI components.
    /// A schema is considered shared if it is referenced as a property in at least two different parent schemas.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to check.</param>
    /// <param name="openApiComponents">The OpenAPI components containing all schemas.</param>
    /// <returns>True if the schema is shared across multiple parent schemas; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> or <paramref name="openApiComponents"/> is null.</exception>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static bool IsSharedContract(
        this OpenApiSchema schema,
        OpenApiComponents openApiComponents)
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

    /// <summary>
    /// Extracts the model name from the schema.
    /// For reference types, returns the reference ID (optionally PascalCased).
    /// For pagination types, extracts the model name from the non-pagination allOf element.
    /// For arrays of objects, returns the item's model name.
    /// For inline objects, returns "object".
    /// For primitives, returns empty string.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to extract the model name from.</param>
    /// <param name="ensureFirstCharacterToUpper">If true, ensures the model name is PascalCased; otherwise returns as-is.</param>
    /// <returns>The model name, or empty string if the schema doesn't represent a model.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static string GetModelName(
        this OpenApiSchema schema,
        bool ensureFirstCharacterToUpper = true)
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

    /// <summary>
    /// Extracts the model type from the schema.
    /// For pagination types, extracts the type from the non-pagination allOf element.
    /// For regular schemas, returns the Type property.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to extract the model type from.</param>
    /// <returns>The model type, or null if not available.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Gets the .NET data type for the schema, converting OpenAPI types and formats to their corresponding .NET types.
    /// Examples: "number" with "int32" format becomes "int", "string" with "uuid" format becomes "Guid",
    /// "string" with "binary" format becomes "IFormFile", etc.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to get the data type from.</param>
    /// <returns>The .NET data type as a string, or empty string if no type can be determined.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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
                if (string.Equals(schema.Format, OpenApiFormatTypeConstants.Int64, StringComparison.Ordinal))
                {
                    return "long";
                }

                if (string.Equals(schema.Format, OpenApiFormatTypeConstants.Int32, StringComparison.Ordinal))
                {
                    return "int";
                }

                if (string.Equals(schema.Format, OpenApiFormatTypeConstants.Float, StringComparison.Ordinal))
                {
                    return "float";
                }

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

        if (schema.AllOf is not null &&
            schema.AllOf.Count > 0 &&
            (dataType is null || dataType is "string"))
        {
            foreach (var apiSchema in schema.AllOf)
            {
                var subDataType = apiSchema.GetDataType();
                if (!string.IsNullOrEmpty(subDataType))
                {
                    dataType = subDataType;
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

    /// <summary>
    /// Extracts the simple data type from an array schema's items.
    /// Returns empty string if the schema is not an array or doesn't have simple data type items.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to extract the data type from.</param>
    /// <returns>The simple data type of the array items, or empty string if not applicable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Extracts the simple data type from a pagination schema's items.
    /// Returns empty string if the schema is not a pagination type.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to extract the data type from.</param>
    /// <returns>The simple data type of the paginated items, or empty string if not a pagination type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
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

    /// <summary>
    /// Gets the title of a property by its property key (name).
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> containing the properties.</param>
    /// <param name="propertyKey">The property key to search for.</param>
    /// <returns>The title of the property.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> or <paramref name="propertyKey"/> is null.</exception>
    /// <exception cref="ItemNotFoundException">Thrown when no property with the specified key is found.</exception>
    public static string GetTitleFromPropertyByPropertyKey(
        this OpenApiSchema schema,
        string propertyKey)
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

    /// <summary>
    /// Extracts the enum schema from the schema, either from the schema itself or from its first enum property.
    /// Returns a tuple containing the enum name and the enum schema.
    /// </summary>
    /// <param name="schema">The <see cref="OpenApiSchema"/> to extract the enum from.</param>
    /// <returns>A tuple containing the enum name and the enum schema.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
    /// <exception cref="ItemNotFoundException">Thrown when the schema does not contain an enum.</exception>
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

    /// <summary>
    /// Gets the schema from component schemas by model name (case-insensitive).
    /// </summary>
    /// <param name="componentSchemas">The dictionary of component schemas.</param>
    /// <param name="modelName">The model name to search for.</param>
    /// <returns>The matching schema.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no schema with the specified model name is found.</exception>
    public static OpenApiSchema GetSchemaByModelName(
        this IDictionary<string, OpenApiSchema> componentSchemas,
        string modelName)
        => componentSchemas.First(x => x.Key.Equals(modelName, StringComparison.OrdinalIgnoreCase)).Value;

    /// <summary>
    /// Extracts the property name of the first array property found in the schema, with the first character converted to uppercase.
    /// Returns empty string if no array properties are found.
    /// </summary>
    /// <param name="apiSchema">The <see cref="OpenApiSchema"/> to search.</param>
    /// <returns>The property name with first character uppercase, or empty string if no array properties exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="apiSchema"/> is null.</exception>
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

    private static bool HasAnyPropertiesFormatTypeFromSystemNamespaceHelper(
        KeyValuePair<string, OpenApiSchema> schema,
        IDictionary<string, OpenApiSchema> componentSchemas)
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

    private static bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespaceHelper(
        KeyValuePair<string, OpenApiSchema> schema,
        IDictionary<string, OpenApiSchema> componentSchemas)
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