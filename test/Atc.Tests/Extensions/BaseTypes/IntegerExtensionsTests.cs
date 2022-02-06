namespace Atc.Tests.Extensions.BaseTypes;

public class IntegerExtensionsTests
{
    [Theory]
    [InlineData(true, 5, 5)]
    [InlineData(false, 5, 2)]
    [InlineData(false, 2, 5)]
    [InlineData(true, null, null)]
    public void IsEqual(bool expected, int? a, int? b)
    {
        // Act
        var actual = a.IsEqual(b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, -1)]
    [InlineData(true, 0)]
    [InlineData(false, 1)]
    [InlineData(true, 2)]
    [InlineData(true, 22)]
    [InlineData(false, 23)]
    public void IsEven(bool expected, int input)
    {
        // Act
        var actual = input.IsEven();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, -1)]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    [InlineData(false, 2)]
    [InlineData(false, 22)]
    [InlineData(true, 23)]
    public void IsOdd(bool expected, int input)
    {
        // Act
        var actual = input.IsOdd();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, -1)]
    [InlineData(false, 0)]
    [InlineData(false, 1)]
    [InlineData(true, 2)]
    [InlineData(true, 3)]
    [InlineData(false, 4)]
    [InlineData(true, 5)]
    [InlineData(false, 6)]
    [InlineData(true, 7)]
    [InlineData(false, 8)]
    [InlineData(false, 9)]
    [InlineData(false, 10)]
    [InlineData(true, 11)]
    public void IsPrime(bool expected, int input)
    {
        // Act
        var actual = input.IsPrime();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, -1)]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    [InlineData(true, 2)]
    [InlineData(false, 3)]
    [InlineData(true, 4)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    [InlineData(false, 7)]
    [InlineData(true, 8)]
    [InlineData(false, 9)]
    public void IsBinarySequence(bool expected, int input)
    {
        // Act
        var actual = input.IsBinarySequence();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForExtensionsInteger.MonthNameData), MemberType = typeof(TestMemberDataForExtensionsInteger))]
    public void GetMonthNameByMonthNumber(int arrangeUiLcid, string expected, int input, bool pascalCased)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = input.GetMonthNameByMonthNumber(pascalCased);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(52, 2019)]
    [InlineData(53, 2020)]
    [InlineData(52, 2021)]
    [InlineData(52, 2022)]
    public void GetNumberOfWeeksByYear(int expected, int input)
    {
        // Act
        var actual = input.GetNumberOfWeeksByYear();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2018, 12, 31, 2019, 1)]
    [InlineData(2019, 12, 30, 2020, 1)]
    [InlineData(2021, 1, 4, 2021, 1)]
    [InlineData(2022, 1, 3, 2022, 1)]
    public void GetFirstDayOfWeekNumberByYear(int expectedYear, int expectedMonth, int expectedDay, int input, int weekNumber)
    {
        // Assert
        var expectedDateTime = new DateTime(expectedYear, expectedMonth, expectedDay);

        // Act
        var actual = input.GetFirstDayOfWeekNumberByYear(weekNumber);

        // Assert
        Assert.Equal(expectedDateTime, actual);
    }

    [Theory]
    [InlineData(2019, 1, 6, 2019, 1)]
    [InlineData(2020, 1, 5, 2020, 1)]
    [InlineData(2021, 1, 10, 2021, 1)]
    [InlineData(2022, 1, 9, 2022, 1)]
    public void GetLastDayOfWeekNumberByYear(int expectedYear, int expectedMonth, int expectedDay, int input, int weekNumber)
    {
        // Assert
        var expectedDateTime = new DateTime(expectedYear, expectedMonth, expectedDay);

        // Act
        var actual = input.GetLastDayOfWeekNumberByYear(weekNumber);

        // Assert
        Assert.Equal(expectedDateTime, actual);
    }
}