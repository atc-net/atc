// ReSharper disable InvertIf
namespace Atc.Units.DigitalInformation;

/// <summary>
/// A formatter that converts a byte size to a human readable string.
/// </summary>
public class ByteSizeFormatter
{
    private ByteSizeUnitType minUnit;
    private ByteSizeUnitType maxUnit;
    private int numberOfDecimals;

    /// <summary>
    /// Initializes a new instance of the <see cref="ByteSizeFormatter"/> class.
    /// </summary>
    public ByteSizeFormatter()
    {
        SuffixFormat = ByteSizeSuffixType.Short;
        MinUnit = ByteSizeUnitType.Byte;
        MaxUnit = ByteSizeUnitType.Exabyte;
        RoundingRule = ByteSizeRoundingRuleType.Closest;
        NumberOfDecimals = 0;
        NumberFormatInfo = Thread.CurrentThread.CurrentUICulture.NumberFormat;
    }

    /// <summary>
    /// Returns a default instance of ByteSizeFormatter. This formatter will be used by the ByteSize.ToString() method.
    /// </summary>
    public static ByteSizeFormatter Default { get; } = new ByteSizeFormatter();

    /// <summary>
    /// Gets or sets a value indicating whether the suffix format should be short or full wording.
    /// </summary>
    public ByteSizeSuffixType SuffixFormat { get; set; }

    /// <summary>
    /// Gets or sets the smallest unit used by the formatter.
    /// </summary>
    public ByteSizeUnitType MinUnit
    {
        get => minUnit;
        set
        {
            minUnit = value;
            if (MaxUnit < minUnit)
            {
                minUnit = MaxUnit;
            }
        }
    }

    /// <summary>
    /// Gets or sets the largest unit used by the formatter.
    /// </summary>
    public ByteSizeUnitType MaxUnit
    {
        get => maxUnit;
        set
        {
            maxUnit = value;
            if (MinUnit > maxUnit)
            {
                maxUnit = MinUnit;
            }
        }
    }

    /// <summary>
    /// Gets or sets the rounding rule.
    /// </summary>
    public ByteSizeRoundingRuleType RoundingRule { get; set; }

    /// <summary>
    /// Gets or sets the number of decimals.
    /// </summary>
    public int NumberOfDecimals
    {
        get => numberOfDecimals;
        set
        {
            numberOfDecimals = value;
            if (numberOfDecimals < 0)
            {
                numberOfDecimals = 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the number format information.
    /// </summary>
    public NumberFormatInfo NumberFormatInfo { get; set; }

    /// <summary>
    /// Formats the specified size.
    /// </summary>
    /// <param name="size">The size to format.</param>
    /// <returns>The formatted size.</returns>
    public string Format(long size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        var multiples = ByteSizeCalculationData.BinaryMultiples;
        var prefixIndex = GetPrefixIndex(size, multiples);

        var displaySize = Round((decimal)size / multiples[prefixIndex]);
        var displaySizeStr = displaySize.ToString("#,##0.###", NumberFormatInfo);

        if (SuffixFormat == ByteSizeSuffixType.None)
        {
            return displaySizeStr;
        }

        var prefixes = SuffixFormat == ByteSizeSuffixType.Full
            ? ByteSizeCalculationData.PrefixesFull
            : ByteSizeCalculationData.PrefixesShort;

        var suffixLastPart = BuildSuffixLastPart(size, prefixIndex);

        return $"{displaySizeStr} {prefixes[prefixIndex]}{suffixLastPart}";
    }

    private int GetPrefixIndex(long size, IReadOnlyList<long> multiples)
    {
        var prefixIndex = (int)MinUnit;
        for (int i = prefixIndex; i <= (int)MaxUnit; i++)
        {
            if (size < multiples[i])
            {
                break;
            }

            prefixIndex = i;
        }

        return prefixIndex;
    }

    private string BuildSuffixLastPart(long size, int prefixIndex)
    {
        var text = "B";
        if (SuffixFormat == ByteSizeSuffixType.Full)
        {
            if (prefixIndex == 0)
            {
                text = size > 1
                    ? "bytes"
                    : "byte";
            }
            else
            {
                text = "byte";
            }
        }

        return text;
    }

    private decimal Round(decimal value)
    {
        if (RoundingRule == ByteSizeRoundingRuleType.Closest)
        {
            return value.RoundOff(NumberOfDecimals);
        }

        var factor = (decimal)System.Math.Pow(10, NumberOfDecimals);

        Func<decimal, decimal> roundFunc = RoundingRule == ByteSizeRoundingRuleType.Down
            ? decimal.Floor
            : decimal.Ceiling;

        return roundFunc(value * factor) / factor;
    }
}