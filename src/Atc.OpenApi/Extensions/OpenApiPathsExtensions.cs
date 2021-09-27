using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiPathsExtensions
    {
        public static List<KeyValuePair<string, OpenApiPathItem>> GetPathsStartingWithSegmentName(this OpenApiPaths urlPaths, string segmentName)
        {
            if (segmentName is null)
            {
                throw new ArgumentNullException(nameof(segmentName));
            }

            return urlPaths
                .Where(x => x.IsPathStartingSegmentName(segmentName))
                .ToList();
        }
    }
}