// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable UseDeconstruction
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiOperation"/>.
/// </summary>
public static class OpenApiOperationExtensions
{
    private const string RegexPatternUppercase = @"(?<!^)(?=[A-Z])";

    /// <summary>
    /// Retrieves the operation name from the <see cref="OpenApiOperation"/> in PascalCase format.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to extract the name from.</param>
    /// <returns>The operation name in PascalCase format, or an empty string if OperationId is null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static string GetOperationName(
        this OpenApiOperation openApiOperation)
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

    /// <summary>
    /// Retrieves the model schema from the operation's response for successful status codes (OK or Created).
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to extract the schema from.</param>
    /// <returns>The <see cref="OpenApiSchema"/> from the response, or null if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static OpenApiSchema? GetModelSchemaFromResponse(
        this OpenApiOperation openApiOperation)
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

    /// <summary>
    /// Retrieves the model schema from the operation's request body.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to extract the schema from.</param>
    /// <returns>The <see cref="OpenApiSchema"/> from the request body, or null if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static OpenApiSchema? GetModelSchemaFromRequest(
        this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return openApiOperation.RequestBody?.Content?.GetSchema();
    }

    /// <summary>
    /// Determines whether the operation has any parameters or a request body defined.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to check.</param>
    /// <returns>True if the operation has parameters or a request body; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static bool HasParametersOrRequestBody(
        this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return openApiOperation.Parameters.Any() || openApiOperation.RequestBody is not null;
    }

    /// <summary>
    /// Determines whether the operation's request body contains any binary format type data.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to check.</param>
    /// <returns>True if the request body contains binary format data; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static bool HasRequestBodyWithAnythingAsFormatTypeBinary(
        this OpenApiOperation openApiOperation)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        var schema = openApiOperation.RequestBody?.Content?.GetSchemaByFirstMediaType();
        return schema is not null && schema.HasAnythingAsFormatTypeBinary();
    }

    /// <summary>
    /// Determines whether the operation references the specified schema in its request body or responses.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to check.</param>
    /// <param name="schemaKey">The schema reference ID to search for.</param>
    /// <returns>True if the operation references the schema; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> or <paramref name="schemaKey"/> is null.</exception>
    public static bool IsOperationReferencingSchema(
        this OpenApiOperation openApiOperation,
        string schemaKey)
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

    /// <summary>
    /// Determines whether the operation name is pluralized based on naming conventions.
    /// This checks if the operation name ends with 's' or contains plural forms, excluding common exceptions like "Ids", "Identifiers", and "Status".
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to check.</param>
    /// <param name="operationType">The HTTP operation type (GET, POST, etc.) used to strip the verb prefix.</param>
    /// <returns>True if the operation name is pluralized; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static bool IsOperationNamePluralized(
        this OpenApiOperation openApiOperation,
        OperationType operationType)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        var operationName = openApiOperation.GetOperationName();

        // Remove Http-verb
        if (operationName.StartsWith(operationType.ToString(), StringComparison.Ordinal))
        {
            operationName = operationName[operationType.ToString().Length..];
        }

        // Split by uppercase
        var sa = Regex.Split(operationName, RegexPatternUppercase, RegexOptions.None, TimeSpan.FromSeconds(1));
        if (sa.Length > 0)
        {
            // Test for last-term
            var termWord = sa[^1];
            if (termWord.EndsWith('s') &&
                !(termWord.Equals("Ids", StringComparison.Ordinal) ||
                  termWord.Equals("Identifiers", StringComparison.Ordinal) ||
                  termWord.Equals("Details", StringComparison.Ordinal) ||
                  termWord.Equals("Status", StringComparison.Ordinal)))
            {
                return true;
            }

            // Test for first-term
            termWord = sa[0];
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
                    if (termWord.Equals("Details", StringComparison.Ordinal) ||
                        termWord.Equals("Status", StringComparison.Ordinal))
                    {
                        return false;
                    }

                    if (termWord.EndsWith('s'))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the operation ID is pluralized based on naming conventions.
    /// This is an alias for <see cref="IsOperationNamePluralized"/>.
    /// </summary>
    /// <param name="openApiOperation">The <see cref="OpenApiOperation"/> to check.</param>
    /// <param name="operationType">The HTTP operation type (GET, POST, etc.) used to strip the verb prefix.</param>
    /// <returns>True if the operation ID is pluralized; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiOperation"/> is null.</exception>
    public static bool IsOperationIdPluralized(
        this OpenApiOperation openApiOperation,
        OperationType operationType)
    {
        if (openApiOperation is null)
        {
            throw new ArgumentNullException(nameof(openApiOperation));
        }

        return IsOperationNamePluralized(openApiOperation, operationType);
    }

    /// <summary>
    /// Determines whether any operation in the collection has a response with array data type, requiring System.Collections.Generic namespace.
    /// </summary>
    /// <param name="apiOperations">The collection of <see cref="OpenApiOperation"/> to check.</param>
    /// <returns>True if any operation response contains array data types; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="apiOperations"/> is null.</exception>
    public static bool HasDataTypeFromSystemCollectionGenericNamespace(
        this List<OpenApiOperation> apiOperations)
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
    private static bool IsOperationReferencingSchemaCheckResponses(
        OpenApiOperation openApiOperation,
        string schemaKey)
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
    private static bool IsOperationReferencingSchemaCheckRequestBody(
        OpenApiOperation openApiOperation,
        string schemaKey)
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