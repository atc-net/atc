// ReSharper disable once CheckNamespace
namespace Atc;

[Flags]
public enum TemplatePatternType
{
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
    /// The hard brackets pattern: [ * ] or [[ * ]]
    /// </summary>
    HardBrackets = SingleHardBrackets | DoubleHardBrackets,

    /// <summary>
    /// The curly braces pattern: { * } or {{ * }}
    /// </summary>
    CurlyBraces = SingleCurlyBraces | DoubleCurlyBraces,

    All = SingleHardBrackets | DoubleHardBrackets | SingleCurlyBraces | DoubleCurlyBraces,
}