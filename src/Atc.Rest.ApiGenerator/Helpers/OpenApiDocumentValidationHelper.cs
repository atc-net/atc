using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Microsoft.OpenApi.Models;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable LocalizableElement
// ReSharper disable ReturnTypeCanBeEnumerable.Local
// ReSharper disable InvertIf
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class OpenApiDocumentValidationHelper
    {
        public static bool IsDocumentValid(OpenApiDocument apiDocument)
        {
            if (apiDocument == null)
            {
                throw new ArgumentNullException(nameof(apiDocument));
            }

            var validationErrors = new List<string>();
            validationErrors.AddRange(ValidateSchemas(apiDocument.Components.Schemas.Values));
            validationErrors.AddRange(ValidatePaths(apiDocument.Paths.Values));
            validationErrors.AddRange(ValidateOperations(apiDocument.Paths.Values));
            validationErrors.AddRange(ValidatePathsAndOperations(apiDocument.Paths));
            validationErrors.AddRange(ValidateOperationsParametersAndResponses(apiDocument.Paths.Values));

            if (validationErrors.Count <= 0)
            {
                return true;
            }

            foreach (var validationError in validationErrors)
            {
                Console.WriteLine($"Yaml Validation Error: {validationError}");
            }

            return false;
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static List<string> ValidateSchemas(ICollection<OpenApiSchema> schemas)
        {
            var result = new List<string>();
            foreach (var schema in schemas)
            {
                switch (schema.Type)
                {
                    case OpenApiDataTypeConstants.Array:
                        {
                            if (string.IsNullOrEmpty(schema.Title))
                            {
                                result.Add($"Schema - Missing title on array type '{schema.Reference.ReferenceV3}'.");
                            }
                            else if (schema.Title.IsFirstCharacterLowerCase())
                            {
                                result.Add($"Schema - Title on array type '{schema.Title}' is not starting with uppercase.");
                            }

                            result.AddRange(ValidateSchemaModelNameCasing(schema));
                            break;
                        }

                    case OpenApiDataTypeConstants.Object:
                        {
                            if (string.IsNullOrEmpty(schema.Title))
                            {
                                result.Add($"Schema - Missing title on object type '{schema.Reference.ReferenceV3}'.");
                            }
                            else if (schema.Title.IsFirstCharacterLowerCase())
                            {
                                result.Add($"Schema - Title on object type '{schema.Title}' is not starting with uppercase.");
                            }

                            foreach (var (key, value) in schema.Properties)
                            {
                                if (value.Type == OpenApiDataTypeConstants.Array)
                                {
                                    if (!value.IsReferenceTypeDeclared() && !value.IsItemsOfSimpleDataType())
                                    {
                                        result.Add($"Schema - Implicit object definition on property '{key}' in array type '{schema.Reference.ReferenceV3}' is not supported.");
                                    }
                                }
                                else
                                {
                                    result.AddRange(ValidateSchemaModelPropertyNameCasing(key, schema));
                                }
                            }

                            result.AddRange(ValidateSchemaModelNameCasing(schema));
                            break;
                        }
                }
            }

            return result;
        }

        [SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Allow TODO here.")]
        [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK for now.")]
        private static List<string> ValidatePaths(Dictionary<string, OpenApiPathItem>.ValueCollection paths)
        {
            var result = new List<string>();
            var x = paths;

            // TODO:
            return result;
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static List<string> ValidateOperations(Dictionary<string, OpenApiPathItem>.ValueCollection paths)
        {
            var result = new List<string>();
            foreach (var path in paths)
            {
                foreach (var (key, value) in path.Operations)
                {
                    if (string.IsNullOrEmpty(value.OperationId))
                    {
                        result.Add($"Operation - Missing OperationId in path '{key} # {path}'.");
                    }
                    else
                    {
                        if (key == OperationType.Get)
                        {
                            if (!value.OperationId.StartsWith("Get", StringComparison.OrdinalIgnoreCase))
                            {
                                result.Add($"Operation - OperationId should start with the prefix 'Get' for operation '{value.GetOperationName()}'.");
                            }
                        }
                        else if (key == OperationType.Post)
                        {
                            if (value.OperationId.StartsWith("Delete", StringComparison.OrdinalIgnoreCase))
                            {
                                result.Add($"Operation - OperationId should not start with the prefix 'Delete' for operation '{value.GetOperationName()}'.");
                            }
                        }
                        else if (key == OperationType.Put)
                        {
                            if (!value.OperationId.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
                            {
                                result.Add($"Operation - OperationId should start with the prefix 'Update' for operation '{value.GetOperationName()}'.");
                            }
                        }
                        else if (key == OperationType.Patch)
                        {
                            if (!value.OperationId.StartsWith("Patch", StringComparison.OrdinalIgnoreCase) &&
                                !value.OperationId.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
                            {
                                result.Add($"Operation - OperationId should start with the prefix 'Update' for operation '{value.GetOperationName()}'.");
                            }
                        }
                        else if (key == OperationType.Delete &&
                                 !value.OperationId.StartsWith("Delete", StringComparison.OrdinalIgnoreCase) &&
                                 !value.OperationId.StartsWith("Remove", StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add($"Operation - OperationId should start with the prefix 'Delete' for operation '{value.GetOperationName()}'.");
                        }
                    }
                }
            }

            return result;
        }

        private static List<string> ValidatePathsAndOperations(OpenApiPaths paths)
        {
            var result = new List<string>();
            foreach (var path in paths)
            {
                if (!path.Key.IsStringFormatParametersBalanced(false))
                {
                    result.Add($"Path - Path parameters are not well-formatted for '{path.Key}'.");
                }

                var globalPathParameterNames = path.Value.Parameters
                    .Where(x => x.In == ParameterLocation.Path)
                    .Select(x => x.Name)
                    .ToList();

                result.AddRange(ValidatePathsAndOperationsHelper.ValidateGlobalParameters(globalPathParameterNames, path));

                if (!globalPathParameterNames.Any())
                {
                    result.AddRange(ValidatePathsAndOperationsHelper.ValidateMissingOperationParameters(path));
                    result.AddRange(ValidatePathsAndOperationsHelper.ValidateOperationsWithParametersNotPresentInPath(path));
                }

                result.AddRange(ValidatePathsAndOperationsHelper.ValidateGetOperations(path));
            }

            return result;
        }

        private static List<string> ValidateOperationsParametersAndResponses(Dictionary<string, OpenApiPathItem>.ValueCollection paths)
        {
            var result = new List<string>();
            foreach (var path in paths)
            {
                foreach (var (_, value) in path.Operations)
                {
                    var httpStatusCodes = value.Responses.GetHttpStatusCodes();
                    if (httpStatusCodes.Contains(HttpStatusCode.BadRequest) &&
                        !value.HasParametersOrRequestBody() && !path.HasParameters())
                    {
                        result.Add($"Operation - Contains BadRequest response type for operation '{value.GetOperationName()}', but has no parameters.");
                    }
                }
            }

            return result;
        }

        private static List<string> ValidateSchemaModelNameCasing(OpenApiSchema schema)
        {
            var result = new List<string>();
            var modelName = schema.GetModelName(false);
            if (!modelName.IsCasingStyleValid(CasingStyle.PascalCase))
            {
                result.Add($"Schema - Object '{modelName}' is not using {CasingStyle.PascalCase}.");
            }

            return result;
        }

        private static List<string> ValidateSchemaModelPropertyNameCasing(string key, OpenApiSchema schema)
        {
            var result = new List<string>();
            if (!key.IsCasingStyleValid(CasingStyle.CamelCase))
            {
                result.Add($"Schema - Object '{schema.Title}' with property '{key}' is not using {CasingStyle.CamelCase}.");
            }

            return result;
        }
    }
}