// ReSharper disable ConvertIfStatementToReturnStatement
namespace Atc.DotNet;

/// <summary>
/// Provides helper methods for building .NET projects and solutions using the dotnet CLI.
/// </summary>
public static class DotnetBuildHelper
{
    private const int DefaultTimeoutInSec = 1200;

    // Sentinel prefix used internally when there are multiple candidate build files so the
    // caller can detect the ambiguity without relying on a localised dotnet CLI message.
    private const string MultipleFilesOutputPrefix = "Please specify which";

    private static readonly ConcurrentDictionary<string, Regex> RegexCache = new(StringComparer.Ordinal);

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
    /// <param name="additionalBuildArguments">Additional arguments appended to the dotnet build command, such as <c>-p:TreatWarningsAsErrors=false</c> or <c>-f net9.0</c>.</param>
    /// <param name="cancellationToken">Token to cancel the build operation.</param>
    /// <returns>A dictionary mapping error codes to their occurrence counts.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rootPath"/> is null.</exception>
    /// <remarks>
    /// This is a convenience overload that uses <see cref="NullLogger.Instance"/>; for build
    /// progress visibility prefer the overload accepting an <see cref="ILogger"/>.
    /// </remarks>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    public static Task<Dictionary<string, int>> BuildAndCollectErrors(
        DirectoryInfo rootPath,
        int? runNumber = null,
        FileInfo? buildFile = null,
        bool useNugetRestore = true,
        bool useConfigurationReleaseMode = true,
        int timeoutInSec = DefaultTimeoutInSec,
        string logPrefix = "",
        string additionalBuildArguments = "",
        CancellationToken cancellationToken = default)
        => BuildAndCollectErrors(
            NullLogger.Instance,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            additionalBuildArguments,
            cancellationToken);

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
    /// <param name="additionalBuildArguments">Additional arguments appended to the dotnet build command, such as <c>-p:TreatWarningsAsErrors=false</c> or <c>-f net9.0</c>.</param>
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
        string additionalBuildArguments = "",
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(rootPath);

        return InvokeBuildAndCollect(
            logger,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            additionalBuildArguments,
            collectWarnings: false,
            cancellationToken);
    }

    /// <summary>
    /// Builds a .NET project or solution and collects compilation warnings grouped by warning code.
    /// </summary>
    /// <param name="rootPath">The root directory containing the project or solution to build.</param>
    /// <param name="runNumber">Optional run number for logging purposes.</param>
    /// <param name="buildFile">Optional specific solution or project file to build. If not specified, discovers the build file automatically.</param>
    /// <param name="useNugetRestore">Whether to perform NuGet restore before building. Default is true.</param>
    /// <param name="useConfigurationReleaseMode">Whether to build in Release mode. If false, builds in Debug mode. Default is true.</param>
    /// <param name="timeoutInSec">Build timeout in seconds. Default is 1200 seconds (20 minutes).</param>
    /// <param name="logPrefix">Optional prefix for log messages.</param>
    /// <param name="additionalBuildArguments">Additional arguments appended to the dotnet build command, such as <c>-p:NoWarn=CS0168</c> or <c>-f net9.0</c>.</param>
    /// <param name="cancellationToken">Token to cancel the build operation.</param>
    /// <returns>A dictionary mapping warning codes to their occurrence counts.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rootPath"/> is null.</exception>
    /// <remarks>
    /// This is a convenience overload that uses <see cref="NullLogger.Instance"/>; for build
    /// progress visibility prefer the overload accepting an <see cref="ILogger"/>.
    /// </remarks>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    public static Task<Dictionary<string, int>> BuildAndCollectWarnings(
        DirectoryInfo rootPath,
        int? runNumber = null,
        FileInfo? buildFile = null,
        bool useNugetRestore = true,
        bool useConfigurationReleaseMode = true,
        int timeoutInSec = DefaultTimeoutInSec,
        string logPrefix = "",
        string additionalBuildArguments = "",
        CancellationToken cancellationToken = default)
        => BuildAndCollectWarnings(
            NullLogger.Instance,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            additionalBuildArguments,
            cancellationToken);

    /// <summary>
    /// Builds a .NET project or solution with logging support and collects compilation warnings grouped by warning code.
    /// </summary>
    /// <param name="logger">The logger to use for build progress and results.</param>
    /// <param name="rootPath">The root directory containing the project or solution to build.</param>
    /// <param name="runNumber">Optional run number for logging purposes.</param>
    /// <param name="buildFile">Optional specific solution or project file to build. If not specified, discovers the build file automatically.</param>
    /// <param name="useNugetRestore">Whether to perform NuGet restore before building. Default is true.</param>
    /// <param name="useConfigurationReleaseMode">Whether to build in Release mode. If false, builds in Debug mode. Default is true.</param>
    /// <param name="timeoutInSec">Build timeout in seconds. Default is 1200 seconds (20 minutes).</param>
    /// <param name="logPrefix">Optional prefix for log messages.</param>
    /// <param name="additionalBuildArguments">Additional arguments appended to the dotnet build command, such as <c>-p:NoWarn=CS0168</c> or <c>-f net9.0</c>.</param>
    /// <param name="cancellationToken">Token to cancel the build operation.</param>
    /// <returns>A dictionary mapping warning codes to their occurrence counts.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="logger"/> or <paramref name="rootPath"/> is null.</exception>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    public static Task<Dictionary<string, int>> BuildAndCollectWarnings(
        ILogger logger,
        DirectoryInfo rootPath,
        int? runNumber = null,
        FileInfo? buildFile = null,
        bool useNugetRestore = true,
        bool useConfigurationReleaseMode = true,
        int timeoutInSec = DefaultTimeoutInSec,
        string logPrefix = "",
        string additionalBuildArguments = "",
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(rootPath);

        return InvokeBuildAndCollect(
            logger,
            rootPath,
            runNumber,
            buildFile,
            useNugetRestore,
            useConfigurationReleaseMode,
            timeoutInSec,
            logPrefix,
            additionalBuildArguments,
            collectWarnings: true,
            cancellationToken);
    }

    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    private static async Task<Dictionary<string, int>> InvokeBuildAndCollect(
        ILogger logger,
        DirectoryInfo rootPath,
        int? runNumber,
        FileInfo? buildFile,
        bool useNugetRestore,
        bool useConfigurationReleaseMode,
        int timeoutInSec,
        string logPrefix,
        string additionalBuildArguments,
        bool collectWarnings,
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
                additionalBuildArguments,
                cancellationToken)
            .ConfigureAwait(false);

        if (output.StartsWith(MultipleFilesOutputPrefix, StringComparison.Ordinal) &&
            output.Contains("option: --buildFile", StringComparison.Ordinal))
        {
            stopwatch.Stop();
            throw new IOException(output);
        }

        var parsed = collectWarnings
            ? ParseBuildOutput(output, diagnostic: "warning")
            : ParseBuildOutput(output, diagnostic: "error");

        int total = parsed.Sum(x => x.Value);

        stopwatch.Stop();

        if (total > 0)
        {
            var kind = collectWarnings ? "warnings" : "errors";
            logger.LogError(runNumber is > 0
                ? $"{logPrefix}Found {total} {kind} divided into {parsed.Count} rules in Build ({runNumber})"
                : $"{logPrefix}Found {total} {kind} divided into {parsed.Count} rules");
        }

        logger.LogInformation(runNumber is > 0
            ? $"{logPrefix}Build ({runNumber}) time: {stopwatch.Elapsed.GetPrettyTime()}"
            : $"{logPrefix}Build time: {stopwatch.Elapsed.GetPrettyTime()}");

        return parsed;
    }

    private static async Task<(
        bool IsSuccessful,
        string Output)> RunBuildCommand(
        DirectoryInfo rootPath,
        FileInfo? buildFile,
        bool useNugetRestore,
        bool useConfigurationReleaseMode,
        int timeoutInSec,
        string additionalBuildArguments,
        CancellationToken cancellationToken)
    {
        var argumentNugetRestore = useNugetRestore
            ? string.Empty
            : " --no-restore";

        var argumentConfigurationReleaseMode = useConfigurationReleaseMode
            ? " -c Release"
            : " -c Debug";

        var argumentAdditional = string.IsNullOrWhiteSpace(additionalBuildArguments)
            ? string.Empty
            : $" {additionalBuildArguments.Trim()}";

        string arguments;
        if (buildFile is not null && buildFile.Exists)
        {
            arguments = $"build {buildFile.FullName}{argumentNugetRestore}{argumentConfigurationReleaseMode}{argumentAdditional} -v q -clp:NoSummary";
        }
        else
        {
            arguments = $"build{argumentNugetRestore}{argumentConfigurationReleaseMode}{argumentAdditional} -v q -clp:NoSummary";
            var slnFiles = Directory.GetFiles(rootPath.FullName, "*.sln");
            if (slnFiles.Length > 1)
            {
#pragma warning disable AsyncFixer02
                var files = slnFiles
                    .Select(x => new FileInfo(x).Name)
                    .ToList();
#pragma warning restore AsyncFixer02

                return (
                    IsSuccessful: false,
                    Output: $"{MultipleFilesOutputPrefix} solution file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the solution file using this option: --buildFile");
            }

            var csprojFiles = Directory.GetFiles(rootPath.FullName, "*.csproj");
            if (csprojFiles.Length > 1)
            {
#pragma warning disable AsyncFixer02
                var files = csprojFiles
                    .Select(x => new FileInfo(x).Name)
                    .ToList();
#pragma warning restore AsyncFixer02

                return (
                    IsSuccessful: false,
                    Output: $"{MultipleFilesOutputPrefix} C# project file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the C# project file using this option: --buildFile");
            }
        }

        var dotnetFile = DotnetHelper.GetDotnetExecutable();

        return await ProcessHelper
            .Execute(rootPath, dotnetFile, arguments, runAsAdministrator: false, (ushort)timeoutInSec, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Parses raw dotnet build output and returns error codes grouped by their occurrence count.
    /// Recognises MSBuild errors (MSB prefix), NuGet errors (NU prefix), and general compiler errors
    /// (e.g. CS, CA). The project-file suffix that MSBuild appends — <c> [project.csproj]</c> — is
    /// optional; errors emitted without it are still counted.
    /// </summary>
    /// <param name="buildOutput">The raw text output from a dotnet build invocation.</param>
    /// <returns>A dictionary mapping each error code to the number of times it appeared.</returns>
    public static Dictionary<string, int> ParseErrors(string buildOutput)
        => ParseBuildOutput(buildOutput, diagnostic: "error");

    /// <summary>
    /// Parses raw dotnet build output and returns warning codes grouped by their occurrence count.
    /// Recognises MSBuild warnings (MSB prefix), NuGet warnings (NU prefix), and general compiler warnings
    /// (e.g. CS, CA). The project-file suffix that MSBuild appends — <c> [project.csproj]</c> — is
    /// optional; warnings emitted without it are still counted.
    /// </summary>
    /// <param name="buildOutput">The raw text output from a dotnet build invocation.</param>
    /// <returns>A dictionary mapping each warning code to the number of times it appeared.</returns>
    public static Dictionary<string, int> ParseWarnings(string buildOutput)
        => ParseBuildOutput(buildOutput, diagnostic: "warning");

    private static Dictionary<string, int> ParseBuildOutput(
        string buildResult,
        string diagnostic)
    {
        var patternMsBuild = $@": {diagnostic} MSB(\S+?): (.*)";
        var patternNuget = $@": {diagnostic} NU(\S+?): (.*)";
        var patternGeneral = $@": {diagnostic} ([A-Z]\S+?): (.+)";

        var results = ParseBuildOutputHelper(buildResult, patternMsBuild, "MSB");
        if (results.Any())
        {
            return results;
        }

        results = ParseBuildOutputHelper(buildResult, patternNuget, "NU");
        if (results.Any())
        {
            return results;
        }

        return ParseBuildOutputHelper(buildResult, patternGeneral);
    }

    private static Dictionary<string, int> ParseBuildOutputHelper(
        string buildResult,
        string regexPattern,
        string? keyPrefix = null)
    {
        var errors = new Dictionary<string, int>(StringComparer.Ordinal);

        var regex = RegexCache.GetOrAdd(regexPattern, pattern => new Regex(
            pattern,
            RegexOptions.Multiline | RegexOptions.Compiled,
            TimeSpan.FromSeconds(10)));

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