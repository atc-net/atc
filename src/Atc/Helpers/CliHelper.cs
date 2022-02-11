namespace Atc.Helpers;

/// <summary>
/// CliHelper.
/// </summary>
public static class CliHelper
{
    /// <summary>Gets the current version from the executing assembly.</summary>
    public static Version GetCurrentVersion()
        => Assembly.GetExecutingAssembly().GetFileVersion();
}