namespace Atc.Tests.Units.InternationalSystemOfUnits;

public class InternationalSystemOfUnitsHelperTests
{
    [Theory]
    [InlineData(0.0006, PrefixType.Centi, PrefixType.Kilo, 4, 57)]
    [InlineData(0.00057, PrefixType.Centi, PrefixType.Kilo, 10, 57)]
    public void Convert(double expected, PrefixType prefixTypeFrom, PrefixType prefixTypeTo, int numberOfDecimals, double value)
        => Assert.Equal(expected, InternationalSystemOfUnitsHelper.Convert(prefixTypeFrom, prefixTypeTo, numberOfDecimals, value));
}