// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable IdentifierTypo
// ReSharper disable InvertIf
// ReSharper disable NonReadonlyMemberInGetHashCode
// ReSharper disable StringLiteralTypo
namespace Atc.Data.SemVer;

/// <summary>
/// Represents a version object, compliant with the Semantic Version standard 2.0 (http://semver.org).
/// </summary>
[Serializable]
public sealed class SemanticVersion : IComparable, IComparable<SemanticVersion>, IEquatable<SemanticVersion>
{
    private static readonly Regex StrictModeRegex = new(
        @"^
            \s*v?
            ([0-9]|[1-9][0-9]+)       # major version
            \.
            ([0-9]|[1-9][0-9]+)       # minor version
            \.
            ([0-9]|[1-9][0-9]+)       # patch version
            (\-([0-9A-Za-z\-\.]+))?   # pre-release version
            (\+([0-9A-Za-z\-\.]+))?   # build metadata
            \s*
            $",
        RegexOptions.IgnorePatternWhitespace,
        TimeSpan.FromSeconds(3));

    private static readonly Regex LooseModeRegex = new(
        @"^
            [v=\s]*
            (\d+)                     # major version
            \.
            (\d+)                     # minor version
            \.
            (\d+)                     # patch version
            (\-?([0-9A-Za-z\-\.]+))?  # pre-release version
            (\+([0-9A-Za-z\-\.]+))?   # build metadata
            \s*
            $",
        RegexOptions.IgnorePatternWhitespace,
        TimeSpan.FromSeconds(3));

