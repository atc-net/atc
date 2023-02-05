namespace Atc.Data.Models;

/// <summary>
/// AssemblyInformation.
/// </summary>
[Serializable]
public class AssemblyInformation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssemblyInformation"/> class.
    /// </summary>
    public AssemblyInformation()
    {
        FullName = string.Empty;
        Name = string.Empty;
        Version = new Version();
        IsDebugBuild = true;
        TargetFrameworkName = null;
        TargetFrameworkDisplayName = null;
        Copyright = null;
        SourcePath = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssemblyInformation"/> class.
    /// </summary>
    /// <param name="fullName">The full name.</param>
    /// <param name="name">The name.</param>
    public AssemblyInformation(
        string fullName,
        string name)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Version = new Version();
        IsDebugBuild = true;
        TargetFrameworkName = null;
        TargetFrameworkDisplayName = null;
        Copyright = null;
        SourcePath = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssemblyInformation"/> class.
    /// </summary>
    /// <param name="fullName">The full name.</param>
    /// <param name="name">The name.</param>
    /// <param name="version">The version.</param>
    /// <param name="isDebugBuild">The is debug build.</param>
    /// <param name="targetFrameworkName">Name of the target framework.</param>
    /// <param name="targetFrameworkDisplayName">Display name of the target framework.</param>
    /// <param name="copyright">The copyright.</param>
    /// <param name="sourcePath">The source path.</param>
    public AssemblyInformation(
        string fullName,
        string name,
        Version version,
        bool? isDebugBuild,
        string? targetFrameworkName,
        string? targetFrameworkDisplayName,
        string? copyright,
        string? sourcePath)
        : this(fullName, name)
    {
        Version = version;
        IsDebugBuild = isDebugBuild;
        TargetFrameworkName = targetFrameworkName;
        TargetFrameworkDisplayName = targetFrameworkDisplayName;
        Copyright = copyright;
        SourcePath = sourcePath;
    }

    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    /// <value>
    /// The full name.
    /// </value>
    public string FullName { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the version.
    /// </summary>
    /// <value>
    /// The version.
    /// </value>
    public Version Version { get; set; }

    /// <summary>
    /// Gets or sets the is debug build.
    /// </summary>
    /// <value>
    /// The is debug build.
    /// </value>
    public bool? IsDebugBuild { get; set; }

    /// <summary>
    /// Gets or sets the name of the target framework.
    /// </summary>
    /// <value>
    /// The name of the target framework.
    /// </value>
    public string? TargetFrameworkName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the target framework.
    /// </summary>
    /// <value>
    /// The display name of the target framework.
    /// </value>
    public string? TargetFrameworkDisplayName { get; set; }

    /// <summary>
    /// Gets or sets the copyright.
    /// </summary>
    /// <value>
    /// The copyright.
    /// </value>
    public string? Copyright { get; set; }

    /// <summary>
    /// Gets or sets the source path.
    /// </summary>
    /// <value>
    /// The source path.
    /// </value>
    public string? SourcePath { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(FullName)}: {FullName}, {nameof(Name)}: {Name}, {nameof(Version)}: {Version}, {nameof(IsDebugBuild)}: {IsDebugBuild}, {nameof(TargetFrameworkName)}: {TargetFrameworkName}, {nameof(TargetFrameworkDisplayName)}: {TargetFrameworkDisplayName}, {nameof(Copyright)}: {Copyright}, {nameof(SourcePath)}: {SourcePath}";
}