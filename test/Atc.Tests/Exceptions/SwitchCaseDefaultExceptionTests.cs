namespace Atc.Tests.Exceptions;

public class SwitchCaseDefaultExceptionTests
{
    [Fact]
    public void Throw_WithEnumValue_ThrowsWithEnumDetails()
    {
        Enum enumValue = DayOfWeek.Monday;
        try
        {
            SwitchCaseDefaultException.Throw(enumValue);
        }
        catch (SwitchCaseDefaultException ex)
        {
            Assert.Contains("Monday", ex.Message, StringComparison.Ordinal);
            return;
        }

        Assert.Fail("Expected SwitchCaseDefaultException to be thrown.");
    }

    [Fact]
    public void Throw_WithObjectValue_ThrowsWithDetails()
    {
        object value = "unexpected-value";
        try
        {
            SwitchCaseDefaultException.Throw(value);
        }
        catch (SwitchCaseDefaultException ex)
        {
            Assert.Contains("unexpected-value", ex.Message, StringComparison.Ordinal);
            return;
        }

        Assert.Fail("Expected SwitchCaseDefaultException to be thrown.");
    }
}