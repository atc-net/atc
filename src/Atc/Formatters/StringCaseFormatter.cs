// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Provides custom string formatting based on specified case formatting options.<br /><br />
/// Supported formats:
/// <list type="table">
///    <item>
///        <term>U</term>
///        <description>Converts the entire string to uppercase.</description>
///    </item>
///    <item>
///        <term>u</term>
///        <description>Capitalizes the first character of the string.</description>
///    </item>
///    <item>
///        <term>L</term>
///        <description>Converts the entire string to lowercase.</description>
///    </item>
///    <item>
///        <term>l</term>
///        <description>Converts the first character of the string to lowercase.</description>
///    </item>
///    <item>
///        <term>Ul</term>
///        <description>Converts the string to uppercase with the first character in lowercase.</description>
///    </item>
///    <item>
///        <term>Lu</term>
///        <description>Converts the string to lowercase with the first character capitalized.</description>
///    </item>
///    <item>
///        <term>[Format]:</term>
///        <description>Applies the specified format and appends a colon ´<b>:</b>´ to the end.</description>
///    </item>
///    <item>
///        <term>[Format].</term>
///        <description>Applies the specified format and appends a period ´<b>.</b>´ to the end.</description>
///    </item>
/// </list>
/// Examples:
/// <code>string.Format(StringCaseFormatter.Default, "{0:U} {1:u} {2:L} {3:l}", .... 4 parameters );</code>
/// <code>string.Format(StringCaseFormatter.Default, "{0:U.} {1:u.} {2:L:} {3:l:}", .... 4 parameters );</code>
/// <code>string.Format(StringCaseFormatter.Default, "{0:Ul:} {1:Lu:}", ... 2 parameters );</code>
/// <code>string.Format(new StringCaseFormatter(), "{0:U} {1:u} {2:L} {3:l}", ... 4 parameters );</code>
/// </summary>
public sealed class StringCaseFormatter : IFormatProvider, ICustomFormatter
{
    /// <summary>
    /// Static <see cref="StringCaseFormatter"/> using <see cref="CultureInfo.CurrentCulture"/>.
    /// </summary>
    public static readonly StringCaseFormatter Default = new();

    public object? GetFormat(Type? formatType)
        => formatType == typeof(ICustomFormatter)
            ? this
            : null;

    public string Format(
        string? format,
        object? arg,
        IFormatProvider? formatProvider)
    {
        var str = arg?.ToString() ?? string.Empty;

        return format switch
        {
            "U" => str.ToUpper(CultureInfo.CurrentCulture),
            "Ul" => str.ToUpper(CultureInfo.CurrentCulture).EnsureFirstCharacterToLower(),
            "u" => str.EnsureFirstCharacterToUpper(),
            "L" => str.ToLower(CultureInfo.CurrentCulture),
            "Lu" => str.ToLower(CultureInfo.CurrentCulture).EnsureFirstCharacterToUpper(),
            "l" => str.EnsureFirstCharacterToLower(),

            "U." => str.ToUpper(CultureInfo.CurrentCulture).EnsureEndsWithDot(),
            "Ul." => str.ToUpper(CultureInfo.CurrentCulture).EnsureFirstCharacterToLower().EnsureEndsWithDot(),
            "u." => str.EnsureFirstCharacterToUpper().EnsureEndsWithDot(),
            "L." => str.ToLower(CultureInfo.CurrentCulture).EnsureEndsWithDot(),
            "Lu." => str.ToLower(CultureInfo.CurrentCulture).EnsureFirstCharacterToUpper().EnsureEndsWithDot(),
            "l." => str.EnsureFirstCharacterToLower().EnsureEndsWithDot(),

            "U:" => str.ToUpper(CultureInfo.CurrentCulture).EnsureEndsWithColon(),
            "Ul:" => str.ToUpper(CultureInfo.CurrentCulture).EnsureFirstCharacterToLower().EnsureEndsWithColon(),
            "u:" => str.EnsureFirstCharacterToUpper().EnsureEndsWithColon(),
            "L:" => str.ToLower(CultureInfo.CurrentCulture).EnsureEndsWithColon(),
            "Lu:" => str.ToLower(CultureInfo.CurrentCulture).EnsureFirstCharacterToUpper().EnsureEndsWithColon(),
            "l:" => str.EnsureFirstCharacterToLower().EnsureEndsWithColon(),

            _ => str,
        };
    }

    /// <summary>
    /// Formats the given arguments using the specified format string and the custom case formatting rules defined in StringCaseFormatter.
    /// Each format item in the format string is replaced by the string representation of the corresponding object argument, formatted according to the custom case formatting rules.
    /// </summary>
    /// <param name="format">A composite format string that includes one or more format items, each of which corresponds to an object in the <paramref name="args"/> array.</param>
    /// <param name="args">An object array that contains zero or more objects to format and insert in the format string.</param>
    /// <returns>
    /// A copy of <paramref name="format"/> in which the format items have been replaced by the string representation of the corresponding
    /// objects in <paramref name="args"/>, formatted according to the custom case formatting rules.
    /// </returns>
    /// <example>
    /// <code>
    /// var result = StringCaseFormatter.Format("{0:U} {1:u} {2:L} {3:l}", "john", "dove", "HALLO", "WORLD");
    /// // Result: "JOHN Dove hallo wORLD"
    /// </code>
    /// </example>
    public static string Format(
        string format,
        params object[] args)
        => string.Format(Default, format, args);
}