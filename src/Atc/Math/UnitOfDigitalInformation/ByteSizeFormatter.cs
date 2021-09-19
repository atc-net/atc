using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// ReSharper disable InvertIf
namespace Atc.Math.UnitOfDigitalInformation
{
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
            this.SuffixFormat = ByteSizeSuffixType.Short;
            this.MinUnit = ByteSizeUnitType.Byte;
            this.MaxUnit = ByteSizeUnitType.Exabyte;
            this.RoundingRule = ByteSizeRoundingRuleType.Closest;
            this.NumberOfDecimals = 0;
            this.NumberFormatInfo = Thread.CurrentThread.CurrentUICulture.NumberFormat;
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
            get => this.minUnit;
            set
            {
                this.minUnit = value;
                if (this.MaxUnit < this.minUnit)
                {
                    this.minUnit = this.MaxUnit;
                }
            }
        }

        /// <summary>
        /// Gets or sets the largest unit used by the formatter.
        /// </summary>
        public ByteSizeUnitType MaxUnit
        {
            get => this.maxUnit;
            set
            {
                this.maxUnit = value;
                if (this.MinUnit > this.maxUnit)
                {
                    this.maxUnit = this.MinUnit;
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
            get => this.numberOfDecimals;
            set
            {
                this.numberOfDecimals = value;
                if (this.numberOfDecimals < 0)
                {
                    this.numberOfDecimals = 0;
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
            var displaySizeStr = displaySize.ToString("#,##0.###", this.NumberFormatInfo);

            if (this.SuffixFormat == ByteSizeSuffixType.None)
            {
                return displaySizeStr;
            }

            var prefixes = this.SuffixFormat == ByteSizeSuffixType.Full
                ? ByteSizeCalculationData.PrefixesFull
                : ByteSizeCalculationData.PrefixesShort;

            var suffixLastPart = BuildSuffixLastPart(size, prefixIndex);

            return $"{displaySizeStr} {prefixes[prefixIndex]}{suffixLastPart}";
        }

        private int GetPrefixIndex(long size, IReadOnlyList<long> multiples)
        {
            var prefixIndex = (int)this.MinUnit;
            for (int i = prefixIndex; i <= (int)this.MaxUnit; i++)
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
            if (this.SuffixFormat == ByteSizeSuffixType.Full)
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
            if (this.RoundingRule == ByteSizeRoundingRuleType.Closest)
            {
                return value.RoundOff(this.NumberOfDecimals);
            }

            var factor = (decimal)System.Math.Pow(10, this.NumberOfDecimals);

            Func<decimal, decimal> roundFunc = this.RoundingRule == ByteSizeRoundingRuleType.Down
                ? decimal.Floor
                : decimal.Ceiling;

            return roundFunc(value * factor) / factor;
        }
    }
}