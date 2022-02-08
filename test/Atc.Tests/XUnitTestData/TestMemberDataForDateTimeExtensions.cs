namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForDateTimeExtensions
{
    public static TheoryData<string, DateTime> GetPrettyTimeDiff()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime>
        {
            { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15) },
            { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15) },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15) },
            { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15) },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15) },
        };
    }

    public static TheoryData<string, DateTime, int> GetPrettyTimeDiffWithDecimalPrecision()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, int>
        {
            { "11,5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1 },
            { "12,2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 1 },
            { "13,2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1 },
            { "14,0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 1 },
            { "15,0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 1 },
            { "11,51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2 },
            { "12,21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 2 },
            { "13,23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2 },
            { "14,02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 2 },
            { "15,00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 2 },
            { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3 },
            { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 3 },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3 },
            { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 3 },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 3 },
        };
    }

    public static TheoryData<string, DateTime, DateTime> GetPrettyTimeDiffWithEnd()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, DateTime>
        {
            { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
            { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
            { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd },
        };
    }

    public static TheoryData<string, DateTime, DateTime, int> GetPrettyTimeDiffWithEndNowAndDecimalPrecision()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, DateTime, int>
        {
            { "11,5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
            { "12,2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 1 },
            { "13,2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
            { "14,0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
            { "15,0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 1 },
            { "11,51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
            { "12,21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 2 },
            { "13,23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
            { "14,02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
            { "15,00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 2 },
            { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
            { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 3 },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
            { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 3 },
        };
    }
}