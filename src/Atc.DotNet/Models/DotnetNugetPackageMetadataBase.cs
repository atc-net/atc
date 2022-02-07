namespace Atc.DotNet.Models;

[Serializable]
public class DotnetNugetPackageMetadataBase
{
    public DotnetNugetPackageMetadataBase()
    {
        this.PackageId = string.Empty;
        this.Version = string.Empty;
    }

    public DotnetNugetPackageMetadataBase(string packageId, string version)
    {
        this.PackageId = packageId;
        this.Version = version;
    }

    public string PackageId { get; set; }

    public string Version { get; set; }

    public override string ToString()
        => $"{nameof(PackageId)}: {PackageId}, {nameof(Version)}: {Version}";
}