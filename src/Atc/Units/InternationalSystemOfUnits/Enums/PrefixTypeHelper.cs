// ReSharper disable once CheckNamespace
namespace Atc.Units.InternationalSystemOfUnits;

/// <summary>
/// Prefix Type Helper
/// </summary>
public static class PrefixTypeHelper
{
    /// <summary>
    /// Gets the symbol.
    /// </summary>
    /// <param name="prefixType">
    /// Type of the prefix.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string GetSymbol(PrefixType prefixType)
    {
        switch (prefixType)
        {
            case PrefixType.Yotta:
                return "Y";
            case PrefixType.Zetta:
                return "Z";
            case PrefixType.Exa:
                return "E";
            case PrefixType.Peta:
                return "P";
            case PrefixType.Tera:
                return "T";
            case PrefixType.Giga:
                return "G";
            case PrefixType.Mega:
                return "M";
            case PrefixType.Kilo:
                return "k";
            case PrefixType.Hecto:
                return "h";
            case PrefixType.Deca:
                return "da";
            case PrefixType.None:
                break;
            case PrefixType.Deci:
                return "d";
            case PrefixType.Centi:
                return "c";
            case PrefixType.Milli:
                return "m";
            case PrefixType.Micro:
                return "µ"; //// ASCII: &#181;
            case PrefixType.Nano:
                return "n";
            case PrefixType.Pico:
                return "p";
            case PrefixType.Femto:
                return "f";
            case PrefixType.Atto:
                return "a";
            case PrefixType.Zepto:
                return "z";
            case PrefixType.Yocto:
                return "y";
            default:
                return string.Empty;
        }

        return string.Empty;
    }

    /// <summary>
    /// Gets the symbol for meter.
    /// </summary>
    /// <param name="prefixType">
    /// Type of the prefix.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string GetSymbolForMeter(PrefixType prefixType)
        => GetSymbol(prefixType) + "m";
}