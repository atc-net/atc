namespace Atc.Tests.Helpers;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class InternetBrowserHelperTests
{
    [Fact(Skip = "Because it opens a webpage in a browser")]
    [SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "OK.")]
    public void OpenUrl()
    {
        Assert.True(InternetBrowserHelper.OpenUrl("http://dr.dk"));
    }

    [Fact(Skip = "Because it opens a webpage in a browser")]
    public void OpenUri()
    {
        Assert.True(InternetBrowserHelper.OpenUrl(new Uri("http://dr.dk")));
    }
}