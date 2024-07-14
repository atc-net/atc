// ReSharper disable RedundantExplicitTupleComponentName
// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo
namespace Atc.Helpers;

[ExcludeFromCodeCoverage]
[SuppressMessage("Major Bug", "S2583:Conditionally executed code should be reachable", Justification = "OK - False/Positive")]
public static class ProcessHelper
{
    private const ushort DefaultTimeoutInSec = 30;
    private const ushort DefaultKillTimeoutInSec = 30;

    public static Task<(bool IsSuccessful, string Output)> Execute(
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator = false,
        ushort timeoutInSec = DefaultTimeoutInSec,
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

        return InvokeExecuteWithTimeout(
            workingDirectory: null,
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);
    }

    public static Task<(bool IsSuccessful, string Output)> Execute(
        DirectoryInfo workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator = false,
        ushort timeoutInSec = DefaultTimeoutInSec,
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

        return InvokeExecuteWithTimeout(
            workingDirectory,
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);
    }

    public static Task<bool> ExecuteAndIgnoreOutput(
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator = false,
        ushort timeoutInSec = DefaultTimeoutInSec,
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

        if (timeoutInSec < 1)
        {
            throw new ArgumentException("Timeout should be greater then 1 seconds", nameof(timeoutInSec));
        }

        return InvokeExecuteWithTimeoutAndIgnoreOutput(
            workingDirectory: null,
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);
    }

    public static Task<bool> ExecuteAndIgnoreOutput(
        DirectoryInfo workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator = false,
        ushort timeoutInSec = DefaultTimeoutInSec,
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

        if (timeoutInSec < 1)
        {
            throw new ArgumentException("Timeout should be greater then 1 seconds", nameof(timeoutInSec));
        }

        return InvokeExecuteWithTimeoutAndIgnoreOutput(
            workingDirectory,
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);
    }

    public static Task<(bool IsSuccessful, string Output)> ExecutePrompt(
        DirectoryInfo workingDirectory,
        FileInfo fileInfo,
        string arguments,
        string[] inputLines,
        bool runAsAdministrator = false,
        ushort timeoutInSec = 1,
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

        if (inputLines is null)
        {
            throw new ArgumentNullException(nameof(inputLines));
        }

        if (!File.Exists(fileInfo.FullName))
        {
            throw new FileNotFoundException(nameof(fileInfo));
        }

        if (timeoutInSec < 1)
        {
            throw new ArgumentException("Timeout should be greater then 1 seconds", nameof(timeoutInSec));
        }

        return InvokeExecutePromptWithTimeout(
            workingDirectory,
            fileInfo,
            arguments,
            inputLines,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);
    }

