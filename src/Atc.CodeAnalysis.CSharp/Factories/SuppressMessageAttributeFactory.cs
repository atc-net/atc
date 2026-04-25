namespace Atc.CodeAnalysis.CSharp.Factories;

/// <summary>
/// SuppressMessage Attribute Factory.
/// </summary>
/// <remarks>
/// Code Analysis Warnings for Managed Code by CheckId:
/// https://docs.microsoft.com/en-us/visualstudio/code-quality/code-analysis-warnings-for-managed-code-by-checkid?view=vs-2019.
/// </remarks>
public static class SuppressMessageAttributeFactory
{
    private const string DefaultCodeAnalysisCategory = "Microsoft.Design";
    private const string DefaultStyleCopCategory = "StyleCop.CSharp.MaintainabilityRules";

    private static readonly Dictionary<int, (string Category, string Title)> CodeAnalysisRules = new()
    {
        [1000] = ("Design", "CA1000:Do not declare static members on generic types"),
        [1002] = ("Design", "CA1002:Do not expose generic lists"),
        [1008] = ("Design", "CA1008:Enums should have zero value"),
        [1019] = ("Design", "CA1019:Define accessors for attribute arguments"),
        [1024] = ("Design", "CA1024:Use properties where appropriate"),
        [1030] = ("Design", "CA1030:Use events where appropriate"),
        [1031] = ("Design", "CA1031:Do not catch general exception types"),
        [1034] = ("Design", "CA1034:Nested types should not be visible"),
        [1051] = ("Design", "CA1051:Do not declare visible instance fields"),
        [1062] = ("Design", "CA1062:Validate arguments of public methods"),
        [1304] = ("Globalization", "CA1304:Specify CultureInfo"),
        [1305] = ("Globalization", "CA1305:Specify IFormatProvider"),
        [1308] = ("Globalization", "CA1308:Normalize strings to uppercase"),
        [1508] = ("Maintainability", "CA1508:Avoid dead conditional code"),
        [1707] = ("Naming", "CA1707:Identifiers should not contain underscores"),
        [1708] = ("Naming", "CA1708:Identifiers should differ by more than case"),
        [1711] = ("Naming", "CA1711:Identifiers should not have incorrect suffix"),
        [1716] = ("Naming", "CA1716:Identifiers should not match keywords"),
        [1720] = ("Naming", "CA1720:Identifiers should not contain type names"),
        [1810] = ("Performance", "CA1810:Initialize reference type static fields inline"),
        [1811] = ("Performance", "CA1811:Avoid uncalled private code"),
        [1813] = ("Performance", "CA1813:Avoid unsealed attributes"),
        [1820] = ("Performance", "CA1820:Test for empty strings using string length"),
        [1822] = ("Performance", "CA1822:Mark members as static"),
        [1849] = ("Performance", "CA1849:Call async methods when in an async method"),
        [2000] = ("Reliability", "CA2000:Dispose objects before losing scope"),
        [2007] = ("Reliability", "CA2007:Do not directly await a Task"),
        [2008] = ("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler"),
        [2227] = ("Usage", "CA2227:Collection properties should be read only"),
        [5404] = ("Security", "CA5404:Do not disable token validation checks"),
    };

    private static readonly Dictionary<int, (string Category, string Title)> StyleCopRules = new()
    {
        [1011] = ("Spacing Rules", "SA1011:Closing square brackets should be spaced correctly"),
        [1025] = ("Readability Rules", "SA1025:Code should not contain multiple whitespace in a row"),
        [1028] = ("Readability Rules", "SA1028:Code should not contain trailing whitespace"),
        [1123] = ("Readability Rules", "SA1123:Do not place regions within elements"),
        [1131] = ("Readability Rules", "SA1131:Use readable conditions"),
        [1307] = ("Naming Rules", "SA1307:Accessible fields should begin with upper-case letter"),
        [1310] = ("Naming Rules", "SA1310:Field names should not contain underscore"),
        [1312] = ("Naming Rules", "SA1312:Variable names should begin with lower-case letter"),
        [1401] = ("Maintainability Rules", "SA1401:Fields should be private"),
        [1407] = ("Maintainability Rules", "SA1407:Arithmetic expressions should declare precedence"),
        [1413] = ("Maintainability Rules", "SA1413:Use trailing comma in multi-line initializers"),
        [1605] = ("Documentation Rules", "SA1605:Partial element documentation should have summary"),
        [1615] = ("Documentation Rules", "SA1615:Element return value should be documented"),
        [1625] = ("Documentation Rules", "SA1625:Element documentation should not be copied and pasted"),
    };

    /// <summary>
    /// Creates a <see cref="SuppressMessageAttribute"/> for a Code Analysis (CA) rule suppression.
    /// </summary>
    /// <param name="checkId">The numeric identifier of the CA rule to suppress (e.g., 1062 for CA1062).</param>
    /// <param name="justification">The justification for suppressing the rule. If null or empty, defaults to "OK.".</param>
    /// <returns>
    /// A <see cref="SuppressMessageAttribute"/> configured for the specified rule. Well-known rules
    /// receive their canonical category and human-readable title; unknown rules receive a generic
    /// "<c>Microsoft.Design</c>" category and the bare rule id, which is sufficient for the
    /// analyzer match (matching is on rule id only, not on category).
    /// </returns>
    public static SuppressMessageAttribute CreateCodeAnalysisSuppression(
        int checkId,
        string? justification)
    {
        if (string.IsNullOrEmpty(justification))
        {
            justification = "OK.";
        }

        if (CodeAnalysisRules.TryGetValue(checkId, out var rule))
        {
            return new SuppressMessageAttribute(rule.Category, rule.Title) { Justification = justification };
        }

        return new SuppressMessageAttribute(DefaultCodeAnalysisCategory, $"CA{checkId}") { Justification = justification };
    }

    /// <summary>
    /// Creates a <see cref="SuppressMessageAttribute"/> for a StyleCop (SA) rule suppression.
    /// </summary>
    /// <param name="checkId">The numeric identifier of the SA rule to suppress (e.g., 1413 for SA1413).</param>
    /// <param name="justification">The justification for suppressing the rule. If null or empty, defaults to "OK.".</param>
    /// <returns>
    /// A <see cref="SuppressMessageAttribute"/> configured for the specified rule. Well-known rules
    /// receive their canonical category and human-readable title; unknown rules receive a generic
    /// "<c>StyleCop.CSharp.MaintainabilityRules</c>" category and the bare rule id.
    /// </returns>
    public static SuppressMessageAttribute CreateStyleCopSuppression(
        int checkId,
        string? justification)
    {
        if (string.IsNullOrEmpty(justification))
        {
            justification = "OK.";
        }

        if (StyleCopRules.TryGetValue(checkId, out var rule))
        {
            return new SuppressMessageAttribute(rule.Category, rule.Title) { Justification = justification };
        }

        return new SuppressMessageAttribute(DefaultStyleCopCategory, $"SA{checkId}") { Justification = justification };
    }
}