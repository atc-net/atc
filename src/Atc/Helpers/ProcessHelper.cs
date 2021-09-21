using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Atc.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ProcessHelper
    {
        public static Task<(bool isSuccessful, string output)> Execute(FileInfo fileInfo, string arguments)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecute(workingDirectory: null, fileInfo, arguments);
        }

        public static Task<(bool isSuccessful, string output)> Execute(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments)
        {
            if (workingDirectory is null)
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecute(workingDirectory, fileInfo, arguments);
        }

        public static Task<(bool isSuccessful, string output)> Execute(
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken = default)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteWithTimeout(workingDirectory: null, fileInfo, arguments, timeoutInSec, cancellationToken);
        }

        public static Task<(bool isSuccessful, string output)> Execute(
            DirectoryInfo workingDirectory,
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken = default)
        {
            if (workingDirectory is null)
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteWithTimeout(workingDirectory, fileInfo, arguments, timeoutInSec, cancellationToken);
        }

        public static Task<bool> ExecuteAndIgnoreOutput(FileInfo fileInfo, string arguments)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteAndIgnoreOutput(workingDirectory: null, fileInfo, arguments);
        }

        public static Task<bool> ExecuteAndIgnoreOutput(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments)
        {
            if (workingDirectory is null)
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteAndIgnoreOutput(workingDirectory, fileInfo, arguments);
        }

        public static Task<bool> ExecuteAndIgnoreOutput(
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken = default)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteWithTimeoutAndIgnoreOutput(workingDirectory: null, fileInfo, arguments, timeoutInSec, cancellationToken);
        }

        public static Task<bool> ExecuteAndIgnoreOutput(
            DirectoryInfo workingDirectory,
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken = default)
        {
            if (workingDirectory is null)
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException(nameof(fileInfo));
            }

            return InvokeExecuteWithTimeoutAndIgnoreOutput(workingDirectory, fileInfo, arguments, timeoutInSec, cancellationToken);
        }

        public static (bool isSuccessful, string output) KillEntryCaller(int timeoutInSec = 30)
        {
            var processName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()!.Location);
            return KillByName(processName, allowMultiKill: true, timeoutInSec);
        }

        public static (bool isSuccessful, string output) KillById(int processId, int timeoutInSec = 30)
        {
            try
            {
                var process = Process.GetProcessById(processId);

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (process is null)
                {
                    return (
                        isSuccessful: false,
                        output: $"No process found by pid '{processId}'");
                }

                process.Kill();
                process.WaitForExit(timeoutInSec * 1000);
                return (
                    isSuccessful: true,
                    output: $"Process found by pid '{processId}' is now terminated");
            }
            catch (Exception ex)
            {
                return (
                    isSuccessful: false,
                    output: ex.GetMessage(
                        includeInnerMessage: true,
                        includeExceptionName: false));
            }
        }

        public static (bool isSuccessful, string output) KillByName(
            string processName,
            bool allowMultiKill = true,
            int timeoutInSec = 30)
        {
            if (processName is null)
            {
                throw new ArgumentNullException(nameof(processName));
            }

            var processes = Process.GetProcessesByName(processName);
            if (allowMultiKill)
            {
                if (processes.Length == 0)
                {
                    return (
                        isSuccessful: false,
                        output: $"No process found by name '{processName}'");
                }

                try
                {
                    foreach (var process in processes)
                    {
                        process.Kill();
                        process.WaitForExit(timeoutInSec * 1000);
                    }

                    return (
                        isSuccessful: true,
                        output: $"{processes.Length} processes found by name '{processName}' is now terminated");
                }
                catch (Exception ex)
                {
                    return (
                        isSuccessful: false,
                        output: ex.GetMessage(
                            includeInnerMessage: true,
                            includeExceptionName: false));
                }
            }

            switch (processes.Length)
            {
                case 0:
                    return (
                        isSuccessful: false,
                        output: $"No process found by name '{processName}'");
                case > 1:
                    return (
                        isSuccessful: false,
                        output: $"Too many processes found by name '{processName}'");
                default:
                {
                    var process = processes.First();
                    try
                    {
                        process.Kill();
                        process.WaitForExit(timeoutInSec * 1000);
                        return (
                            isSuccessful: true,
                            output: $"Process found by name '{processName}' is now terminated");
                    }
                    catch (Exception ex)
                    {
                        return (
                            isSuccessful: false,
                            output: ex.GetMessage(
                                includeInnerMessage: true,
                                includeExceptionName: false));
                    }
                }
            }
        }

        private static async Task<(bool isSuccessful, string output)> InvokeExecuteWithTimeout(
            DirectoryInfo? workingDirectory,
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken)
        {
            var resultOutput = string.Empty;
            var processName = Path.GetFileNameWithoutExtension(fileInfo.FullName);

            try
            {
                var result = await TaskHelper
                    .Execute(
                        _ =>
                        InvokeExecute(workingDirectory, fileInfo, arguments),
                        TimeSpan.FromSeconds(timeoutInSec),
                        cancellationToken)
                    .ConfigureAwait(false);

                resultOutput = result.output;

                KillByName(processName);

                return result;
            }
            catch (TimeoutException)
            {
                var (killIsSuccessful, _) = KillByName(processName);

                if (string.IsNullOrEmpty(resultOutput))
                {
                    resultOutput = killIsSuccessful
                        ? $"Process has been running for {timeoutInSec}sec. before terminated."
                        : $"Process has been running for {timeoutInSec}sec.";
                }

                return await Task
                    .FromResult((
                        isSuccessful: false,
                        output: resultOutput))
                    .ConfigureAwait(false);
            }
        }

        [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
        private static async Task<(bool isSuccessful, string output)> InvokeExecute(DirectoryInfo? workingDirectory, FileInfo fileInfo, string arguments)
        {
            using var process = CreateProcess(redirectStandard: true, workingDirectory, fileInfo, arguments);

            try
            {
                process.Start();

                var standardOutput = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
                var standardError = await process.StandardError.ReadToEndAsync().ConfigureAwait(false);

                var message = string.IsNullOrEmpty(standardError)
                    ? standardOutput
                    : string.IsNullOrEmpty(standardOutput)
                        ? standardError
                        : $"{standardOutput}{Environment.NewLine}{standardError}";

                return (
                    isSuccessful: process.ExitCode == ConsoleExitStatusCodes.Success && string.IsNullOrEmpty(standardError),
                    output: message);
            }
            catch (Exception ex)
            {
                return (
                    isSuccessful: false,
                    output: ex.GetMessage(
                        includeInnerMessage: true,
                        includeExceptionName: true));
            }
        }

        private static async Task<bool> InvokeExecuteWithTimeoutAndIgnoreOutput(
            DirectoryInfo? workingDirectory,
            FileInfo fileInfo,
            string arguments,
            int timeoutInSec,
            CancellationToken cancellationToken)
        {
            var processName = Path.GetFileNameWithoutExtension(fileInfo.FullName);

            try
            {
                var result = await TaskHelper
                    .Execute(
                        _ =>
                        InvokeExecuteAndIgnoreOutput(workingDirectory, fileInfo, arguments),
                        TimeSpan.FromSeconds(timeoutInSec),
                        cancellationToken)
                    .ConfigureAwait(false);

                KillByName(processName);

                return result;
            }
            catch (TimeoutException)
            {
                KillByName(processName);

                return await Task
                    .FromResult(true)
                    .ConfigureAwait(false);
            }
        }

        private static Task<bool> InvokeExecuteAndIgnoreOutput(DirectoryInfo? workingDirectory, FileInfo fileInfo, string arguments)
        {
            using var process = CreateProcess(redirectStandard: false, workingDirectory, fileInfo, arguments);

            try
            {
                process.Start();

                return Task.FromResult(process.ExitCode == ConsoleExitStatusCodes.Success);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        private static Process CreateProcess(bool redirectStandard, DirectoryInfo? workingDirectory, FileInfo fileInfo, string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileInfo.FullName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardError = redirectStandard,
                    RedirectStandardOutput = redirectStandard,
                    CreateNoWindow = true,
                },
            };

            process.StartInfo.WorkingDirectory = workingDirectory is not null && workingDirectory.Exists
                ? workingDirectory.FullName
                : fileInfo.Directory!.FullName;

            return process;
        }
    }
}