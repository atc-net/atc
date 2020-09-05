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
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (basePathSegmentName == null)
            {
                throw new ArgumentNullException(nameof(basePathSegmentName));
            }

            var startName = basePathSegmentName.EnsureSingular();
            return document.Paths
                .OrderBy(x => x.Key)
                .Where(x => x.Key.StartsWith(startName, StringComparison.Ordinal) ||
                            x.Key.StartsWith("/" + startName, StringComparison.Ordinal)).ToList();
        }
    }
}