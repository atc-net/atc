// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

public static class OpenApiResponsesExtensions
{
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

            var httpStatusCode = parsedType is HttpStatusCode code ? code : 0;
            result.Add(httpStatusCode);
        }

        return result;
    }

    public static string GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
        return responseSchema is null
            ? string.Empty
            : responseSchema.GetModelName();
    }

    public static string GetDataTypeForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
        return responseSchema is null
            ? string.Empty
            : responseSchema.GetDataType();
    }

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

    public static bool IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var schema = responses.GetSchemaForStatusCode(httpStatusCode);
        return schema is not null && schema.IsTypeArray();
    }

    public static bool IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        var schema = responses.GetSchemaForStatusCode(httpStatusCode);
        return schema is not null &&
               schema.AllOf.Count == 2 &&
               (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase));
    }

    public static bool IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
    {
        return string.Equals(responses.GetSchemaForStatusCode(httpStatusCode)?.Reference?.Id, nameof(ProblemDetails), StringComparison.Ordinal);
    }

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