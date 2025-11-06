namespace Atc.Console.Spectre.Tests.SampleIntegrationTests.Demo.Atc.Console.Spectre.Cli;

[Collection("TestCollection")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class CommandTests : SampleIntegrationTestBase
{
    [Theory]
    [InlineData("Hello, Phil", "hello Phil")]
    [InlineData("Hello, Phil - 4", "hello Phil --count 4")]
    public async Task Hello_Command(
        string expected,
        string arguments)
    {
        // Arrange & Act
        var (isCliExecutedCorrectly, output) = await ExecuteCli(arguments);
        var outputLines = CleanConsoleMarkupAndSplitLines(output);

        // Assert
        Assert.True(isCliExecutedCorrectly, "isCliExecutedCorrectly");
        AssertInLines(expected, outputLines);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForCommandTests.LogCommand), MemberType = typeof(TestMemberDataForCommandTests))]
    public async Task Log_Command(
        string[] expectedList,
        string arguments,
        ConsoleLoggerConfiguration config)
    {
        // Arrange
        PrepareCliAppSettings(config);

        // Act
        var (isCliExecutedCorrectly, output) = await ExecuteCli(arguments);
        var outputLines = CleanConsoleMarkupAndSplitLines(output);

        // Assert
        Assert.True(isCliExecutedCorrectly, "isCliExecutedCorrectly");
        foreach (var expected in expectedList)
        {
            AssertInLines(expected, outputLines);
        }
    }

    private static void AssertInLines(
        string expected,
        string[] lines)
    {
        var found = lines.Any(x => x.Equals(expected, StringComparison.Ordinal));
        Assert.True(found, $"\nExpectedLine:  '{expected}'\nin ActualData: '{string.Join('\n', lines)}'");
    }

    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1025:Code should not contain multiple whitespace in a row", Justification = "OK.")]
    private static string[] CleanConsoleMarkupAndSplitLines(string output)
    {
        var s = JsonSerializer.Serialize(output);

        var value = s.Substring(1, s.Length - 2);   // Remove first and last " from Serialization
        value = value
            .Replace("\\r\\n", "\n", StringComparison.Ordinal)
            .Replace("\\r", "\n", StringComparison.Ordinal)
            .Replace("\\n", "\n", StringComparison.Ordinal);

        var lines = value
            .Replace("\\u001B[38;5;9m", string.Empty, StringComparison.Ordinal)         // Red
            .Replace("\\u001B[38;5;9;48;5;15m", string.Empty, StringComparison.Ordinal) // Red on White
            .Replace("\\u001B[38;5;214m", string.Empty, StringComparison.Ordinal)       // Orange1
            .Replace("\\u001B[38;5;39m", string.Empty, StringComparison.Ordinal)        // Deepskyblue1
            .Replace("\\u001B[38;5;2m", string.Empty, StringComparison.Ordinal)         // Green
            .Replace("\\u001B[38;5;12m", string.Empty, StringComparison.Ordinal)        // Blue
            .Replace("\\u001B[38;5;8m", string.Empty, StringComparison.Ordinal)         // Gray
            .Replace("\\u001B[0m", string.Empty, StringComparison.Ordinal)              // "End"
            .Split("\n", StringSplitOptions.RemoveEmptyEntries);

        return lines;
    }
}