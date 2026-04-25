namespace Atc.Tests.Extensions;

public class LogCategoryTypeExtensionsTests
{
    [Theory]
    [InlineData("CRT", LogCategoryType.Critical)]
    [InlineData("ERR", LogCategoryType.Error)]
    [InlineData("WRN", LogCategoryType.Warning)]
    [InlineData("SEC", LogCategoryType.Security)]
    [InlineData("AUD", LogCategoryType.Audit)]
    [InlineData("SVC", LogCategoryType.Service)]
    [InlineData("UI ", LogCategoryType.UI)]
    [InlineData("INF", LogCategoryType.Information)]
    [InlineData("DBG", LogCategoryType.Debug)]
    [InlineData("TRC", LogCategoryType.Trace)]
    public void ToShortName(
        string expected,
        LogCategoryType logCategoryType)
        => Assert.Equal(expected, logCategoryType.ToShortName());

    [Fact]
    public void ToShortName_Throws_WhenLogCategoryTypeIsOutOfRange()
    {
        // Arrange
        const LogCategoryType logCategoryType = (LogCategoryType)999;

        // Act & Assert
        Assert.Throws<SwitchCaseDefaultException>(() => logCategoryType.ToShortName());
    }

    [Theory]
    [InlineData("[CRT]", LogCategoryType.Critical)]
    [InlineData("[ERR]", LogCategoryType.Error)]
    [InlineData("[WRN]", LogCategoryType.Warning)]
    [InlineData("[SEC]", LogCategoryType.Security)]
    [InlineData("[AUD]", LogCategoryType.Audit)]
    [InlineData("[SVC]", LogCategoryType.Service)]
    [InlineData("[UI ]", LogCategoryType.UI)]
    [InlineData("[INF]", LogCategoryType.Information)]
    [InlineData("[DBG]", LogCategoryType.Debug)]
    [InlineData("[TRC]", LogCategoryType.Trace)]
    public void ToShortNameBracketed(
        string expected,
        LogCategoryType logCategoryType)
        => Assert.Equal(expected, logCategoryType.ToShortNameBracketed());

    [Fact]
    public void ToShortNameBracketed_Throws_WhenLogCategoryTypeIsOutOfRange()
    {
        // Arrange
        const LogCategoryType logCategoryType = (LogCategoryType)999;

        // Act & Assert
        Assert.Throws<SwitchCaseDefaultException>(() => logCategoryType.ToShortNameBracketed());
    }
}