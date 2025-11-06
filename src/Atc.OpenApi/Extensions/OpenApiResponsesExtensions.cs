// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiResponses"/>.
/// </summary>
public static class OpenApiResponsesExtensions
{
    /// <summary>
    /// Extracts all HTTP status codes defined in the <see cref="OpenApiResponses"/> collection.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to process.</param>
    /// <returns>A list of <see cref="HttpStatusCode"/> values parsed from the response keys.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="responses"/> is null.</exception>
    public static List<HttpStatusCode> GetHttpStatusCodes(this OpenApiResponses responses)
    {
        if (responses is null)
        {
            throw new ArgumentNullException(nameof(responses));
        }

        var result = new List<HttpStatusCode>();
        foreach (var responseKey in responses.Keys.OrderBy(x => x, StringComparer.Ordinal))
        {
            if (!Enum.TryParse(typeof(HttpStatusCode), responseKey, out var parsedType))
            {
                continue;
            }

            result.Add((HttpStatusCode)parsedType);
        }

        return result;
    }

    /// <summary>
    /// Retrieves the model name from the schema associated with the specified HTTP status code.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to search.</param>
    /// <param name="httpStatusCode">The HTTP status code to retrieve the model name for.</param>
    /// <returns>The model name of the response schema, or an empty string if not found.</returns>
    public static string GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
        return responseSchema is null
            ? string.Empty
            : responseSchema.GetModelName();
    }

    /// <summary>
    /// Retrieves the data type from the schema associated with the specified HTTP status code.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to search.</param>
    /// <param name="httpStatusCode">The HTTP status code to retrieve the data type for.</param>
    /// <returns>The data type of the response schema, or an empty string if not found.</returns>
    public static string GetDataTypeForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
        return responseSchema is null
            ? string.Empty
            : responseSchema.GetDataType();
    }

    /// <summary>
    /// Determines whether any response in the collection has a schema with array type.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <returns>True if any response schema is an array type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="responses"/> is null.</exception>
    public static bool HasSchemaTypeArray(this OpenApiResponses responses)
    {
        if (responses is null)
        {
            throw new ArgumentNullException(nameof(responses));
        }

        foreach (var (_, value) in responses)
        {
            if (value?.Content is null)
            {
                continue;
            }

            if (value.Content.Any(x => x.Value.Schema is not null && x.Value.Schema.IsTypeArray()))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the responses contain any HTTP status codes that require the System.Net namespace.
    /// These include error status codes like BadRequest, InternalServerError, etc.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <returns>True if any response uses a System.Net HTTP status code; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="responses"/> is null.</exception>
    public static bool HasSchemaHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
    {
        if (responses is null)
        {
            throw new ArgumentNullException(nameof(responses));
        }

        var httpStatusCodes = responses.GetHttpStatusCodes();
        foreach (var httpStatusCode in httpStatusCodes)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the responses contain any HTTP status codes that require the Microsoft.AspNetCore.Http namespace.
    /// Currently checks for the Created (201) status code.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <returns>True if any response uses an ASP.NET Core HTTP status code; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="responses"/> is null.</exception>
    public static bool HasSchemaHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
    {
        if (responses is null)
        {
            throw new ArgumentNullException(nameof(responses));
        }

        var httpStatusCodes = responses.GetHttpStatusCodes();
        foreach (var httpStatusCode in httpStatusCodes)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.Created:
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Retrieves the <see cref="OpenApiSchema"/> for the specified HTTP status code and content type.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to search.</param>
    /// <param name="httpStatusCode">The HTTP status code to retrieve the schema for.</param>
    /// <param name="contentType">The content type to retrieve the schema for. Defaults to application/json.</param>
    /// <returns>The <see cref="OpenApiSchema"/> for the specified status code and content type, or null if not found.</returns>
    public static OpenApiSchema? GetSchemaForStatusCode(
        this OpenApiResponses responses,
        HttpStatusCode httpStatusCode,
        string contentType = MediaTypeNames.Application.Json)
    {
        foreach (var (key, value) in responses.OrderBy(x => x.Key, StringComparer.Ordinal))
        {
            if (!key.Equals(httpStatusCode.ToString(), StringComparison.OrdinalIgnoreCase) &&
                !key.Equals($"{(int)httpStatusCode}", StringComparison.Ordinal))
            {
                continue;
            }

            if (value is null)
            {
                continue;
            }

            return value.Content.GetSchema(contentType);
        }

        return null;
    }

    /// <summary>
    /// Determines whether the schema for the specified HTTP status code is an array type.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <param name="httpStatusCode">The HTTP status code to check the schema type for.</param>
    /// <returns>True if the response schema is an array type; otherwise, false.</returns>
    public static bool IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var schema = responses.GetSchemaForStatusCode(httpStatusCode);
        return schema is not null && schema.IsTypeArray();
    }

    /// <summary>
    /// Determines whether the schema for the specified HTTP status code is a pagination wrapper type.
    /// A pagination type is identified by having two allOf schemas where one references "Pagination".
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <param name="httpStatusCode">The HTTP status code to check the schema type for.</param>
    /// <returns>True if the response schema is a pagination type; otherwise, false.</returns>
    public static bool IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var schema = responses.GetSchemaForStatusCode(httpStatusCode);
        return schema is not null &&
               schema.AllOf.Count == 2 &&
               (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Determines whether the schema for the specified HTTP status code references ProblemDetails.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <param name="httpStatusCode">The HTTP status code to check the schema type for.</param>
    /// <returns>True if the response schema references ProblemDetails; otherwise, false.</returns>
    public static bool IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        return string.Equals(responses.GetSchemaForStatusCode(httpStatusCode)?.Reference?.Id, "ProblemDetails", StringComparison.Ordinal);
    }

    /// <summary>
    /// Determines whether the OK (200) response uses a binary format type schema.
    /// </summary>
    /// <param name="responses">The <see cref="OpenApiResponses"/> collection to check.</param>
    /// <returns>True if the OK response schema uses binary format; otherwise, false.</returns>
    public static bool IsSchemaUsingBinaryFormatForOkResponse(this OpenApiResponses responses)
    {
        foreach (var (key, value) in responses.OrderBy(x => x.Key, StringComparer.Ordinal))
        {
            if (!key.Equals(((int)HttpStatusCode.OK).ToString(CultureInfo.CurrentCulture), StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (value is null)
            {
                continue;
            }

            var schema = value.Content.GetSchemaByFirstMediaType();
            return schema is not null && schema.IsFormatTypeBinary();
        }

        return false;
    }
}