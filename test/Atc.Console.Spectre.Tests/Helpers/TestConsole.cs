namespace Atc.Console.Spectre.Tests.Helpers;

/// <summary>
/// A plain-text Spectre console that writes to a string, so a test can read what was written.
/// </summary>
internal sealed class TestConsole : IDisposable
{
    private readonly StringWriter writer = new(CultureInfo.InvariantCulture);

    public TestConsole(int width = 200)
    {
        Console = AnsiConsole.Create(new AnsiConsoleSettings
        {
            Ansi = AnsiSupport.No,
            ColorSystem = ColorSystemSupport.NoColors,
            Interactive = InteractionSupport.No,
            Out = new AnsiConsoleOutput(writer),
        });

        Console.Profile.Width = width;
    }

    public IAnsiConsole Console { get; }

    public string Output => writer.ToString();

    public void Dispose()
        => writer.Dispose();
}