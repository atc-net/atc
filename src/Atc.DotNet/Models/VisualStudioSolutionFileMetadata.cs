namespace Atc.DotNet.Models;

/// <summary>
/// Represents metadata extracted from a Visual Studio solution (.sln) file.
/// </summary>
public class VisualStudioSolutionFileMetadata
{
    /// <summary>
    /// Gets or sets the solution file format version.
    /// </summary>
    public Version FileFormatVersion { get; set; } = new();

    /// <summary>
    /// Gets or sets the Visual Studio version number.
    /// </summary>
    public int VisualStudioVersionNumber { get; set; }

    /// <summary>
    /// Gets or sets the Visual Studio version.
    /// </summary>
    public Version VisualStudioVersion { get; set; } = new();

    /// <summary>
    /// Gets or sets the minimum Visual Studio version required to open this solution.
    /// </summary>
    public Version MinimumVisualStudioVersion { get; set; } = new();

    /// <summary>
    /// Gets the human-readable name of the Visual Studio version based on the version number.
    /// </summary>
    public string VisualStudioName
        => VisualStudioVersionNumber switch
        {
            2003 => "Visual Studio .NET 2003",
            2005 => "Visual Studio 2005",
            2008 => "Visual Studio 2008",
            2010 => "Visual Studio 2010",
            2012 => "Visual Studio 2012",
            2013 => "Visual Studio 2013",
            14 => "Visual Studio 2015",
            15 => "Visual Studio 2017",
            16 => "Visual Studio 2019",
            17 => "Visual Studio 2022",
            _ => "Unknown Visual Studio",
        };

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(FileFormatVersion)}: {FileFormatVersion}, {nameof(VisualStudioVersionNumber)}: {VisualStudioVersionNumber}, {nameof(VisualStudioVersion)}: {VisualStudioVersion}, {nameof(MinimumVisualStudioVersion)}: {MinimumVisualStudioVersion}, {nameof(VisualStudioName)}: {VisualStudioName}";
}