using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    internal static class OpenApiResponsesExtensions
    {
        public static List<string> GetProducesResponseAttributeParts(this OpenApiResponses responses, string resultTypeName, bool useProblemDetailsAsDefaultResponseBody, string contractArea)
        {
            var result = new List<string>();
            foreach (var response in responses.OrderBy(x => x.Key))
            {
                if (!Enum.TryParse(typeof(HttpStatusCode), response.Key, out var parsedType))
                {
                    continue;
                }

                var httpStatusCode = parsedType is HttpStatusCode code ? code : 0;

                var isList = responses.IsSchemaTypeArrayForStatusCode(httpStatusCode);
                var modelName = responses.GetModelNameForStatusCode(httpStatusCode);
                modelName = EnsureModelNameNamespaceIfNeeded(modelName, contractArea);

                var useProblemDetails = responses.IsSchemaTypeProblemDetailsForStatusCode(httpStatusCode);
                if (!useProblemDetails && useProblemDetailsAsDefaultResponseBody)
                {
                    useProblemDetails = true;
                }

                string? typeResponseName;
                switch (httpStatusCode)
                {
                    case HttpStatusCode.OK:
                        if (string.IsNullOrEmpty(modelName))
                        {
                            typeResponseName = "string";
                        }
                        else
                        {
                            if (isList)
                            {
                                typeResponseName = $"List<{modelName}>";
                            }
                            else
                            {
                                var isPagination = responses.IsSchemaTypePaginationForStatusCode(httpStatusCode);
                                typeResponseName = isPagination
                                    ? $"{NameConstants.Pagination}<{modelName}>"
                                    : modelName;
                            }
                        }

                        break;
                    case HttpStatusCode.Created:
                        typeResponseName = "string";
                        break;
                    case HttpStatusCode.Accepted:
                    case HttpStatusCode.NoContent:
                    case HttpStatusCode.NotModified:
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        typeResponseName = useProblemDetails
                            ? "ProblemDetails"
                            : null;
                        break;
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.Conflict:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotImplemented:
                    case HttpStatusCode.BadGateway:
                    case HttpStatusCode.ServiceUnavailable:
                    case HttpStatusCode.GatewayTimeout:
                        typeResponseName = useProblemDetails
                            ? "ProblemDetails"
                            : "string";
                        break;
                    default:
                        throw new NotImplementedException($"ProducesResponseType for {(int)httpStatusCode} - {httpStatusCode} is missing for '{resultTypeName}'.");
                }

                result.Add(typeResponseName == null
                    ? $"ProducesResponseType(StatusCodes.Status{response.Key}{httpStatusCode})"
                    : $"ProducesResponseType(typeof({typeResponseName}), StatusCodes.Status{response.Key}{httpStatusCode})");
            }

            return result;
        }

        private static string EnsureModelNameNamespaceIfNeeded(string modelName, string contractArea)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return modelName;
            }

            var reservedModelNames = new List<string>
            {
                nameof(Task),
                "Event",
            };

            return reservedModelNames.Contains(modelName)
                ? $"{Atc.Rest.ApiGenerator.NameConstants.Contracts}.{contractArea.EnsureFirstCharacterToUpper()}.{modelName}"
                : modelName;
        }
    }
}