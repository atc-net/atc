using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable UseDeconstruction
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiOperationExtensions
    {
        private const string RegexPatternUppercase = @"(?<!^)(?=[A-Z])";

        public static string GetOperationName(this OpenApiOperation openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            if (openApiOperation.OperationId == null)
            {
                return string.Empty;
            }

            return openApiOperation
                .OperationId
                .PascalCase(true)
                .EnsureFirstCharacterToUpper();
        }

        public static OpenApiSchema? GetModelSchemaFromResponse(this OpenApiOperation openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            var httpStatusCodes = openApiOperation.Responses.GetHttpStatusCodes();
            foreach (var httpStatusCode in httpStatusCodes)
            {
                if (httpStatusCode == HttpStatusCode.OK ||
                    httpStatusCode == HttpStatusCode.Created)
                {
                    var modelSchema = openApiOperation.Responses.GetSchemaForStatusCode(httpStatusCode);
                    if (modelSchema != null)
                    {
                        return modelSchema;
                    }
                }
            }

            return null;
        }

        public static OpenApiSchema? GetModelSchemaFromRequest(this OpenApiOperation openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            return openApiOperation.RequestBody?.Content?.GetSchema();
        }

        public static bool HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            return openApiOperation.Parameters.Any() || openApiOperation.RequestBody != null;
        }

        public static bool IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            if (schemaKey == null)
            {
                throw new ArgumentNullException(nameof(schemaKey));
            }

            // Check Responses
            if (IsOperationReferencingSchemaCheckResponses(openApiOperation, schemaKey))
            {
                return true;
            }

            // Check RequestBody
            if (IsOperationReferencingSchemaCheckRequestBody(openApiOperation, schemaKey))
            {
                return true;
            }

            return false;
        }

        public static bool IsOperationNamePluralized(this OpenApiOperation openApiOperation, OperationType operationType)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            string operationName = openApiOperation.GetOperationName();

            // Remove Http-verb
            if (operationName.StartsWith(operationType.ToString(), StringComparison.Ordinal))
            {
                operationName = operationName.Substring(operationType.ToString().Length);
            }

            // Split by uppercase
            var sa = Regex.Split(operationName, RegexPatternUppercase);
            if (sa.Length > 0)
            {
                // Test for last-term
                var termWord = sa.Last();
                if (termWord.EndsWith("s", StringComparison.Ordinal) &&
                    !(termWord.Equals("Ids", StringComparison.Ordinal) ||
                      termWord.Equals("Identifiers", StringComparison.Ordinal)))
                {
                    return true;
                }

                // Test for first-term
                termWord = sa.First();
                if (termWord.EndsWith("s", StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsOperationIdPluralized(this OpenApiOperation openApiOperation, OperationType operationType)
        {
            return IsOperationNamePluralized(openApiOperation, operationType);
        }

        public static bool HasDataTypeFromSystemCollectionGenericNamespace(this List<OpenApiOperation> apiOperations)
        {
            if (apiOperations == null)
            {
                throw new ArgumentNullException(nameof(apiOperations));
            }

            foreach (var apiOperation in apiOperations)
            {
                foreach (var response in apiOperation.Responses.Values)
                {
                    foreach (var mediaType in response.Content.Values)
                    {
                        if (string.Equals(mediaType.Schema.Type, OpenApiDataTypeConstants.Array, StringComparison.Ordinal))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static bool IsOperationReferencingSchemaCheckResponses(OpenApiOperation openApiOperation, string schemaKey)
        {
            if (openApiOperation.Responses != null && openApiOperation.Responses.Any())
            {
                foreach (var response in openApiOperation.Responses)
                {
                    if (response.Value?.Content == null || !response.Value.Content.Any())
                    {
                        continue;
                    }

                    foreach (var mediaType in response.Value.Content)
                    {
                        if (mediaType.Value.Schema == null)
                        {
                            continue;
                        }

                        if (string.Equals(mediaType.Value.Schema.Reference?.Id, schemaKey, StringComparison.Ordinal))
                        {
                            return true;
                        }

                        foreach (var property in mediaType.Value.Schema.Properties)
                        {
                            if (string.Equals(property.Value.Reference?.Id, schemaKey, StringComparison.Ordinal))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static bool IsOperationReferencingSchemaCheckRequestBody(OpenApiOperation openApiOperation, string schemaKey)
        {
            if (openApiOperation.RequestBody?.Content != null)
            {
                foreach (var item in openApiOperation.RequestBody.Content)
                {
                    if (item.Value.Schema == null)
                    {
                        continue;
                    }

                    if (string.Equals(item.Value.Schema.Reference?.Id, schemaKey, StringComparison.Ordinal))
                    {
                        return true;
                    }

                    foreach (var property in item.Value.Schema.Properties)
                    {
                        if (string.Equals(property.Value.Reference?.Id, schemaKey, StringComparison.Ordinal))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}