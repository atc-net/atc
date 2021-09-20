using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Units.InternationalSystemOfUnits
{
    /// <summary>
    /// Convert Util
    /// </summary>
    public static class InternationalSystemOfUnitsHelper
    {
        /// <summary>
        /// Converts the specified prefix type from.
        /// </summary>
        /// <param name="prefixTypeFrom">
        /// The prefix type from.
        /// </param>
        /// <param name="prefixTypeTo">
        /// The prefix type to.
        /// </param>
        /// <param name="numberOfDecimals">
        /// The number of decimals.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1123:Do not place regions within elements", Justification = "OK. For now.")]
        public static double Convert(PrefixType prefixTypeFrom, PrefixType prefixTypeTo, int numberOfDecimals, double value)
        {
            var d = double.NaN;

            switch (prefixTypeFrom)
            {
                case PrefixType.Yotta:
                    break;
                case PrefixType.Zetta:
                    break;
                case PrefixType.Exa:
                    break;
                case PrefixType.Peta:
                    break;
                case PrefixType.Tera:
                    break;
                case PrefixType.Giga:
                    break;
                case PrefixType.Mega:
                    break;
                case PrefixType.Kilo:
                    break;
                case PrefixType.Hecto:
                    break;
                case PrefixType.Deca:
                    break;
                case PrefixType.None:
                    #region - None -
                    switch (prefixTypeTo)
                    {
                        case PrefixType.Yotta:
                        case PrefixType.Zetta:
                        case PrefixType.Exa:
                        case PrefixType.Peta:
                        case PrefixType.Tera:
                        case PrefixType.Giga:
                        case PrefixType.Mega:
                        case PrefixType.Kilo:
                        case PrefixType.Hecto:
                        case PrefixType.Deca:
                            throw new NotSupportedException();
                        case PrefixType.None:
                            d = value;
                            break;
                        case PrefixType.Deci:
                            d = value * 10;
                            break;
                        case PrefixType.Centi:
                            d = value * 100;
                            break;
                        case PrefixType.Milli:
                            d = value * 1000;
                            break;
                        case PrefixType.Micro:
                        case PrefixType.Nano:
                        case PrefixType.Pico:
                        case PrefixType.Femto:
                        case PrefixType.Atto:
                        case PrefixType.Zepto:
                        case PrefixType.Yocto:
                            throw new NotSupportedException();
                    }
                    #endregion
                    break;
                case PrefixType.Deci:
                    break;
                case PrefixType.Centi:
                    #region - Centi -
                    switch (prefixTypeTo)
                    {
                        case PrefixType.Yotta:
                        case PrefixType.Zetta:
                        case PrefixType.Exa:
                        case PrefixType.Peta:
                        case PrefixType.Tera:
                            throw new NotSupportedException();
                        case PrefixType.Giga:
                            d = value / 100000000000;
                            break;
                        case PrefixType.Mega:
                            d = value / 100000000;
                            break;
                        case PrefixType.Kilo:
                            d = value / 100000;
                            break;
                        case PrefixType.Hecto:
                            d = value / 10000;
                            break;
                        case PrefixType.Deca:
                            d = value / 1000;
                            break;
                        case PrefixType.None:
                            d = value / 100;
                            break;
                        case PrefixType.Deci:
                            d = value / 10;
                            break;
                        case PrefixType.Centi:
                            d = value;
                            break;
                        case PrefixType.Milli:
                            d = value * 10;
                            break;
                        case PrefixType.Micro:
                            d = value * 1000;
                            break;
                        case PrefixType.Nano:
                            d = value * 1000000;
                            break;
                        case PrefixType.Pico:
                            d = value * 1000000000;
                            break;
                        case PrefixType.Femto:
                        case PrefixType.Atto:
                        case PrefixType.Zepto:
                        case PrefixType.Yocto:
                            throw new NotSupportedException();
                    }
                    #endregion
                    break;
                case PrefixType.Milli:
                    #region - Milli -
                    switch (prefixTypeTo)
                    {
                        case PrefixType.Yotta:
                        case PrefixType.Zetta:
                        case PrefixType.Exa:
                        case PrefixType.Peta:
                        case PrefixType.Tera:
                            throw new NotSupportedException();
                        case PrefixType.Giga:
                            d = value / 1000000000000;
                            break;
                        case PrefixType.Mega:
                            d = value / 1000000000;
                            break;
                        case PrefixType.Kilo:
                            d = value / 1000000;
                            break;
                        case PrefixType.Hecto:
                            d = value / 100000;
                            break;
                        case PrefixType.Deca:
                            d = value / 10000;
                            break;
                        case PrefixType.None:
                            d = value / 1000;
                            break;
                        case PrefixType.Deci:
                            d = value / 100;
                            break;
                        case PrefixType.Centi:
                            d = value / 10;
                            break;
                        case PrefixType.Milli:
                            d = value;
                            break;
                        case PrefixType.Micro:
                            d = value * 1000;
                            break;
                        case PrefixType.Nano:
                            d = value * 1000000;
                            break;
                        case PrefixType.Pico:
                            d = value * 1000000000;
                            break;
                        case PrefixType.Femto:
                        case PrefixType.Atto:
                        case PrefixType.Zepto:
                        case PrefixType.Yocto:
                            throw new NotSupportedException();
                    }
                    #endregion
                    break;
                case PrefixType.Micro:
                    break;
                case PrefixType.Nano:
                    break;
                case PrefixType.Pico:
                    break;
                case PrefixType.Femto:
                    break;
                case PrefixType.Atto:
                    break;
                case PrefixType.Zepto:
                    break;
                case PrefixType.Yocto:
                    break;
            }

            if (double.IsNaN(d))
            {
                throw new ArithmeticException("d IsNaN");
            }

            if (numberOfDecimals != decimal.Zero)
            {
                d = System.Math.Round(d, numberOfDecimals);
            }

            return d;
        }
    }
}