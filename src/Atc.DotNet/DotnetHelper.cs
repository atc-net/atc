// ReSharper disable CommentTypo
namespace Atc.DotNet;

public static class DotnetHelper
{
    /// <summary>
    /// Get the directory of the .NET runtime.
    /// </summary>
    /// <remarks>
    /// <para>This method is platform independent.</para>
    /// <para>The default location on Windows is C:\Program Files\dotnet.</para>
    /// <para>The default location on Linux and macOS is /usr/share/dotnet.</para>
    /// <para>On Linux it varies from distribution to distribution and method of installation.</para>
    /// </remarks>
    public static DirectoryInfo GetDotnetDirectory()
    {
        var pathEnvironmentVariable = Environment.GetEnvironmentVariable("path");
        if (pathEnvironmentVariable is not null &&
            pathEnvironmentVariable.Contains("dotnet", StringComparison.Ordinal))
        {
            var sa = pathEnvironmentVariable.Split(';');
            foreach (var s in sa)
            {
                if (s.Contains("dotnet", StringComparison.Ordinal))
                {
                    return new DirectoryInfo(s);
                }
            }
        }

        var directory = new DirectoryInfo(RuntimeEnvironment.GetRuntimeDirectory());

        while (directory.Parent is not null && !IsDefaultDotnetDirectoryName(directory.Name))
        {
            directory = directory.Parent;
        }

        if (directory.Exists && IsDefaultDotnetDirectoryName(directory.Name))
        {
            return directory;
        }

        // The environment variable 'DOTNET_ROOT' specifies the location of the .NET runtimes,
        // if they are not installed in the default location.
        // https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-environment-variables
        if (TryGetDirectoryFromEnvVariable("DOTNET_ROOT", out var result))
        {
            return result!;
        }

        throw new DirectoryNotFoundException("Could not determine location of system dotnet folder");
    }

    /// <summary>
    /// Get the dotnet executable file from the OS.
    /// </summary>
    /// <remarks>
    /// This method is platform independent.
    /// </remarks>
    public static FileInfo GetDotnetExecutable()
    {
        var dotnetDirectory = GetDotnetDirectory();

        var dotnetFilename = OperatingSystem.IsWindows()
            ? "dotnet.exe"
            : "dotnet";

        var dotnetFullName = Path.Combine(dotnetDirectory.FullName, dotnetFilename);

        if (!File.Exists(dotnetFullName))
        {
            throw new FileNotFoundException($"No '{dotnetFilename}' file found in dotnet directory '{dotnetDirectory}'");
        }

        return new FileInfo(dotnetFullName);
    }

    /// <summary>
    /// Get the dotnet version.
    /// </summary>
    /// <remarks>
    /// This method is platform independent.
    /// </remarks>
    public static async Task<Version> GetDotnetVersion()
    {
        var dotnetFile = GetDotnetExecutable();

        var (isSuccessful, output) = await ProcessHelper.Execute(dotnetFile.Directory!, dotnetFile, "--version");
        if (!isSuccessful)
        {
            return new Version(0, 0);
        }

        var s = output.TrimSpecial();
        return Version.TryParse(s, out var version)
            ? version
            : new Version(0, 0);
    }

    /// <remarks>
    /// "dotnet" is the default name, but Github Actions installs to ".dotnet" ("/home/runner/.dotnet")
    /// </remarks>
    private static bool IsDefaultDotnetDirectoryName(string value)
    {
        return value.Equals("dotnet", StringComparison.Ordinal) ||
               value.Equals(".dotnet", StringComparison.Ordinal);
    }

    private static bool TryGetDirectoryFromEnvVariable(string envVariable, out DirectoryInfo? directory)
    {
        directory = null;
        var value = Environment.GetEnvironmentVariable(envVariable);
        if (string.IsNullOrEmpty(value) || !Directory.Exists(value))
        {
            return false;
        }

        directory = new DirectoryInfo(value);
        return true;
    }
}