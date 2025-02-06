// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

public static class VersionExtensions
{
    /// <summary>
    /// Is 'version' greater than the 'otherVersion', where the significantParts is the stop part.
    /// Example significantParts=2, then only Major and Minor wil be taken into consideration.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts (default is 4 which means [major.minor.build.revision] ).</param>
    /// <param name="startingPart">The starting parts (default is 1 which means all 4 significant parts).</param>
    /// <returns>-1, 0 or 1.</returns>
    /// <example>
    /// - Set significantParts = 4 and startingPart 1 => [major.minor.build.revision]
    /// - Set significantParts = 4 and startingPart 2 => major.[minor.build.revision]
    /// - Set significantParts = 3 and startingPart 1 => [major.minor.build]
    /// - Set significantParts = 3 and startingPart 2 => major.[minor.build]
    /// </example>
    /// <exception cref="ArgumentNullException">version.</exception>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static int CompareTo(
        this Version version,
        Version? otherVersion,
        int significantParts = 4,
        int startingPart = 1)
    {
        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (significantParts is < 0 or > 4)
        {
            throw new ArgumentOutOfRangeException(nameof(significantParts), "Has to be between/or 0 and 4");
        }

        if (startingPart is < 0 or > 4)
        {
            throw new ArgumentOutOfRangeException(nameof(startingPart), "Has to be between/or 0 and 4");
        }

        if (startingPart > significantParts)
        {
            throw new ArgumentException("lessSignificantParts have be greater than significantParts", nameof(startingPart));
        }

        if (otherVersion is null)
        {
            return 1;
        }

        if (version.Major != otherVersion.Major && significantParts >= 1 && startingPart <= 1)
        {
            return version.Major > otherVersion.Major ? 1 : -1;
        }

        if (version.Minor != otherVersion.Minor && significantParts >= 2 && startingPart <= 2)
        {
            return version.Minor > otherVersion.Minor ? 1 : -1;
        }

        if (version.Build != otherVersion.Build && significantParts >= 3 && startingPart <= 3)
        {
            return version.Build > otherVersion.Build ? 1 : -1;
        }

        if (version.Revision != otherVersion.Revision && significantParts >= 4)
        {
            return version.Revision > otherVersion.Revision ? 1 : -1;
        }

        return 0;
    }

    /// <summary>
    /// Is 'version' greater than the 'otherVersion'.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts.</param>
    /// <param name="startingPart">The starting parts.</param>
    /// <returns>
    ///   <see langword="true" /> if 'otherVersion' is greater than the current 'version'; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">version.</exception>
    public static bool GreaterThan(
        this Version version,
        Version? otherVersion,
        int significantParts = 4,
        int startingPart = 1)
    {
        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (otherVersion is null)
        {
            return true;
        }

        return version.CompareTo(otherVersion, significantParts, startingPart) > 0;
    }

    /// <summary>
    /// Is 'version' greater than or equal to the 'otherVersion'.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts.</param>
    /// <param name="startingPart">The starting parts.</param>
    /// <returns>
    ///   <see langword="true" /> if 'otherVersion' is greater than or equal to the current 'version'; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">version.</exception>
    public static bool GreaterThanOrEqualTo(
        this Version version,
        Version? otherVersion,
        int significantParts = 4,
        int startingPart = 1)
    {
        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (otherVersion is null)
        {
            return true;
        }

        return version.CompareTo(otherVersion, significantParts, startingPart) >= 0;
    }

    /// <summary>Determines whether 'version' is newer than the 'otherVersion'.</summary>
    /// <param name="version">The version.</param>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="withinMinorReleaseOnly">if set to <see langword="true" /> Than major has to be the same or smaller.</param>
    /// <example>
    ///   For withinMinorReleaseOnly = true:
    ///     4.8.8.0 is newer than 4.5.3.3
    ///     4.5.8.0 is newer than 4.5.3.3
    ///     4.8.3.0 is newer than 4.5.3.3
    ///     4.5.4.0 is newer than 4.5.3.3
    ///     4.5.3.0 is NOT newer than 4.5.3.3
    ///     5.8.8.0 is NOT newer than 4.5.3.3
    ///
    ///   For withinMinorReleaseOnly = false:
    ///     4.8.8.0 is newer than 4.5.3.3
    ///     4.5.8.0 is newer than 4.5.3.3
    ///     4.8.3.0 is newer than 4.5.3.3
    ///     4.5.4.0 is newer than 4.5.3.3
    ///     4.5.3.0 is NOT newer than 4.5.3.3
    ///     5.8.8.0 is newer than 4.5.3.3
    /// </example>
    /// <returns>
    ///   <see langword="true" /> if 'otherVersion' is newer than the 'version'; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsNewerThan(
        this Version version,
        Version? otherVersion,
        bool withinMinorReleaseOnly = false)
    {
        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (otherVersion is null)
        {
            return true;
        }

        if (withinMinorReleaseOnly)
        {
            return version.Major == otherVersion.Major &&
                   version.GreaterThan(otherVersion, significantParts: 4, startingPart: 2);
        }

        return version.GreaterThan(otherVersion);
    }
}