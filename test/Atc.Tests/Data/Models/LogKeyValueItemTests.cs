namespace Atc.Tests.Data.Models;

public class LogKeyValueItemTests
{
    [Theory]
    [InlineData("MyKey: MyValue", LogCategoryType.Audit, "MyKey", "MyValue", null, true, true)]
    [InlineData("MyKey: MyValue", LogCategoryType.Audit, "MyKey", "MyValue", null, true, false)]
    [InlineData("MyValue", LogCategoryType.Audit, "MyKey", "MyValue", null, false, true)]
    [InlineData("MyValue", LogCategoryType.Audit, "MyKey", "MyValue", null, false, false)]
    [InlineData("MyKey: MyValue - MyDescription", LogCategoryType.Audit, "MyKey", "MyValue", "MyDescription", true, true)]
    [InlineData("MyKey: MyValue", LogCategoryType.Audit, "MyKey", "MyValue", "MyDescription", true, false)]
    [InlineData("MyValue - MyDescription", LogCategoryType.Audit, "MyKey", "MyValue", "MyDescription", false, true)]
    [InlineData("MyValue", LogCategoryType.Audit, "MyKey", "MyValue", "MyDescription", false, false)]
    public void GetLogMessage(
        string expected,
        LogCategoryType logCategory,
        string key,
        string value,
        string? description,
        bool includeKey,
        bool includeDescription)
    {
        // Arrange
        var sut = description is null
            ? new LogKeyValueItem(logCategory, key, value)
            : new LogKeyValueItem(logCategory, key, value, description);

        // Act
        var actual = sut.GetLogMessage(includeKey, includeDescription);

        // Assert
        Assert.Equal(expected, actual);
    }
}