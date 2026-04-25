// ReSharper disable RedundantSuppressNullableWarningExpression
// ReSharper disable StringLiteralTypo
// ReSharper disable once CheckNamespace
namespace System.Diagnostics;

/// <summary>
/// Extension methods for <see cref="Process"/> that add async-friendly waiting and
/// cross-platform process-tree termination.
/// </summary>
public static class ProcessExtensions
{
    private static readonly TimeSpan DefaultKillTimeout = TimeSpan.FromSeconds(30);

    [SuppressMessage("Major Code Smell", "S4457:Parameter validation in \"async\"/\"await\" methods should be wrapped", Justification = "OK.")]
    public static async Task WaitForExitAsync(
        this Process process,
        CancellationToken cancellationToken = default)
    {
        if (process is null)
        {
            throw new ArgumentNullException(nameof(process));
        }

        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        void ProcessExited(
            object? sender,
            EventArgs e)
        {
            tcs.TrySetResult(true);
        }

        process.EnableRaisingEvents = true;
        process.Exited += ProcessExited;

        try
        {
            if (process.HasExited)
            {
                return;
            }

#if NETSTANDARD2_0
            using (cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken)))
#else
            await using (cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken)))
#endif
            {
                await tcs.Task.ConfigureAwait(false);
            }
        }
        finally
        {
            process.Exited -= ProcessExited;
        }
    }

    /// <summary>
    /// Synchronously terminates the process and any child processes it started, using a default
    /// 30-second timeout per spawned helper command. On Windows uses <c>taskkill /T /F</c>; on
    /// other platforms uses <c>pgrep</c> + <c>kill -TERM</c>.
    /// </summary>
    /// <param name="process">The root process whose tree should be terminated.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="process"/> is null.</exception>
    public static void KillTree(this Process process)
        => process.KillTree(DefaultKillTimeout);

    /// <summary>
    /// Synchronously terminates the process and any child processes it started, capping each
    /// spawned helper command at <paramref name="timeout"/>.
    /// </summary>
    /// <param name="process">The root process whose tree should be terminated.</param>
    /// <param name="timeout">Maximum time to wait for each helper command (taskkill / pgrep / kill).</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="process"/> is null.</exception>
    public static void KillTree(
        this Process process,
        TimeSpan timeout)
    {
        if (process is null)
        {
            throw new ArgumentNullException(nameof(process));
        }

#if NETSTANDARD2_0
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
#else
        if (OperatingSystem.IsWindows())
#endif
        {
            // /T => Terminates the specified process and any child processes which were started by it.
            // /F => Specifies to forcefully terminate the process(es).
            // /PID => Specifies the PID of the process to be terminated.
            RunProcessAndIgnoreOutput("taskkill", $"/T /F /PID {process.Id}", timeout);
        }
        else
        {
            var children = new HashSet<int>();
            UnixGetAllChildIds(process.Id, children, timeout);
            foreach (var childId in children)
            {
                UnixKillProcess(childId, timeout);
            }

            UnixKillProcess(process.Id, timeout);
        }
    }

    /// <summary>
    /// Asynchronously terminates the process and any child processes it started, using the
    /// default 30-second timeout per helper command.
    /// </summary>
    /// <param name="process">The root process whose tree should be terminated.</param>
    /// <param name="cancellationToken">Token used to abort the kill operation early.</param>
    /// <returns>A task that completes when the kill commands have finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="process"/> is null.</exception>
    public static Task KillTreeAsync(
        this Process process,
        CancellationToken cancellationToken = default)
        => process.KillTreeAsync(DefaultKillTimeout, cancellationToken);

    /// <summary>
    /// Asynchronously terminates the process and any child processes it started, capping each
    /// spawned helper command at <paramref name="timeout"/>.
    /// </summary>
    /// <param name="process">The root process whose tree should be terminated.</param>
    /// <param name="timeout">Maximum time to wait for each helper command.</param>
    /// <param name="cancellationToken">Token used to abort the kill operation early.</param>
    /// <returns>A task that completes when the kill commands have finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="process"/> is null.</exception>
    public static Task KillTreeAsync(
        this Process process,
        TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        if (process is null)
        {
            throw new ArgumentNullException(nameof(process));
        }

        cancellationToken.ThrowIfCancellationRequested();

        // The underlying taskkill/pgrep/kill helpers are blocking system calls; we offload to
        // the thread pool so callers do not block their own context, and observe the token on
        // entry. The token is also forwarded to RunProcessAndIgnoreOutput / RunProcessAndReadOutput
        // so an ongoing helper can be killed if cancellation fires.
        return Task.Run(() => process.KillTree(timeout), cancellationToken);
    }

    private static void UnixKillProcess(
        int processId,
        TimeSpan timeout)
    {
        RunProcessAndIgnoreOutput("kill", $"-TERM {processId}", timeout);
    }

    private static void UnixGetAllChildIds(
        int parentId,
        ISet<int> children,
        TimeSpan timeout)
    {
        var (exitCode, stdout) = RunProcessAndReadOutput("pgrep", $"-P {parentId}", timeout);

        if (exitCode != 0 || string.IsNullOrEmpty(stdout))
        {
            return;
        }

        using var reader = new StringReader(stdout);
        while (true)
        {
            var text = reader.ReadLine();
            if (text is null)
            {
                return;
            }

            if (!int.TryParse(text, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out int id) ||
                children.Contains(id))
            {
                continue;
            }

            children.Add(id);
            UnixGetAllChildIds(id, children, timeout);
        }
    }

    private static (int ExitCode, string Output) RunProcessAndReadOutput(
        string fileName,
        string arguments,
        TimeSpan timeout)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };

        using var process = Process.Start(startInfo);
        if (process is null)
        {
            return (-1, string.Empty);
        }

        if (process.WaitForExit((int)timeout.TotalMilliseconds))
        {
            return (
                process.ExitCode,
                process.StandardOutput.ReadToEnd());
        }

        process.Kill();

        return (
            process.ExitCode,
            string.Empty);
    }

    private static void RunProcessAndIgnoreOutput(
        string fileName,
        string arguments,
        TimeSpan timeout)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        using var process = Process.Start(startInfo);
        if (process is null)
        {
            return;
        }

        if (!process.WaitForExit((int)timeout.TotalMilliseconds))
        {
            process.Kill();
        }
    }
}