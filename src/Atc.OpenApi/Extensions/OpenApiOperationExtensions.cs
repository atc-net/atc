// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable UseDeconstruction
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

public static class OpenApiOperationExtensions
{
    private const string RegexPatternUppercase = @"(?<!^)(?=[A-Z])";

    public static string GetOperationName(this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        if (openApiOperation.OperationId is null)
        {
            return string.Empty;
        }

        return openApiOperation
            .OperationId
            .PascalCase(removeSeparators: true)
            .EnsureFirstCharacterToUpper();
    }

    public static OpenApiSchema? GetModelSchemaFromResponse(this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
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
                if (modelSchema is not null)
                {
                    return modelSchema;
                }
            }
        }

        return null;
    }

    public static OpenApiSchema? GetModelSchemaFromRequest(this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return openApiOperation.RequestBody?.Content?.GetSchema();
    }

    public static bool HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return openApiOperation.Parameters.Any() || openApiOperation.RequestBody is not null;
    }

    public static bool HasRequestBodyWithAnythingAsFormatTypeBinary(this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        var schema = openApiOperation.RequestBody?.Content?.GetSchemaByFirstMediaType();
        return schema is not null && schema.HasAnythingAsFormatTypeBinary();
    }

    public static bool IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        if (schemaKey is null)
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
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        var operationName = openApiOperation.GetOperationName();

        // Remove Http-verb
        if (operationName.StartsWith(operationType.ToString(), StringComparison.Ordinal))
        {
            operationName = operationName.Substring(operationType.ToString().Length);
        }

        // Split by uppercase
        var sa = Regex.Split(operationName, RegexPatternUppercase, RegexOptions.None, TimeSpan.FromSeconds(1));
        if (sa.Length > 0)
        {
            // Test for last-term
            var termWord = sa.Last();
            if (termWord.EndsWith('s') &&
                !(termWord.Equals("Ids", StringComparison.Ordinal) ||
                  termWord.Equals("Identifiers", StringComparison.Ordinal) ||
                  termWord.Equals("Status", StringComparison.Ordinal)))
            {
                return true;
            }

            // Test for first-term
            termWord = sa.First();
            if (termWord.EndsWith('s'))
            {
                return true;
            }

            if (sa.Any(x => x.Equals("By", StringComparison.Ordinal)))
            {
                var index = Array.IndexOf(sa, "By");
                if (index > 1)
                {
                    termWord = sa[index - 1];
                    if (termWord.EndsWith('s'))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public static bool IsOperationIdPluralized(this OpenApiOperation openApiOperation, OperationType operationType)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return IsOperationNamePluralized(openApiOperation, operationType);
    }

    public static bool HasDataTypeFromSystemCollectionGenericNamespace(this List<OpenApiOperation> apiOperations)
    {
        if (apiOperations is null)
        {
            throw new ArgumentNullException(nameof(apiOperations));
        }

        foreach (var apiOperation in apiOperations)
        {
            foreach (var response in apiOperation.Responses.Values)
            {
                foreach (var mediaType in response.Content.Values)
                {
                    if (mediaType.Schema.IsTypeArray())
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
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        if (string.IsNullOrEmpty(schemaKey))
        {
            throw new ArgumentNullException(nameof(schemaKey));
        }

        if (openApiOperation.Responses is not null && openApiOperation.Responses.Any())
        {
            foreach (var response in openApiOperation.Responses)
            {
                if (response.Value?.Content is null || !response.Value.Content.Any())
                {
                    continue;
                }

                foreach (var mediaType in response.Value.Content)
                {
                    if (mediaType.Value.Schema is null)
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

    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    private static bool IsOperationReferencingSchemaCheckRequestBody(OpenApiOperation openApiOperation, string schemaKey)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        if (string.IsNullOrEmpty(schemaKey))
        {
            throw new ArgumentNullException(nameof(schemaKey));
        }

        if (openApiOperation.RequestBody?.Content is null)
        {
            return false;
        }

        foreach (var item in openApiOperation.RequestBody.Content)
        {
            if (item.Value.Schema is null)
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

        return false;
    }
}