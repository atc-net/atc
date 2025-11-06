namespace Atc.Console.Spectre.Logging;

/// <summary>
/// Defines the rendering modes for console log output.
/// </summary>
public enum ConsoleRenderingMode
{
    /// <summary>
    /// Default rendering mode with minimal formatting.
    /// </summary>
    Default,

    /// <summary>
    /// Includes log level in the output.
    /// </summary>
    LogLevel,

    /// <summary>
    /// Includes category name in the output.
    /// </summary>
    CategoryName,

    /// <summary>
    /// Includes both log level and category name in the output.
    /// </summary>
    LogLevelAndCategoryName,
}