    /// <summary>
    /// Initializes a new instance of the <see cref="SemanticVersion"/> class.
    /// </summary>
    public SemanticVersion()
    {
        // Dummy for serialization
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SemanticVersion"/> class.
    /// </summary>
    /// <param name="input">The version string.</param>
    /// <param name="looseMode">When true, be more forgiving of some invalid version specifications.</param>
    public SemanticVersion(
        string input,
        bool looseMode = false)
    {
        var regex = looseMode
            ? LooseModeRegex
            : StrictModeRegex;

        var match = regex.Match(input);
        if (!match.Success)
        {
            throw new ArgumentException($"Invalid version string: {input}", nameof(input));
        }

        Major = int.Parse(
            match.Groups[1].Value,
            GlobalizationConstants.EnglishCultureInfo);
        Minor = int.Parse(
            match.Groups[2].Value,
            GlobalizationConstants.EnglishCultureInfo);
        Patch = int.Parse(
            match.Groups[3].Value,
            GlobalizationConstants.EnglishCultureInfo);

        if (match.Groups[4].Success)
        {
            var inputPreRelease = match.Groups[5].Value;
            var cleanedPreRelease = PreReleaseVersion.Build(inputPreRelease);
            if (!looseMode && inputPreRelease != cleanedPreRelease)
            {
                throw new ArgumentException($"Invalid pre-release version: {inputPreRelease}", nameof(input));
            }

            PreRelease = cleanedPreRelease;
        }

        if (match.Groups[6].Success)
        {
            Build = match.Groups[7].Value;
        }

        if (looseMode &&
            !string.IsNullOrEmpty(PreRelease) &&
            string.IsNullOrEmpty(Build) &&
            PreRelease.StartsWith('.') &&
            int.TryParse(
                PreRelease.Replace(".", string.Empty, StringComparison.Ordinal),
                NumberStyles.Any,
                GlobalizationConstants.EnglishCultureInfo,
                out var build))
        {
            PreRelease = string.Empty;
            Build = build.ToString(GlobalizationConstants.EnglishCultureInfo);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SemanticVersion"/> class.
    /// </summary>
    /// <param name="major">The major part of the version.</param>
    /// <param name="minor">The minor part of the version.</param>
    /// <param name="patch">The patch part of the version.</param>
    /// <param name="preRelease">The pre-release version string, or null for no pre-release version.</param>
    /// <param name="build">The build version string, or null for no build version.</param>
    public SemanticVersion(
        int major,
        int minor,
        int patch,
        string preRelease = "",
        string build = "")
    {
        Major = major;
        Minor = minor;
        Patch = patch;
        PreRelease = preRelease;
        Build = build;
    }

    /// <summary>
    /// The major part of the version.
    /// </summary>
    /// <remarks>
    /// Increment the major version part - when you make incompatible API changes.
    /// </remarks>
    public int Major { get; set; }

    /// <summary>
    /// The minor part of the version.uu
    /// </summary>
    /// <remarks>
    /// Increment the minor version part - when you add functionality in a backwards compatible manner.
    /// </remarks>
    public int Minor { get; set; }

    /// <summary>
    /// The patch part of the version.
    /// </summary>
    /// <remarks>
    /// Increment the patch version part - when you make backwards compatible bug fixes.
    /// </remarks>
    public int Patch { get; set; }

    /// <summary>
    /// The pre-release string, or null for no pre-release version.
    /// </summary>
    public string PreRelease { get; set; } = string.Empty;

    /// <summary>
    /// The build string, or null for no build version.
    /// </summary>
    public string Build { get; set; } = string.Empty;

    /// <summary>
    /// Whether this version is a pre-release.
    /// </summary>
    public bool IsPreRelease => !string.IsNullOrEmpty(PreRelease);

    /// <summary>
    /// Whether this version is a strict SemVer2.0.
    /// </summary>
    public bool IsStrictMode => TryParse(ToString(), looseMode: false, out _);

    /// <summary>
    /// Returns this version without any pre-release or build version.
    /// </summary>
    /// <returns>The base version</returns>
    public SemanticVersion BaseVersion()
        => new(Major, Minor, Patch);

    /// <summary>
    /// Compares two versions are semantically.
    /// </summary>
    /// <param name="obj">The other.</param>
    public int CompareTo(object obj)
    {
        switch (obj)
        {
            case null:
                return 1;
            case SemanticVersion v:
                return CompareTo(v);
            default:
                throw new ArgumentException("Object is not a SemanticVersion", nameof(obj));
        }
    }

    /// <summary>
    /// Compares two versions are semantically.
    /// </summary>
    /// <param name="other">The other version.</param>
    public int CompareTo(
        SemanticVersion? other)
    {
        if (ReferenceEquals(other, null))
        {
            return 1;
        }

        foreach (var c in PartComparisons(other))
        {
            if (c != 0)
            {
                return c;
            }
        }

        return PreReleaseVersion.Compare(PreRelease, other.PreRelease);
    }

    /// <summary>
    /// Compares two versions are semantically.
    /// </summary>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts.</param>
    /// <param name="startingPart">The starting part.</param>
    /// <param name="looseMode">if set to <c>true</c> [loose mode].</param>
    public int CompareTo(
        SemanticVersion? otherVersion,
        int significantParts,
        int startingPart,
        bool looseMode = false)
    {
        var version = Parse(ToString(), looseMode);

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

        if (version.Patch != otherVersion.Patch && significantParts >= 3 && startingPart <= 3)
        {
            return version.Patch > otherVersion.Patch ? 1 : -1;
        }

        if (significantParts >= 4 && BuildPreReleaseComparisons(version, otherVersion, out var result))
        {
            return result;
        }

        return 0;
    }

    /// <summary>
    /// Test whether two versions are semantically equivalent.
    /// </summary>
    /// <param name="other">The other.</param>
    public bool Equals(
        SemanticVersion? other)
        => !ReferenceEquals(other, null) && CompareTo(other) == 0;

    /// <summary>
    /// Test whether two versions are semantically equivalent.
    /// </summary>
    /// <param name="obj">The object.</param>
    public override bool Equals(
        object obj)
        => Equals(obj as SemanticVersion);

    /// <summary>
    /// Calculate a hash code for the version.
    /// </summary>
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 7;
            hash = (hash * 397) + Major.GetHashCode();
            hash = (hash * 397) + Minor.GetHashCode();
            hash = (hash * 397) + Patch.GetHashCode();
            if (!string.IsNullOrEmpty(PreRelease))
            {
                hash = (hash * 397) + StringComparer.Ordinal.GetHashCode(PreRelease);
            }

            return hash;
        }
    }

    /// <summary>
    /// Greater than.
    /// </summary>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts.</param>
    /// <param name="startingPart">The starting part.</param>
    /// <param name="looseMode">if set to <c>true</c> [loose mode].</param>
    public bool GreaterThan(
        SemanticVersion? otherVersion,
        int significantParts = 4,
        int startingPart = 1,
        bool looseMode = false)
    {
        if (otherVersion is null)
        {
            return true;
        }

        var version = Parse(ToString(), looseMode);
        return version.CompareTo(otherVersion, significantParts, startingPart, looseMode) > 0;
    }

    /// <summary>
    /// Greater than or equal.
    /// </summary>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="significantParts">The significant parts.</param>
    /// <param name="startingPart">The starting part.</param>
    public bool GreaterThanOrEqualTo(
        SemanticVersion? otherVersion,
        int significantParts = 4,
        int startingPart = 1)
    {
        if (otherVersion is null)
        {
            return true;
        }

        var version = Parse(ToString());
        return version.CompareTo(otherVersion, significantParts, startingPart) >= 0;
    }

    /// <summary>
    /// Is newer than.
    /// </summary>
    /// <param name="otherVersion">The other version.</param>
    /// <param name="withinMinorReleaseOnly">if set to <c>true</c> [within minor release only].</param>
    /// <param name="looseMode">if set to <c>true</c> [loose mode].</param>
    public bool IsNewerThan(
        SemanticVersion? otherVersion,
        bool withinMinorReleaseOnly = false,
        bool looseMode = false)
    {
        if (otherVersion is null)
        {
            return true;
        }

        var version = Parse(ToString(), looseMode);
        if (withinMinorReleaseOnly)
        {
            return version.Major == otherVersion.Major &&
                   version.GreaterThan(otherVersion, significantParts: 4, startingPart: 2, looseMode);
        }

        return version.GreaterThan(otherVersion, significantParts: 4, startingPart: 1, looseMode);
    }

    /// <summary>
    /// Construct a new semantic version from a version string.
    /// </summary>
    /// <param name="input">The version string.</param>
    /// <param name="looseMode">When true, be more forgiving of some invalid version specifications.</param>
    /// <exception cref="System.ArgumentException">Thrown when the version string is invalid.</exception>
    /// <returns>The SemanticVersion</returns>
    public static SemanticVersion Parse(
        string input,
        bool looseMode = false)
        => new(input, looseMode);

    /// <summary>
    /// Try to construct a new semantic version from a version string.
    /// </summary>
    /// <param name="input">The version string.</param>
    /// <param name="result">The Version, or null when parse fails.</param>
    /// <returns>A boolean indicating success of the parse operation.</returns>
    public static bool TryParse(
        string input,
        out SemanticVersion? result)
        => TryParse(input, looseMode: false, out result);

    /// <summary>
    /// Try to construct a new semantic version from a version string.
    /// </summary>
    /// <param name="input">The version string.</param>
    /// <param name="looseMode">When true, be more forgiving of some invalid version specifications.</param>
    /// <param name="result">The Version, or null when parse fails.</param>
    /// <returns>A boolean indicating success of the parse operation.</returns>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool TryParse(
        string input,
        bool looseMode,
        out SemanticVersion? result)
    {
        try
        {
            result = Parse(input, looseMode);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var preReleaseString = string.IsNullOrEmpty(PreRelease)
            ? string.Empty
            : $"-{PreReleaseVersion.Build(PreRelease)}";

        var buildString = string.Empty;
        if (!string.IsNullOrEmpty(Build))
        {
            buildString = Build.IsNumericOnly()
                ? $".{Build}"
                : $"+{Build}";
        }

        return $"{Major}.{Minor}.{Patch}{preReleaseString}{buildString}";
    }

    /// <summary>
    /// Converts to <see cref="Version"/> based on Major, Minor and Patch.
    /// </summary>
    public Version ToVersion()
    {
        if (!string.IsNullOrEmpty(Build) &&
            int.TryParse(
                Build,
                NumberStyles.Any,
                GlobalizationConstants.EnglishCultureInfo,
                out var build))
        {
            return new(Major, Minor, Patch, build);
        }

        return new(Major, Minor, Patch);
    }

    public static bool operator ==(SemanticVersion? a, SemanticVersion? b)
        => a?.Equals(b) ?? ReferenceEquals(b, null);

    public static bool operator !=(SemanticVersion a, SemanticVersion b)
        => !(a == b);

    public static bool operator >(SemanticVersion? a, SemanticVersion? b)
        => !ReferenceEquals(a, null) && a.CompareTo(b) > 0;

    public static bool operator >=(SemanticVersion? a, SemanticVersion? b)
        => ReferenceEquals(a, null)
            ? ReferenceEquals(b, null)
            : a.CompareTo(b) >= 0;

    public static bool operator <(SemanticVersion? a, SemanticVersion? b)
        => ReferenceEquals(a, null)
            ? !ReferenceEquals(b, null)
            : a.CompareTo(b) < 0;

    public static bool operator <=(SemanticVersion? a, SemanticVersion? b)
        => ReferenceEquals(a, null) || a.CompareTo(b) <= 0;

    private IEnumerable<int> PartComparisons(
        SemanticVersion other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        return Compare();

        IEnumerable<int> Compare()
        {
            yield return Major.CompareTo(other.Major);
            yield return Minor.CompareTo(other.Minor);
            yield return Patch.CompareTo(other.Patch);
        }
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    private static bool BuildPreReleaseComparisons(
        SemanticVersion version,
        SemanticVersion otherVersion,
        out int compareOrdinal)
    {
        var a = GetBuildPreReleaseValue(version);
        var b = GetBuildPreReleaseValue(otherVersion);

        if (CompareIfAnyEmpty(a, b, out compareOrdinal))
        {
            return true;
        }

        var an = a.IsNumericOnly();
        var bn = b.IsNumericOnly();

        if (an && bn)
        {
            if (a == b)
            {
                compareOrdinal = 0;
                return true;
            }

            compareOrdinal = new NumericAlphaComparer().Compare(a, b);
            return true;
        }

        if (!an && !bn)
        {
            if (a == b)
            {
                compareOrdinal = 0;
                return true;
            }

            var saa = EnsureDotSeparator(a).Split('.', StringSplitOptions.RemoveEmptyEntries);
            var sab = EnsureDotSeparator(b).Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (saa.Length == 2 && sab.Length == 2)
            {
                if (saa[0] == sab[0])
                {
                    var saan = saa[1].IsNumericOnly();
                    var sabn = sab[1].IsNumericOnly();
                    if (saan && sabn)
                    {
                        compareOrdinal = new NumericAlphaComparer().Compare(saa[1], sab[1]);
                        return true;
                    }
                }
                else
                {
                    var saas = saa[0].IsNumericOnly();
                    var sabs = sab[0].IsNumericOnly();
                    if (!saas && !sabs)
                    {
                        compareOrdinal = string.CompareOrdinal(sab[0], saa[0]);
                        return true;
                    }
                }
            }
        }

        compareOrdinal = 0;
        return false;
    }

    private static bool CompareIfAnyEmpty(
        string versionBuildPreReleaseValue,
        string otherVersionBuildPreReleaseValue,
        out int compareOrdinal)
    {
        if (string.IsNullOrEmpty(versionBuildPreReleaseValue) &&
            string.IsNullOrEmpty(otherVersionBuildPreReleaseValue))
        {
            compareOrdinal = 0;
            return true;
        }

        if (!string.IsNullOrEmpty(versionBuildPreReleaseValue) &&
            string.IsNullOrEmpty(otherVersionBuildPreReleaseValue))
        {
            compareOrdinal = 1;
            return true;
        }

        if (string.IsNullOrEmpty(versionBuildPreReleaseValue))
        {
            compareOrdinal = -1;
            return true;
        }

        compareOrdinal = 0;
        return false;
    }

    private static string GetBuildPreReleaseValue(
        SemanticVersion version)
    {
        var value = string.Empty;
        if (!string.IsNullOrEmpty(version.Build))
        {
            value = version.Build;
        }
        else if (!string.IsNullOrEmpty(version.PreRelease))
        {
            value = version.PreRelease;
        }

        return value;
    }

    private static string EnsureDotSeparator(
        string value)
    {
        if (value.StartsWith("alfa", StringComparison.Ordinal) &&
            !value.Equals("alfa", StringComparison.Ordinal) &&
            !value.StartsWith("alfa.", StringComparison.Ordinal))
        {
            value = value.Replace("alfa", "alfa.", StringComparison.Ordinal);
        }
        else if (value.StartsWith("beta", StringComparison.Ordinal) &&
                 !value.Equals("beta", StringComparison.Ordinal) &&
                 !value.StartsWith("beta.", StringComparison.Ordinal))
        {
            value = value.Replace("beta", "beta.", StringComparison.Ordinal);
        }

        return value;
    }
}