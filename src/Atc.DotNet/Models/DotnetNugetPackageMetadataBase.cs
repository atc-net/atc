namespace Atc.DotNet.Models;

[Serializable]
public class DotnetNugetPackageMetadataBase
{
    public DotnetNugetPackageMetadataBase()
    {
        PackageId = string.Empty;
        Version = string.Empty;
    }

    public DotnetNugetPackageMetadataBase(string packageId, string version)
    {
        PackageId = packageId;
        Version = version;
    }

    public string PackageId { get; set; }

    public string Version { get; set; }

    public override string ToString()
        => $"{nameof(PackageId)}: {PackageId}, {nameof(Version)}: {Version}";
}