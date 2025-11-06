// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiDocument"/>.
/// </summary>
public static class OpenApiDocumentExtensions
{
    /// <summary>
    /// Retrieves all paths from the <see cref="OpenApiDocument"/> that start with the specified base path segment name.
    /// The segment name is normalized to singular form before matching, and results are sorted alphabetically.
    /// </summary>
    /// <param name="document">The <see cref="OpenApiDocument"/> to search.</param>
    /// <param name="basePathSegmentName">The base path segment name to filter paths by.</param>
    /// <returns>An ordered list of key-value pairs containing paths that start with the specified segment name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="document"/> or <paramref name="basePathSegmentName"/> is null.</exception>
    public static List<KeyValuePair<string, OpenApiPathItem>> GetPathsByBasePathSegmentName(
        this OpenApiDocument document,
        string basePathSegmentName)
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