    public static (bool IsSuccessful, string Output) KillEntryCaller(
        int timeoutInSec = DefaultKillTimeoutInSec)
    {
        var processName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()!.Location);
        return KillByName(processName, allowMultiKill: true, timeoutInSec);
    }

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static (bool IsSuccessful, string Output) KillById(
        int processId,
        int timeoutInSec = DefaultKillTimeoutInSec)
    {
        try
        {
            var process = Process.GetProcessById(processId);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (process is null)
            {
                return (
                    IsSuccessful: false,
                    Output: $"No process found by pid '{processId}'");
            }

            process.KillTree();
            process.WaitForExit(timeoutInSec * 1000);

            return (
                IsSuccessful: true,
                Output: $"Process found by pid '{processId}' is now terminated");
        }
        catch (Exception ex)
        {
            return (
                IsSuccessful: false,
                Output: ex.GetMessage(
                    includeInnerMessage: true,
                    includeExceptionName: false));
        }
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static (bool IsSuccessful, string Output) KillByName(
        string processName,
        bool allowMultiKill = true,
        int timeoutInSec = DefaultKillTimeoutInSec)
    {
        if (processName is null)
        {
            throw new ArgumentNullException(nameof(processName));
        }

        if (timeoutInSec < 1)
        {
            throw new ArgumentException("Timeout should be greater then 1 seconds", nameof(timeoutInSec));
        }

        var processes = Process.GetProcessesByName(processName);
        if (allowMultiKill)
        {
            if (processes.Length == 0)
            {
                return (
                    IsSuccessful: false,
                    Output: $"No process found by name '{processName}'");
            }

            try
            {
                foreach (var process in processes)
                {
                    process.KillTree();
                    process.WaitForExit(timeoutInSec * 1000);
                }

                return (
                    IsSuccessful: true,
                    Output: $"{processes.Length} processes found by name '{processName}' is now terminated");
            }
            catch (Exception ex)
            {
                return (
                    IsSuccessful: false,
                    Output: ex.GetMessage(
                        includeInnerMessage: true,
                        includeExceptionName: false));
            }
        }

        switch (processes.Length)
        {
            case 0:
                return (
                    IsSuccessful: false,
                    Output: $"No process found by name '{processName}'");
            case > 1:
                return (
                    IsSuccessful: false,
                    Output: $"Too many processes found by name '{processName}'");
            default:
            {
                var process = processes[0];

                try
                {
                    process.KillTree();
                    process.WaitForExit(timeoutInSec * 1000);

                    return (
                        IsSuccessful: true,
                        Output: $"Process found by name '{processName}' is now terminated");
                }
                catch (Exception ex)
                {
                    return (
                        IsSuccessful: false,
                        Output: ex.GetMessage(
                            includeInnerMessage: true,
                            includeExceptionName: false));
                }
            }
        }
    }

    private static async Task<(bool IsSuccessful, string Output)> InvokeExecuteWithTimeout(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec,
        CancellationToken cancellationToken)
    {
        var processId = -1;
        var resultOutput = string.Empty;

        try
        {
            var (isSuccessful, output, assignedProcessId) = await TaskHelper
                .Execute(
                    _ => InvokeExecuteWithProcessId(workingDirectory, fileInfo, arguments, runAsAdministrator),
                    TimeSpan.FromSeconds(timeoutInSec),
                    cancellationToken)
                .ConfigureAwait(false);

            processId = assignedProcessId;
            resultOutput = output;

            return (IsSuccessful: isSuccessful, Output: output);
        }
        catch (TimeoutException)
        {
            if (processId > 0)
            {
                var (killIsSuccessful, _) = KillById(processId);

                if (string.IsNullOrEmpty(resultOutput))
                {
                    resultOutput = killIsSuccessful
                        ? $"Process has been running for {timeoutInSec} seconds. before terminated."
                        : $"Process has been running for {timeoutInSec} seconds.";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(resultOutput))
                {
                    resultOutput = $"Process has been running for {timeoutInSec} seconds.";
                }
            }

            return await Task
                .FromResult((
                    isSuccessful: false,
                    output: resultOutput))
                .ConfigureAwait(false);
        }
    }

    private static async Task<bool> InvokeExecuteWithTimeoutAndIgnoreOutput(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec,
        CancellationToken cancellationToken)
    {
        var processName = Path.GetFileNameWithoutExtension(fileInfo.FullName);

        try
        {
            var result = await TaskHelper
                .Execute(
                    _ => InvokeExecuteAndIgnoreOutput(workingDirectory, fileInfo, arguments, runAsAdministrator),
                    TimeSpan.FromSeconds(timeoutInSec),
                    cancellationToken)
                .ConfigureAwait(false);

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

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static async Task<bool> InvokeExecuteAndIgnoreOutput(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator)
    {
        using var process = CreateProcess(
            redirectStandard: false,
            useRedirectStandardInput: false,
            workingDirectory,
            fileInfo,
            arguments,
            runAsAdministrator);

        try
        {
            process.Start();
            await process
                .WaitForExitAsync()
                .ConfigureAwait(false);

            return process.ExitCode == ConsoleExitStatusCodes.Success;
        }
        catch
        {
            return false;
        }
    }

    private static async Task<(bool IsSuccessful, string Output)> InvokeExecutePromptWithTimeout(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        string[] inputLines,
        bool runAsAdministrator,
        int timeoutInSec,
        CancellationToken cancellationToken)
    {
        var processId = -1;
        var resultOutput = string.Empty;

        try
        {
            var (isSuccessful, output, assignedProcessId) = await TaskHelper
                .Execute(
                    _ => InvokeExecutePromptWithProcessId(workingDirectory, fileInfo, arguments, inputLines, runAsAdministrator),
                    TimeSpan.FromSeconds(timeoutInSec),
                    cancellationToken)
                .ConfigureAwait(false);

            processId = assignedProcessId;
            resultOutput = output;

            return (IsSuccessful: isSuccessful, Output: output);
        }
        catch (TimeoutException)
        {
            if (processId > 0)
            {
                var (killIsSuccessful, _) = KillById(processId);

                if (string.IsNullOrEmpty(resultOutput))
                {
                    resultOutput = killIsSuccessful
                        ? $"Process has been running for {timeoutInSec} seconds. before terminated."
                        : $"Process has been running for {timeoutInSec} seconds.";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(resultOutput))
                {
                    resultOutput = $"Process has been running for {timeoutInSec} seconds.";
                }
            }

            return await Task
                .FromResult((
                    isSuccessful: false,
                    output: resultOutput))
                .ConfigureAwait(false);
        }
    }

    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static async Task<(bool IsSuccessful, string Output, int ProcessId)> InvokeExecuteWithProcessId(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator)
    {
        using var process = CreateProcess(
            redirectStandard: true,
            useRedirectStandardInput: false,
            workingDirectory,
            fileInfo,
            arguments,
            runAsAdministrator);
        var processId = -1;

        try
        {
            process.Start();
            processId = process.Id;

            var standardOutput = await process
                .StandardOutput
                .ReadToEndAsync()
                .ConfigureAwait(false);

            var standardError = await process
                .StandardError
                .ReadToEndAsync()
                .ConfigureAwait(false);

            await process
                .WaitForExitAsync()
                .ConfigureAwait(false);

            var message = string.IsNullOrEmpty(standardError)
                ? standardOutput
                : string.IsNullOrEmpty(standardOutput)
                    ? standardError
                    : $"{standardOutput}{Environment.NewLine}{standardError}";

            return (
                IsSuccessful: process.ExitCode == ConsoleExitStatusCodes.Success && string.IsNullOrEmpty(standardError),
                Output: message,
                ProcessId: processId);
        }
        catch (Exception ex)
        {
            return (
                IsSuccessful: false,
                Output: ex.GetMessage(
                    includeInnerMessage: true,
                    includeExceptionName: true),
                ProcessId: processId);
        }
    }

    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static async Task<(bool IsSuccessful, string Output, int ProcessId)> InvokeExecutePromptWithProcessId(
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        IEnumerable<string> inputLines,
        bool runAsAdministrator)
    {
        using var process = CreateProcess(
            redirectStandard: true,
            useRedirectStandardInput: true,
            workingDirectory,
            fileInfo,
            arguments,
            runAsAdministrator);
        var processId = -1;

        try
        {
            process.Start();
            processId = process.Id;

            foreach (var line in inputLines)
            {
                await process
                    .StandardInput
                    .WriteLineAsync(line)
                    .ConfigureAwait(false);
            }

            var standardOutput = await process
                .StandardOutput
                .ReadToEndAsync()
                .ConfigureAwait(false);

            var standardError = await process
                .StandardError
                .ReadToEndAsync()
                .ConfigureAwait(false);

            await process
                .WaitForExitAsync()
                .ConfigureAwait(false);

            var message = string.IsNullOrEmpty(standardError)
                ? standardOutput
                : string.IsNullOrEmpty(standardOutput)
                    ? standardError
                    : $"{standardOutput}{Environment.NewLine}{standardError}";

            return (
                IsSuccessful: process.ExitCode == ConsoleExitStatusCodes.Success && string.IsNullOrEmpty(standardError),
                Output: message,
                ProcessId: processId);
        }
        catch (Exception ex)
        {
            return (
                IsSuccessful: false,
                Output: ex.GetMessage(
                    includeInnerMessage: true,
                    includeExceptionName: true),
                ProcessId: processId);
        }
    }

    private static Process CreateProcess(
        bool redirectStandard,
        bool useRedirectStandardInput,
        DirectoryInfo? workingDirectory,
        FileInfo fileInfo,
        string arguments,
        bool runAsAdministrator)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = fileInfo.FullName,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardError = redirectStandard,
            RedirectStandardOutput = redirectStandard,
            CreateNoWindow = true,
        };

        if (redirectStandard && useRedirectStandardInput)
        {
            processStartInfo.RedirectStandardInput = true;
        }

        if (runAsAdministrator &&
            processStartInfo.Verbs.Contains("runas", StringComparer.OrdinalIgnoreCase))
        {
            processStartInfo.Verb = "runas";
        }

        var process = new Process
        {
            StartInfo = processStartInfo,
        };

        process.StartInfo.WorkingDirectory = workingDirectory is not null && workingDirectory.Exists
            ? workingDirectory.FullName
            : fileInfo.Directory!.FullName;

        return process;
    }
}