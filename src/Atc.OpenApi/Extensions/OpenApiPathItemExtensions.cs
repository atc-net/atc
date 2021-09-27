using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UseDeconstructionOnParameter
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiPathItemExtensions
    {
        public static bool IsPathStartingSegmentName(this KeyValuePair<string, OpenApiPathItem> urlPath, string segmentName)
        {
            if (segmentName is null)
            {
                throw new ArgumentNullException(nameof(segmentName));
            }

            var urlPathKey = urlPath.Key.Replace("-", string.Empty, StringComparison.Ordinal);

            return urlPathKey.StartsWith(segmentName, StringComparison.OrdinalIgnoreCase) ||
                   urlPathKey.StartsWith($"/{segmentName}", StringComparison.OrdinalIgnoreCase);
        }

        public static bool HasParameters(this OpenApiPathItem openApiOperation)
        {
            if (openApiOperation is null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            return openApiOperation.Parameters.Any();
        }
    }
}