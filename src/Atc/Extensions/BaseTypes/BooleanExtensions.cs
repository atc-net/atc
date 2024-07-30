// ReSharper disable once CheckNamespace
// ReSharper disable GrammarMistakeInComment
namespace System;

/// <summary>
/// Extensions for the <see cref="bool"/> class.
/// </summary>
[SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
public static class BooleanExtensions
{
    /// <summary>
    /// Determines if the nullable boolean has a value and it is true.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns><c>true</c> if the source has a value and it is true; otherwise, <c>false</c>.</returns>
    public static bool HasValueAndTrue(
        this bool? source)
        => source.HasValue &&
           source.Value;

    /// <summary>
    /// Determines if the nullable boolean has a value and it is false.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns><c>true</c> if the source has a value and it is false; otherwise, <c>false</c>.</returns>
    public static bool HasValueAndFalse(
        this bool? source)
        => source.HasValue &&
           !source.Value;

    /// <summary>
    /// Determines if the nullable boolean does not have a value.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns><c>true</c> if the source does not have a value; otherwise, <c>false</c>.</returns>
    public static bool HasNoValue(
        this bool? source)
        => !source.HasValue;

    /// <summary>
    /// Determines if the nullable boolean does not have a value or is true.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns><c>true</c> if the source does not have a value or is true; otherwise, <c>false</c>.</returns>
    public static bool HasNoValueOrTrue(
        this bool? source)
        => !source.HasValue ||
           source.Value;

    /// <summary>
    /// Determines if the nullable boolean does not have a value or is false.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns><c>true</c> if the source does not have a value or is false; otherwise, <c>false</c>.</returns>
    public static bool HasNoValueOrFalse(
        this bool? source)
        => !source.HasValue ||
           !source.Value;

    /// <summary>
    /// Determines whether the specified nullable booleans are equal.
    /// </summary>
    /// <param name="a">The first nullable boolean.</param>
    /// <param name="b">The second nullable boolean.</param>
    /// <returns><c>true</c> if both nullable booleans are equal; otherwise, <c>false</c>.</returns>
    public static bool IsEqual(
        this bool? a,
        bool? b)
        => a is null || b is null
            ? a is null && b is null
            : a == b;

    /// <summary>
    /// Converts the boolean to an integer.
    /// </summary>
    /// <param name="source">The boolean source.</param>
    /// <returns>1 if the source is true; otherwise, 0.</returns>
    public static int ToInt(
        this bool source)
        => source
            ? 1
            : 0;

    /// <summary>
    /// Converts the nullable boolean to an integer.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns>1 if the source is true; otherwise, 0.</returns>
    public static int ToInt(
        this bool? source)
        => source?.ToInt() ?? 0;

    /// <summary>
    /// Converts the boolean to a "Yes" or "No" string.
    /// </summary>
    /// <param name="source">The boolean source.</param>
    /// <returns>"Yes" if the source is true; otherwise, "No".</returns>
    public static string ToYesNoString(
        this bool source)
        => source
            ? nameof(YesNoType.Yes)
            : nameof(YesNoType.No);

    /// <summary>
    /// Converts the boolean to a <see cref="YesNoType"/>.
    /// </summary>
    /// <param name="source">The boolean source.</param>
    /// <returns><see cref="YesNoType.Yes"/> if the source is true; otherwise, <see cref="YesNoType.No"/>.</returns>
    public static YesNoType ToYesNoType(
        this bool source)
        => source
            ? YesNoType.Yes
            : YesNoType.No;

    /// <summary>
    /// Converts the nullable boolean to a <see cref="YesNoType"/>.
    /// </summary>
    /// <param name="source">The nullable boolean source.</param>
    /// <returns>
    /// <see cref="YesNoType.Yes"/> if the source is true;
    /// <see cref="YesNoType.No"/> if the source is false;
    /// <see cref="YesNoType.None"/> if the source is null.
    /// </returns>
    public static YesNoType ToYesNoType(
        this bool? source)
        => source is null
            ? YesNoType.None
            : source.Value
                ? YesNoType.Yes
                : YesNoType.No;
}