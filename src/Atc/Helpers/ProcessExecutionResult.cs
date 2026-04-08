namespace Atc.Helpers;

/// <summary>
/// Represents the result of a process execution, including success status, output, and timeout information.
/// </summary>
/// <param name="IsSuccessful">Whether the process completed with exit code 0 and no stderr output.</param>
/// <param name="Output">The combined stdout/stderr output, or a timeout/cancellation message.</param>
/// <param name="ExitCode">The process exit code, or -1 if the process was killed or did not start.</param>
/// <param name="IsTimedOut">Whether the process was terminated due to a timeout.</param>
/// <param name="IsCancelled">Whether the process was terminated due to cancellation.</param>
public sealed record ProcessExecutionResult(
    bool IsSuccessful,
    string Output,
    int ExitCode = -1,
    bool IsTimedOut = false,
    bool IsCancelled = false);