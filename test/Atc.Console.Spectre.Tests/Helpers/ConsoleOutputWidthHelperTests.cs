namespace Atc.Console.Spectre.Tests.Helpers;

public class ConsoleOutputWidthHelperTests
{
    [Theory]
    [InlineData("120", 120)]
    [InlineData(" 300 ", 300)]
    [InlineData(null, ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    [InlineData("", ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    [InlineData("wide", ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    [InlineData("0", ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    [InlineData("-5", ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    public void GetRedirectedOutputWidth_TakesColumnsWhenItHoldsAWidth(
        string? columns,
        int expected)
        => ConsoleOutputWidthHelper.GetRedirectedOutputWidth(columns).Should().Be(expected);

    [Fact]
    public void RedirectedOutputWidth_IsWiderThanAConsoleWithoutAWindow()
        => ConsoleOutputWidthHelper.RedirectedOutputWidth.Should().BeGreaterThanOrEqualTo(200);

    [Theory]
    [InlineData(true, "150", true, 150)]
    [InlineData(true, null, true, ConsoleOutputWidthHelper.RedirectedOutputWidth)]
    [InlineData(false, "150", false, 80)]
    public void ApplyRedirectedOutputWidth_SetsTheWidthOnlyWhenRedirected(
        bool isOutputRedirected,
        string? columns,
        bool expectedApplied,
        int expectedWidth)
    {
        // Arrange
        using var testConsole = new TestConsole(width: 80);
        var console = testConsole.Console;

        // Act
        var applied = ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth(console, isOutputRedirected, columns);

        // Assert
        applied.Should().Be(expectedApplied);
        testConsole.Console.Profile.Width.Should().Be(expectedWidth);
    }

    [Fact]
    public void ApplyRedirectedOutputWidth_RedirectedOutput_DoesNotBreakALongLine()
    {
        // Arrange
        using var testConsole = new TestConsole(width: 80);
        var path = Path.Combine("C:", new string('a', 60), new string('b', 60), "missing.yaml");

        // Act
        ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth(testConsole.Console, isOutputRedirected: true, columns: null);
        testConsole.Console.WriteLine(path);

        // Assert
        testConsole.Output.Should().Contain(path);
    }

    [Fact]
    public void ApplyRedirectedOutputWidth_DefaultConsole_FollowsTheProcessOutput()
    {
        // Arrange
        var originalWidth = AnsiConsole.Profile.Width;

        try
        {
            // Act
            var applied = ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth();

            // Assert
            applied.Should().Be(System.Console.IsOutputRedirected);
        }
        finally
        {
            AnsiConsole.Profile.Width = originalWidth;
        }
    }

    [Fact]
    public void ApplyRedirectedOutputWidth_NullConsole_Throws()
    {
        // Act
        var act = () => ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth(null!, isOutputRedirected: true, columns: null);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}