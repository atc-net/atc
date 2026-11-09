namespace Atc.Nuget;

/// <summary>
/// Looks up package versions on a NuGet feed.
/// </summary>
/// <remarks>
/// Implementations are best effort: a lookup that cannot be answered (no network, an unknown package,
/// a feed that answers something unexpected, a cancellation) gives <see langword="null"/> instead of throwing,
/// so a caller such as a start-up update check never fails because of the feed.
/// </remarks>
public interface INugetFeedClient
{
    /// <summary>
    /// Gets the latest stable (non-prerelease) version of a package.
    /// </summary>
    /// <param name="packageId">The package id, for example <c>Atc</c>. Package ids are case-insensitive.</param>
    /// <param name="cancellationToken">A token that cancels the lookup; a cancelled lookup gives <see langword="null"/>.</param>
    /// <returns>
    /// The highest stable version on the feed, or <see langword="null"/> when the package is unknown,
    /// has only prerelease versions, or the feed cannot be read.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="packageId"/> is null, empty or white space.</exception>
    Task<Version?> GetLatestStableVersionAsync(
        string packageId,
        CancellationToken cancellationToken);
}