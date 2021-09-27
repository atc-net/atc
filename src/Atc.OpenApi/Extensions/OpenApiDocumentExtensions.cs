using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiDocumentExtensions
    {
        public static List<KeyValuePair<string, OpenApiPathItem>> GetPathsByBasePathSegmentName(this OpenApiDocument document, string basePathSegmentName)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (basePathSegmentName is null)
            {
                throw new ArgumentNullException(nameof(basePathSegmentName));
            }

            var startName = basePathSegmentName.EnsureSingular();
            return document.Paths
                .OrderBy(x => x.Key)
                .Where(x => x.IsPathStartingSegmentName(startName)).ToList();
        }
    }
}