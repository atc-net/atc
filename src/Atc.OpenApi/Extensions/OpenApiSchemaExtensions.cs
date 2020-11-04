using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UseDeconstruction
// ReSharper disable UseDeconstructionOnParameter
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    //// https://swagger.io/docs/specification/data-models/
    //// https://swagger.io/docs/specification/data-models/data-types/-> "String Formats"

    public static class OpenApiSchemaExtensions
    {
        public static bool HasDataTypeOfList(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsDataTypeOfList());
        }

        public static bool HasFormatTypeOfUuid(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfUuid());
        }

        public static bool HasFormatTypeOfDate(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfDate());
        }

        public static bool HasFormatTypeOfTime(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfTime());
        }

        public static bool HasFormatTypeOfTimestamp(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfTimestamp());
        }

        public static bool HasFormatTypeOfDateTime(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfDateTime());
        }

        public static bool HasFormatTypeOfByte(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfByte());
        }

        public static bool HasFormatTypeOfInt32(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfInt32());
        }

        public static bool HasFormatTypeOfInt64(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfInt64());
        }

        public static bool HasFormatTypeOfEmail(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfEmail());
        }

        public static bool HasFormatTypeOfUri(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeOfUri());
        }

        public static bool HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsFormatTypeOfUuid() ||
                   schema.IsFormatTypeOfDate() ||
                   schema.IsFormatTypeOfDateTime() ||
                   schema.IsFormatTypeOfTime() ||
                   schema.IsFormatTypeOfTimestamp() ||
                   schema.IsFormatTypeOfUri();
        }

        public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasFormatTypeFromSystemNamespace());
        }

        public static bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsDataTypeOfList();
        }

        public static bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasDataTypeFromSystemCollectionGenericNamespace());
        }

        public static bool HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsFormatTypeOfEmail() ||
                   schema.IsFormatTypeOfUri() ||
                   schema.HasFormatStringValidation() ||
                   schema.HasFormatIntegerValidation();
        }

        public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasFormatTypeFromDataAnnotationsNamespace());
        }

        public static bool HasFormatType(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return !string.IsNullOrEmpty(schema.Format);
        }

        public static bool HasAnyProperties(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.OneOf != null &&
                schema.OneOf.Count == 1 &&
                schema.OneOf.First().Properties.Count > 0)
            {
                return true;
            }

            return schema.Properties.Count > 0;
        }

        public static bool IsDataTypeOfList(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return !string.IsNullOrEmpty(schema.Type) && schema.Type.Equals(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfUuid(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uuid, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfDate(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Date, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfTime(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Time, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfTimestamp(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Timestamp, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfDateTime(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.DateTime, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfByte(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Byte, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfInt32(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int32, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfInt64(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int64, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfEmail(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Email, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeOfUri(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uri, StringComparison.OrdinalIgnoreCase);
        }

        public static bool HasFormatStringValidation(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.MaxLength != null ||
                   schema.MinLength != null;
        }

        public static bool HasFormatIntegerValidation(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Minimum != null ||
                   schema.Maximum != null;
        }

        public static bool IsSimpleDataType(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.Type == null)
            {
                return false;
            }

            var dataType = schema.GetDataType();

            return dataType == OpenApiDataTypeConstants.Boolean ||
                   dataType == OpenApiDataTypeConstants.Integer ||
                   dataType == "int" ||
                   dataType == "long" ||
                   dataType == "double" ||
                   dataType == "float" ||
                   dataType == OpenApiDataTypeConstants.Number ||
                   dataType == OpenApiDataTypeConstants.String;
        }

        public static bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Reference != null;
        }

        public static bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Reference != null || schema.Items?.Reference != null;
        }

        public static bool IsItemsOfSimpleDataType(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Items != null && schema.Items.IsSimpleDataType();
        }

        public static bool IsSchemaEnum(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Enum != null && schema.Enum.Any();
        }

        public static bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsSchemaEnum() ||
                   (schema.Properties.Any(x => x.Value.Enum.Any()) && schema.Properties.Count == 1);
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static bool IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (openApiComponents == null)
            {
                throw new ArgumentNullException(nameof(openApiComponents));
            }

            var referencedSchemaSet = new List<Tuple<string, string>>();

            foreach (var itemSchema in openApiComponents.Schemas.Values)
            {
                foreach (var itemPropertySchema in itemSchema.Properties.Values)
                {
                    if (itemPropertySchema.Reference == null)
                    {
                        continue;
                    }

                    var schemaReference = itemPropertySchema.Reference.Id;
                    if (schema.Title != schemaReference || itemPropertySchema.IsSchemaEnum())
                    {
                        continue;
                    }

                    if (!referencedSchemaSet.Any(x => x.Item1 == itemSchema.Title && x.Item2 == schemaReference))
                    {
                        referencedSchemaSet.Add(Tuple.Create(itemSchema.Title, schemaReference));
                    }

                    if (referencedSchemaSet.Any(x => x.Item1 != itemSchema.Title && x.Item2 == schemaReference))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = true)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.AllOf.Count == 2 &&
                (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                 NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase)))
            {
                if (!NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[0].GetModelName();
                }

                if (!NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[1].GetModelName();
                }
            }

            if (schema.Items == null && schema.Reference == null)
            {
                return string.Empty;
            }

            if (ensureFirstCharacterToUpper)
            {
                return schema.Items == null
                    ? schema.Reference.Id.EnsureFirstCharacterToUpper()
                    : schema.Items.Reference.Id.EnsureFirstCharacterToUpper();
            }

            return schema.Items == null
                ? schema.Reference.Id
                : schema.Items.Reference.Id;
        }

        public static string? GetModelType(this OpenApiSchema schema)
        {
            if (schema == null)
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

        public static string GetDataType(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            var dataType = schema.Type;

            switch (schema.Type)
            {
                case OpenApiDataTypeConstants.Number:
                    return "double";
                case OpenApiDataTypeConstants.Integer:
                    return schema.Format == OpenApiFormatTypeConstants.Int64
                        ? "long"
                        : "int";
                case OpenApiDataTypeConstants.Boolean:
                    return "bool";
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

            if (schema.Reference?.Id != null)
            {
                dataType = schema.Reference.Id;
            }
            else if (schema.OneOf != null && schema.OneOf.Count == 1 && schema.OneOf.First().Reference?.Id != null)
            {
                dataType = schema.OneOf.First().Reference.Id;
            }

            return dataType == OpenApiDataTypeConstants.String
                ? dataType
                : dataType.EnsureFirstCharacterToUpper();
        }

        public static string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (propertyKey == null)
            {
                throw new ArgumentNullException(nameof(propertyKey));
            }

            foreach (var property in schema.Properties)
            {
                if (property.Key == propertyKey)
                {
                    return property.Value.Title;
                }
            }

            throw new ItemNotFoundException($"Can't find property title by property-key: {propertyKey}");
        }

        public static Tuple<string, OpenApiSchema> GetEnumSchema(this OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.Enum != null && schema.Enum.Any())
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
    }
}