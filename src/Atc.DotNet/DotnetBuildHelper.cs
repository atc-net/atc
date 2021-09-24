using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Atc.Helpers;
using Microsoft.Extensions.Logging;

namespace Atc.DotNet
{
    public static class DotnetBuildHelper
    {
        public static Task<Dictionary<string, int>> BuildAndCollectErrors(
            ILogger logger,
            DirectoryInfo rootPath,
            int runNumber,
            FileInfo? buildFile = null,
            bool useNugetRestore = true,
            bool useConfigurationReleaseMode = true,
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

            return InvokeBuildAndCollectErrors(logger, rootPath, runNumber, buildFile, useNugetRestore, useConfigurationReleaseMode, cancellationToken);
        }

        private static async Task<Dictionary<string, int>> InvokeBuildAndCollectErrors(
            ILogger logger,
            DirectoryInfo rootPath,
            int runNumber,
            FileInfo? buildFile,
            bool useNugetRestore,
            bool useConfigurationReleaseMode,
            CancellationToken cancellationToken)
        {
            logger.LogInformation(runNumber < 0
                ? "Working on Build"
                : $"Working on Build ({runNumber})");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (_, string output) = await RunBuildCommand(rootPath, buildFile, useNugetRestore, useConfigurationReleaseMode, cancellationToken).ConfigureAwait(false);

            var parsedErrors = ParseBuildOutput(output);
            int totalErrors = parsedErrors.Sum(parsedError => parsedError.Value);

            stopwatch.Stop();

            logger.LogInformation(runNumber < 0
                ? $"Build is done in {stopwatch.Elapsed.GetPrettyTime()}"
                : $"Build ({runNumber}) is done in {stopwatch.Elapsed.GetPrettyTime()}");

            if (totalErrors > 0)
            {
                logger.LogError(runNumber < 0
                    ? $"Found {totalErrors} errors divided into {parsedErrors.Count} rules"
                    : $"Found {totalErrors} errors divided into {parsedErrors.Count} rules in Build ({runNumber})");
            }

            return parsedErrors;
        }

        private static async Task<(bool isSuccessful, string output)> RunBuildCommand(
            DirectoryInfo rootPath,
            FileInfo? buildFile,
            bool useNugetRestore,
            bool useConfigurationReleaseMode,
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

            var dotnetFilePath = string.Empty;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                dotnetFilePath = @"C:\Program Files\dotnet\dotnet.exe";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new PlatformNotSupportedException(nameof(OSPlatform.Linux));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new PlatformNotSupportedException(nameof(OSPlatform.OSX));
            }

            return await ProcessHelper
                .Execute(rootPath, new FileInfo(dotnetFilePath), arguments, timeoutInSec: 5 * 60, cancellationToken)
                .ConfigureAwait(false);
        }

        private static Dictionary<string, int> ParseBuildOutput(string buildResult)
        {
            const string? regexPattern = @": error ([A-Z]\S+?): (.*) \[";
            var errors = new Dictionary<string, int>(StringComparer.Ordinal);

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