namespace Atc.Tests.Data.Models;

public class LogItemTests
{
    [Fact]
    public void DefaultConstructor_TimeStamp_IsUtc()
    {
        // DateTime.Now captures local time (Kind=Local), which is DST-sensitive and
        // unsuitable for logs. Timestamps should always be UTC.
        var item = new LogItem();
        Assert.Equal(DateTimeKind.Utc, item.TimeStamp.Kind);
    }
}