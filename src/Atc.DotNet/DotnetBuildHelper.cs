using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Atc.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Atc.DotNet
{
    public static class DotnetBuildHelper
    {
        private const int DefaultTimeoutInSec = 1200;

        public static Task<Dictionary<string, int>> BuildAndCollectErrors(
            DirectoryInfo rootPath,
            int? runNumber = null,
            FileInfo? buildFile = null,
            bool useNugetRestore = true,
            bool useConfigurationReleaseMode = true,
            int timeoutInSec = DefaultTimeoutInSec,
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
                cancellationToken);
        }

        public static Task<Dictionary<string, int>> BuildAndCollectErrors(
            ILogger logger,
            DirectoryInfo rootPath,
            int? runNumber = null,
            FileInfo? buildFile = null,
            bool useNugetRestore = true,
            bool useConfigurationReleaseMode = true,
            int timeoutInSec = DefaultTimeoutInSec,
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
                cancellationToken);
        }

        private static async Task<Dictionary<string, int>> InvokeBuildAndCollectErrors(
            ILogger logger,
            DirectoryInfo rootPath,
            int? runNumber,
            FileInfo? buildFile,
            bool useNugetRestore,
            bool useConfigurationReleaseMode,
            int timeoutInSec,
            CancellationToken cancellationToken)
        {
            logger.LogInformation(runNumber is > 0
                ? $"Working on Build ({runNumber})"
                : "Working on Build");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (_, string output) = await RunBuildCommand(
                    rootPath,
                    buildFile,
                    useNugetRestore,
                    useConfigurationReleaseMode,
                    timeoutInSec,
                    cancellationToken)
                .ConfigureAwait(false);

            var parsedErrors = ParseBuildOutput(output);
            int totalErrors = parsedErrors.Sum(parsedError => parsedError.Value);

            stopwatch.Stop();

            logger.LogInformation(runNumber is > 0
                ? $"Build ({runNumber}) is done in {stopwatch.Elapsed.GetPrettyTime()}"
                : $"Build is done in {stopwatch.Elapsed.GetPrettyTime()}");

            if (totalErrors > 0)
            {
                logger.LogError(runNumber is > 0
                    ? $"Found {totalErrors} errors divided into {parsedErrors.Count} rules in Build ({runNumber})"
                    : $"Found {totalErrors} errors divided into {parsedErrors.Count} rules");
            }

            return parsedErrors;
        }

        private static async Task<(bool isSuccessful, string output)> RunBuildCommand(
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
                    var files = slnFiles.Select(x => new FileInfo(x).Name).ToList();
                    return (
                        isSuccessful: false,
                        output: $"Please specify which solution file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the solution file using this option: --buildFile");
                }

                var csprojFiles = Directory.GetFiles(rootPath.FullName, "*.csproj");
                if (csprojFiles.Length > 1)
                {
                    var files = csprojFiles.Select(x => new FileInfo(x).Name).ToList();
                    return (
                        isSuccessful: false,
                        output: $"Please specify which C# project file to use:{Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", files)}{Environment.NewLine} Specify the C# project file using this option: --buildFile");
                }
            }

            var dotnetFile = DotnetHelper.GetDotnetExecutable();

            return await ProcessHelper
                .Execute(rootPath, dotnetFile, arguments, timeoutInSec, cancellationToken)
                .ConfigureAwait(false);
        }

        private static Dictionary<string, int> ParseBuildOutput(string buildResult)
        {
            var errors = new Dictionary<string, int>(StringComparer.Ordinal);

            const string? regexPatternMsb = @": error MSB(\S+?): (.*)";
            var regexMsb = new Regex(
                regexPatternMsb,
                RegexOptions.Multiline | RegexOptions.Compiled,
                TimeSpan.FromMinutes(2));

            var matchCollectionMsb = regexMsb.Matches(buildResult);
            foreach (Match match in matchCollectionMsb)
            {
                if (match.Groups.Count != 3)
                {
                    continue;
                }

                var key = "MSB" + match.Groups[1].Value;
                if (errors.ContainsKey(key))
                {
                    errors[key] += 1;
                }
                else
                {
                    errors.Add(key, 1);
                }
            }

            const string? regexPattern = @": error ([A-Z]\S+?): (.*) \[";
            var regex = new Regex(
                regexPattern,
                RegexOptions.Multiline | RegexOptions.Compiled,
                TimeSpan.FromMinutes(2));

            var matchCollection = regex.Matches(buildResult);
            foreach (Match match in matchCollection)
            {
                if (match.Groups.Count != 3)
                {
                    continue;
                }

                var key = match.Groups[1].Value;
                if (errors.ContainsKey(key))
                {
                    errors[key] += 1;
                }
                else
                {
                    errors.Add(key, 1);
                }
            }

            return errors;
        }
    }
}