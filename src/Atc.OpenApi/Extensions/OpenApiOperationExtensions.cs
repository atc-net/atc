using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UseDeconstruction
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiOperationExtensions
    {
        public static string GetOperationName(this OpenApiOperation openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            return openApiOperation
                .OperationId
                .PascalCase(true)
                .EnsureFirstLetterToUpper();
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
                        foreach (var property in mediaType.Value.Schema.Properties)
                        {
                            if (property.Value.Reference == null)
                            {
                                continue;
                            }

                            if (property.Value.Reference.Id == schemaKey)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            // Check RequestBody
            if (openApiOperation.RequestBody?.Content != null)
            {
                foreach (var item in openApiOperation.RequestBody.Content)
                {
                    if (item.Value.Schema?.Title == null)
                    {
                        continue;
                    }

                    if (schemaKey == item.Value.Schema.Title.PascalCase(true))
                    {
                        return true;
                    }
                }
            }

            return false;
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
                        if (mediaType.Schema.Type == OpenApiDataTypeConstants.Array)
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