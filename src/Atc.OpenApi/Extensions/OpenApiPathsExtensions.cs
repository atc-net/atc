// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiPaths"/>.
/// </summary>
public static class OpenApiPathsExtensions
{
    /// <summary>
    /// Retrieves all paths from the <see cref="OpenApiPaths"/> collection that start with the specified segment name.
    /// </summary>
    /// <param name="urlPaths">The <see cref="OpenApiPaths"/> collection to filter.</param>
    /// <param name="segmentName">The segment name to match at the beginning of paths.</param>
    /// <returns>A list of key-value pairs containing paths that start with the specified segment name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="segmentName"/> is null.</exception>
    public static List<KeyValuePair<string, OpenApiPathItem>> GetPathsStartingWithSegmentName(
        this OpenApiPaths urlPaths,
        string segmentName)
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