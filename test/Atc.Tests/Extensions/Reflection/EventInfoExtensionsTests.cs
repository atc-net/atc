namespace Atc.Tests.Extensions.Reflection;

public class EventInfoExtensionsTests
{
    [Fact]
    public void BeautifyName_ReturnsEventName()
    {
        var eventInfo = typeof(AppDomain).GetEvent(nameof(AppDomain.UnhandledException))!;
        Assert.Equal("UnhandledException", eventInfo.BeautifyName());
    }

    [Fact]
    public void BeautifyName_WithHandlerType_IncludesType()
    {
        var eventInfo = typeof(AppDomain).GetEvent(nameof(AppDomain.UnhandledException))!;
        var result = eventInfo.BeautifyName(includeEventHandlerType: true);
        Assert.Contains("UnhandledException", result, StringComparison.Ordinal);
        Assert.Contains("UnhandledExceptionEventHandler", result, StringComparison.Ordinal);
    }

    [Fact]
    public void BeautifyName_Null_Throws()
        => Assert.Throws<ArgumentNullException>(() =>
            ((EventInfo)null!).BeautifyName());
}