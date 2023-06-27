// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
namespace Atc.Tests.Helpers;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "OK.")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
[SupportedOSPlatform("Windows")]
public class ProcessHelperTests
{
    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help")]
    public async Task Execute_With_FileInfo_Arguments(
        string expectedLineInOutput,
        string filePath,
        string arguments)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help")]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            directoryInfo,
            fileInfo,
            arguments);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", true)]
    public async Task Execute_With_FileInfo_Arguments_RunAsAdmin(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        bool runAsAdministrator)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            runAsAdministrator);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", 1)]
    public async Task Execute_With_FileInfo_Arguments_Timeout_CancellationToken(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        int timeoutInSec)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            timeoutInSec,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", 1, true)]
    public async Task Execute_With_FileInfo_Arguments_Timeout_RunAsAdmin(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        int timeoutInSec,
        bool runAsAdministrator)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            timeoutInSec,
            runAsAdministrator);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", 1, true)]
    public async Task Execute_With_FileInfo_Arguments_Timeout_RunAsAdmin_CancellationToken(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        int timeoutInSec,
        bool runAsAdministrator)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            timeoutInSec,
            runAsAdministrator,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help", 1)]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments_Timeout_CancellationToken(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments,
        int timeoutInSec)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            directoryInfo,
            fileInfo,
            arguments,
            timeoutInSec,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help", 1, true)]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments_Timeout_RunAsAdmin_CancellationToken(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments,
        int timeoutInSec,
        bool runAsAdministrator)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            directoryInfo,
            fileInfo,
            arguments,
            timeoutInSec,
            runAsAdministrator,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }
}