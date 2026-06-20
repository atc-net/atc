// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
namespace Atc.Units.InternationalSystemOfUnits;

/// <summary>
/// Provides utility methods for converting between International System of Units (SI) prefixes.
/// </summary>
/// <remarks>
/// This helper class supports conversions between all standard SI unit prefixes
/// (Yotta through Yocto) using a table-driven exponent approach.
/// </remarks>
public static class InternationalSystemOfUnitsHelper
{
    private static readonly IReadOnlyDictionary<PrefixType, int> PrefixExponents =
        new Dictionary<PrefixType, int>
        {
            { PrefixType.Yotta, 24 },
            { PrefixType.Zetta, 21 },
            { PrefixType.Exa, 18 },
            { PrefixType.Peta, 15 },
            { PrefixType.Tera, 12 },
            { PrefixType.Giga, 9 },
            { PrefixType.Mega, 6 },
            { PrefixType.Kilo, 3 },
            { PrefixType.Hecto, 2 },
            { PrefixType.Deca, 1 },
            { PrefixType.None, 0 },
            { PrefixType.Deci, -1 },
            { PrefixType.Centi, -2 },
            { PrefixType.Milli, -3 },
            { PrefixType.Micro, -6 },
            { PrefixType.Nano, -9 },
            { PrefixType.Pico, -12 },
            { PrefixType.Femto, -15 },
            { PrefixType.Atto, -18 },
            { PrefixType.Zepto, -21 },
            { PrefixType.Yocto, -24 },
        };

    /// <summary>
    /// Converts a value from one SI prefix type to another with optional decimal precision.
    /// </summary>
    /// <param name="prefixTypeFrom">The source SI prefix type.</param>
    /// <param name="prefixTypeTo">The target SI prefix type.</param>
    /// <param name="numberOfDecimals">The number of decimal places to round to. Pass 0 for no rounding.</param>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in the target prefix type, optionally rounded.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="prefixTypeFrom"/> or <paramref name="prefixTypeTo"/> is not a recognised <see cref="PrefixType"/> value.
    /// </exception>
    /// <exception cref="ArithmeticException">Thrown when the conversion results in NaN.</exception>
    public static double Convert(
        PrefixType prefixTypeFrom,
        PrefixType prefixTypeTo,
        int numberOfDecimals,
        double value)
    {
        if (!PrefixExponents.TryGetValue(prefixTypeFrom, out var fromExp))
        {
            throw new ArgumentOutOfRangeException(nameof(prefixTypeFrom), prefixTypeFrom, "Unsupported SI prefix type.");
        }

        if (!PrefixExponents.TryGetValue(prefixTypeTo, out var toExp))
        {
            throw new ArgumentOutOfRangeException(nameof(prefixTypeTo), prefixTypeTo, "Unsupported SI prefix type.");
        }

        var result = value * System.Math.Pow(10, fromExp - toExp);

        if (double.IsNaN(result))
        {
            throw new ArithmeticException("Conversion resulted in NaN.");
        }

        return numberOfDecimals != 0
            ? System.Math.Round(result, numberOfDecimals)
            : result;
    }
}