namespace Atc.Helpers;

/// <summary>
/// Helpers for the reserved C# keywords, for code generators that turn arbitrary names into C# identifiers.
/// </summary>
/// <remarks>
/// Only the reserved keywords are covered (including the undocumented <c>__arglist</c>, <c>__makeref</c>,
/// <c>__reftype</c> and <c>__refvalue</c>). Contextual keywords such as <c>var</c>, <c>async</c> or <c>record</c>
/// are valid identifiers and are not reported.
/// </remarks>
public static class CSharpKeywordHelper
{
    private static readonly HashSet<string> Keywords = new(StringComparer.Ordinal)
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
        "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
        "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
        "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
        "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
        "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
        "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
        "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual",
        "void", "volatile", "while",

        // Reserved too, though undocumented
        "__arglist", "__makeref", "__reftype", "__refvalue",
    };

    /// <summary>
    /// Gets the reserved C# keywords, in no particular order.
    /// </summary>
    public static IReadOnlyCollection<string> ReservedKeywords
        => Keywords;

    /// <summary>
    /// Determines whether a name is a reserved C# keyword (case-sensitive: <c>Class</c> is not a keyword).
    /// </summary>
    /// <param name="name">The name to check.</param>
    /// <returns><see langword="true"/> when <paramref name="name"/> is a reserved keyword; otherwise <see langword="false"/>.</returns>
    public static bool IsReservedKeyword(string? name)
        => name is not null && Keywords.Contains(name);

    /// <summary>
    /// Prefixes a name with <c>@</c> when it is a reserved C# keyword, so it can be emitted as an identifier
    /// (<c>event</c> becomes <c>@event</c>); any other name is returned unchanged.
    /// </summary>
    /// <param name="name">The candidate identifier.</param>
    /// <returns>An identifier that does not collide with a reserved keyword.</returns>
    public static string EscapeIfReservedKeyword(string name)
        => IsReservedKeyword(name)
            ? "@" + name
            : name;

    /// <summary>
    /// Determines whether a name is a valid C# identifier without an <c>@</c> prefix: it starts with a letter or
    /// <c>_</c>, has only letters, digits and <c>_</c> after that, and is not a reserved keyword.
    /// </summary>
    /// <remarks>
    /// The check is deliberately conservative: C# also allows some Unicode combining and formatting characters,
    /// which this method rejects, so a name it accepts is always valid.
    /// </remarks>
    /// <param name="name">The name to check.</param>
    /// <returns><see langword="true"/> when <paramref name="name"/> can be used as an identifier as it is.</returns>
    public static bool IsValidIdentifier(string? name)
    {
        if (name is null ||
            name.Length == 0 ||
            !(char.IsLetter(name[0]) || name[0] == '_') ||
            Keywords.Contains(name))
        {
            return false;
        }

        foreach (var c in name)
        {
            if (!char.IsLetterOrDigit(c) && c != '_')
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Puts <paramref name="prefix"/> in front of a name that does not start as an identifier does (with a letter or
    /// <c>_</c>): <c>2fa</c> becomes <c>Header2fa</c> with the prefix <c>Header</c>. An empty name becomes the prefix.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="prefix">The prefix to add when needed.</param>
    /// <returns>The name, starting as an identifier does.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> or <paramref name="prefix"/> is <see langword="null"/>.</exception>
    public static string EnsureIdentifierStart(
        string name,
        string prefix)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (prefix is null)
        {
            throw new ArgumentNullException(nameof(prefix));
        }

        return name.Length > 0 && (char.IsLetter(name[0]) || name[0] == '_')
            ? name
            : prefix + name;
    }
}