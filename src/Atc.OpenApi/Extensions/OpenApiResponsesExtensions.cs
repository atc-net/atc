using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiResponsesExtensions
    {
        public static List<HttpStatusCode> GetHttpStatusCodes(this OpenApiResponses responses)
        {
            if (responses == null)
            {
                throw new ArgumentNullException(nameof(responses));
            }

            var result = new List<HttpStatusCode>();
            foreach (var responseKey in responses.Keys.OrderBy(x => x))
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

        public static bool HasSchemaTypeOfArray(this OpenApiResponses responses)
        {
            if (responses == null)
            {
                throw new ArgumentNullException(nameof(responses));
            }

            foreach (var response in responses)
            {
                if (response.Value?.Content == null)
                {
                    continue;
                }

                if (response.Value.Content.Any(x => x.Value.Schema?.Type == OpenApiDataTypeConstants.Array))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasSchemaTypeOfHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
        {
            if (responses == null)
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

        public static bool HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
        {
            if (responses == null)
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

        public static OpenApiSchema? GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode, string contentType = MediaTypeNames.Application.Json)
        {
            foreach (var (key, value) in responses.OrderBy(x => x.Key))
            {
                if (!key.Equals(httpStatusCode.ToString(), StringComparison.OrdinalIgnoreCase) &&
                    !key.Equals($"{(int)httpStatusCode}", StringComparison.Ordinal))
                {
                    continue;
                }

                if (value == null)
                {
                    continue;
                }

                return value.Content.GetSchema(contentType);
            }

            return null;
        }

        public static string GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
        {
            var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
            return responseSchema == null
                ? string.Empty
                : responseSchema.GetModelName();
        }

        public static string GetDataTypeForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
        {
            var responseSchema = responses.GetSchemaForStatusCode(httpStatusCode);
            return responseSchema == null
                ? string.Empty
                : responseSchema.GetDataType();
        }

        public static bool IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
        {
            return responses.GetSchemaForStatusCode(httpStatusCode)?.Type == OpenApiDataTypeConstants.Array;
        }

        public static bool IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
        {
            var schema = responses.GetSchemaForStatusCode(httpStatusCode);
            return schema != null &&
                   schema.AllOf.Count == 2 &&
                   (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                    NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
        {
            return responses.GetSchemaForStatusCode(httpStatusCode)?.Reference?.Id == nameof(ProblemDetails);
        }
    }
}