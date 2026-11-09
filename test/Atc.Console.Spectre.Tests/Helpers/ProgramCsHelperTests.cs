namespace Atc.Console.Spectre.Tests.Helpers;

public class ProgramCsHelperTests
{
    [Fact]
    public void SetHelpArgumentIfNeeded_NoArguments_ReturnsTheHelpArgument()
    {
        // Act
        var actual = ProgramCsHelper.SetHelpArgumentIfNeeded([]);

        // Assert
        actual.Should().Equal(CommandConstants.ArgumentShortHelp);
    }

    [Fact]
    public void SetHelpArgumentIfNeeded_WithArguments_ReturnsThemUnchanged()
    {
        // Arrange
        string[] args = ["hello", "Phil"];

        // Act
        var actual = ProgramCsHelper.SetHelpArgumentIfNeeded(args);

        // Assert
        actual.Should().BeSameAs(args);
    }

    [Fact]
    public void SetHelpArgumentIfNeeded_Null_Throws()
    {
        // Act
        var act = () => ProgramCsHelper.SetHelpArgumentIfNeeded(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(new[] { "hello", "--verbose" }, LogLevel.Trace)]
    [InlineData(new[] { "hello", "--VERBOSE" }, LogLevel.Trace)]
    [InlineData(new[] { "hello" }, LogLevel.Information)]
    public void SetMinimumLogLevelIfNeeded_SetsTraceOnlyForVerbose(
        string[] args,
        LogLevel expected)
    {
        // Arrange
        var configuration = new ConsoleLoggerConfiguration
        {
            MinimumLogLevel = LogLevel.Information,
        };

        // Act
        ProgramCsHelper.SetMinimumLogLevelIfNeeded(args, configuration);

        // Assert
        configuration.MinimumLogLevel.Should().Be(expected);
    }
}