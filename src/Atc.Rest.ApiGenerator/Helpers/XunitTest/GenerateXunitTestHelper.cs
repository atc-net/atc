using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Helpers.XunitTest
{
    public static class GenerateXunitTestHelper
    {
        public static void AppendNewModelOrListOfModel(
            int indentSpaces,
            StringBuilder sb,
            EndpointMethodMetadata endpointMethodMetadata,
            OpenApiSchema schema,
            HttpStatusCode httpStatusCode,
            string variableName = "data")
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            if (endpointMethodMetadata == null)
            {
                throw new ArgumentNullException(nameof(endpointMethodMetadata));
            }

            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            var contractReturnTypeName = endpointMethodMetadata.ContractReturnTypeNames.First(x => x.Item1 == httpStatusCode);
            if (!string.IsNullOrEmpty(contractReturnTypeName.Item2) && (
                contractReturnTypeName.Item2.StartsWith(Microsoft.OpenApi.Models.NameConstants.Pagination, StringComparison.Ordinal) ||
                contractReturnTypeName.Item2.StartsWith(Microsoft.OpenApi.Models.NameConstants.List, StringComparison.Ordinal)))
            {
                if (contractReturnTypeName.Item2.StartsWith(Microsoft.OpenApi.Models.NameConstants.Pagination, StringComparison.Ordinal))
                {
                    var listDataType = contractReturnTypeName.Item2.Replace(Microsoft.OpenApi.Models.NameConstants.Pagination, Microsoft.OpenApi.Models.NameConstants.List, StringComparison.Ordinal);
                    sb.AppendLine(indentSpaces, $"var {variableName} = new {listDataType}");
                }
                else
                {
                    sb.AppendLine(indentSpaces, $"var {variableName} = new {contractReturnTypeName.Item2}");
                }

                sb.AppendLine(indentSpaces, "{");
                for (int i = 0; i < 3; i++)
                {
                    AppendNewModel(indentSpaces + 4, sb, endpointMethodMetadata.ComponentsSchemas, schema, i + 1, null);
                }

                sb.AppendLine(indentSpaces, "};");
            }
            else
            {
                AppendNewModel(indentSpaces, sb, endpointMethodMetadata.ComponentsSchemas, schema, 0, variableName);
            }
        }

        private static void AppendNewModel(int indentSpaces, StringBuilder sb, IDictionary<string, OpenApiSchema> componentsSchemas, OpenApiSchema schema, int itemNumber, string? variableName)
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            if (componentsSchemas == null)
            {
                throw new ArgumentNullException(nameof(componentsSchemas));
            }

            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            int countString = 0;
            sb.AppendLine(
                indentSpaces,
                variableName == null
                    ? $"new {schema.GetModelName()}"
                    : $"var {variableName} = new {schema.GetModelName()}");

            sb.AppendLine(indentSpaces, "{");
            foreach (var schemaProperty in schema.Properties)
            {
                string dataType = schemaProperty.Value.GetDataType();
                string propertyValueGenerated = PropertyValueGenerator(schemaProperty, componentsSchemas, false, itemNumber, null);
                switch (dataType)
                {
                    case "string":
                        if (schemaProperty.Value.Format != OpenApiFormatTypeConstants.Email)
                        {
                            if (countString > 0)
                            {
                                propertyValueGenerated = $"{propertyValueGenerated}{countString}";
                            }

                            countString++;
                        }

                        sb.AppendLine(
                            indentSpaces + 4,
                            $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = \"{propertyValueGenerated}\",");
                        break;
                    case "DateTimeOffset":
                        sb.AppendLine(
                            indentSpaces + 4,
                            $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = DateTimeOffset.Parse(\"{propertyValueGenerated}\"),");
                        break;
                    case "Guid":
                        sb.AppendLine(
                            indentSpaces + 4,
                            $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = Guid.Parse(\"{propertyValueGenerated}\"),");
                        break;
                    case "Uri":
                        sb.AppendLine(
                            indentSpaces + 4,
                            $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = new Uri(\"{propertyValueGenerated}\"),");
                        break;
                    default:
                        string? enumDataType = GetDataTypeIfEnum(schemaProperty, componentsSchemas);
                        sb.AppendLine(
                            indentSpaces + 4,
                            enumDataType != null
                                ? $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = {enumDataType}.{propertyValueGenerated},"
                                : $"{schemaProperty.Key.EnsureFirstCharacterToUpper()} = {propertyValueGenerated},");

                        break;
                }
            }

            sb.AppendLine(
                indentSpaces,
                variableName == null
                    ? "},"
                    : "};");
        }

        private static string? GetDataTypeIfEnum(KeyValuePair<string, OpenApiSchema> schema, IDictionary<string, OpenApiSchema> componentsSchemas)
        {
            var schemaForDataType = componentsSchemas.FirstOrDefault(x => x.Key.Equals(schema.Value.GetDataType(), StringComparison.OrdinalIgnoreCase));
            return schemaForDataType.Key != null && schemaForDataType.Value.IsSchemaEnumOrPropertyEnum()
                ? schemaForDataType.Key
                : null;
        }

        private static string PropertyValueGenerator(KeyValuePair<string, OpenApiSchema> schema, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest, int itemNumber, string? customValue)
        {
            var name = schema.Key.EnsureFirstCharacterToUpper();

            // Match on OpenApiSchemaExtensions->GetDataType
            return schema.Value.GetDataType() switch
            {
                "double" => ValueTypeTestPropertiesHelper.CreateValueDouble(),
                "long" => ValueTypeTestPropertiesHelper.Number(name, useForBadRequest),
                "int" => ValueTypeTestPropertiesHelper.Number(name, useForBadRequest),
                "bool" => ValueTypeTestPropertiesHelper.CreateValueBool(),
                "string" => ValueTypeTestPropertiesHelper.CreateValueString(name, schema.Value.Format, useForBadRequest, itemNumber, customValue),
                "DateTimeOffset" => ValueTypeTestPropertiesHelper.CreateValueDateTimeOffset(useForBadRequest),
                "Guid" => ValueTypeTestPropertiesHelper.CreateValueGuid(useForBadRequest, itemNumber),
                "Uri" => ValueTypeTestPropertiesHelper.CreateValueUri(useForBadRequest),
                _ => PropertyValueGeneratorTypeResolver(schema, componentsSchemas, useForBadRequest)
            };
        }

        private static string PropertyValueGeneratorTypeResolver(KeyValuePair<string, OpenApiSchema> schema, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest)
        {
            var name = schema.Key.EnsureFirstCharacterToUpper();
            var schemaForDataType = componentsSchemas.FirstOrDefault(x => x.Key.Equals(schema.Value.GetDataType(), StringComparison.OrdinalIgnoreCase));
            if (schemaForDataType.Key != null)
            {
                if (schemaForDataType.Value.IsSchemaEnumOrPropertyEnum())
                {
                    return ValueTypeTestPropertiesHelper.CreateValueEnum(name, schemaForDataType, useForBadRequest);
                }

                if (schema.Value.GetDataType() == "Address")
                {
                    // TO-DO: Imp. this.
                    return $"new {schemaForDataType.Key}()";
                }
            }

            if (schema.Value.Type == "array")
            {
                // TO-DO: Imp. this.
                return "null";
            }

            throw new NotSupportedException($"PropertyValueGenerator: {name} - {schema.Value.GetDataType()}");
        }
    }
}