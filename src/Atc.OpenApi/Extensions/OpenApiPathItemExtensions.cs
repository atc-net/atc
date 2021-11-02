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

            var sa = urlPath.Key.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (string.IsNullOrEmpty(segmentName) && sa.Length == 0)
            {
                return true;
            }

            if (sa.Length == 0)
            {
                return false;
            }

            var routeSegmentName = sa[0].Replace("-", string.Empty, StringComparison.Ordinal);

            return segmentName.Equals(routeSegmentName, StringComparison.OrdinalIgnoreCase) ||
                   segmentName.Equals(routeSegmentName.EnsureSingular(), StringComparison.OrdinalIgnoreCase);
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