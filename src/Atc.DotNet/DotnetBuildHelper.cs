// ReSharper disable ConvertIfStatementToReturnStatement
namespace Atc.DotNet;

/// <summary>
/// Provides helper methods for building .NET projects and solutions using the dotnet CLI.
/// </summary>
public static class DotnetBuildHelper
{
    private const int DefaultTimeoutInSec = 1200;

    /// <summary>
    /// Builds a .NET project or solution and collects compilation errors grouped by error code.
    /// </summary>
    /// <param name="rootPath">The root directory containing the project or solution to build.</param>
    /// <param name="runNumber">Optional run number for logging purposes.</param>
    /// <param name="buildFile">Optional specific solution or project file to build. If not specified, discovers the build file automatically.</param>
    /// <param name="useNugetRestore">Whether to perform NuGet restore before building. Default is true.</param>
    /// <param name="useConfigurationReleaseMode">Whether to build in Release mode. If false, builds in Debug mode. Default is true.</param>
    /// <param name="timeoutInSec">Build timeout in seconds. Default is 1200 seconds (20 minutes).</param>
    /// <param name="logPrefix">Optional prefix for log messages.</param>
    /// <param name="cancellationToken">Token to cancel the build operation.</param>
    /// <returns>A dictionary mapping error codes to their occurrence counts.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rootPath"/> is null.</exception>
    public static Task<Dictionary<string, int>> BuildAndCollectErrors(
        DirectoryInfo rootPath,
        int? runNumber = null,
        FileInfo? buildFile = null,
        bool useNugetRestore = true,
        bool useConfigurationReleaseMode = true,
        int timeoutInSec = DefaultTimeoutInSec,
        string logPrefix = "",
        CancellationToken cancellationToken = default)
    {
        if (rootPath is null)
        {
            throw new ArgumentNullException(nameof(rootPath));
        }

        return InvokeBuildAndCollectErrors(
            NullLogger.Instance,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            cancellationToken);
    }

