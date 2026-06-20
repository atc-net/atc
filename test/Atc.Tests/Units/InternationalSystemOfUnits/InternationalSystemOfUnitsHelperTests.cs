namespace Atc.Tests.Units.InternationalSystemOfUnits;

public class InternationalSystemOfUnitsHelperTests
{
    [Theory]
    [InlineData(0.0006, PrefixType.Centi, PrefixType.Kilo, 4, 57)]
    [InlineData(0.00057, PrefixType.Centi, PrefixType.Kilo, 10, 57)]
    [InlineData(1.0, PrefixType.Kilo, PrefixType.Kilo, 0, 1.0)]
    [InlineData(1.0, PrefixType.None, PrefixType.None, 0, 1.0)]
    [InlineData(1.0, PrefixType.Micro, PrefixType.Micro, 0, 1.0)]
    [InlineData(1000.0, PrefixType.Kilo, PrefixType.None, 0, 1.0)]
    [InlineData(1000000.0, PrefixType.Kilo, PrefixType.Milli, 0, 1.0)]
    [InlineData(1.0, PrefixType.Kilo, PrefixType.Mega, 0, 1000.0)]
    [InlineData(1000.0, PrefixType.Mega, PrefixType.Kilo, 0, 1.0)]
    [InlineData(1.0, PrefixType.Mega, PrefixType.Mega, 0, 1.0)]
    [InlineData(1000000.0, PrefixType.Mega, PrefixType.None, 0, 1.0)]
    [InlineData(1000.0, PrefixType.Giga, PrefixType.Mega, 0, 1.0)]
    [InlineData(1000000.0, PrefixType.Giga, PrefixType.Kilo, 0, 1.0)]
    [InlineData(1000000000.0, PrefixType.Giga, PrefixType.None, 0, 1.0)]
    [InlineData(1000.0, PrefixType.Tera, PrefixType.Giga, 0, 1.0)]
    [InlineData(1000000000.0, PrefixType.Tera, PrefixType.Kilo, 0, 1.0)]
    [InlineData(100.0, PrefixType.Hecto, PrefixType.None, 0, 1.0)]
    [InlineData(10.0, PrefixType.Deca, PrefixType.None, 0, 1.0)]
    [InlineData(1000.0, PrefixType.Hecto, PrefixType.Deci, 0, 1.0)]
    [InlineData(1.0, PrefixType.Deci, PrefixType.None, 0, 10.0)]
    [InlineData(10.0, PrefixType.Deci, PrefixType.Centi, 0, 1.0)]
    [InlineData(1.0, PrefixType.Deci, PrefixType.Deci, 0, 1.0)]
    [InlineData(1.0, PrefixType.Micro, PrefixType.Milli, 0, 1000.0)]
    [InlineData(1.0, PrefixType.Nano, PrefixType.Micro, 0, 1000.0)]
    [InlineData(1.0, PrefixType.Pico, PrefixType.Nano, 0, 1000.0)]
    [InlineData(1.0, PrefixType.None, PrefixType.Kilo, 0, 1000.0)]
    [InlineData(1.0, PrefixType.None, PrefixType.Mega, 0, 1000000.0)]
    [InlineData(1.0, PrefixType.None, PrefixType.Deca, 0, 10.0)]
    [InlineData(1.0, PrefixType.None, PrefixType.Hecto, 0, 100.0)]
    [InlineData(1000000.0, PrefixType.None, PrefixType.Micro, 0, 1.0)]
    [InlineData(1000000000.0, PrefixType.None, PrefixType.Nano, 0, 1.0)]
    public void Convert(
        double expected,
        PrefixType prefixTypeFrom,
        PrefixType prefixTypeTo,
        int numberOfDecimals,
        double value)
        => Assert.Equal(expected, InternationalSystemOfUnitsHelper.Convert(prefixTypeFrom, prefixTypeTo, numberOfDecimals, value));
}