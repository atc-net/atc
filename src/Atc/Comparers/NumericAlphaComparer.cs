// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Provides natural sorting comparison for strings containing both numeric and alphabetic characters.
/// Numbers are compared numerically rather than alphabetically (e.g., "file2" comes before "file10").
/// </summary>
public class NumericAlphaComparer : IComparer<string>
{
    /// <inheritdoc />
    [SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public int Compare(string? x, string? y)
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
        if (x.IsDigitOnly() && int.TryParse(x, out var i1))
        {
            a = i1;
        }

        int? b = null;
        if (y.IsDigitOnly() && int.TryParse(y, out var i2))
        {
            b = i2;
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

        var tupleA = a.HasValue
            ? new Tuple<int, string>(a.Value, null!)
            : new Tuple<int, string>(ExtractNumber(x), ExtractLetters(x));
        var tupleB = b.HasValue
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
            return string.Compare(tupleA.Item2, tupleB.Item2, StringComparison.OrdinalIgnoreCase);
        }

        return 0;
    }

    private static int ExtractNumber(string value)
    {
        // ReSharper disable once InvertIf
        if (!string.IsNullOrEmpty(value))
        {
            var s = Regex.Match(value, @"\d+", RegexOptions.None, TimeSpan.FromSeconds(1)).Value;
            if (int.TryParse(s, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var x))
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