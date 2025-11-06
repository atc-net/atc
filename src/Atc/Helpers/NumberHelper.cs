// ReSharper disable InvertIf
// ReSharper disable ConvertIfStatementToReturnStatement
namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for parsing and validating numeric string values across different cultures.
/// </summary>
/// <remarks>
/// This helper supports parsing to int, decimal, double, and float types with optional culture-specific formatting.
/// </remarks>
[SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
public static class NumberHelper
{
    /// <summary>
    /// Determines whether the specified string can be parsed as any numeric type (int, decimal, double, or float).
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(
        string value)
    {
        if (TryParseToInt(value, out _))
        {
            return true;
        }

        if (TryParseToDecimal(value, out _))
        {
            return true;
        }

        if (TryParseToDouble(value, out _))
        {
            return true;
        }

        if (TryParseToFloat(value, out _))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as any numeric type using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(
        string value,
        bool useUiCulture)
    {
        if (TryParseToInt(value, out _))
        {
            return true;
        }

        if (TryParseToDecimal(value, useUiCulture, out _))
        {
            return true;
        }

        if (TryParseToDouble(value, useUiCulture, out _))
        {
            return true;
        }

        if (TryParseToFloat(value, useUiCulture, out _))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as any numeric type using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(
        string value,
        CultureInfo cultureInfo)
    {
        if (TryParseToInt(value, out _))
        {
            return true;
        }

        if (TryParseToDecimal(value, cultureInfo, out _))
        {
            return true;
        }

        if (TryParseToDouble(value, cultureInfo, out _))
        {
            return true;
        }

        if (TryParseToFloat(value, cultureInfo, out _))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as an integer.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><see langword="true"/> if the value can be parsed as an integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsInt(
        string value)
        => TryParseToInt(value, out _);

    /// <summary>
    /// Parses the specified string to an integer.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed integer value, or -1 if parsing fails.</returns>
    public static int ParseToInt(
        string value)
        => TryParseToInt(value, out var result)
            ? result
            : -1;

    /// <summary>
    /// Tries to parse the specified string to an integer using English culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">When this method returns, contains the parsed integer value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToInt(
        string value,
        out int result)
    {
        result = 0;

        if (int.TryParse(value, NumberStyles.Integer, GlobalizationConstants.EnglishCultureInfo, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as a decimal.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a decimal; otherwise, <see langword="false"/>.</returns>
    public static bool IsDecimal(
        string value)
        => TryParseToDecimal(value, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a decimal; otherwise, <see langword="false"/>.</returns>
    public static bool IsDecimal(
        string value,
        bool useUiCulture)
        => TryParseToDecimal(value, useUiCulture, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a decimal; otherwise, <see langword="false"/>.</returns>
    public static bool IsDecimal(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDecimal(value, cultureInfo, out _);

    /// <summary>
    /// Parses the specified string to a decimal.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed decimal value, or -1 if parsing fails.</returns>
    public static decimal ParseToDecimal(
        string value)
        => TryParseToDecimal(value, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns>The parsed decimal value, or -1 if parsing fails.</returns>
    public static decimal ParseToDecimal(
        string value,
        bool useUiCulture)
        => TryParseToDecimal(value, useUiCulture, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns>The parsed decimal value, or -1 if parsing fails.</returns>
    public static decimal ParseToDecimal(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDecimal(value, cultureInfo, out var result)
            ? result
            : -1;

    /// <summary>
    /// Tries to parse the specified string to a decimal using CurrentCulture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">When this method returns, contains the parsed decimal value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDecimal(
        string value,
        out decimal result)
    {
        result = 0;

        if (TryParseToDecimal(value, useUiCulture: false, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <param name="result">When this method returns, contains the parsed decimal value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDecimal(
        string value,
        bool useUiCulture,
        out decimal result)
    {
        result = 0;

        if (useUiCulture)
        {
            if (TryParseToDecimal(value, Thread.CurrentThread.CurrentUICulture, out var res))
            {
                result = res;
                return true;
            }
        }
        else
        {
            if (TryParseToDecimal(value, Thread.CurrentThread.CurrentCulture, out var res))
            {
                result = res;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a decimal using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <param name="result">When this method returns, contains the parsed decimal value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDecimal(
        string value,
        CultureInfo cultureInfo,
        out decimal result)
    {
        result = 0;

        if (decimal.TryParse(value, NumberStyles.Float, cultureInfo, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as a double.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a double; otherwise, <see langword="false"/>.</returns>
    public static bool IsDouble(
        string value)
        => TryParseToDouble(value, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a double; otherwise, <see langword="false"/>.</returns>
    public static bool IsDouble(
        string value,
        bool useUiCulture)
        => TryParseToDouble(value, useUiCulture, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a double; otherwise, <see langword="false"/>.</returns>
    public static bool IsDouble(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDouble(value, cultureInfo, out _);

    /// <summary>
    /// Parses the specified string to a double.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed double value, or -1 if parsing fails.</returns>
    public static double ParseToDouble(
        string value)
        => TryParseToDouble(value, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns>The parsed double value, or -1 if parsing fails.</returns>
    public static double ParseToDouble(
        string value,
        bool useUiCulture)
        => TryParseToDouble(value, useUiCulture, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns>The parsed double value, or -1 if parsing fails.</returns>
    public static double ParseToDouble(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDouble(value, cultureInfo, out var result)
            ? result
            : -1;

    /// <summary>
    /// Tries to parse the specified string to a double using CurrentCulture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">When this method returns, contains the parsed double value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDouble(
        string value,
        out double result)
    {
        result = 0;

        if (TryParseToDouble(value, useUiCulture: false, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <param name="result">When this method returns, contains the parsed double value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDouble(
        string value,
        bool useUiCulture,
        out double result)
    {
        result = 0;

        if (useUiCulture)
        {
            if (TryParseToDouble(value, Thread.CurrentThread.CurrentUICulture, out var res))
            {
                result = res;
                return true;
            }
        }
        else
        {
            if (TryParseToDouble(value, Thread.CurrentThread.CurrentCulture, out var res))
            {
                result = res;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a double using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <param name="result">When this method returns, contains the parsed double value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToDouble(
        string value,
        CultureInfo cultureInfo,
        out double result)
    {
        result = 0;

        if (double.TryParse(value, NumberStyles.Float, cultureInfo, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string can be parsed as a float.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a float; otherwise, <see langword="false"/>.</returns>
    public static bool IsFloat(
        string value)
        => TryParseToFloat(value, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a float; otherwise, <see langword="false"/>.</returns>
    public static bool IsFloat(
        string value,
        bool useUiCulture)
        => TryParseToFloat(value, useUiCulture, out _);

    /// <summary>
    /// Determines whether the specified string can be parsed as a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns><see langword="true"/> if the value can be parsed as a float; otherwise, <see langword="false"/>.</returns>
    public static bool IsFloat(
        string value,
        CultureInfo cultureInfo)
        => TryParseToFloat(value, cultureInfo, out _);

    /// <summary>
    /// Parses the specified string to a float.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed float value, or -1 if parsing fails.</returns>
    public static float ParseToFloat(
        string value)
        => TryParseToFloat(value, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <returns>The parsed float value, or -1 if parsing fails.</returns>
    public static float ParseToFloat(
        string value,
        bool useUiCulture)
        => TryParseToFloat(value, useUiCulture, out var result)
            ? result
            : -1;

    /// <summary>
    /// Parses the specified string to a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <returns>The parsed float value, or -1 if parsing fails.</returns>
    public static float ParseToFloat(
        string value,
        CultureInfo cultureInfo)
        => TryParseToFloat(value, cultureInfo, out var result)
            ? result
            : -1;

    /// <summary>
    /// Tries to parse the specified string to a float using CurrentCulture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">When this method returns, contains the parsed float value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToFloat(
        string value,
        out float result)
    {
        result = 0;

        if (TryParseToFloat(value, useUiCulture: false, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="useUiCulture">If <see langword="true"/>, uses CurrentUICulture; otherwise, uses CurrentCulture.</param>
    /// <param name="result">When this method returns, contains the parsed float value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToFloat(
        string value,
        bool useUiCulture,
        out float result)
    {
        result = 0;

        if (useUiCulture)
        {
            if (TryParseToFloat(value, Thread.CurrentThread.CurrentUICulture, out var res))
            {
                result = res;
                return true;
            }
        }
        else
        {
            if (TryParseToFloat(value, Thread.CurrentThread.CurrentCulture, out var res))
            {
                result = res;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Tries to parse the specified string to a float using the specified culture.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture to use for parsing.</param>
    /// <param name="result">When this method returns, contains the parsed float value if successful; otherwise, 0.</param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseToFloat(
        string value,
        CultureInfo cultureInfo,
        out float result)
    {
        result = 0;

        if (float.TryParse(value, NumberStyles.Float, cultureInfo, out var res))
        {
            result = res;
            return true;
        }

        return false;
    }
}