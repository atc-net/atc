// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ReplaceSubstringWithRangeIndexer
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the string class.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// The regex expression for split lines.
    /// </summary>
    /// <remarks>
    /// This regex don't use the platform dependent System.Environment.Newline
    /// but instead works for all platforms as Windows, Unix and Mac.
    /// "\r\n" (\u000D\u000A) for Windows
    /// "\n" (\u000A) for Unix
    /// "\r" (\u000D) for Mac
    /// </remarks>
    private static readonly Lazy<Regex> RxSplitLines = new(() => new Regex("\r\n|\n|\r", RegexOptions.Multiline, TimeSpan.FromSeconds(5)));
    private static readonly Lazy<Regex> RxStringFormatParameterSingleTemplatePlaceholder = new(() => new Regex("{.*?}", RegexOptions.Multiline, TimeSpan.FromSeconds(5)));
    private static readonly Lazy<Regex> RxStringFormatParameterDoubleTemplatePlaceholder = new(() => new Regex("{{.*?}}", RegexOptions.Multiline, TimeSpan.FromSeconds(5)));
    private static readonly Lazy<Regex> RxUnderscore = new(() => new Regex(@"_", RegexOptions.Multiline, TimeSpan.FromSeconds(1)));
    private static readonly Lazy<Regex> RxCamelCase = new(() => new Regex(@"[a-z][A-Z]", RegexOptions.Multiline, TimeSpan.FromSeconds(1)));
    private static readonly Lazy<MatchEvaluator> SplitCamelCaseString = new(() => m =>
    {
        var x = m.ToString();
        return x[0] + " " + x.Substring(1);
    });

    private static readonly char[] TrimCharsForTryParseVersion = { '[', ']', '(', ')', ',' };

    /// <summary>
    /// Indexers the of.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="pattern">The pattern.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> [ignore case sensitive].</param>
    /// <param name="useEndOfPatternToMatch">if set to <see langword="true" /> [use end of pattern to match].</param>
    /// <exception cref="ArgumentNullException">
    /// value
    /// or
    /// pattern.
    /// </exception>
    public static int[] IndexersOf(
        this string value,
        string pattern,
        bool ignoreCaseSensitive = true,
        bool useEndOfPatternToMatch = false)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }

        var indexes = new List<int>();
        var index = 0;
        while ((index = value.IndexOf(
                   pattern,
                   index,
                   ignoreCaseSensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
        {
            if (useEndOfPatternToMatch)
            {
                indexes.Add(index++ + pattern.Length);
            }
            else
            {
                indexes.Add(index++);
            }
        }

        return indexes.ToArray();
    }

    /// <summary>
    /// Words count.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The count of words in the string.</returns>
    public static int WordCount(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return -1;
        }

        var rgx = new Regex("[^a-zA-Z0-9 ]", RegexOptions.None, TimeSpan.FromSeconds(1));
        value = rgx.Replace(value, string.Empty);

        return Regex.Matches(value, @"[\S]+", RegexOptions.None, TimeSpan.FromSeconds(1)).Count;
    }

    /// <summary>
    /// Gets the value between less and greater than chars if exist.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string GetValueBetweenLessAndGreaterThanCharsIfExist(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var indexStart = value.IndexOf('<', StringComparison.Ordinal);
        if (indexStart == -1)
        {
            return value;
        }

        indexStart++;
        var indexEnd = value.IndexOf('>', StringComparison.Ordinal);
        return indexEnd > indexStart
            ? value.Substring(indexStart, indexEnd - indexStart)
            : value;
    }

    /// <summary>
    /// Gets the string format parameter numeric count.
    /// </summary>
    /// <param name="value">The value.</param>
    public static int GetStringFormatParameterNumericCount(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return -1;
        }

        if (!value.IsStringFormatParametersBalanced())
        {
            return -1;
        }

        var parameterIds = new List<int>();
        var sa = value.Split('{');

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var s in sa)
        {
            if (!s.Contains('}', StringComparison.Ordinal))
            {
                continue;
            }

            var sas = s.Split('}');

            // ReSharper disable once InvertIf
            if (sas.Length > 0 && int.TryParse(sas[0], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var x))
            {
                if (!parameterIds.Contains(x))
                {
                    parameterIds.Add(x);
                }
            }
            else
            {
                return -1;
            }
        }

        return parameterIds.Count;
    }

    /// <summary>
    /// Gets the string format parameter literal count.
    /// </summary>
    /// <param name="value">The value.</param>
    public static int GetStringFormatParameterLiteralCount(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return -1;
        }

        if (!value.IsStringFormatParametersBalanced(false))
        {
            return -1;
        }

        var parameterLiterals = new List<string>();
        var sa = value.Split('{');

        // ReSharper disable once NotAccessedVariable
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var s in sa)
        {
            if (!s.Contains('}', StringComparison.Ordinal))
            {
                continue;
            }

            var sas = s.Split('}');

            // ReSharper disable once InvertIf
            if (sas.Length > 0 && !int.TryParse(sas[0], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out _))
            {
                if (!parameterLiterals.Contains(sas[0], StringComparer.Ordinal))
                {
                    parameterLiterals.Add(sas[0]);
                }
            }
            else
            {
                return -1;
            }
        }

        return parameterLiterals.Count;
    }

    /// <summary>
    /// Gets the string format parameter template placeholders.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="useDoubleBracket">Use double bracket if <see langword="true" />;otherwise <see langword="false" />.</param>
    /// <exception cref="ArgumentNullException">value.</exception>
    public static List<string> GetStringFormatParameterTemplatePlaceholders(
        this string value,
        bool useDoubleBracket = true)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var matches = useDoubleBracket
                ? RxStringFormatParameterDoubleTemplatePlaceholder.Value.Matches(value)
                : RxStringFormatParameterSingleTemplatePlaceholder.Value.Matches(value);

        return (from Match match
                in matches
                select match.Value).ToList();
    }

    /// <summary>
    /// Sets the string format parameter template placeholders.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="replacements">The replacements.</param>
    /// <param name="useDoubleBracket">Use double bracket if <see langword="true" />;otherwise <see langword="false" />.</param>
    /// <exception cref="ArgumentNullException">
    /// value
    /// or
    /// replacementData.
    /// </exception>
    public static string SetStringFormatParameterTemplatePlaceholders(
        this string value,
        IDictionary<string, string> replacements,
        bool useDoubleBracket = true)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (replacements is null)
        {
            throw new ArgumentNullException(nameof(replacements));
        }

        var placeholders = value.GetStringFormatParameterTemplatePlaceholders(useDoubleBracket: useDoubleBracket);
        if (useDoubleBracket)
        {
            foreach (var pair in replacements)
            {
                var s = (pair.Key.StartsWith("{{", StringComparison.Ordinal) &&
                         pair.Key.EndsWith("}}", StringComparison.Ordinal)
                    ? placeholders.Find(x => string.Equals(x, pair.Key, StringComparison.Ordinal))
                    : placeholders.Find(x => string.Equals(x, "{{" + pair.Key + "}}", StringComparison.Ordinal)))!;

                if (!string.IsNullOrEmpty(s))
                {
                    value = value.Replace(s, pair.Value, StringComparison.Ordinal);
                }
            }
        }
        else
        {
            foreach (var pair in replacements)
            {
                var s = (pair.Key.StartsWith("{", StringComparison.Ordinal) &&
                         pair.Key.EndsWith("}", StringComparison.Ordinal)
                    ? placeholders.Find(x => string.Equals(x, pair.Key, StringComparison.Ordinal))
                    : placeholders.Find(x => string.Equals(x, "{" + pair.Key + "}", StringComparison.Ordinal)))!;

                if (!string.IsNullOrEmpty(s))
                {
                    value = value.Replace(s, pair.Value, StringComparison.Ordinal);
                }
            }
        }

        return value;
    }

    /// <summary>
    /// Determines if the provided string contains specific template patterns based on the specified TemplatePatternType.
    /// </summary>
    /// <param name="value">The string to check for template patterns.</param>
    /// <param name="templatePatternType">The type of template pattern to look for. Defaults to HardBrackets.</param>
    /// <returns>True if the string contains the specified template pattern; otherwise, false.</returns>
    /// <exception cref="SwitchCaseDefaultException">Thrown when an undefined TemplatePatternType is provided.</exception>
    public static bool ContainsTemplatePattern(
        this string value,
        TemplatePatternType templatePatternType = TemplatePatternType.HardBrackets)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        return templatePatternType switch
        {
            TemplatePatternType.None => false,
            TemplatePatternType.SingleHardBrackets => value.Contains('[', StringComparison.Ordinal) &&
                                                      value.Contains(']', StringComparison.Ordinal),
            TemplatePatternType.HardBrackets => value.Contains('[', StringComparison.Ordinal) &&
                                                value.Contains(']', StringComparison.Ordinal),
            TemplatePatternType.DoubleHardBrackets => value.Contains("[[", StringComparison.Ordinal) &&
                                                      value.Contains("]]", StringComparison.Ordinal),
            TemplatePatternType.SingleCurlyBraces => value.Contains('{', StringComparison.Ordinal) &&
                                                     value.Contains('}', StringComparison.Ordinal),
            TemplatePatternType.CurlyBraces => value.Contains('{', StringComparison.Ordinal) &&
                                               value.Contains('}', StringComparison.Ordinal),
            TemplatePatternType.DoubleCurlyBraces => value.Contains("{{", StringComparison.Ordinal) &&
                                                     value.Contains("}}", StringComparison.Ordinal),
            TemplatePatternType.All => (value.Contains('[', StringComparison.Ordinal) &&
                                        value.Contains(']', StringComparison.Ordinal)) ||
                                       (value.Contains('{', StringComparison.Ordinal) &&
                                        value.Contains('}', StringComparison.Ordinal)),
            _ => throw new SwitchCaseDefaultException(templatePatternType),
        };
    }

    /// <summary>
    /// Extracts template keys from the provided string based on the specified TemplatePatternType.
    /// </summary>
    /// <param name="value">The string to extract template keys from.</param>
    /// <param name="templatePatternType">The type of template pattern to use for extraction. Defaults to HardBrackets.</param>
    /// <param name="includeTemplatePattern">Indicates whether to include the template pattern in the returned keys.</param>
    /// <returns>A list of extracted template keys. If no keys are found, an empty list is returned.</returns>
    /// <exception cref="SwitchCaseDefaultException">Thrown when an undefined TemplatePatternType is provided.</exception>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public static IList<string> GetTemplateKeys(
        this string value,
        TemplatePatternType templatePatternType = TemplatePatternType.HardBrackets,
        bool includeTemplatePattern = false)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(value) ||
            templatePatternType == TemplatePatternType.None)
        {
            return result;
        }

        var regexPattern = templatePatternType switch
        {
            TemplatePatternType.SingleHardBrackets => @"\[(.*?)\]",
            TemplatePatternType.DoubleHardBrackets => @"\[\[(.*?)\]\]",
            TemplatePatternType.HardBrackets => @"\[(.*?)\]",
            TemplatePatternType.SingleCurlyBraces => @"\{(.*?)\}",
            TemplatePatternType.DoubleCurlyBraces => @"\{\{(.*?)\}\}",
            TemplatePatternType.CurlyBraces => @"\{(.*?)\}",
            TemplatePatternType.All => @"\[(.*?)\]",
            TemplatePatternType.None => throw new SwitchCaseDefaultException(templatePatternType),
            _ => throw new SwitchCaseDefaultException(templatePatternType),
        };

        var tmpResult = new Regex(
            regexPattern,
            RegexOptions.Multiline | RegexOptions.ExplicitCapture,
            TimeSpan.FromSeconds(1))
            .Matches(value)
            .Select(match => match.Groups[0].Value)
            .ToList();

        if (templatePatternType == TemplatePatternType.All)
        {
            var matches = new Regex(
                @"\{(.*?)\}",
                RegexOptions.Multiline | RegexOptions.ExplicitCapture,
                TimeSpan.FromSeconds(1))
                .Matches(value);

            tmpResult.AddRange(matches.Select(match => match.Groups[0].Value));
        }

        if (includeTemplatePattern)
        {
            foreach (var str in tmpResult)
            {
                switch (templatePatternType)
                {
                    case TemplatePatternType.HardBrackets:
                        result.Add(str.StartsWith("[[", StringComparison.Ordinal)
                            ? str.Replace("]", "]]", StringComparison.Ordinal)
                            : str);
                        break;
                    case TemplatePatternType.CurlyBraces:
                        result.Add(str.StartsWith("{{", StringComparison.Ordinal)
                            ? str.Replace("}", "}}", StringComparison.Ordinal)
                            : str);
                        break;
                    case TemplatePatternType.All:
                        if (str.StartsWith("[[", StringComparison.Ordinal))
                        {
                            result.Add(str.Replace("]", "]]", StringComparison.Ordinal));
                        }
                        else if (str.StartsWith("{{", StringComparison.Ordinal))
                        {
                            result.Add(str.Replace("}", "}}", StringComparison.Ordinal));
                        }
                        else
                        {
                            result.Add(str);
                        }

                        break;
                    default:
                        result.Add(str);
                        break;
                }
            }
        }
        else
        {
            foreach (var str in tmpResult)
            {
                switch (templatePatternType)
                {
                    case TemplatePatternType.SingleHardBrackets:
                        result.Add(str
                            .Replace("[", string.Empty, StringComparison.Ordinal)
                            .Replace("]", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.DoubleHardBrackets:
                        result.Add(str
                            .Replace("[[", string.Empty, StringComparison.Ordinal)
                            .Replace("]]", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.SingleCurlyBraces:
                        result.Add(str
                            .Replace("{", string.Empty, StringComparison.Ordinal)
                            .Replace("}", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.DoubleCurlyBraces:
                        result.Add(str
                            .Replace("{{", string.Empty, StringComparison.Ordinal)
                            .Replace("}}", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.HardBrackets:
                        result.Add(str
                            .Replace("[[", string.Empty, StringComparison.Ordinal)
                            .Replace("]]", string.Empty, StringComparison.Ordinal)
                            .Replace("[", string.Empty, StringComparison.Ordinal)
                            .Replace("]", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.CurlyBraces:
                        result.Add(str
                            .Replace("{{", string.Empty, StringComparison.Ordinal)
                            .Replace("}}", string.Empty, StringComparison.Ordinal)
                            .Replace("{", string.Empty, StringComparison.Ordinal)
                            .Replace("}", string.Empty, StringComparison.Ordinal));
                        break;
                    case TemplatePatternType.All:
                        result.Add(str
                            .Replace("[[", string.Empty, StringComparison.Ordinal)
                            .Replace("]]", string.Empty, StringComparison.Ordinal)
                            .Replace("[", string.Empty, StringComparison.Ordinal)
                            .Replace("]", string.Empty, StringComparison.Ordinal)
                            .Replace("{{", string.Empty, StringComparison.Ordinal)
                            .Replace("}}", string.Empty, StringComparison.Ordinal)
                            .Replace("{", string.Empty, StringComparison.Ordinal)
                            .Replace("}", string.Empty, StringComparison.Ordinal));
                        break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Gets unique template keys from the input string and counts their occurrences.
    /// </summary>
    /// <param name="value">The input string containing template keys.</param>
    /// <param name="templatePatternType">The type of template pattern to match.</param>
    /// <param name="includeTemplatePattern">Determines whether to include the template pattern itself.</param>
    /// <returns>A dictionary where keys are unique template keys, and values are the number of times each
    /// key appears in the input string.</returns>
    public static IDictionary<string, int> GetUniqueTemplateKeysWithOccurrence(
        this string value,
        TemplatePatternType templatePatternType = TemplatePatternType.HardBrackets,
        bool includeTemplatePattern = false)
    {
        var templateKeys = value.GetTemplateKeys(
            templatePatternType,
            includeTemplatePattern);

        var result = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var templateKey in templateKeys)
        {
            if (!result.TryAdd(templateKey, 1))
            {
                result[templateKey]++;
            }
        }

        return result;
    }

    /// <summary>
    /// Replaces a template key in the input string with a specified template value based on the given template pattern type.
    /// </summary>
    /// <param name="value">The input string containing template keys.</param>
    /// <param name="templateKey">The template key to be replaced.</param>
    /// <param name="templateValue">The value to replace the template key with.</param>
    /// <param name="templatePatternType">The type of template pattern to match in the input string.</param>
    /// <returns>The modified input string with the template key replaced by the template value.</returns>
    public static string ReplaceTemplateKeyWithValue(
        this string value,
        string templateKey,
        string templateValue,
        TemplatePatternType templatePatternType = TemplatePatternType.HardBrackets)
    {
        if (string.IsNullOrEmpty(value) ||
            templatePatternType == TemplatePatternType.None)
        {
            return value;
        }

        switch (templatePatternType)
        {
            case TemplatePatternType.SingleHardBrackets:
                return value.Replace($"[{templateKey}]", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.DoubleHardBrackets:
                return value.Replace($"[[{templateKey}]]", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.SingleCurlyBraces:
                return value.Replace($"{{{templateKey}}}", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.DoubleCurlyBraces:
                return value.Replace($"{{{{{templateKey}}}}}", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.HardBrackets:
                value = value.Replace($"[[{templateKey}]]", templateValue, StringComparison.OrdinalIgnoreCase);
                return value.Replace($"[{templateKey}]", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.CurlyBraces:
                value = value.Replace($"{{{{{templateKey}}}}}", templateValue, StringComparison.OrdinalIgnoreCase);
                return value.Replace($"{{{templateKey}}}", templateValue, StringComparison.OrdinalIgnoreCase);
            case TemplatePatternType.All:
                value = value.Replace($"[[{templateKey}]]", templateValue, StringComparison.OrdinalIgnoreCase);
                value = value.Replace($"[{templateKey}]", templateValue, StringComparison.OrdinalIgnoreCase);
                value = value.Replace($"{{{{{templateKey}}}}}", templateValue, StringComparison.OrdinalIgnoreCase);
                return value.Replace($"{{{templateKey}}}", templateValue, StringComparison.OrdinalIgnoreCase);
            default:
                throw new SwitchCaseDefaultException(templatePatternType);
        }
    }

    /// <summary>
    /// Replaces multiple template keys in the input string with their corresponding template values
    /// based on the given template pattern type and a dictionary of key-value pairs.
    /// </summary>
    /// <param name="value">The input string containing template keys.</param>
    /// <param name="templateKeyValues">A dictionary of key-value pairs where keys are template keys
    /// and values are the replacements for those keys.</param>
    /// <param name="templatePatternType">The type of template pattern to match in the input string.</param>
    /// <returns>The modified input string with template keys replaced by their corresponding template values.</returns>
    public static string ReplaceTemplateKeysWithValues(
        this string value,
        IDictionary<string, string> templateKeyValues,
        TemplatePatternType templatePatternType = TemplatePatternType.HardBrackets)
    {
        if (string.IsNullOrEmpty(value) ||
            templateKeyValues is null ||
            templatePatternType == TemplatePatternType.None)
        {
            return value;
        }

        foreach (var templateKeyValue in templateKeyValues)
        {
            value = value.ReplaceTemplateKeyWithValue(
                templateKeyValue.Key,
                templateKeyValue.Value,
                templatePatternType);
        }

        return value;
    }

    /// <summary>
    /// Parses the date from iso8601.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentNullException">value.</exception>
    /// <exception cref="FormatException">Invalid ISO8601 format.</exception>
    public static DateTime ParseDateFromIso8601(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (TryParseDateFromIso8601(value, out var dateTime))
        {
            return dateTime;
        }

        throw new FormatException("Invalid ISO8601 format");
    }

    /// <summary>
    /// Tries the parse date from iso8601.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="dateTime">The date time.</param>
    /// <exception cref="ArgumentNullException">value.</exception>
    public static bool TryParseDateFromIso8601(
        this string value,
        out DateTime dateTime)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return DateTime.TryParseExact(
            value,
            GlobalizationConstants.DateTimeIso8601,
            GlobalizationConstants.EnglishCultureInfo,
            DateTimeStyles.None,
            out dateTime);
    }

    /// <summary>
    /// Tries the parse date.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="dateTime">The date time.</param>
    public static bool TryParseDate(
        this string value,
        out DateTime dateTime)
    {
        return TryParseDate(value, out dateTime, GlobalizationConstants.EnglishCultureInfo);
    }

    /// <summary>
    /// Tries the parse date.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="dateTime">The date time.</param>
    /// <param name="cultureInfo">The culture information.</param>
    /// <param name="dateTimeStyles">The date time styles.</param>
    public static bool TryParseDate(
        this string value,
        out DateTime dateTime,
        CultureInfo cultureInfo,
        DateTimeStyles dateTimeStyles = DateTimeStyles.None)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        dateTime = DateTime.MinValue;
        return !string.IsNullOrEmpty(value) &&
               DateTime.TryParse(value, cultureInfo, dateTimeStyles, out dateTime);
    }

    /// <summary>
    /// Attempts to parse a string into a <see cref="Version"/> object.
    /// Handles input with brackets or braces and varying number of version components.
    /// </summary>
    /// <param name="value">The version string to parse.</param>
    /// <param name="version">When this method returns, contains the <see cref="Version"/> object if parsing succeeded, or a default version if parsing failed.</param>
    /// <returns><see langword="true" /> if the string was successfully parsed; otherwise, <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool TryParseVersion(
        this string value,
        out Version version)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        version = new Version();

        if (value.IndexOfAny(TrimCharsForTryParseVersion) != -1)
        {
            value = value
                .TrimStart('[').TrimEnd(']')
                .TrimStart('(').TrimEnd(')')
                .Trim(',');
        }

        var segments = value.Split('.');
        if (segments.Length is > 4 or 0)
        {
            return false;
        }

        try
        {
            var major = segments.Length > 0 ? int.Parse(segments[0], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo) : 0;
            var minor = segments.Length > 1 ? int.Parse(segments[1], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo) : 0;
            var build = segments.Length > 2 ? int.Parse(segments[2], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo) : 0;
            var revision = segments.Length > 3 ? int.Parse(segments[3], NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo) : 0;
            version = new Version(major, minor, build, revision);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Encodes the <paramref name="value"/> to Base64 in UTF8.
    /// </summary>
    /// <param name="value">The string value to encode</param>
    public static string Base64Encode(
        this string value)
    {
        return value.Base64Encode(Encoding.UTF8);
    }

    /// <summary>
    /// Encodes the <paramref name="value"/> to Base64 using the specified <paramref name="encoding"/>.
    /// </summary>
    /// <param name="value">The string value to encode.</param>
    /// <param name="encoding">The encoding.</param>
    public static string Base64Encode(
        this string value,
        Encoding encoding)
    {
        if (encoding is null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        return Convert.ToBase64String(encoding.GetBytes(value));
    }

    /// <summary>
    /// Decodes the <paramref name="base64EncodedData"/> <see langword="string"/> using UTF8.
    /// </summary>
    /// <param name="base64EncodedData">The Base64 encoded data.</param>
    public static string Base64Decode(
        this string base64EncodedData)
    {
        return base64EncodedData.Base64Decode(Encoding.UTF8);
    }

    /// <summary>
    /// Decodes the <paramref name="base64EncodedData"/> using the specified <paramref name="encoding"/>
    /// </summary>
    /// <param name="base64EncodedData">The Base64 encoded data.</param>
    /// <param name="encoding">The encoding.</param>
    public static string Base64Decode(
        this string base64EncodedData,
        Encoding encoding)
    {
        if (encoding is null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        return encoding.GetString(Convert.FromBase64String(base64EncodedData));
    }

    /// <summary>
    /// Javas the script encode.
    /// </summary>
    /// <param name="javaScript">The java script.</param>
    /// <param name="htmlEncode">if set to <see langword="true" /> [HTML encode].</param>
    public static string JavaScriptEncode(
        this string javaScript,
        bool htmlEncode)
    {
        if (string.IsNullOrEmpty(javaScript))
        {
            return javaScript;
        }

        javaScript = javaScript
            .Replace("'", "\x27", StringComparison.Ordinal)
            .Replace("\"", "\x22", StringComparison.Ordinal);
        return htmlEncode
            ? HttpUtility.HtmlEncode(javaScript)
            : javaScript;
    }

    /// <summary>
    /// Javas the script decode.
    /// </summary>
    /// <param name="javaScript">The java script.</param>
    /// <param name="htmlDecode">if set to <see langword="true" /> [HTML decode].</param>
    public static string JavaScriptDecode(
        this string javaScript,
        bool htmlDecode)
    {
        if (string.IsNullOrEmpty(javaScript))
        {
            return javaScript;
        }

        if (htmlDecode)
        {
            javaScript = HttpUtility.HtmlDecode(javaScript);
        }

        return javaScript
            .Replace("\x27", "'", StringComparison.Ordinal)
            .Replace("\x22", "\"", StringComparison.Ordinal);
    }

    /// <summary>
    /// XMLs the encode.
    /// </summary>
    /// <param name="xml">The XML.</param>
    public static string XmlEncode(
        this string xml)
    {
        if (string.IsNullOrEmpty(xml))
        {
            return xml;
        }

        return xml
            .Replace("&", "&amp", StringComparison.Ordinal)
            .Replace("'", "&#39;", StringComparison.Ordinal)
            .Replace("<", "&lt;", StringComparison.Ordinal)
            .Replace(">", "&gt;", StringComparison.Ordinal)
            .Replace("\"", "&quot", StringComparison.Ordinal);
    }

    /// <summary>
    /// XMLs the decode.
    /// </summary>
    /// <param name="xml">The XML.</param>
    public static string XmlDecode(
        this string xml)
    {
        return string.IsNullOrEmpty(xml)
            ? xml
            : xml
                .Replace("&amp", "&", StringComparison.Ordinal)
                .Replace("&#39;", "'", StringComparison.Ordinal)
                .Replace("&lt;", "<", StringComparison.Ordinal)
                .Replace("&gt;", ">", StringComparison.Ordinal)
                .Replace("&quot", "\"", StringComparison.Ordinal);
    }

    /// <summary>
    /// Sorts letters in the string alphabetically.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The string sorted alphabetically.</returns>
    public static string Alphabetize(
        this string value)
    {
        if (!value.IsAlphaNumericOnly())
        {
            return value;
        }

        // 1.
        // Convert to char array.
        var charArray = value.ToCharArray();

        // 2.
        // Sort letters.
        Array.Sort(charArray);

        // 3.
        // Return modified string.
        return new string(charArray);
    }

    /// <summary>
    /// Normalizes the accents.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The string that is normalize for accent-letter.</returns>
    public static string NormalizeAccents(
        this string value)
    {
        // ReSharper disable once IntroduceOptionalParameters.Global
        return NormalizeAccents(value, LetterAccentType.All, decode: true, forLower: true, forUpper: true);
    }

    /// <summary>
    /// Normalizes the accents.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="letterAccentType">Type of the letter accent.</param>
    /// <param name="decode">if set to <see langword="true" /> [decode].</param>
    /// <param name="forLower">if set to <see langword="true" /> [for lower].</param>
    /// <param name="forUpper">if set to <see langword="true" /> [for upper].</param>
    /// <returns>The string that is normalize for accent-letter.</returns>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static string NormalizeAccents(
        this string value,
        LetterAccentType letterAccentType,
        bool decode,
        bool forLower,
        bool forUpper)
    {
        //// http://symbolcodes.tlt.psu.edu/web/codehtml.html
        ////-------------------------------------------------------------
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        if (decode)
        {
            if (forLower)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (letterAccentType)
                {
                    case LetterAccentType.Grave:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode: true, forLower: true, forUpper);
                        break;
                    case LetterAccentType.Acute:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode: true, forLower: true, forUpper);
                        break;
                    case LetterAccentType.Circumflex:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode: true, forLower: true, forUpper);
                        break;
                    case LetterAccentType.Tilde:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode: true, forLower: true, forUpper);
                        break;
                    case LetterAccentType.Umlaut:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode: true, forLower: true, forUpper);
                        break;
                    case LetterAccentType.All:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode: true, forLower: true, forUpper);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode: true, forLower: true, forUpper);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode: true, forLower: true, forUpper);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode: true, forLower: true, forUpper);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode: true, forLower: true, forUpper);
                        break;
                    default:
                        throw new SwitchCaseDefaultException(letterAccentType);
                }
            }

            if (forUpper)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (letterAccentType)
                {
                    case LetterAccentType.Grave:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode: true, forLower, forUpper: true);
                        break;
                    case LetterAccentType.Acute:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode: true, forLower, forUpper: true);
                        break;
                    case LetterAccentType.Circumflex:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode: true, forLower, forUpper: true);
                        break;
                    case LetterAccentType.Tilde:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode: true, forLower, forUpper: true);
                        break;
                    case LetterAccentType.Umlaut:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode: true, forLower, forUpper: true);
                        break;
                    case LetterAccentType.All:
                        value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode: true, forLower, forUpper: true);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode: true, forLower, forUpper: true);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode: true, forLower, forUpper: true);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode: true, forLower, forUpper: true);
                        value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode: true, forLower, forUpper: true);
                        break;
                    default:
                        throw new SwitchCaseDefaultException(letterAccentType);
                }
            }
        }

        if (forLower)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (letterAccentType)
            {
                case LetterAccentType.Grave:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode, forLower: true, forUpper);
                    break;
                case LetterAccentType.Acute:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode, forLower: true, forUpper);
                    break;
                case LetterAccentType.Circumflex:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode, forLower: true, forUpper);
                    break;
                case LetterAccentType.Tilde:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode, forLower: true, forUpper);
                    break;
                case LetterAccentType.Umlaut:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode, forLower: true, forUpper);
                    break;
                case LetterAccentType.All:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode, forLower: true, forUpper);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode, forLower: true, forUpper);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode, forLower: true, forUpper);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode, forLower: true, forUpper);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode, forLower: true, forUpper);
                    break;
                default:
                    throw new SwitchCaseDefaultException(letterAccentType);
            }
        }

        // ReSharper disable once InvertIf
        if (forUpper)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (letterAccentType)
            {
                case LetterAccentType.Grave:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode, forLower, forUpper: true);
                    break;
                case LetterAccentType.Acute:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode, forLower, forUpper: true);
                    break;
                case LetterAccentType.Circumflex:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode, forLower, forUpper: true);
                    break;
                case LetterAccentType.Tilde:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode, forLower, forUpper: true);
                    break;
                case LetterAccentType.Umlaut:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode, forLower, forUpper: true);
                    break;
                case LetterAccentType.All:
                    value = NormalizeAccentsHelper(value, LetterAccentType.Grave, decode, forLower, forUpper: true);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Acute, decode, forLower, forUpper: true);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Circumflex, decode, forLower, forUpper: true);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Tilde, decode, forLower, forUpper: true);
                    value = NormalizeAccentsHelper(value, LetterAccentType.Umlaut, decode, forLower, forUpper: true);
                    break;
                default:
                    throw new SwitchCaseDefaultException(letterAccentType);
            }
        }

        return value;
    }

    /// <summary>
    /// Converts a string from camel case to a string where space is inserted before each capital letter.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The string with space inserted before each capital letter.</returns>
    /// [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "OK.")]
    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "OK.")]
    public static string NormalizePascalCase(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var sb = new StringBuilder();
        for (var i = 0; i < value.Length; i++)
        {
            if (i > 0 && char.IsUpper(value[i]) && !char.IsUpper(value[i - 1]))
            {
                sb.Append(' ');
                if (i == value.Length - 1 || char.IsUpper(value[i + 1]))
                {
                    sb.Append(value[i]);
                }
                else
                {
                    sb.Append(value[i].ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
                }

                continue;
            }

            sb.Append(value[i]);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Humanizes (make more human-readable) an identifier-style string
    /// in either camel case or snake case. For example, CamelCase will be converted to
    /// Camel Case and Snake_Case will be converted to Snake Case.
    /// </summary>
    /// <param name="value">The identifier-style string.</param>
    /// <returns>A <see cref="string" /> humanized.</returns>
    public static string Humanize(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        if (value.Length <= 1)
        {
            return value;
        }

        if (value.Any(x => x == '_'))
        {
            value = RxUnderscore.Value.Replace(value, " ");
        }

        if (value.Any(char.IsDigit))
        {
            var chars = value.ToCharArray();
            var lengthMinusOne = chars.Length - 1;
            var sb = new StringBuilder();
            for (var i = 0; i < chars.Length; i++)
            {
                sb.Append(chars[i]);
                if (i != lengthMinusOne && char.IsDigit(chars[i]) && !char.IsDigit(chars[i + 1]))
                {
                    sb.Append(' ');
                }
            }

            value = sb.ToString();
        }

        value = RxCamelCase.Value.Replace(value, SplitCamelCaseString.Value);

        return value;
    }

    /// <summary>
    /// Gets as camel case.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The string with camel-case format.</returns>
    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "OK.")]
    public static string CamelCase(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

#if NETSTANDARD2_1
        return value.Length <= 1
            ? value
            : value.Substring(0, 1).ToLowerInvariant() + value.Substring(1);
#else
        if (value.Length == 1)
        {
            return value.ToLowerInvariant();
        }

        Span<char> buffer = stackalloc char[1];
        buffer[0] = char.ToLowerInvariant(value[0]);

        return string.Concat(buffer, value.AsSpan(1));
#endif
    }

    /// <summary>
    /// Gets as pascal case.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="removeSeparators">If true, remove all separators.</param>
    /// <returns>The string with pascal-case format.</returns>
    public static string PascalCase(
        this string value,
        bool removeSeparators = false)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        char[] c = { ' ', '-', '_' };
        return PascalCase(value, c, removeSeparators);
    }

    /// <summary>
    /// Gets as pascal case.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="separators">A char array to separate on.</param>
    /// <param name="removeSeparators">If true, remove all separators.</param>
    /// <returns>The string with pascal-case format.</returns>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static string PascalCase(
        this string value,
        char[]? separators,
        bool removeSeparators = false)
    {
        if (string.IsNullOrEmpty(value) || separators is null)
        {
            return value;
        }

        if (separators.Length <= 0)
        {
            return value.Substring(0, 1).ToUpperInvariant() + value.Substring(1).ToLowerInvariant();
        }

        if (separators.Length == 1 && value.IndexOfAny(separators) == -1)
        {
            return value.Substring(0, 1).ToUpperInvariant() + value.Substring(1).ToLowerInvariant();
        }

        var strArray = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < strArray.Length; i++)
        {
            var tmp = strArray[i].Substring(0, 1).ToUpperInvariant() + strArray[i].Substring(1).ToLowerInvariant();
            for (var j = 1; j < strArray[i].Length - 1; j++)
            {
                var c1 = strArray[i][j - 1];
                var c2 = strArray[i][j];
                var c3 = strArray[i][j + 1];
                if (char.IsLower(c1) && char.IsUpper(c2) && char.IsLower(c3))
                {
                    tmp = tmp.ReplaceAt(j, c2);
                }
            }

            strArray[i] = tmp;
        }

        var sb = new StringBuilder();
        for (var i = 0; i < strArray.Length; i++)
        {
            sb.Append(strArray[i]);
            if (removeSeparators)
            {
                continue;
            }

            if (i != strArray.Length - 1)
            {
                sb.Append(value.AsSpan(sb.Length, 1));
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Ensure the newline characters are the platform dependent System.Environment.Newline.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <remarks>
    /// This method transform Windows, Unix, Mac newline characters to
    /// the platform dependent System.Environment.Newline.
    /// "\r\n" (\u000D\u000A) for Windows
    /// "\n" (\u000A) for Unix
    /// "\r" (\u000D) for Mac
    /// </remarks>
    public static string EnsureEnvironmentNewLines(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        switch (Environment.NewLine)
        {
            case "\r\n":
                // Windows - Streamline to '\n' and then to '\r\n'
                value = value
                    .Replace("\r\n", "\n", StringComparison.Ordinal)
                    .Replace('\r', '\n');
                value = value
                    .Replace("\n", "\r\n", StringComparison.Ordinal);
                break;
            case "\n":
                // Unix
                value = value
                    .Replace("\r\n", "\n", StringComparison.Ordinal)
                    .Replace('\r', '\n');
                break;
            case "\r":
                // Mac
                value = value
                    .Replace("\r\n", "\r", StringComparison.Ordinal)
                    .Replace('\n', '\r');
                break;
        }

        return value;
    }

    /// <summary>
    /// Ensures the first character to upper.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureFirstCharacterToUpper(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.Length switch
        {
            0 => value,
            1 => value.ToUpper(CultureInfo.CurrentCulture),
#if NETSTANDARD2_1
            _ => char.ToUpper(value[0], CultureInfo.CurrentCulture).ToString() + value.Substring(1),
#else
            _ => string.Concat(
                new string(char.ToUpper(value[0], CultureInfo.CurrentCulture), 1),
                value.AsSpan(1)),
#endif
        };
    }

    /// <summary>
    /// Ensures the first character to lower.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureFirstCharacterToLower(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.Length switch
        {
            0 => value,
            1 => value.ToLower(CultureInfo.CurrentCulture),
#if NETSTANDARD2_1
            _ => char.ToLower(value[0], CultureInfo.CurrentCulture).ToString() + value.Substring(1),
#else
            _ => string.Concat(
                new string(char.ToLower(value[0], CultureInfo.CurrentCulture), 1),
                value.AsSpan(1)),
#endif
        };
    }

    /// <summary>
    /// Ensures the string-value ends with a '.'.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureEndsWithDot(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.EndsWith('.')
            ? value
            : $"{value}.";
    }

    /// <summary>
    /// Ensures the string-value ends with a ':'.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureEndsWithColon(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.EndsWith(':')
            ? value
            : $"{value}:";
    }

    /// <summary>
    /// Ensures the singular.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureSingular(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < 2)
        {
            return value;
        }

        return value.EndsWith('s')
            ? value.Substring(0, value.Length - 1)
            : value;
    }

    /// <summary>
    /// Ensures the plural.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsurePlural(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < 2)
        {
            return value;
        }

        return value.EndsWith('s')
            ? value
            : value + "s";
    }

    /// <summary>
    /// Ensures the first character to upper and singular.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureFirstCharacterToUpperAndSingular(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return EnsureFirstCharacterToUpper(EnsureSingular(value));
    }

    /// <summary>
    /// Ensures the first character to upper and plural.
    /// </summary>
    /// <param name="value">The value.</param>
    public static string EnsureFirstCharacterToUpperAndPlural(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return EnsureFirstCharacterToUpper(EnsurePlural(value));
    }

    /// <summary>
    /// Determines whether a string contains a specified value.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="containsValue">The string to compare with.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> ignore case sensitive.</param>
    /// <returns>
    ///   <see langword="true" /> if input string contains a value from specified value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool Contains(
        this string value,
        string containsValue,
        bool ignoreCaseSensitive = true)
    {
        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrEmpty(containsValue))
        {
            return false;
        }

        return value.Contains(containsValue, ignoreCaseSensitive ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
    }

    /// <summary>
    /// Determines whether a chars contains all specified values.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="containsValues">The chars to compare with.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> ignore case sensitive.</param>
    /// <returns>
    ///   <see langword="true" /> if input string contains a value from specified char-values; otherwise, <see langword="false" />.
    /// </returns>
    public static bool Contains(
        this string value,
        char[] containsValues,
        bool ignoreCaseSensitive = true)
    {
        if (string.IsNullOrEmpty(value) ||
            containsValues is null ||
            containsValues.Length == 0)
        {
            return false;
        }

        return containsValues.All(x => Contains(value, x.ToString(), ignoreCaseSensitive));
    }

    /// <summary>
    /// Determines whether a string contains all specified values.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="containsValues">The strings to compare with.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> ignore case sensitive.</param>
    /// <returns>
    ///   <see langword="true" /> if input string contains a value from specified string-values; otherwise, <see langword="false" />.
    /// </returns>
    public static bool Contains(
        this string value,
        string[] containsValues,
        bool ignoreCaseSensitive = true)
    {
        if (string.IsNullOrEmpty(value) ||
            containsValues is null ||
            containsValues.Length == 0)
        {
            return false;
        }

        return containsValues.All(x => Contains(value, x, ignoreCaseSensitive));
    }

    /// <summary>
    /// Cuts the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">Length of the max.</param>
    /// <param name="appendValue">The append value.</param>
    /// <returns>The string that is cutoff by the max-length and appended with the appendValue.</returns>
    public static string Cut(
        this string value,
        int maxLength,
        string appendValue = "...")
    {
        return Truncate(value, maxLength, appendValue);
    }

    /// <summary>
    /// Replaces at.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="index">The index.</param>
    /// <param name="newChar">The new character.</param>
    public static string ReplaceAt(
        this string value,
        int index,
        char newChar)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var chars = value.ToCharArray();
        chars[index] = newChar;
        return new string(chars);
    }

    /// <summary>
    /// Returns a new string in which all occurrences of specified strings are replaced by other specified strings.
    /// </summary>
    /// <param name="value">The string to filter.</param>
    /// <param name="replacements">The replacements definition.</param>
    /// <returns>The filtered string.</returns>
    public static string ReplaceMany(
        this string value,
        IDictionary<string, string> replacements)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (replacements is null)
        {
            throw new ArgumentNullException(nameof(replacements));
        }

        return replacements.Aggregate(value, (current, item) => current.Replace(item.Key, item.Value, StringComparison.Ordinal));
    }

    /// <summary>
    /// Returns a new string in which all occurrences of specified characters are replaced by a specified character.
    /// </summary>
    /// <param name="value">The string to filter.</param>
    /// <param name="chars">The characters to replace.</param>
    /// <param name="replacement">The replacement character.</param>
    /// <returns>The filtered string.</returns>
    public static string ReplaceMany(
        this string value,
        char[] chars,
        char replacement)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (chars is null)
        {
            throw new ArgumentNullException(nameof(chars));
        }

        return chars.Aggregate(value, (current, c) => current.Replace(c, replacement));
    }

    /// <summary>
    /// Replace the newline characters with the newValue.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="newValue">The new value for NewLine.</param>
    /// <remarks>
    /// This method don't use the platform dependent System.Environment.Newline
    /// but instead works for all platforms as Windows, Unix and Mac.
    /// "\r\n" (\u000D\u000A) for Windows
    /// "\n" (\u000A) for Unix
    /// "\r" (\u000D) for Mac
    /// </remarks>
    public static string ReplaceNewLines(
        this string value,
        string newValue)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value
            .Replace("\r\n", newValue, StringComparison.Ordinal)
            .Replace("\n", newValue, StringComparison.Ordinal)
            .Replace("\r", newValue, StringComparison.Ordinal);
    }

    /// <summary>
    /// Remove the newline characters with the string.Empty.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <remarks>
    /// This method don't use the platform dependent System.Environment.Newline
    /// but instead works for all platforms as Windows, Unix and Mac.
    /// "\r\n" (\u000D\u000A) for Windows
    /// "\n" (\u000A) for Unix
    /// "\r" (\u000D) for Mac
    /// </remarks>
    public static string RemoveNewLines(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.ReplaceNewLines(string.Empty);
    }

    /// <summary>
    /// Remove a specified string from the string if occurs in the start of the string.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="startValue">The string to compare with.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> ignore case sensitive.</param>
    /// <returns>The string that remains after a specified string are removed from the start of the current string.</returns>
    public static string RemoveStart(
        this string value,
        string startValue,
        bool ignoreCaseSensitive = true)
    {
        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrEmpty(startValue))
        {
            return string.Empty;
        }

        if (ignoreCaseSensitive && value.StartsWith(startValue, StringComparison.OrdinalIgnoreCase))
        {
            return value.Substring(startValue.Length);
        }

        return value.StartsWith(startValue, StringComparison.Ordinal) ? value.Substring(startValue.Length) : value;
    }

    /// <summary>
    /// Remove a specified string from the string if occure in the end of the string.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <param name="endValue">The string to compare with.</param>
    /// <param name="ignoreCaseSensitive">if set to <see langword="true" /> ignore case sensitive.</param>
    /// <returns>The string that remains after a specified string are removed from the end of the current string.</returns>
    public static string RemoveEnd(
        this string value,
        string endValue,
        bool ignoreCaseSensitive = true)
    {
        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrEmpty(endValue))
        {
            return string.Empty;
        }

        if (ignoreCaseSensitive && value.EndsWith(endValue, StringComparison.OrdinalIgnoreCase))
        {
            return value.Substring(0, value.Length - endValue.Length);
        }

        return value.EndsWith(endValue, StringComparison.Ordinal) ? value.Substring(0, value.Length - endValue.Length) : value;
    }

    /// <summary>
    /// Removes the ending slash if exist.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="System.ArgumentNullException">value.</exception>
    public static string RemoveEndingSlashIfExist(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.EndsWith('/')
            ? value.Substring(0, value.Length - 1)
            : value;
    }

    /// <summary>
    /// Removes the data crap.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The string without non-printable character.</returns>
    public static string RemoveDataCrap(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var sb = new StringBuilder(value);
        sb.Replace("\u0000", " ");
        sb.Replace("\u0001", " ");
        sb.Replace("\u0002", " ");
        sb.Replace("\u0003", " ");
        sb.Replace("\u0004", " ");
        sb.Replace("\u0005", " ");
        sb.Replace("\u0006", " ");
        sb.Replace("\u0007", " ");
        sb.Replace("\u0008", " ");
        sb.Replace("\u0009", " "); // tabulation
        sb.Replace("\u000A", " ");
        sb.Replace("\u000B", Environment.NewLine); // a sort of tabulation
        sb.Replace("\u000C", " ");
        sb.Replace("\u000D", " ");
        sb.Replace("\u000E", " ");
        sb.Replace("\u000F", " ");
        sb.Replace("\u0010", " ");
        sb.Replace("\u0011", " ");
        sb.Replace("\u0012", " ");
        sb.Replace("\u0013", " ");
        sb.Replace("\u0014", " ");
        sb.Replace("\u0015", " ");
        sb.Replace("\u0016", " ");
        sb.Replace("\u0017", " ");
        sb.Replace("\u0018", " ");
        sb.Replace("\u0019", " ");
        sb.Replace("\u001A", " ");
        sb.Replace("\u001B", " ");
        sb.Replace("\u001C", " ");
        sb.Replace("\u001D", " ");
        sb.Replace("\u001E", " ");
        sb.Replace("\u001F", " ");
        return sb.ToString();
    }

    /// <summary>
    /// Removes the non-printable character.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The string without non-printable character.</returns>
    public static string RemoveNonPrintableCharacter(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var ca = value
            .Where(c => !char.IsControl(c))
            .ToArray();

        return new string(ca);
    }

    /// <summary>
    /// Truncates the specified maximum length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">The maximum length.</param>
    /// <param name="appendValue">The append value.</param>
    public static string Truncate(
        this string value,
        int maxLength,
        string appendValue = "...")
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        if (value.Length > maxLength)
        {
#if NETSTANDARD2_1
            return value.Substring(0, maxLength) + appendValue;
#else
            return string.Concat(value.AsSpan(0, maxLength), appendValue);
#endif
        }

        return value;
    }

    /// <summary>
    /// TrimSpecial removes some doubles chars and none readable chars.
    /// </summary>
    /// <param name="value">The string to work on.</param>
    /// <returns>The string without none readable chars etc.</returns>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public static string TrimSpecial(
        this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        value = value.Trim();
        while (value.Contains('\t', StringComparison.Ordinal))
        {
            value = value.Replace('\t', ' ');
        }

        var lengthBefore = value.Length;
        while (value.Contains("\n ", StringComparison.Ordinal))
        {
            value = value.Replace("\n ", "\n", StringComparison.Ordinal);
            if (lengthBefore == value.Length)
            {
                break;
            }

            lengthBefore = value.Length;
        }

        lengthBefore = value.Length;
        while (value.Contains("\n\n", StringComparison.Ordinal))
        {
            value = value.Replace("\n\n", "\n", StringComparison.Ordinal);
            if (lengthBefore == value.Length)
            {
                break;
            }

            lengthBefore = value.Length;
        }

        lengthBefore = value.Length;
        while (value.Contains("\r\n\r\n", StringComparison.Ordinal))
        {
            value = value.Replace("\r\n\r\n", "\r\n", StringComparison.Ordinal);
            if (lengthBefore == value.Length)
            {
                break;
            }

            lengthBefore = value.Length;
        }

        while (value.Contains("..", StringComparison.Ordinal))
        {
            value = value.Replace("..", ".", StringComparison.Ordinal);
        }

        value = value.TrimExtended();

        value = RemoveDataCrap(value);
        if (string.Equals(value, "\n", StringComparison.Ordinal))
        {
            value = string.Empty;
        }

        return value;
    }

    /// <summary>
    /// TrimExtended removes all leading and trailing white-space.
    /// and multi-space characters from the current System.String object.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The string that remains after all white-space characters.
    /// are removed from the start and end and multi-space characters  of the current string.
    /// If no characters can be trimmed from the current instance, the method returns the current instance unchanged.
    /// </returns>
    public static string TrimExtended(
        this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!value.Contains(' ', StringComparison.Ordinal))
        {
            return value;
        }

        var s = value.Trim();
        while (s.Contains("  ", StringComparison.Ordinal))
        {
            s = s.Replace("  ", " ", StringComparison.Ordinal);
        }

        return s;
    }

    /// <summary>
    /// Splits the specified text into r, n or rn separated lines.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// An array whose elements contain the substrings from this instance
    /// that are delimited by one or more characters in separator.
    /// </returns>
    public static string[] ToLines(
        this string value)
    {
        return string.IsNullOrEmpty(value)
            ? Array.Empty<string>()
            : RxSplitLines.Value
                .Split(value)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
    }

    /// <summary>
    /// Converts to stream.
    /// </summary>
    /// <param name="value">The value.</param>
    public static Stream ToStream(this string value)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(value));
    }

    /// <summary>
    /// Converts to stream from base64.
    /// </summary>
    /// <param name="base64Data">The base64 data.</param>
    public static Stream? ToStreamFromBase64(
        this string base64Data)
    {
        if (string.IsNullOrEmpty(base64Data))
        {
            return null;
        }

        var bytes = Convert.FromBase64String(base64Data);
        var stream = new MemoryStream();
        stream.Write(bytes, 0, bytes.Length);
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    public static bool TryParseToHttpStatusCode(
        this string value,
        out HttpStatusCode httpStatusCode)
        => Enum<HttpStatusCode>.TryParse(value, false, out httpStatusCode) &&
           !NumberHelper.IsInt(httpStatusCode.ToString());

#if NET8_0_OR_GREATER
    /// <summary>
    /// Formats a string template by replacing placeholders with corresponding argument values.
    /// </summary>
    /// <param name="template">The format string containing placeholders.</param>
    /// <param name="arg0">The first required argument to replace a placeholder.</param>
    /// <param name="arg1">Optional argument for placeholder replacement.</param>
    /// <param name="arg2">Optional argument for placeholder replacement.</param>
    /// <param name="arg3">Optional argument for placeholder replacement.</param>
    /// <param name="arg4">Optional argument for placeholder replacement.</param>
    /// <param name="arg5">Optional argument for placeholder replacement.</param>
    /// <param name="arg6">Optional argument for placeholder replacement.</param>
    /// <param name="arg7">Optional argument for placeholder replacement.</param>
    /// <param name="arg8">Optional argument for placeholder replacement.</param>
    /// <param name="arg9">Optional argument for placeholder replacement.</param>
    /// <param name="arg0Name">The name of <paramref name="arg0"/>, provided via <see cref="CallerArgumentExpressionAttribute"/>.</param>
    /// <param name="arg1Name">The name of <paramref name="arg1"/> (if provided), automatically inferred.</param>
    /// <param name="arg2Name">The name of <paramref name="arg2"/> (if provided), automatically inferred.</param>
    /// <param name="arg3Name">The name of <paramref name="arg3"/> (if provided), automatically inferred.</param>
    /// <param name="arg4Name">The name of <paramref name="arg4"/> (if provided), automatically inferred.</param>
    /// <param name="arg5Name">The name of <paramref name="arg5"/> (if provided), automatically inferred.</param>
    /// <param name="arg6Name">The name of <paramref name="arg6"/> (if provided), automatically inferred.</param>
    /// <param name="arg7Name">The name of <paramref name="arg7"/> (if provided), automatically inferred.</param>
    /// <param name="arg8Name">The name of <paramref name="arg8"/> (if provided), automatically inferred.</param>
    /// <param name="arg9Name">The name of <paramref name="arg9"/> (if provided), automatically inferred.</param>
    /// <returns>
    /// A formatted string where placeholders in <paramref name="template"/> are replaced with corresponding argument values.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="template"/> or <paramref name="arg0"/> is null.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the number of provided arguments does not match the number of placeholders in the template, 
    /// or if a placeholder does not match any argument.
    /// </exception>
    /// <remarks>
    /// - The method extracts placeholders from the template and ensures that the provided arguments match the placeholders.<br/>
    /// - Named placeholders (e.g., '{argName}') and indexed placeholders (e.g., '{0}') are supported.<br/>
    /// - Argument names are inferred using the <see cref="CallerArgumentExpressionAttribute"/> for better debugging.
    /// </remarks>
    public static string FormatWith(
        this string template,
        string arg0,
        string? arg1 = null,
        string? arg2 = null,
        string? arg3 = null,
        string? arg4 = null,
        string? arg5 = null,
        string? arg6 = null,
        string? arg7 = null,
        string? arg8 = null,
        string? arg9 = null,
        [CallerArgumentExpression("arg0")] string arg0Name = null!,
        [CallerArgumentExpression("arg1")] string? arg1Name = null,
        [CallerArgumentExpression("arg2")] string? arg2Name = null,
        [CallerArgumentExpression("arg3")] string? arg3Name = null,
        [CallerArgumentExpression("arg4")] string? arg4Name = null,
        [CallerArgumentExpression("arg5")] string? arg5Name = null,
        [CallerArgumentExpression("arg6")] string? arg6Name = null,
        [CallerArgumentExpression("arg7")] string? arg7Name = null,
        [CallerArgumentExpression("arg8")] string? arg8Name = null,
        [CallerArgumentExpression("arg9")] string? arg9Name = null)
    {
        ArgumentNullException.ThrowIfNull(template);
        ArgumentNullException.ThrowIfNull(arg0);

        var usedArgsCount = 1 + new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }
            .TakeWhile(x => x is not null)
            .Count();

        var placeholders = template.GetStringFormatParameterTemplatePlaceholders(useDoubleBracket: false);
        if (usedArgsCount != placeholders.Count)
        {
            throw new InvalidOperationException($"The template contains {placeholders.Count} placeholders, and the provided values are {usedArgsCount}");
        }

        var argValues = new[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 };
        var argNames = new[] { arg0Name, arg1Name, arg2Name, arg3Name, arg4Name, arg5Name, arg6Name, arg7Name, arg8Name, arg9Name };

        var dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var placeholder in placeholders)
        {
            var key = placeholder.Trim('{', '}');

            var index = Array.IndexOf(argNames, key);
            if (index != -1 && index < usedArgsCount)
            {
                dictionary.Add(key, argValues[index]!);
            }
            else if (int.TryParse(key, out var pos))
            {
                if (pos < 0 || pos >= usedArgsCount)
                {
                    throw new InvalidOperationException($"Placeholder index {pos} is out of range.");
                }

                dictionary.Add(placeholder, argValues[pos]!);
            }
            else
            {
                throw new InvalidOperationException($"No argument matching placeholder '{key}'.");
            }
        }

        return template.SetStringFormatParameterTemplatePlaceholders(dictionary, useDoubleBracket: false);
    }
