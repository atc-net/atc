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
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", true, 1)]
    public async Task Execute_With_FileInfo_Arguments_RunAsAdmin_Timeout(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\Windows\System32\netsh.exe", "help", true, 1)]
    public async Task Execute_With_FileInfo_Arguments_RunAsAdmin_Timeout_Cancellation(
        string expectedLineInOutput,
        string filePath,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec)
    {
        // Arrange
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);

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
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help", true)]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments_RunAsAdmin(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments,
        bool runAsAdministrator)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            directoryInfo,
            fileInfo,
            arguments,
            runAsAdministrator);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help", true, 1)]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments_RunAsAdmin_Timeout(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.Execute(
            directoryInfo,
            fileInfo,
            arguments,
            runAsAdministrator,
            timeoutInSec);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("Commands in this context:", @"C:\", @"C:\Windows\System32\netsh.exe", "help", true, 1)]
    public async Task Execute_With_WorkingDirectory_FileInfo_Arguments_RunAsAdmin_Timeout_Cancellation(
        string expectedLineInOutput,
        string workingDirectoryPath,
        string filePath,
        string arguments,
        bool runAsAdministrator,
        ushort timeoutInSec)
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
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        Assert.True(output.Contains(expectedLineInOutput, StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(@"C:\", @"C:\Windows\System32\cmd.exe", "", new[] { "node.exe -v", "exit" })]
    public async Task ExecutePrompt_With_WorkingDirectory_FileInfo_Arguments_InputLines(
        string workingDirectoryPath,
        string filePath,
        string arguments,
        string[] inputLines)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.ExecutePrompt(
            directoryInfo,
            fileInfo,
            arguments,
            inputLines);

        // Assert
        Assert.True(isSuccessful);
        foreach (var inputLine in inputLines)
        {
            Assert.True(output.Contains(inputLine, StringComparison.Ordinal));
        }
    }

    [Theory]
    [InlineData(@"C:\", @"C:\Windows\System32\cmd.exe", "", new[] { "node.exe -v", "exit" }, true)]
    public async Task ExecutePrompt_With_WorkingDirectory_FileInfo_Arguments_InputLines_RunAsAdmin(
        string workingDirectoryPath,
        string filePath,
        string arguments,
        string[] inputLines,
        bool runAsAdministrator)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.ExecutePrompt(
            directoryInfo,
            fileInfo,
            arguments,
            inputLines,
            runAsAdministrator);

        // Assert
        Assert.True(isSuccessful);
        foreach (var inputLine in inputLines)
        {
            Assert.True(output.Contains(inputLine, StringComparison.Ordinal));
        }
    }

    [Theory]
    [InlineData(@"C:\", @"C:\Windows\System32\cmd.exe", "", new[] { "node.exe -v", "exit" }, true, 1)]
    public async Task ExecutePrompt_With_WorkingDirectory_FileInfo_Arguments_InputLines_RunAsAdmin_Timeout(
        string workingDirectoryPath,
        string filePath,
        string arguments,
        string[] inputLines,
        bool runAsAdministrator,
        ushort timeoutInSec)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);

        // Act
        var (isSuccessful, output) = await ProcessHelper.ExecutePrompt(
            directoryInfo,
            fileInfo,
            arguments,
            inputLines,
            runAsAdministrator,
            timeoutInSec);

        // Assert
        Assert.True(isSuccessful);
        foreach (var inputLine in inputLines)
        {
            Assert.True(output.Contains(inputLine, StringComparison.Ordinal));
        }
    }

    [Theory]
    [InlineData(@"C:\", @"C:\Windows\System32\cmd.exe", "", new[] { "node.exe -v", "exit" }, true, 1)]
    public async Task ExecutePrompt_With_WorkingDirectory_FileInfo_Arguments_InputLines_RunAsAdmin_Timeout_Cancellation(
        string workingDirectoryPath,
        string filePath,
        string arguments,
        string[] inputLines,
        bool runAsAdministrator,
        ushort timeoutInSec)
    {
        // Arrange
        var directoryInfo = new DirectoryInfo(workingDirectoryPath);
        var fileInfo = new FileInfo(filePath);
        var cancellationToken = CancellationToken.None;

        // Act
        var (isSuccessful, output) = await ProcessHelper.ExecutePrompt(
            directoryInfo,
            fileInfo,
            arguments,
            inputLines,
            runAsAdministrator,
            timeoutInSec,
            cancellationToken);

        // Assert
        Assert.True(isSuccessful);
        foreach (var inputLine in inputLines)
        {
            Assert.True(output.Contains(inputLine, StringComparison.Ordinal));
        }
    }
}