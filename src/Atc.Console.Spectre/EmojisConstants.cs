namespace Atc.Console.Spectre;

/// <summary>
/// Provides commonly used emoji constants for console output using Spectre.Console.
/// </summary>
public static class EmojisConstants
{
    /// <summary>
    /// Green circle emoji used to indicate a file was created.
    /// </summary>
    public const string FileCreated = Emoji.Known.GreenCircle;

    /// <summary>
    /// Blue circle emoji used to indicate a file was updated.
    /// </summary>
    public const string FileUpdated = Emoji.Known.BlueCircle;

    /// <summary>
    /// White circle emoji used to indicate a file was not updated.
    /// </summary>
    public const string FileNotUpdated = Emoji.Known.WhiteCircle;

    /// <summary>
    /// Check mark button emoji used to indicate success.
    /// </summary>
    public const string Success = Emoji.Known.CheckMarkButton;

    /// <summary>
    /// Red circle emoji used to indicate an error.
    /// </summary>
    public const string Error = Emoji.Known.RedCircle;
}