#endif

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    private static string NormalizeAccentsHelper(
        string value,
        LetterAccentType letterAccentType,
        bool decode,
        bool forLower,
        bool forUpper)
    {
        //// http://symbolcodes.tlt.psu.edu/web/codehtml.html
        ////-------------------------------------------------------------
        if (decode)
        {
            if (forLower)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                // ReSharper disable StringLiteralTypo
                // ReSharper disable once ConvertSwitchStatementToSwitchExpression
                switch (letterAccentType)
                {
                    case LetterAccentType.Grave:
                        value = value
                            .Replace("&agrave;", "a", StringComparison.Ordinal)
                            .Replace("&egrave; ", "e", StringComparison.Ordinal)
                            .Replace("&igrave; ", "i", StringComparison.Ordinal)
                            .Replace("&ograve;", "o", StringComparison.Ordinal)
                            .Replace("&ugrave;", "u", StringComparison.Ordinal)
                            .Replace("&#224;", "a", StringComparison.Ordinal)
                            .Replace("&#232; ", "e", StringComparison.Ordinal)
                            .Replace("&#236; ", "i", StringComparison.Ordinal)
                            .Replace("&#242;", "o", StringComparison.Ordinal)
                            .Replace("&#249;", "u", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Acute:
                        value = value
                            .Replace("&aacute;", "a", StringComparison.Ordinal)
                            .Replace("&eacute;", "e", StringComparison.Ordinal)
                            .Replace("&iacute;", "i", StringComparison.Ordinal)
                            .Replace("&oacute;", "o", StringComparison.Ordinal)
                            .Replace("&uacute;", "u", StringComparison.Ordinal)
                            .Replace("&yacute;", "y", StringComparison.Ordinal)
                            .Replace("&#225;", "a", StringComparison.Ordinal)
                            .Replace("&#233;", "e", StringComparison.Ordinal)
                            .Replace("&#237;", "i", StringComparison.Ordinal)
                            .Replace("&#243;", "o", StringComparison.Ordinal)
                            .Replace("&#250;", "u", StringComparison.Ordinal)
                            .Replace("&#253;", "y", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Circumflex:
                        value = value
                            .Replace("&acirc;", "a", StringComparison.Ordinal)
                            .Replace("&ecirc;", "e", StringComparison.Ordinal)
                            .Replace("&icirc;", "i", StringComparison.Ordinal)
                            .Replace("&ocirc;", "o", StringComparison.Ordinal)
                            .Replace("&ucirc;", "u", StringComparison.Ordinal)
                            .Replace("&#226;", "a", StringComparison.Ordinal)
                            .Replace("&#234;", "e", StringComparison.Ordinal)
                            .Replace("&#238;", "i", StringComparison.Ordinal)
                            .Replace("&#244;", "o", StringComparison.Ordinal)
                            .Replace("&#251;", "u", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Tilde:
                        value = value
                            .Replace("&atilde;", "a", StringComparison.Ordinal)
                            .Replace("&ntilde;", "n", StringComparison.Ordinal)
                            .Replace("&otilde;", "o", StringComparison.Ordinal)
                            .Replace("&#227;", "a", StringComparison.Ordinal)
                            .Replace("&#241;", "n", StringComparison.Ordinal)
                            .Replace("&#245;", "o", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Umlaut:
                        value = value
                            .Replace("&auml;", "a", StringComparison.Ordinal)
                            .Replace("&euml;", "e", StringComparison.Ordinal)
                            .Replace("&iuml;", "i", StringComparison.Ordinal)
                            .Replace("&ouml;", "o", StringComparison.Ordinal)
                            .Replace("&uuml;", "u", StringComparison.Ordinal)
                            .Replace("&yuml;", "y", StringComparison.Ordinal)
                            .Replace("&#228;", "a", StringComparison.Ordinal)
                            .Replace("&#235;", "e", StringComparison.Ordinal)
                            .Replace("&#239;", "i", StringComparison.Ordinal)
                            .Replace("&#246;", "o", StringComparison.Ordinal)
                            .Replace("&#252;", "u", StringComparison.Ordinal)
                            .Replace("&#255;", "y", StringComparison.Ordinal);
                        break;
                    default:
                        throw new SwitchCaseDefaultException(letterAccentType);
                } // ReSharper restore StringLiteralTypo
            }

            if (forUpper)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                // ReSharper disable StringLiteralTypo
                // ReSharper disable once ConvertSwitchStatementToSwitchExpression
                switch (letterAccentType)
                {
                    case LetterAccentType.Grave:
                        value = value
                            .Replace("&Agrave;", "A", StringComparison.Ordinal)
                            .Replace("&Egrave;", "E", StringComparison.Ordinal)
                            .Replace("&Igrave;", "I", StringComparison.Ordinal)
                            .Replace("&Ograve;", "O", StringComparison.Ordinal)
                            .Replace("&Ugrave;", "U", StringComparison.Ordinal)
                            .Replace("&#192;", "A", StringComparison.Ordinal)
                            .Replace("&#200;", "E", StringComparison.Ordinal)
                            .Replace("&#204;", "I", StringComparison.Ordinal)
                            .Replace("&#210;", "O", StringComparison.Ordinal)
                            .Replace("&#217;", "U", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Acute:
                        value = value
                            .Replace("&Aacute;", "A", StringComparison.Ordinal)
                            .Replace("&Eacute;", "E", StringComparison.Ordinal)
                            .Replace("&Iacute;", "I", StringComparison.Ordinal)
                            .Replace("&Oacute;", "O", StringComparison.Ordinal)
                            .Replace("&Uacute;", "U", StringComparison.Ordinal)
                            .Replace("&Yacute;", "Y", StringComparison.Ordinal)
                            .Replace("&#193;", "A", StringComparison.Ordinal)
                            .Replace("&#201;", "E", StringComparison.Ordinal)
                            .Replace("&#205;", "I", StringComparison.Ordinal)
                            .Replace("&#211;", "O", StringComparison.Ordinal)
                            .Replace("&#218;", "U", StringComparison.Ordinal)
                            .Replace("&#221;", "Y", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Circumflex:
                        value = value
                            .Replace("&Acirc;", "A", StringComparison.Ordinal)
                            .Replace("&Ecirc;", "E", StringComparison.Ordinal)
                            .Replace("&Icirc;", "I", StringComparison.Ordinal)
                            .Replace("&Ocirc;", "O", StringComparison.Ordinal)
                            .Replace("&Ucirc;", "U", StringComparison.Ordinal)
                            .Replace("&#194;", "A", StringComparison.Ordinal)
                            .Replace("&#202;", "E", StringComparison.Ordinal)
                            .Replace("&#206;", "I", StringComparison.Ordinal)
                            .Replace("&#212;", "O", StringComparison.Ordinal)
                            .Replace("&#219;", "U", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Tilde:
                        value = value
                            .Replace("&#195;", "A", StringComparison.Ordinal)
                            .Replace("&#209;", "N", StringComparison.Ordinal)
                            .Replace("&#213;", "O", StringComparison.Ordinal);
                        break;
                    case LetterAccentType.Umlaut:
                        value = value
                            .Replace("&#196;", "A", StringComparison.Ordinal)
                            .Replace("&#203;", "E", StringComparison.Ordinal)
                            .Replace("&#207;", "I", StringComparison.Ordinal)
                            .Replace("&#214,", "O", StringComparison.Ordinal)
                            .Replace("&#220;", "U", StringComparison.Ordinal)
                            .Replace("&#159;", "Y", StringComparison.Ordinal);
                        break;
                    default:
                        throw new SwitchCaseDefaultException(letterAccentType);
                } // ReSharper restore StringLiteralTypo
            }
        }

        if (forLower)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (letterAccentType)
            {
                case LetterAccentType.Grave:
                    value = value
                        .Replace("à", "a", StringComparison.Ordinal)
                        .Replace("è", "e", StringComparison.Ordinal)
                        .Replace("ì", "i", StringComparison.Ordinal)
                        .Replace("ò", "o", StringComparison.Ordinal)
                        .Replace("ù", "u", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Acute:
                    value = value
                        .Replace("á", "a", StringComparison.Ordinal)
                        .Replace("é", "e", StringComparison.Ordinal)
                        .Replace("í", "i", StringComparison.Ordinal)
                        .Replace("ó", "o", StringComparison.Ordinal)
                        .Replace("ú", "u", StringComparison.Ordinal)
                        .Replace("ý", "y", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Circumflex:
                    value = value
                        .Replace("â", "a", StringComparison.Ordinal)
                        .Replace("ê", "e", StringComparison.Ordinal)
                        .Replace("î", "i", StringComparison.Ordinal)
                        .Replace("ô", "o", StringComparison.Ordinal)
                        .Replace("û", "u", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Tilde:
                    value = value
                        .Replace("ã", "a", StringComparison.Ordinal)
                        .Replace("ñ", "n", StringComparison.Ordinal)
                        .Replace("õ", "o", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Umlaut:
                    value = value
                        .Replace("ä", "a", StringComparison.Ordinal)
                        .Replace("ë", "e", StringComparison.Ordinal)
                        .Replace("ï", "i", StringComparison.Ordinal)
                        .Replace("ö", "o", StringComparison.Ordinal)
                        .Replace("ü", "u", StringComparison.Ordinal)
                        .Replace("ÿ", "y", StringComparison.Ordinal);
                    break;
                default:
                    throw new SwitchCaseDefaultException(letterAccentType);
            }
        }

        // ReSharper disable once InvertIf
        if (forUpper)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (letterAccentType)
            {
                case LetterAccentType.Grave:
                    value = value
                        .Replace("À", "A", StringComparison.Ordinal)
                        .Replace("È", "E", StringComparison.Ordinal)
                        .Replace("Ì", "I", StringComparison.Ordinal)
                        .Replace("Ò", "O", StringComparison.Ordinal)
                        .Replace("Ù", "U", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Acute:
                    value = value
                        .Replace("Á", "A", StringComparison.Ordinal)
                        .Replace("É", "E", StringComparison.Ordinal)
                        .Replace("Í", "I", StringComparison.Ordinal)
                        .Replace("Ó", "O", StringComparison.Ordinal)
                        .Replace("Ú", "U", StringComparison.Ordinal)
                        .Replace("Ý", "Y", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Circumflex:
                    value = value
                        .Replace("Â", "A", StringComparison.Ordinal)
                        .Replace("Ê", "E", StringComparison.Ordinal)
                        .Replace("Î", "I", StringComparison.Ordinal)
                        .Replace("Ô", "O", StringComparison.Ordinal)
                        .Replace("Û", "U", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Tilde:
                    value = value
                        .Replace("Ã", "A", StringComparison.Ordinal)
                        .Replace("Ñ", "N", StringComparison.Ordinal)
                        .Replace("Õ", "O", StringComparison.Ordinal);
                    break;
                case LetterAccentType.Umlaut:
                    value = value
                        .Replace("Ä", "A", StringComparison.Ordinal)
                        .Replace("Ë", "E", StringComparison.Ordinal)
                        .Replace("Ï", "I", StringComparison.Ordinal)
                        .Replace("Ö", "O", StringComparison.Ordinal)
                        .Replace("Ü", "U", StringComparison.Ordinal)
                        .Replace("Ÿ", "Y", StringComparison.Ordinal);
                    break;
                default:
                    throw new SwitchCaseDefaultException(letterAccentType);
            }
        }

        return value;
    }
}