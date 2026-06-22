namespace Atc.Tests.Exceptions;

public class ConfigurationExceptionTests
{
    [Fact]
    public void ThrowIfMissing_WithPresentValue_DoesNotThrow()
    {
        string value = "present-value";
        string section = "MySection";
        string key = "MyKey";
        ConfigurationException.ThrowIfMissing(value, section, key);
        Assert.NotEmpty(value);
    }

    [Fact]
    public void ThrowIfInvalid_WhenConditionFalse_DoesNotThrow()
    {
        bool condition = false;
        string section = "MySection";
        string key = "MyKey";
        ConfigurationException.ThrowIfInvalid(condition, section, key);
        Assert.False(condition);
    }
}