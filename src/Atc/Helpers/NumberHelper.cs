// ReSharper disable InvertIf
// ReSharper disable ConvertIfStatementToReturnStatement
namespace Atc.Helpers;

[SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
public static class NumberHelper
{
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

    public static bool IsInt(
        string value)
        => TryParseToInt(value, out _);

    public static int ParseToInt(
        string value)
        => TryParseToInt(value, out var result)
            ? result
            : -1;

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

    public static bool IsDecimal(
        string value)
        => TryParseToDecimal(value, out _);

    public static bool IsDecimal(
        string value,
        bool useUiCulture)
        => TryParseToDecimal(value, useUiCulture, out _);

    public static bool IsDecimal(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDecimal(value, cultureInfo, out _);

    public static decimal ParseToDecimal(
        string value)
        => TryParseToDecimal(value, out var result)
            ? result
            : -1;

    public static decimal ParseToDecimal(
        string value,
        bool useUiCulture)
        => TryParseToDecimal(value, useUiCulture, out var result)
            ? result
            : -1;

    public static decimal ParseToDecimal(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDecimal(value, cultureInfo, out var result)
            ? result
            : -1;

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

    public static bool IsDouble(
        string value)
        => TryParseToDouble(value, out _);

    public static bool IsDouble(
        string value,
        bool useUiCulture)
        => TryParseToDouble(value, useUiCulture, out _);

    public static bool IsDouble(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDouble(value, cultureInfo, out _);

    public static double ParseToDouble(
        string value)
        => TryParseToDouble(value, out var result)
            ? result
            : -1;

    public static double ParseToDouble(
        string value,
        bool useUiCulture)
        => TryParseToDouble(value, useUiCulture, out var result)
            ? result
            : -1;

    public static double ParseToDouble(
        string value,
        CultureInfo cultureInfo)
        => TryParseToDouble(value, cultureInfo, out var result)
            ? result
            : -1;

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

    public static bool IsFloat(
        string value)
        => TryParseToFloat(value, out _);

    public static bool IsFloat(
        string value,
        bool useUiCulture)
        => TryParseToFloat(value, useUiCulture, out _);

    public static bool IsFloat(
        string value,
        CultureInfo cultureInfo)
        => TryParseToFloat(value, cultureInfo, out _);

    public static float ParseToFloat(
        string value)
        => TryParseToFloat(value, out var result)
            ? result
            : -1;

    public static float ParseToFloat(
        string value,
        bool useUiCulture)
        => TryParseToFloat(value, useUiCulture, out var result)
            ? result
            : -1;

    public static float ParseToFloat(
        string value,
        CultureInfo cultureInfo)
        => TryParseToFloat(value, cultureInfo, out var result)
            ? result
            : -1;

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