// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

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
            .Where(x => x.IsPathStartingSegmentName(startName))
            .OrderBy(x => x.Key, StringComparer.Ordinal)
            .ToList();
    }
}