    /// <summary>
    /// Builds a .NET project or solution with logging support and collects compilation errors grouped by error code.
    /// </summary>
    /// <param name="logger">The logger to use for build progress and results.</param>
    /// <param name="rootPath">The root directory containing the project or solution to build.</param>
    /// <param name="runNumber">Optional run number for logging purposes.</param>
    /// <param name="buildFile">Optional specific solution or project file to build. If not specified, discovers the build file automatically.</param>
    /// <param name="useNugetRestore">Whether to perform NuGet restore before building. Default is true.</param>
    /// <param name="useConfigurationReleaseMode">Whether to build in Release mode. If false, builds in Debug mode. Default is true.</param>
    /// <param name="timeoutInSec">Build timeout in seconds. Default is 1200 seconds (20 minutes).</param>
    /// <param name="logPrefix">Optional prefix for log messages.</param>
    /// <param name="cancellationToken">Token to cancel the build operation.</param>
    /// <returns>A dictionary mapping error codes to their occurrence counts.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="logger"/> or <paramref name="rootPath"/> is null.</exception>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    public static Task<Dictionary<string, int>> BuildAndCollectErrors(
        ILogger logger,
        DirectoryInfo rootPath,
        int? runNumber = null,
        FileInfo? buildFile = null,
        bool useNugetRestore = true,
        bool useConfigurationReleaseMode = true,
        int timeoutInSec = DefaultTimeoutInSec,
        string logPrefix = "",
        CancellationToken cancellationToken = default)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (rootPath is null)
        {
            throw new ArgumentNullException(nameof(rootPath));
        }

        return InvokeBuildAndCollectErrors(
            logger,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            cancellationToken);
    }

    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    private static async Task<Dictionary<string, int>> InvokeBuildAndCollectErrors(
        ILogger logger,
        DirectoryInfo rootPath,
        int? runNumber,
        FileInfo? buildFile,
        bool useNugetRestore,
        bool useConfigurationReleaseMode,
        int timeoutInSec,
        string logPrefix,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(runNumber is > 0
            ? $"{logPrefix}Build ({runNumber})"
            : $"{logPrefix}Build");

        var stopwatch = Stopwatch.StartNew();

        (_, string output) = await RunBuildCommand(
                rootPath,
                buildFile,
                useNugetRestore,
                useConfigurationReleaseMode,
                timeoutInSec,
                cancellationToken)
            .ConfigureAwait(false);

        if (output.StartsWith("Please specify which", StringComparison.Ordinal) &&
            output.Contains("option: --buildFile", StringComparison.Ordinal))
        {
            stopwatch.Stop();
            throw new IOException(output);
        }

        var parsedErrors = ParseBuildOutput(output);
        int totalErrors = parsedErrors.Sum(parsedError => parsedError.Value);

        stopwatch.Stop();

        if (totalErrors > 0)
        {
            logger.LogError(runNumber is > 0
                ? $"{logPrefix}Found {totalErrors} errors divided into {parsedErrors.Count} rules in Build ({runNumber})"
                : $"{logPrefix}Found {totalErrors} errors divided into {parsedErrors.Count} rules");
        }

        logger.LogInformation(runNumber is > 0
            ? $"{logPrefix}Build ({runNumber}) time: {stopwatch.Elapsed.GetPrettyTime()}"
            : $"{logPrefix}Build time: {stopwatch.Elapsed.GetPrettyTime()}");

        return parsedErrors;
    }

    private static async Task<(
        bool IsSuccessful,
        string Output)> RunBuildCommand(
        DirectoryInfo rootPath,
        FileInfo? buildFile,
        bool useNugetRestore,
        bool useConfigurationReleaseMode,
        int timeoutInSec,
        CancellationToken cancellationToken)
    {
        var argumentNugetRestore = useNugetRestore
            ? string.Empty
            : " --no-restore";

        var argumentConfigurationReleaseMode = useConfigurationReleaseMode
            ? " -c Release"
            : " -c Debug";

        string arguments;
        if (buildFile is not null && buildFile.Exists)
        {
            arguments = $"build {buildFile.FullName}{argumentNugetRestore}{argumentConfigurationReleaseMode} -v q -clp:NoSummary";
        }
        else
        {
            arguments = $"build{argumentNugetRestore}{argumentConfigurationReleaseMode} -v q -clp:NoSummary";
            var slnFiles = Directory.GetFiles(rootPath.FullName, "*.sln");
            if (slnFiles.Length > 1)
            {
                var files = slnFiles.Select(x => new FileInfo(x).Name).ToListAsync(cancellationToken);
                return (
                    IsSuccessful: false,
                    Output: $"Please specify which solution file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the solution file using this option: --buildFile");
            }

            var csprojFiles = Directory.GetFiles(rootPath.FullName, "*.csproj");
            if (csprojFiles.Length > 1)
            {
                var files = csprojFiles.Select(x => new FileInfo(x).Name).ToListAsync(cancellationToken);
                return (
                    IsSuccessful: false,
                    Output: $"Please specify which C# project file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the C# project file using this option: --buildFile");
            }
        }

        var dotnetFile = DotnetHelper.GetDotnetExecutable();

        return await ProcessHelper
            .Execute(rootPath, dotnetFile, arguments, runAsAdministrator: false, (ushort)timeoutInSec, cancellationToken)
            .ConfigureAwait(false);
    }

    private static Dictionary<string, int> ParseBuildOutput(string buildResult)
    {
        const string? regexPatternMsBuild = @": error MSB(\S+?): (.*)";
        const string? regexPatternNuget = @": error NU(\S+?): (.*)";
        const string? regexPatternGeneral = @": error ([A-Z]\S+?): (.*) \[";

        var errors = ParseBuildOutputHelper(buildResult, regexPatternMsBuild, "MSB");
        if (errors.Any())
        {
            return errors;
        }

        errors = ParseBuildOutputHelper(buildResult, regexPatternNuget, "NU");
        if (errors.Any())
        {
            return errors;
        }

        return ParseBuildOutputHelper(buildResult, regexPatternGeneral);
    }

    private static Dictionary<string, int> ParseBuildOutputHelper(
        string buildResult,
        string regexPattern,
        string? keyPrefix = null)
    {
        var errors = new Dictionary<string, int>(StringComparer.Ordinal);

        var regex = new Regex(
            regexPattern,
            RegexOptions.Multiline | RegexOptions.Compiled,
            TimeSpan.FromMinutes(2));

        var matchCollection = regex.Matches(buildResult);
        foreach (var matchGroups in matchCollection.Select(x => x.Groups))
        {
            if (matchGroups.Count != 3)
            {
                continue;
            }

            var key = keyPrefix is null
                ? matchGroups[1].Value
                : keyPrefix + matchGroups[1].Value;

            if (!errors.TryAdd(key, 1))
            {
                errors[key] += 1;
            }
        }

        return errors;
    }
}