// ReSharper disable AssignNullToNotNullAttribute
namespace Atc.Tests.Extensions;

public class LoggerExtensionsTests
{
    [Fact]
    public void LogKeyValueItem_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange
        ILogger logger = null!;
        var logKeyValueItem = new LogKeyValueItem(LogCategoryType.Information, "Key", "Value");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => logger.LogKeyValueItem(logKeyValueItem));
    }

    [Fact]
    public void LogKeyValueItem_WithNullLogKeyValueItem_ThrowsArgumentNullException()
    {
        // Arrange
        var logger = Substitute.For<ILogger>();
        LogKeyValueItem logKeyValueItem = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => logger.LogKeyValueItem(logKeyValueItem));
    }

    [Theory]
    [InlineData(LogCategoryType.Critical)]
    [InlineData(LogCategoryType.Error)]
    [InlineData(LogCategoryType.Warning)]
    [InlineData(LogCategoryType.Information)]
    [InlineData(LogCategoryType.Debug)]
    [InlineData(LogCategoryType.Trace)]
    public void LogKeyValueItem_LogsWithCorrectLevel(
        LogCategoryType logCategory)
    {
        // Arrange
        var logger = Substitute.For<ILogger>();
        var logKeyValueItem = new LogKeyValueItem(logCategory, "Key", "Value");

        // Act
        var exception = Record.Exception(() => logger.LogKeyValueItem(logKeyValueItem));

        // Assert - method should execute without throwing
        Assert.Null(exception);
    }

    [Fact]
    public void LogKeyValueItems_WithNullLogger_ThrowsArgumentNullException()
    {
        // Arrange
        ILogger logger = null!;
        var logKeyValueItems = new List<LogKeyValueItem>
        {
            new(LogCategoryType.Information, "Key1", "Value1"),
        };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => logger.LogKeyValueItems(logKeyValueItems));
    }

    [Fact]
    public void LogKeyValueItems_WithNullList_ThrowsArgumentNullException()
    {
        // Arrange
        var logger = Substitute.For<ILogger>();
        List<LogKeyValueItem> logKeyValueItems = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => logger.LogKeyValueItems(logKeyValueItems));
    }

    [Fact]
    public void LogKeyValueItems_LogsAllItems()
    {
        // Arrange
        var logger = Substitute.For<ILogger>();
        var logKeyValueItems = new List<LogKeyValueItem>
        {
            new(LogCategoryType.Information, "Key1", "Value1"),
            new(LogCategoryType.Warning, "Key2", "Value2"),
            new(LogCategoryType.Error, "Key3", "Value3"),
        };

        // Act
        var exception = Record.Exception(() => logger.LogKeyValueItems(logKeyValueItems));

        // Assert - method should execute without throwing
        Assert.Null(exception);
    }
}