namespace Atc.Tests.Helpers;

[SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "OK.")]
[SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
public class NumberHelperTests
{
    public NumberHelperTests()
    {
        Thread.CurrentThread.CurrentCulture = GlobalizationConstants.EnglishCultureInfo;
        Thread.CurrentThread.CurrentUICulture = GlobalizationConstants.DanishCultureInfo;
    }

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "123,45")]
    [InlineData(false, "-123,45")]
    [InlineData(false, "abc")]
    public void IsNumber(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.IsNumber(value));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void IsNumber_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.IsNumber(value, useUiCulture));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]

    public void IsNumber_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.IsNumber(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(true, "123")]
    [InlineData(true, "-123")]
    [InlineData(false, "abc")]
    public void IsInt(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.IsInt(value));

    [Theory]
    [InlineData(123, "123")]
    [InlineData(-123, "-123")]
    [InlineData(-1, "abc")]
    public void ParseToInt(int expected, string value)
        => Assert.Equal(expected, NumberHelper.ParseToInt(value));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void IsDecimal(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.IsDecimal(value));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void IsDecimal_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.IsDecimal(value, useUiCulture));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void IsDecimal_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.IsDecimal(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(123.45, "123.45")]
    [InlineData(-123.45, "-123.45")]
    [InlineData(-1, "abc")]
    public void ParseToDecimal(decimal expected, string value)
        => Assert.Equal(expected, NumberHelper.ParseToDecimal(value));

    [Theory]
    [InlineData(123.45, "123.45", false)]
    [InlineData(-123.45, "-123.45", false)]
    [InlineData(-1, "123.45", true)]
    [InlineData(-1, "-123.45", true)]
    [InlineData(-1, "123,45", false)]
    [InlineData(-1, "-123,45", false)]
    [InlineData(123.45, "123,45", true)]
    [InlineData(-123.45, "-123,45", true)]
    [InlineData(-1, "abc", false)]
    public void ParseToDecimal_UseUiCulture(decimal expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.ParseToDecimal(value, useUiCulture));

    [Theory]
    [InlineData(123.45, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-123.45, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(123.45, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-123.45, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void ParseToDecimal_CultureInfo(decimal expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.ParseToDecimal(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void TryParseToDecimal(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.TryParseToDecimal(value, out _));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void TryParseToDecimal_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.TryParseToDecimal(value, useUiCulture, out _));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void TryParseToDecimal_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.TryParseToDecimal(value, new CultureInfo(cultureInfoLcid), out _));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void IsDouble(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.IsDouble(value));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void IsDouble_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.IsDouble(value, useUiCulture));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void IsDouble_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.IsDouble(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(123.45, "123.45")]
    [InlineData(-123.45, "-123.45")]
    [InlineData(-1, "abc")]
    public void ParseToDouble(double expected, string value)
        => Assert.Equal(expected, NumberHelper.ParseToDouble(value));

    [Theory]
    [InlineData(123.45, "123.45", false)]
    [InlineData(-123.45, "-123.45", false)]
    [InlineData(-1, "123.45", true)]
    [InlineData(-1, "-123.45", true)]
    [InlineData(-1, "123,45", false)]
    [InlineData(-1, "-123,45", false)]
    [InlineData(123.45, "123,45", true)]
    [InlineData(-123.45, "-123,45", true)]
    [InlineData(-1, "abc", false)]
    public void ParseToDouble_UseUiCulture(double expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.ParseToDouble(value, useUiCulture));

    [Theory]
    [InlineData(123.45, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-123.45, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(123.45, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-123.45, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void ParseToDouble_CultureInfo(double expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.ParseToDouble(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void TryParseToDouble(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.TryParseToDouble(value, out _));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void TryParseToDouble_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.TryParseToDouble(value, useUiCulture, out _));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void TryParseToDouble_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.TryParseToDouble(value, new CultureInfo(cultureInfoLcid), out _));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void IsFloat(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.IsFloat(value));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void IsFloat_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.IsFloat(value, useUiCulture));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void IsFloat_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.IsFloat(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(123.45f, "123.45")]
    [InlineData(-123.45f, "-123.45")]
    [InlineData(-1f, "abc")]
    public void ParseToFloat(float expected, string value)
        => Assert.Equal(expected, NumberHelper.ParseToFloat(value));

    [Theory]
    [InlineData(123.45f, "123.45", false)]
    [InlineData(-123.45f, "-123.45", false)]
    [InlineData(-1f, "123.45", true)]
    [InlineData(-1f, "-123.45", true)]
    [InlineData(-1f, "123,45", false)]
    [InlineData(-1f, "-123,45", false)]
    [InlineData(123.45f, "123,45", true)]
    [InlineData(-123.45f, "-123,45", true)]
    [InlineData(-1f, "abc", false)]
    public void ParseToFloat_UseUiCulture(float expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.ParseToFloat(value, useUiCulture));

    [Theory]
    [InlineData(123.45f, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-123.45f, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1f, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1f, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1f, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(-1f, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(123.45f, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-123.45f, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(-1f, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void ParseToFloat_CultureInfo(float expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.ParseToFloat(value, new CultureInfo(cultureInfoLcid)));

    [Theory]
    [InlineData(true, "123.45")]
    [InlineData(true, "-123.45")]
    [InlineData(false, "abc")]
    public void TryParseToFloat(bool expected, string value)
        => Assert.Equal(expected, NumberHelper.TryParseToFloat(value, out _));

    [Theory]
    [InlineData(true, "123.45", false)]
    [InlineData(true, "-123.45", false)]
    [InlineData(false, "123.45", true)]
    [InlineData(false, "-123.45", true)]
    [InlineData(false, "123,45", false)]
    [InlineData(false, "-123,45", false)]
    [InlineData(true, "123,45", true)]
    [InlineData(true, "-123,45", true)]
    [InlineData(false, "abc", false)]
    public void TryParseToFloat_UseUiCulture(bool expected, string value, bool useUiCulture)
        => Assert.Equal(expected, NumberHelper.TryParseToFloat(value, useUiCulture, out _));

    [Theory]
    [InlineData(true, "123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "-123.45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "-123.45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(false, "-123,45", GlobalizationLcidConstants.UnitedStates)]
    [InlineData(true, "123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(true, "-123,45", GlobalizationLcidConstants.Denmark)]
    [InlineData(false, "abc", GlobalizationLcidConstants.UnitedStates)]
    public void TryParseToFloat_CultureInfo(bool expected, string value, int cultureInfoLcid)
        => Assert.Equal(expected, NumberHelper.TryParseToFloat(value, new CultureInfo(cultureInfoLcid), out _));
}