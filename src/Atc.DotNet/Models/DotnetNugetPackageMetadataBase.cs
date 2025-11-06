namespace Atc.DotNet.Models;

/// <summary>
/// Represents the base metadata for a .NET NuGet package.
/// </summary>
[Serializable]
public class DotnetNugetPackageMetadataBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DotnetNugetPackageMetadataBase"/> class with empty values.
    /// </summary>
    public DotnetNugetPackageMetadataBase()
    {
        PackageId = string.Empty;
        Version = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DotnetNugetPackageMetadataBase"/> class with the specified package ID and version.
    /// </summary>
    /// <param name="packageId">The NuGet package identifier.</param>
    /// <param name="version">The package version.</param>
    public DotnetNugetPackageMetadataBase(
        string packageId,
        string version)
    {
        PackageId = packageId;
        Version = version;
    }

    /// <summary>
    /// Gets or sets the NuGet package identifier.
    /// </summary>
    public string PackageId { get; set; }

    /// <summary>
    /// Gets or sets the package version.
    /// </summary>
    public string Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(PackageId)}: {PackageId}, {nameof(Version)}: {Version}";
}