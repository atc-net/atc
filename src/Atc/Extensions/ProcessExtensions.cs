// ReSharper disable RedundantSuppressNullableWarningExpression
// ReSharper disable StringLiteralTypo
// ReSharper disable once CheckNamespace
namespace System.Diagnostics;

public static class ProcessExtensions
{
    private static readonly TimeSpan DefaultKillTimeout = TimeSpan.FromSeconds(30);

    public static async Task WaitForExitAsync(this Process process, CancellationToken cancellationToken = default)
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        void ProcessExited(object sender, EventArgs e)
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

            await using (cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken)))
            {
                await tcs.Task.ConfigureAwait(false);
            }
        }
        finally
        {
            process.Exited -= ProcessExited;
        }
    }

    public static void KillTree(this Process process) => process.KillTree(DefaultKillTimeout);

    public static void KillTree(this Process process, TimeSpan timeout)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
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

    private static void UnixKillProcess(int processId, TimeSpan timeout)
    {
        RunProcessAndIgnoreOutput("kill", $"-TERM {processId}", timeout);
    }

    private static void UnixGetAllChildIds(int parentId, ISet<int> children, TimeSpan timeout)
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

            if (!int.TryParse(text, out int id) || children.Contains(id))
            {
                continue;
            }

            children.Add(id);
            UnixGetAllChildIds(id, children, timeout);
        }
    }

    private static (int exitCode, string output) RunProcessAndReadOutput(string fileName, string arguments, TimeSpan timeout)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };

        using var process = Process.Start(startInfo);
        if (process!.WaitForExit((int)timeout.TotalMilliseconds))
        {
            return (
                process.ExitCode,
                process.StandardOutput.ReadToEnd());
        }

        process.Kill();

        return (
            process!.ExitCode,
            string.Empty);
    }

    private static void RunProcessAndIgnoreOutput(string fileName, string arguments, TimeSpan timeout)
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
        if (!process!.WaitForExit((int)timeout.TotalMilliseconds))
        {
            process.Kill();
        }
    }
}