// ReSharper disable UseDeconstructionOnParameter
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiPathItem"/>.
/// </summary>
public static class OpenApiPathItemExtensions
{
    /// <summary>
    /// Determines whether the path starts with the specified segment name.
    /// The comparison is case-insensitive and handles singular/plural forms and hyphenated names.
    /// </summary>
    /// <param name="urlPath">The path key-value pair to check.</param>
    /// <param name="segmentName">The segment name to match against the first path segment.</param>
    /// <returns>True if the path starts with the specified segment name; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="segmentName"/> is null.</exception>
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

    /// <summary>
    /// Determines whether the <see cref="OpenApiPathItem"/> has any parameters defined.
    /// </summary>
    /// <param name="openApiPathItem">The <see cref="OpenApiPathItem"/> to check.</param>
    /// <returns>True if the path item has one or more parameters; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="openApiPathItem"/> is null.</exception>
    public static bool HasParameters(this OpenApiPathItem openApiPathItem)
    {
        if (openApiPathItem is null)
        {
            throw new ArgumentNullException(nameof(openApiPathItem));
        }

        return openApiPathItem.Parameters.Any();
    }
}