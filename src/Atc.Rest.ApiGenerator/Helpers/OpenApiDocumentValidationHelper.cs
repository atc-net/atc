using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
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
        public static List<LogKeyValueItem> ValidateDocument(OpenApiDocument apiDocument, ApiOptionsValidation validationOptions)
        {
            if (apiDocument == null)
            {
                throw new ArgumentNullException(nameof(apiDocument));
            }

            if (validationOptions == null)
            {
                throw new ArgumentNullException(nameof(validationOptions));
            }

            var logItems = new List<LogKeyValueItem>();
            logItems.AddRange(ValidateSchemas(validationOptions, apiDocument.Components.Schemas.Values));
            logItems.AddRange(ValidateOperations(validationOptions, apiDocument.Paths.Values, apiDocument.Components.Schemas));
            logItems.AddRange(ValidatePathsAndOperations(validationOptions, apiDocument.Paths));
            logItems.AddRange(ValidateOperationsParametersAndResponses(validationOptions, apiDocument.Paths.Values));

            return logItems;
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static List<LogKeyValueItem> ValidateSchemas(
            ApiOptionsValidation validationOptions,
            ICollection<OpenApiSchema> schemas)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            foreach (var schema in schemas)
            {
                switch (schema.Type)
                {
                    case OpenApiDataTypeConstants.Array:
                        {
                            if (string.IsNullOrEmpty(schema.Title))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema01, $"Missing title on array type '{schema.Reference.ReferenceV3}'."));
                            }
                            else if (schema.Title.IsFirstCharacterLowerCase())
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema02, $"Title on array type '{schema.Title}' is not starting with uppercase."));
                            }

                            logItems.AddRange(ValidateSchemaModelNameCasing(validationOptions, schema));
                            break;
                        }

                    case OpenApiDataTypeConstants.Object:
                        {
                            if (string.IsNullOrEmpty(schema.Title))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema03, $"Missing title on object type '{schema.Reference.ReferenceV3}'."));
                            }
                            else if (schema.Title.IsFirstCharacterLowerCase())
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema04, $"Title on object type '{schema.Title}' is not starting with uppercase."));
                            }

                            foreach (var (key, value) in schema.Properties)
                            {
                                if (value.Type == OpenApiDataTypeConstants.Array)
                                {
                                    if (!value.IsReferenceTypeDeclared() && !value.IsItemsOfSimpleDataType())
                                    {
                                        logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema05, $"Implicit object definition on property '{key}' in array type '{schema.Reference.ReferenceV3}' is not supported."));
                                    }
                                }
                                else
                                {
                                    logItems.AddRange(ValidateSchemaModelPropertyNameCasing(validationOptions, key, schema));
                                }
                            }

                            logItems.AddRange(ValidateSchemaModelNameCasing(validationOptions, schema));
                            break;
                        }
                }
            }

            return logItems;
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static List<LogKeyValueItem> ValidateOperations(
            ApiOptionsValidation validationOptions,
            Dictionary<string, OpenApiPathItem>.ValueCollection paths,
            IDictionary<string, OpenApiSchema> modelSchemas)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            foreach (var path in paths)
            {
                foreach (var (key, value) in path.Operations)
                {
                    if (string.IsNullOrEmpty(value.OperationId))
                    {
                        logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation01, $"Missing OperationId in path '{key} # {path}'."));
                    }
                    else
                    {
                        if (!value.OperationId.IsCasingStyleValid(validationOptions.OperationIdCasingStyle))
                        {
                            logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation02, $"OperationId '{value.OperationId}' is not using {validationOptions.OperationIdCasingStyle}."));
                        }

                        if (key == OperationType.Get)
                        {
                            if (!value.OperationId.StartsWith("Get", StringComparison.OrdinalIgnoreCase) &&
                                !value.OperationId.StartsWith("List", StringComparison.OrdinalIgnoreCase))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation03, $"OperationId should start with the prefix 'Get' or 'List' for operation '{value.GetOperationName()}'."));
                            }
                        }
                        else if (key == OperationType.Post)
                        {
                            if (value.OperationId.StartsWith("Delete", StringComparison.OrdinalIgnoreCase))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation04, $"OperationId should not start with the prefix 'Delete' for operation '{value.GetOperationName()}'."));
                            }
                        }
                        else if (key == OperationType.Put)
                        {
                            if (!value.OperationId.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation05, $"OperationId should start with the prefix 'Update' for operation '{value.GetOperationName()}'."));
                            }
                        }
                        else if (key == OperationType.Patch)
                        {
                            if (!value.OperationId.StartsWith("Patch", StringComparison.OrdinalIgnoreCase) &&
                                !value.OperationId.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation06, $"OperationId should start with the prefix 'Update' for operation '{value.GetOperationName()}'."));
                            }
                        }
                        else if (key == OperationType.Delete &&
                                 !value.OperationId.StartsWith("Delete", StringComparison.OrdinalIgnoreCase) &&
                                 !value.OperationId.StartsWith("Remove", StringComparison.OrdinalIgnoreCase))
                        {
                            logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation07, $"OperationId should start with the prefix 'Delete' for operation '{value.GetOperationName()}'."));
                        }
                    }
                }

                foreach (var (_, value) in path.Operations)
                {
                    var modelSchema = value.GetModelSchema();
                    if (modelSchema != null)
                    {
                        if (value.OperationId.EndsWith("s", StringComparison.Ordinal))
                        {
                            if (!IsModelOfTypeArray(modelSchema, modelSchemas))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation08, $"OperationId '{value.GetOperationName()}' is not singular - Response model is defined as a single item."));
                            }
                        }
                        else
                        {
                            if (IsModelOfTypeArray(modelSchema, modelSchemas))
                            {
                                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation09, $"OperationId '{value.GetOperationName()}' is not pluralized - Response model is defined as an array."));
                            }
                        }
                    }
                }
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ValidatePathsAndOperations(
            ApiOptionsValidation validationOptions,
            OpenApiPaths paths)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            foreach (var path in paths)
            {
                if (!path.Key.IsStringFormatParametersBalanced(false))
                {
                    logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Path01, $"Path parameters are not well-formatted for '{path.Key}'."));
                }

                var globalPathParameterNames = path.Value.Parameters
                    .Where(x => x.In == ParameterLocation.Path)
                    .Select(x => x.Name)
                    .ToList();

                if (globalPathParameterNames.Any())
                {
                    logItems.AddRange(ValidatePathsAndOperationsHelper.ValidateGlobalParameters(validationOptions, globalPathParameterNames, path));
                }
                else
                {
                    logItems.AddRange(ValidatePathsAndOperationsHelper.ValidateMissingOperationParameters(validationOptions, path));
                    logItems.AddRange(ValidatePathsAndOperationsHelper.ValidateOperationsWithParametersNotPresentInPath(validationOptions, path));
                }

                logItems.AddRange(ValidatePathsAndOperationsHelper.ValidateGetOperations(validationOptions, path));
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ValidateOperationsParametersAndResponses(
            ApiOptionsValidation validationOptions,
            Dictionary<string, OpenApiPathItem>.ValueCollection paths)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            foreach (var path in paths)
            {
                foreach (var (_, value) in path.Operations)
                {
                    var httpStatusCodes = value.Responses.GetHttpStatusCodes();
                    if (httpStatusCodes.Contains(HttpStatusCode.BadRequest) &&
                        !value.HasParametersOrRequestBody() && !path.HasParameters())
                    {
                        logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Operation10, $"Contains BadRequest response type for operation '{value.GetOperationName()}', but has no parameters."));
                    }
                }
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ValidateSchemaModelNameCasing(
            ApiOptionsValidation validationOptions,
            OpenApiSchema schema)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            var modelName = schema.GetModelName(false);
            if (!modelName.IsCasingStyleValid(validationOptions.ModelNameCasingStyle))
            {
                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema06, $"Object '{modelName}' is not using {validationOptions.ModelNameCasingStyle}."));
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ValidateSchemaModelPropertyNameCasing(
            ApiOptionsValidation validationOptions,
            string key,
            OpenApiSchema schema)
        {
            var logItems = new List<LogKeyValueItem>();
            var logCategory = validationOptions.StrictMode
                ? LogCategoryType.Error
                : LogCategoryType.Warning;

            if (!key.IsCasingStyleValid(validationOptions.ModelPropertyNameCasingStyle))
            {
                logItems.Add(LogItemHelper.Create(logCategory, ValidationRuleNameConstants.Schema07, $"Object '{schema.Title}' with property '{key}' is not using {validationOptions.ModelPropertyNameCasingStyle}."));
            }

            return logItems;
        }

        private static bool IsModelOfTypeArray(OpenApiSchema schema, IDictionary<string, OpenApiSchema> modelSchemas)
        {
            var modelType = schema.GetModelType();
            if (modelType == null && schema.Reference.Id != null)
            {
                var (key, value) = modelSchemas.FirstOrDefault(x => x.Key.Equals(schema.Reference.Id, StringComparison.OrdinalIgnoreCase));
                if (key != null)
                {
                    return value.Type != null && value.Type.EndsWith(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
                }
            }

            return modelType != null && modelType.EndsWith(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
        }
    }
}