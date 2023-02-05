namespace Atc.Helpers;

/// <summary>
/// CliHelper.
/// </summary>
public static class CliHelper
{
    /// <summary>Gets the current version from the executing assembly.</summary>
    /// <returns>Return the <see cref="Version"/> of the CLI tool.</returns>
    public static Version GetCurrentVersion()
        => AssemblyHelper.GetSystemVersion();
}