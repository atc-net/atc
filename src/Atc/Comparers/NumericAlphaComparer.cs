using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// NumericAlphaComparer.
    /// </summary>
    public class NumericAlphaComparer : IComparer<string>
    {
        /// <inheritdoc />
        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(x))
            {
                return -1;
            }

            if (string.IsNullOrEmpty(y))
            {
                return 1;
            }

            int? a = null;
            if (x.IsDigitOnly())
            {
                if (int.TryParse(x, out int i))
                {
                    a = i;
                }
            }

            int? b = null;
            if (y.IsDigitOnly())
            {
                if (int.TryParse(y, out int i))
                {
                    b = i;
                }
            }

            if (a.HasValue && b.HasValue)
            {
                if (a.Value > b.Value)
                {
                    return 1;
                }

                if (a.Value < b.Value)
                {
                    return -1;
                }

                if (a.Value == b.Value)
                {
                    return 0;
                }
            }

            Tuple<int, string> tupleA = a.HasValue
                ? new Tuple<int, string>(a.Value, null!)
                : new Tuple<int, string>(ExtractNumber(x), ExtractLetters(x));
            Tuple<int, string> tupleB = b.HasValue
                ? new Tuple<int, string>(b.Value, null!)
                : new Tuple<int, string>(ExtractNumber(y), ExtractLetters(y));

            if (tupleA.Item1 > tupleB.Item1)
            {
                return 1;
            }

            if (tupleA.Item1 < tupleB.Item1)
            {
                return -1;
            }

            if (tupleA.Item1 == tupleB.Item1)
            {
                return string.Compare(tupleA.Item2, tupleB.Item2, StringComparison.CurrentCultureIgnoreCase);
            }

            return 0;
        }

        private static int ExtractNumber(string value)
        {
            // ReSharper disable once InvertIf
            if (!string.IsNullOrEmpty(value))
            {
                var s = Regex.Match(value, @"\d+").Value;
                if (int.TryParse(s, out int x))
                {
                    return x;
                }
            }

            return 0;
        }

        private static string ExtractLetters(string value)
        {
            value = value
                .Replace(" ", string.Empty, StringComparison.Ordinal)
                .Replace(".", string.Empty, StringComparison.Ordinal)
                .Replace(",", string.Empty, StringComparison.Ordinal);
            return value
                .Replace(ExtractNumber(value).ToString(Thread.CurrentThread.CurrentCulture), string.Empty, StringComparison.Ordinal)
                .Trim();
        }
    }
}