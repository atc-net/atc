// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines template placeholder patterns that can be used for string replacement and templating.
/// This is a flags enumeration that allows multiple pattern types to be combined.
/// </summary>
[Flags]
public enum TemplatePatternType
{
    /// <summary>
    /// No template pattern specified.
    /// </summary>
    None = 0x0,

    /// <summary>
    /// The single hard brackets pattern: [ * ]
    /// </summary>
    SingleHardBrackets = 0x1,

    /// <summary>
    /// The double hard brackets pattern: [[ * ]]
    /// </summary>
    DoubleHardBrackets = 0x2,

    /// <summary>
    /// The single curly braces: { * }
    /// </summary>
    SingleCurlyBraces = 0x4,

    /// <summary>
    /// The double curly braces pattern: {{ * }}
    /// </summary>
    DoubleCurlyBraces = 0x8,

    /// <summary>
    /// Combines both single and double hard bracket patterns: [ * ] or [[ * ]]
    /// </summary>
    HardBrackets = SingleHardBrackets | DoubleHardBrackets,

    /// <summary>
    /// Combines both single and double curly brace patterns: { * } or {{ * }}
    /// </summary>
    CurlyBraces = SingleCurlyBraces | DoubleCurlyBraces,

    /// <summary>
    /// All template patterns combined.
    /// </summary>
    All = SingleHardBrackets | DoubleHardBrackets | SingleCurlyBraces | DoubleCurlyBraces,
}