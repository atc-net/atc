using System;
using System.Threading;
using Atc.Enums;
using Atc.Extensions.BaseTypes;
using Atc.Tests.XUnitTestData;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class DateTimeExtensionsTests
    {
        [Theory]
        [InlineData(true, 2019, 10, 5, 15)]
        [InlineData(true, 2019, 10, 10, 15)]
        [InlineData(true, 2019, 10, 5, 10)]
        [InlineData(false, 2019, 10, 15, 25)]
        public void IsBetween(bool expected, int year, int inputSeconds, int secondsA, int secondsB)
        {
            // Arrange
            var input = new DateTime(year, 1, 1, 0, 0, inputSeconds);
            var inputA = new DateTime(year, 1, 1, 0, 0, secondsA);
            var inputB = new DateTime(year, 1, 1, 0, 0, secondsB);

            // Act
            var actual = input.IsBetween(inputA, inputB);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiff), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
        public void GetPrettyTimeDiff(string expected, DateTime start)
        {
            // Act
            var actual = start.GetPrettyTimeDiff();

            // Assert - A kind of a dummy test, because of timing issues
            Assert.NotNull(expected);
            Assert.NotNull(actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithDecimalPrecision), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
        public void GetPrettyTimeDiff_DecimalPrecision(string expected, DateTime start, int decimalPrecision)
        {
            // Act
            var actual = start.GetPrettyTimeDiff(decimalPrecision);

            // Assert - A kind of a dummy test, because of timing issues
            Assert.NotNull(expected);
            Assert.NotNull(actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithEnd), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
        public void GetPrettyTimeDiff_EndNow(string expected, DateTime start, DateTime end)
        {
            // Arrange
            Thread.CurrentThread.CurrentUICulture = GlobalizationConstants.DanishCultureInfo;

            // Act
            var actual = start.GetPrettyTimeDiff(end);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithEndNowAndDecimalPrecision), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
        public void GetPrettyTimeDiff_EndNow_DecimalPrecision(string expected, DateTime start, DateTime end, int decimalPrecision)
        {
            // Arrange
            Thread.CurrentThread.CurrentUICulture = GlobalizationConstants.DanishCultureInfo;

            // Act
            var actual = start.GetPrettyTimeDiff(end, decimalPrecision);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1970, 1)]
        [InlineData(48, 2019, 12)]
        public void GetWeekNumber(int expected, int year, int month)
        {
            // Arrange
            var input = new DateTime(year, month, 1, 0, 0, 0);

            // Act
            var actual = input.GetWeekNumber();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10000, 10, DateTimeDiffCompareType.Milliseconds)]
        [InlineData(42000, 42, DateTimeDiffCompareType.Milliseconds)]
        public void DateTimeDiff(double expected, int seconds, DateTimeDiffCompareType dateTimeDiffCompareType)
        {
            // Arrange
            var inputA = new DateTime(1970, 1, 1, 0, 0, 0);
            var inputB = new DateTime(1970, 1, 1, 0, 0, seconds);

            // Act
            var actual = inputA.DateTimeDiff(inputB, dateTimeDiffCompareType);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1970-01-01T00:00:42", 1970, 42)]
        [InlineData("2019-01-01T00:00:42", 2019, 42)]
        public void ToIso8601Date(string expected, int year, int seconds)
        {
            // Arrange
            var input = new DateTime(year, 1, 1, 0, 0, seconds);

            // Act
            var actual = input.ToIso8601Date();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1969-12-31T23:00:42", 1970, 0, 42)]
        [InlineData("1970-01-01T01:00:42", 1970, 2, 42)]
        [InlineData("2018-12-31T23:00:42", 2019, 0, 42)]
        public void ToIso8601Utc(string expected, int year, int hour, int seconds)
        {
            // Arrange
            Thread.CurrentThread.CurrentCulture = GlobalizationConstants.EnglishCultureInfo;

            var input = new DateTime(year, 1, 1, hour, 0, seconds);

            // Act
            var actual = input.ToIso8601UtcDate();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}