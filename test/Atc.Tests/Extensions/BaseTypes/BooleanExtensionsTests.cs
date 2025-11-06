namespace Atc.Tests.Extensions.BaseTypes;

public class BooleanExtensionsTests
{
    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(false, null)]
    public void HasValueAndTrue(
        bool expected,
        bool? source)
    {
        // Act
        var actual = source.HasValueAndTrue();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, null)]
    public void HasValueAndFalse(
        bool expected,
        bool? source)
    {
        // Act
        var actual = source.HasValueAndFalse();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, null)]
    public void HasNoValue(
        bool expected,
        bool? source)
    {
        // Act
        var actual = source.HasNoValue();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, true)]
    [InlineData(true, null)]
    public void HasNoValueOrTrue(
        bool expected,
        bool? source)
    {
        // Act
        var actual = source.HasNoValueOrTrue();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, null)]
    public void HasNoValueOrFalse(
        bool expected,
        bool? source)
    {
        // Act
        var actual = source.HasNoValueOrFalse();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, true, true)]
    [InlineData(false, true, false)]
    [InlineData(false, false, true)]
    [InlineData(true, false, false)]
    public void IsEqual(
        bool expected,
        bool? a,
        bool? b)
    {
        // Act
        var actual = a.IsEqual(b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void ToInt(
        int expected,
        bool input)
    {
        // Act
        var actual = input.ToInt();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, null)]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void ToInt_Nullable(
        int expected,
        bool? input)
    {
        // Act
        var actual = input.ToInt();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Yes", true)]
    [InlineData("No", false)]
    public void ToYesNoString(
        string expected,
        bool source)
    {
        // Act
        var actual = source.ToYesNoString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(YesNoType.Yes, true)]
    [InlineData(YesNoType.No, false)]
    public void ToYesNoType(
        YesNoType expected,
        bool source)
    {
        // Act
        var actual = source.ToYesNoType();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(YesNoType.Yes, true)]
    [InlineData(YesNoType.No, false)]
    [InlineData(YesNoType.None, null)]
    public void ToYesNoTypeForNullable(
        YesNoType expected,
        bool? source)
    {
        // Act
        var actual = source.ToYesNoType();

        // Assert
        Assert.Equal(expected, actual);
    }
}