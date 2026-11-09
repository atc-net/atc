namespace Atc.Console.Spectre.Tests.Helpers;

public class CommandAppHelperTests
{
    [Fact]
    public void WriteException_PlainException_WritesOneErrorLineWithTheMessageAsItIs()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var console = testConsole.Console;
        var exception = new InvalidOperationException("File [red]C:\\a[1].yaml[/] not found");

        // Act
        var exitCode = CommandAppHelper.WriteException(console, exception);

        // Assert
        exitCode.Should().Be(1);
        testConsole.Output.TrimEnd().Should().Be("Error: File [red]C:\\a[1].yaml[/] not found");
    }

    [Fact]
    public void WriteException_NullException_Throws()
    {
        // Arrange
        using var testConsole = new TestConsole();

        // Act
        var act = () => CommandAppHelper.WriteException(testConsole.Console, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void UseSingleLineExceptionHandler_CommandThrows_WritesOneErrorLineAndReturnsOne()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var console = testConsole.Console;
        var app = CreateApp(console);

        // Act
        CommandAppHelper.UseSingleLineExceptionHandler(app, console);
        var exitCode = app.Run(["fail"], TestContext.Current.CancellationToken);

        // Assert
        exitCode.Should().Be(1);
        testConsole.Output.TrimEnd().Should().Be("Error: Something [went] wrong");
    }

    [Fact]
    public void UseSingleLineExceptionHandler_UnknownCommand_WritesTheParseError()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var app = CreateApp(testConsole.Console);

        // Act
        CommandAppHelper.UseSingleLineExceptionHandler(app, testConsole.Console);
        var exitCode = app.Run(["nope"], TestContext.Current.CancellationToken);

        // Assert
        exitCode.Should().Be(1);
        testConsole.Output.Should().Contain("nope");
        testConsole.Output.Should().NotContain(" at ");
    }

    [Fact]
    public void UseSingleLineExceptionHandler_DefaultConsole_ConfiguresTheApp()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var app = CreateApp(testConsole.Console);

        // Act
        CommandAppHelper.UseSingleLineExceptionHandler(app);
        var exitCode = app.Run(["ok"], TestContext.Current.CancellationToken);

        // Assert
        exitCode.Should().Be(0);
    }

    [Fact]
    public void UseSingleLineExceptionHandler_NullApp_Throws()
    {
        // Act
        var act = () => CommandAppHelper.UseSingleLineExceptionHandler(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void UseStrictParsing_UnknownOption_Fails()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var app = CreateApp(testConsole.Console);
        CommandAppHelper.UseSingleLineExceptionHandler(app, testConsole.Console);

        // Act
        CommandAppHelper.UseStrictParsing(app);
        var exitCode = app.Run(["ok", "--unknown"], TestContext.Current.CancellationToken);

        // Assert
        exitCode.Should().Be(1);
        testConsole.Output.Should().Contain("--unknown");
    }

    [Fact]
    public void UseStrictParsing_NullApp_Throws()
    {
        // Act
        var act = () => CommandAppHelper.UseStrictParsing(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    private static CommandApp CreateApp(IAnsiConsole console)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config.ConfigureConsole(console);
            config.AddCommand<OkCommand>("ok");
            config.AddCommand<FailCommand>("fail");
        });

        return app;
    }

    [SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Created by Spectre.Console.Cli.")]
    private sealed class OkCommand : Command
    {
        public override int Execute(
            CommandContext context,
            CancellationToken cancellationToken)
            => 0;
    }

    [SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Created by Spectre.Console.Cli.")]
    private sealed class FailCommand : Command
    {
        public override int Execute(
            CommandContext context,
            CancellationToken cancellationToken)
            => throw new InvalidOperationException("Something [went] wrong");
    }
}