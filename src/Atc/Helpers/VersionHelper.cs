namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for comparing and handling version strings and Version objects.
/// </summary>
public static class VersionHelper
{
    /// <summary>
    /// Compares two version strings to determine if the source version is newer than the destination version.
    /// </summary>
    /// <param name="sourceVersion">The source version as a string.</param>
    /// <param name="destinationVersion">The destination version as a string.</param>
    /// <returns>
    /// True if the source version is newer than the destination version; otherwise, false.
    /// </returns>
    /// <remarks>
    /// If either version string is null, or if they are equal, the method returns false.
    /// If the version strings cannot be parsed into System.Version, a lexical comparison is performed.
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
    public static bool IsSourceNewerThanDestination(
        string? sourceVersion,
        string? destinationVersion)
    {
        if (sourceVersion is null ||
            destinationVersion is null ||
            sourceVersion == destinationVersion)
        {
            return false;
        }

        try
        {
            return IsSourceNewerThanDestination(
                new Version(sourceVersion),
                new Version(destinationVersion));
        }
        catch
        {
            var sortedSet = new SortedSet<string>(StringComparer.Ordinal)
            {
                sourceVersion,
                destinationVersion,
            };

            return destinationVersion == sortedSet.First();
        }
    }

    /// <summary>
    /// Compares two Version objects to determine if the source version is newer than the destination version.
    /// </summary>
    /// <param name="sourceVersion">The source version as a Version object.</param>
    /// <param name="destinationVersion">The destination version as a Version object.</param>
    /// <returns>
    /// True if the source version is newer than the destination version; otherwise, false.
    /// </returns>
    /// <remarks>
    /// If either Version object is null, or if they are equal, the method returns false.
    /// </remarks>
    public static bool IsSourceNewerThanDestination(
        Version? sourceVersion,
        Version? destinationVersion)
    {
        if (sourceVersion is null ||
            destinationVersion is null ||
            sourceVersion == destinationVersion)
        {
            return false;
        }

        return sourceVersion.IsNewerThan(destinationVersion);
    }

    /// <summary>
    /// Determines whether both source and destination versions are the default version ("1.0.0.0").
    /// </summary>
    /// <param name="sourceVersion">The source version as a Version object.</param>
    /// <param name="destinationVersion">The destination version as a Version object.</param>
    /// <returns>
    /// True if both versions are "1.0.0.0"; otherwise, false.
    /// </returns>
    public static bool IsDefault(
        Version? sourceVersion,
        Version? destinationVersion)
    {
        if (sourceVersion is null ||
            destinationVersion is null)
        {
            return false;
        }

        return "1.0.0.0".Equals(sourceVersion.ToString(), StringComparison.Ordinal) &&
               "1.0.0.0".Equals(destinationVersion.ToString(), StringComparison.Ordinal);
    }
}