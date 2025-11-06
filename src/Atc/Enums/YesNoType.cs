// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a binary yes/no choice or answer.
/// </summary>
public enum YesNoType
{
    /// <summary>
    /// No answer specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Negative response (No).
    /// </summary>
    [LocalizedDescription("YesNoTypeNo", typeof(EnumResources))]
    No = 1,

    /// <summary>
    /// Affirmative response (Yes).
    /// </summary>
    [LocalizedDescription("YesNoTypeYes", typeof(EnumResources))]
    Yes = 2,
}