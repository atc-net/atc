namespace Atc.DotNet.Models;

public class VisualStudioSolutionFileMetadata
{
    public Version FileFormatVersion { get; set; } = new Version();

    public int VisualStudioVersionNumber { get; set; }

    public Version VisualStudioVersion { get; set; } = new Version();

    public Version MinimumVisualStudioVersion { get; set; } = new Version();

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

    public override string ToString()
        => $"{nameof(FileFormatVersion)}: {FileFormatVersion}, {nameof(VisualStudioVersionNumber)}: {VisualStudioVersionNumber}, {nameof(VisualStudioVersion)}: {VisualStudioVersion}, {nameof(MinimumVisualStudioVersion)}: {MinimumVisualStudioVersion}, {nameof(VisualStudioName)}: {VisualStudioName}";
}