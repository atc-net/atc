using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// StringHasIsExtensions.
    /// </summary>
    public static class StringHasIsExtensions
    {
        private static readonly Lazy<Regex> RxAlpha = new Lazy<Regex>(() => new Regex("[^a-zA-Z]", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxAlphaNumeric = new Lazy<Regex>(() => new Regex("[^a-zA-Z0-9]", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxEmailAddress = new Lazy<Regex>(() => new Regex(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxGuid = new Lazy<Regex>(() => new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxNumeric = new Lazy<Regex>(() => new Regex("[^0-9]", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxKey = new Lazy<Regex>(() => new Regex(@"^([a-zA-Z]+[a-zA-Z0-9_]+$)", RegexOptions.Singleline));
        private static readonly Lazy<Regex> RxHtmlTags = new Lazy<Regex>(() => new Regex(@"<[^>]+>", RegexOptions.Multiline));
        private static readonly Lazy<Regex> RxSingleWord = new Lazy<Regex>(() => new Regex(@"^((?!-)+)([a-zA-Z_-]+$).*((?<!-)+)", RegexOptions.Singleline));

        /// <summary>
        /// Determines whether [has HTML tags] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [has HTML tags] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasHtmlTags(this string value)
        {
            return !string.IsNullOrEmpty(value) && RxHtmlTags.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified b is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="stringComparison">The string comparison.</param>
        /// <param name="treatNullAsEmpty">if set to <c>true</c> [treat null as empty].</param>
        /// <param name="useNormalizeAccents">if set to <c>true</c> [use normalize accents].</param>
        /// <returns>
        ///   <c>true</c> if the specified b is equal; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public static bool IsEqual(this string a, string b, StringComparison stringComparison = StringComparison.Ordinal, bool treatNullAsEmpty = true, bool useNormalizeAccents = false)
        {
            if (string.Equals(a, null, StringComparison.Ordinal) && string.Equals(b, null, StringComparison.Ordinal))
            {
                return true;
            }

            if (treatNullAsEmpty)
            {
                if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                {
                    return true;
                }
            }

            if (string.Equals(a, null, StringComparison.Ordinal))
            {
                return false;
            }

            return useNormalizeAccents
                ? a.NormalizeAccents().Equals(b.NormalizeAccents(), stringComparison)
                : a.Equals(b, stringComparison);
        }

        /// <summary>
        /// Determines whether the specified value is true.
        /// </summary>
        /// <param name="value">The value.</param>
        public static bool IsTrue(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            value = value.Trim();
            return value.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("1", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("yes", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the specified value is false.
        /// </summary>
        /// <param name="value">The value.</param>
        public static bool IsFalse(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            value = value.Trim();
            return value.Equals("false", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("0", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("no", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the specified value is alpha [a-zA-Z].
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is alpha [a-zA-Z]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAlphaOnly(this string value)
        {
            return !string.IsNullOrEmpty(value) && !RxAlpha.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified value is alpha-numeric [a- z, A-Z, 0-9].
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is alpha-numeric [a- z, A-Z, 0-9]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAlphaNumericOnly(this string value)
        {
            return !string.IsNullOrEmpty(value) && !RxAlphaNumeric.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified value is a date.
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns><c>true</c> if the specified value is a date; otherwise, <c>false</c>.</returns>
        public static bool IsDate(this string value)
        {
            return !string.IsNullOrEmpty(value) &&
                   value.IsDate(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Determines whether the specified culture information is date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>
        ///   <c>true</c> if the specified culture information is date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDate(this string value, CultureInfo cultureInfo)
        {
            return !string.IsNullOrEmpty(value) &&
                   DateTime.TryParse(value, cultureInfo, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// Determines whether the specified value is digit [0-9].
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is digit [0-9]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDigitOnly(this string value)
        {
            return IsNumericOnly(value);
        }

        /// <summary>
        /// Determines whether [is format json].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is format json] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFormatJson(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();
            return (value.StartsWith("{", StringComparison.Ordinal) && value.EndsWith("}", StringComparison.Ordinal)) ||
                   (value.StartsWith("[", StringComparison.Ordinal) && value.EndsWith("]", StringComparison.Ordinal));
        }

        /// <summary>
        /// Determines whether [is format XML].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is format XML] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFormatXml(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();
            return value.StartsWith("<", StringComparison.Ordinal) && value.EndsWith(">", StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines whether the specified string is a System.Guid.
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns><c>true</c> if the specified string is a System.Guid; otherwise, <c>false</c>.</returns>
        public static bool IsGuid(this string value)
        {
            return RxGuid.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified string is a System.Guid.
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <param name="output">If value is valid, output will be System.Guid passed from value; otherwise output will be System.Guid.Empty.</param>
        /// <returns><c>true</c> if the specified string is a System.Guid; otherwise, <c>false</c>.</returns>
        public static bool IsGuid(this string value, out Guid output)
        {
            output = Guid.Empty;
            if (!RxGuid.Value.IsMatch(value))
            {
                return false;
            }

            output = new Guid(value);
            return true;
        }

        /// <summary>
        /// Determines whether the specified value is key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is key; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsKey(this string value)
        {
            return !string.IsNullOrEmpty(value) && RxKey.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified string length is even.
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns><c>true</c> if the specified string length is even; otherwise, <c>false</c>.</returns>
        public static bool IsLengthEven(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length.IsEven();
        }

        /// <summary>
        /// Determines whether the specified value is numeric [0-9].
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is numeric [0-9]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumericOnly(this string value)
        {
            return !string.IsNullOrEmpty(value) && !RxNumeric.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified value is sentence.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is sentence; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSentence(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.TrimExtended().Split(' ').Length > 1;
        }

        /// <summary>
        /// Determines whether [is string format parameters balanced] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isNumeric">if set to <c>true</c> [is numeric].</param>
        /// <returns>
        ///   <c>true</c> if [is string format parameters balanced] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsStringFormatParametersBalanced(this string value, bool isNumeric = true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            int countLeft = value.Count(x => x == '{');
            int countRight = value.Count(x => x == '}');
            if (countLeft != countRight)
            {
                return false;
            }

            string[] sa = value.Split('{');

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (string s in sa)
            {
                if (s.IndexOf("}", StringComparison.Ordinal) == -1)
                {
                    continue;
                }

                if (s.Count(x => x == '}') != 1)
                {
                    return false;
                }

                if (!isNumeric)
                {
                    continue;
                }

                string[] sas = s.Split('}');
                if (sas.Length == 0 || !int.TryParse(sas[0], out int _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified value is word.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is word; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWord(this string value)
        {
            return !string.IsNullOrEmpty(value) && RxSingleWord.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines whether [is first character lower case].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is first character lower case] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFirstCharacterLowerCase(this string value)
        {
            return !string.IsNullOrEmpty(value) && char.IsLower(value[0]);
        }

        /// <summary>
        /// Determines whether [is first character upper case].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is first character upper case] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFirstCharacterUpperCase(this string value)
        {
            return !string.IsNullOrEmpty(value) && char.IsUpper(value[0]);
        }

        /// <summary>
        /// Determines whether the specified company CVR number is a valid number.
        /// </summary>
        /// <remarks>This works only for Danish companies.</remarks>
        /// <param name="cvrNumber">The CVR number.</param>
        /// <returns>
        ///   <c>true</c> if the specified company CVR number is a valid number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCompanyCvrNumber(this string cvrNumber)
        {
            if (string.IsNullOrEmpty(cvrNumber) ||
                !IsDigitOnly(cvrNumber))
            {
                return false;
            }

            cvrNumber = cvrNumber.Trim();
            if (cvrNumber.Length != 8)
            {
                return false;
            }

            int[] validate = new[] { 2, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                sum += int.Parse(cvrNumber[i].ToString(Thread.CurrentThread.CurrentCulture), Thread.CurrentThread.CurrentCulture) * validate[i];
            }

            if (sum % 11 == 0 && int.Parse(cvrNumber[7].ToString(Thread.CurrentThread.CurrentCulture), Thread.CurrentThread.CurrentCulture) == 0)
            {
                return true;
            }

            return (11 - (sum % 11)).Equals(int.Parse(cvrNumber[7].ToString(Thread.CurrentThread.CurrentCulture), Thread.CurrentThread.CurrentCulture));
        }

        /// <summary>
        /// Determines whether the specified company P number is a valid number.
        /// </summary>
        /// <param name="pNumber">The p number.</param>
        /// <returns>
        /// <c>true</c> if the specified company P number is a valid number; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public static bool IsCompanyPNumber(this string pNumber)
        {
            if (string.IsNullOrEmpty(pNumber) ||
                !IsDigitOnly(pNumber))
            {
                return false;
            }

            pNumber = pNumber.Trim();
            return pNumber.Length == 10;
        }

        /// <summary>
        /// Determines whether the specified person CPR number is a valid number.
        /// </summary>
        /// <param name="cprNumber">The CPR number.</param>
        /// <returns><c>true</c> if the specified person CPR number is a valid number; otherwise, <c>false</c>.</returns>
        public static bool IsPersonCprNumber(this string cprNumber)
        {
            if (string.IsNullOrEmpty(cprNumber))
            {
                return false;
            }

            cprNumber = cprNumber
                .Replace(" ", string.Empty, StringComparison.Ordinal)
                .Replace("-", string.Empty, StringComparison.Ordinal)
                .Replace("/", string.Empty, StringComparison.Ordinal)
                .Replace(".", string.Empty, StringComparison.Ordinal)
                .Replace(":", string.Empty, StringComparison.Ordinal)
                .Trim();
            if (!IsDigitOnly(cprNumber))
            {
                return false;
            }

            if (cprNumber.Length != 9 && cprNumber.Length != 10)
            {
                return false;
            }

            if (cprNumber.Length == 9)
            {
                cprNumber = "0" + cprNumber;
            }

            int[] c = { 4, 3, 2, 7, 6, 5, 4, 3, 2, 1 };
            int temp = 0;
            for (int i = 0; i < 10; i++)
            {
                temp += c[i] * int.Parse(cprNumber.Substring(i, 1), Thread.CurrentThread.CurrentCulture);
            }

            return temp % 11 == 0;
        }

        /// <summary>
        /// Determines whether the specified value is a valid email address.
        /// </summary>
        /// <param name="value">The string to work on.</param>
        /// <returns><c>true</c> if the specified value is a valid email address; otherwise, <c>false</c>.</returns>
        public static bool IsEmailAddress(this string value)
        {
            return !string.IsNullOrEmpty(value) && RxEmailAddress.Value.IsMatch(value);
        }
    }
}