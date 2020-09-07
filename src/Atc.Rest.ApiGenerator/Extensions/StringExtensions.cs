using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace System
{
    internal static class StringExtensions
    {
        private const string AutoPropResultPattern = " { get; set; }";
        private static readonly Regex AutoPropRegex = new Regex(@"\s*\{\s*get;\s*set;\s*}\s");
        private static readonly Regex AutoPropInitializerRegex = new Regex(@"\s*\{ get; set; }\s*= \s*");
        private static readonly Regex AutoPublicLinesRegex = new Regex(@"\s*;\s*public \s*");
        private static readonly Regex AutoPrivateLinesRegex = new Regex(@"\s*;\s*private \s*");
        private static readonly Regex AutoCommentLinesRegex = new Regex(@"\s*;\s*/// \s*");
        private static readonly Regex AutoBracketSpacingStartRegex = new Regex(@"(\S)({)(\S)");
        private static readonly Regex AutoBracketSpacingEndRegex = new Regex(@"(\S)(})(\S)");

        public static string FormatAutoPropertiesOnOneLine(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = AutoPropRegex.Replace(value, AutoPropResultPattern);
            value = AutoPropInitializerRegex.Replace(value, $"{AutoPropResultPattern} = ");
            value = value.Replace(">();", $">();{Environment.NewLine}", StringComparison.Ordinal);
            return value;
        }

        public static string FormatDoubleLines(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Replace($"{Environment.NewLine}{Environment.NewLine}    }}", $"{Environment.NewLine}    }}", StringComparison.Ordinal);
        }

        public static string FormatPublicPrivateLines(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = AutoPublicLinesRegex.Replace(value, $";{Environment.NewLine}{Environment.NewLine}        public ");
            value = AutoPrivateLinesRegex.Replace(value, $";{Environment.NewLine}{Environment.NewLine}        private ");
            value = AutoCommentLinesRegex.Replace(value, $";{Environment.NewLine}{Environment.NewLine}        /// ");
            return value;
        }

        public static string FormatBracketSpacing(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = AutoBracketSpacingStartRegex.Replace(value, "$1 { $3");
            value = AutoBracketSpacingEndRegex.Replace(value, "$1 } $3");
            return value;
        }
    }
}