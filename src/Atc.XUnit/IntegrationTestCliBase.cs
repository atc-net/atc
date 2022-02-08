// ReSharper disable CommentTypo
// ReSharper disable LocalizableElement
// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.XUnit;

[ExcludeFromCodeCoverage]
public abstract class IntegrationTestCliBase
{
    /// <summary>
    /// Gets the filePath to CLI-Exe file's 'appsettings.json'.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="pathFolderNameFilter">Path should include this folder name.</param>
    /// <returns>The filePath to CLI-Exe file's 'appsettings.json'.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);]]></code>
    /// <example><![CDATA[
    /// var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
    /// ]]></example>
    public static FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string? pathFolderNameFilter)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        var (cliFileNameExe, searchFromPath) = GetCliFileExeAndSearchFromPath(programTypeForCliExe);
        var cliFileExe = FindOneAndOnlyOneCliFileExe(searchFromPath, cliFileNameExe, pathFolderNameFilter);
        var cliFileAppSettings = GetAppSettingsFilePathFromCliFileExe(cliFileExe);

        return cliFileAppSettings;
    }

    /// <summary>
    /// Gets the filePath to CLI-Exe file's 'appsettings.json'.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="searchFromSubFolderName">The subfolder to search from.</param>
    /// <param name="pathFolderNameFilter">Path should include this folder name.</param>
    /// <returns>The filePath to CLI-Exe file's 'appsettings.json'.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe, searchFromSubFolderName);]]></code>
    /// <example><![CDATA[
    /// var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), "sample");
    /// ]]></example>
    public static FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string? pathFolderNameFilter)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        var cliFileExe = GetExecutableFileForCli(programTypeForCliExe, searchFromSubFolderName, pathFolderNameFilter);
        var cliFileAppSettings = GetAppSettingsFilePathFromCliFileExe(cliFileExe);

        return cliFileAppSettings;
    }

    /// <summary>
    /// Gets the filePath to CLI-Exe file's 'appsettings.json'.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="searchFromPath">The path to search from.</param>
    /// <returns>The filePath to CLI-Exe file's 'appsettings.json'.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe, searchFromPath);]]></code>
    /// <example><![CDATA[
    /// var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), new DirectoryInfo(@"C:\Code\atc-net\atc"));
    /// ]]></example>
    public static FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        if (searchFromPath is null)
        {
            throw new ArgumentNullException(nameof(searchFromPath));
        }

        var cliFileNameExe = GetCliFileName(programTypeForCliExe);
        var cliFileExe = FindOneAndOnlyOneCliFileExe(searchFromPath, cliFileNameExe, pathFolderNameFilter: null);
        var cliFileAppSettings = GetAppSettingsFilePathFromCliFileExe(cliFileExe);

        return cliFileAppSettings;
    }

    /// <summary>
    /// Gets the filePath to CLI-Exe file.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="pathFolderNameFilter">Path should include this folder name.</param>
    /// <returns>The filePath to CLI-Exe file.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);]]></code>
    /// <example><![CDATA[
    /// var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
    /// ]]></example>
    public static FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string? pathFolderNameFilter)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        var (cliFileNameExe, searchFromPath) = GetCliFileExeAndSearchFromPath(programTypeForCliExe);
        var cliFileExe = FindOneAndOnlyOneCliFileExe(searchFromPath, cliFileNameExe, pathFolderNameFilter);

        return cliFileExe;
    }

    /// <summary>
    /// Gets the filePath to CLI-Exe file.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="searchFromSubFolderName">The subfolder to search from.</param>
    /// <param name="pathFolderNameFilter">Path should include this folder name.</param>
    /// <returns>The filePath to CLI-Exe file.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe, searchFromSubFolderName);]]></code>
    /// <example><![CDATA[
    /// var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), "sample");
    /// ]]></example>
    public static FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string? pathFolderNameFilter)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        if (string.IsNullOrEmpty(searchFromSubFolderName))
        {
            throw new ArgumentException($"{nameof(programTypeForCliExe)} is null og empty.", nameof(programTypeForCliExe));
        }

        if (searchFromSubFolderName.IndexOfAny(new[] { '/', '\\' }) != -1)
        {
            throw new ArgumentException($"{nameof(programTypeForCliExe)} is not a folder name.", nameof(programTypeForCliExe));
        }

        var (cliFileNameExe, searchFromPath) = GetCliFileExeAndSearchFromPath(programTypeForCliExe);
        searchFromPath = new DirectoryInfo(Path.Combine(searchFromPath.FullName, searchFromSubFolderName));
        var cliFileExe = FindOneAndOnlyOneCliFileExe(searchFromPath, cliFileNameExe, pathFolderNameFilter);

        return cliFileExe;
    }

    /// <summary>
    /// Gets the filePath to CLI-Exe file.
    /// </summary>
    /// <param name="programTypeForCliExe">The program type for the cli executable.</param>
    /// <param name="searchFromPath">The path to search from.</param>
    /// <param name="pathFolderNameFilter">Path should include this folder name.</param>
    /// <returns>The filePath to CLI-Exe file.</returns>
    /// <remarks>
    /// This method will throw exceptions if the CLI-Exe file don't exist or
    /// finds too many locations. In case of "too many", please narrow down
    /// by using a more specific "searchFrom" path.
    /// </remarks>
    /// <code><![CDATA[FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe, searchFromPath);]]></code>
    /// <example><![CDATA[
    /// var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), new DirectoryInfo(@"C:\Code\atc-net\atc"));
    /// ]]></example>
    public static FileInfo GetExecutableFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath, string? pathFolderNameFilter)
    {
        if (programTypeForCliExe is null)
        {
            throw new ArgumentNullException(nameof(programTypeForCliExe));
        }

        if (searchFromPath is null)
        {
            throw new ArgumentNullException(nameof(searchFromPath));
        }

        var cliFileNameExe = GetCliFileName(programTypeForCliExe);
        var cliFileExe = FindOneAndOnlyOneCliFileExe(searchFromPath, cliFileNameExe, pathFolderNameFilter: pathFolderNameFilter);

        return cliFileExe;
    }

    private static string? GetTestAssemblyName()
    {
        var testAssembly = GetTestAssembly();
        return testAssembly?.GetName().Name;
    }

    private static Assembly? GetTestAssembly()
    {
        var stackFrames = new StackTrace().GetFrames();
        if (stackFrames is null)
        {
            return Assembly
                .GetCallingAssembly();
        }

        var executingAssemblyFullName = Assembly.GetExecutingAssembly().FullName;

        return (from frame in stackFrames
                select frame.GetMethod().DeclaringType.Assembly
                into assembly
                where !executingAssemblyFullName.Equals(assembly.FullName, StringComparison.Ordinal)
                select assembly)
            .FirstOrDefault();
    }

    private static string GetCliFileName(Type programTypeForCliExe)
    {
        var cliProjectName = programTypeForCliExe
            .Assembly
            .GetName()
            .Name;

        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? cliProjectName + ".exe"
            : cliProjectName;
    }

    private static (string cliFileNameExe, DirectoryInfo searchFromPath) GetCliFileExeAndSearchFromPath(Type programTypeForCliExe)
    {
        var currentDomainBaseDirectory = AppDomain
            .CurrentDomain
            .BaseDirectory;

        var testAssemblyName = GetTestAssemblyName();

        var searchFromPath = new DirectoryInfo(currentDomainBaseDirectory.Split(testAssemblyName, StringSplitOptions.RemoveEmptyEntries)[0]);
        if (searchFromPath.Parent is not null)
        {
            searchFromPath = searchFromPath.Parent;
        }

        var cliFileNameExe = GetCliFileName(programTypeForCliExe);
        return (cliFileNameExe, searchFromPath);
    }

    private static FileInfo GetAppSettingsFilePathFromCliFileExe(FileInfo cliFileExe)
        => new (
            Path.Combine(
                cliFileExe.Directory!.FullName,
                "appsettings.json"));

    private static FileInfo FindOneAndOnlyOneCliFileExe(DirectoryInfo searchFromPath, string cliFileNameExe, string? pathFolderNameFilter)
    {
        var files = Directory.GetFiles(
            searchFromPath.FullName,
            cliFileNameExe,
            new EnumerationOptions
            {
                RecurseSubdirectories = true,
            });

        if (files.Length > 1 && !string.IsNullOrEmpty(pathFolderNameFilter))
        {
            files = files
                .Where(x => x.Contains(pathFolderNameFilter, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();
        }

        if (files.Length > 1)
        {
            var testAssembly = GetTestAssembly();
            if (testAssembly is not null)
            {
                var filter = testAssembly.IsDebugBuild()
                    ? "debug"
                    : "release";

                files = files
                    .Where(x => x.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                    .ToArray();
            }
        }

        switch (files.Length)
        {
            case 0:
                throw new FileNotFoundException($"'{cliFileNameExe}' not found.");
            case > 1:
                throw new NotSupportedException($"Too many '{cliFileNameExe}' files found.{Environment.NewLine}{string.Join(" # ", files)}");
        }

        return new FileInfo(files[0]);
    }
}