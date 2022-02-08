namespace Atc.Tests.Units.InternationalSystemOfUnits;

public class PrefixTypeHelperTests
{
    [Theory]
    [InlineData("Y", PrefixType.Yotta)]
    [InlineData("Z", PrefixType.Zetta)]
    [InlineData("E", PrefixType.Exa)]
    [InlineData("P", PrefixType.Peta)]
    [InlineData("T", PrefixType.Tera)]
    [InlineData("G", PrefixType.Giga)]
    [InlineData("M", PrefixType.Mega)]
    [InlineData("k", PrefixType.Kilo)]
    [InlineData("h", PrefixType.Hecto)]
    [InlineData("da", PrefixType.Deca)]
    [InlineData("", PrefixType.None)]
    [InlineData("d", PrefixType.Deci)]
    [InlineData("c", PrefixType.Centi)]
    [InlineData("m", PrefixType.Milli)]
    [InlineData("µ", PrefixType.Micro)]
    [InlineData("n", PrefixType.Nano)]
    [InlineData("p", PrefixType.Pico)]
    [InlineData("f", PrefixType.Femto)]
    [InlineData("a", PrefixType.Atto)]
    [InlineData("z", PrefixType.Zepto)]
    [InlineData("y", PrefixType.Yocto)]
    public void GetSymbol(string expected, PrefixType input)
    {
        // Act
        var actual = PrefixTypeHelper.GetSymbol(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Ym", PrefixType.Yotta)]
    [InlineData("Zm", PrefixType.Zetta)]
    [InlineData("Em", PrefixType.Exa)]
    [InlineData("Pm", PrefixType.Peta)]
    [InlineData("Tm", PrefixType.Tera)]
    [InlineData("Gm", PrefixType.Giga)]
    [InlineData("Mm", PrefixType.Mega)]
    [InlineData("km", PrefixType.Kilo)]
    [InlineData("hm", PrefixType.Hecto)]
    [InlineData("dam", PrefixType.Deca)]
    [InlineData("m", PrefixType.None)]
    [InlineData("dm", PrefixType.Deci)]
    [InlineData("cm", PrefixType.Centi)]
    [InlineData("mm", PrefixType.Milli)]
    [InlineData("µm", PrefixType.Micro)]
    [InlineData("nm", PrefixType.Nano)]
    [InlineData("pm", PrefixType.Pico)]
    [InlineData("fm", PrefixType.Femto)]
    [InlineData("am", PrefixType.Atto)]
    [InlineData("zm", PrefixType.Zepto)]
    [InlineData("ym", PrefixType.Yocto)]
    public void GetSymbolForMeter(string expected, PrefixType input)
    {
        // Act
        var actual = PrefixTypeHelper.GetSymbolForMeter(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}