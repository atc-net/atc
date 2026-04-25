namespace Atc.Tests.Extensions;

public class ProcessExtensionsTests
{
    [Fact]
    public async Task KillTreeAsync_NullProcess_ThrowsArgumentNullException()
    {
        // Arrange
        Process process = null!;

        // Act
        var act = async () => await process.KillTreeAsync();

        // Assert
        (await act.Should().ThrowAsync<ArgumentNullException>())
            .WithParameterName("process");
    }

    [Fact]
    public async Task KillTreeAsync_AlreadyCancelled_ThrowsOperationCanceled()
    {
        // Arrange
        using var process = new Process();
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var act = async () => await process.KillTreeAsync(cts.Token);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    [Fact]
    public async Task KillTreeAsync_AlreadyExitedProcess_CompletesWithoutThrowing()
    {
        // Arrange — start a no-op short-lived process, wait for exit, then ask for a tree-kill.
        var startInfo = new ProcessStartInfo
        {
            FileName = OperatingSystem.IsWindows() ? "cmd.exe" : "/bin/sh",
            Arguments = OperatingSystem.IsWindows() ? "/c exit 0" : "-c \"exit 0\"",
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        using var process = Process.Start(startInfo);
        process.Should().NotBeNull();
        await process!.WaitForExitAsync();

        // Act
        var act = async () => await process.KillTreeAsync(TimeSpan.FromSeconds(5));

        // Assert
        await act.Should().NotThrowAsync();
    }
}