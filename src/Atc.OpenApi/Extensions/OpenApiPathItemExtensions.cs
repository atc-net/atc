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
            if (segmentName == null)
            {
                throw new ArgumentNullException(nameof(segmentName));
            }

            return urlPath.Key.StartsWith(segmentName, StringComparison.OrdinalIgnoreCase) ||
                   urlPath.Key.StartsWith($"/{segmentName}", StringComparison.OrdinalIgnoreCase);
        }

        public static bool HasParameters(this OpenApiPathItem openApiOperation)
        {
            if (openApiOperation == null)
            {
                throw new ArgumentNullException(nameof(openApiOperation));
            }

            return openApiOperation.Parameters.Any();
        }
    }
}