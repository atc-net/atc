using System;
using Xunit;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForTimeSpanExtensions
    {
        public static TheoryData<string, TimeSpan> GetPrettyTime()
            => new TheoryData<string, TimeSpan>
            {
                { "11,509 days", new TimeSpan(11, 12, 13, 14, 15) },
                { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15) },
                { "13,234 min", new TimeSpan(0, 0, 13, 14, 15) },
                { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15) },
                { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15) },
            };

        public static TheoryData<string, TimeSpan, int> GetPrettyTimeWithDecimalPrecision()
            => new TheoryData<string, TimeSpan, int>
            {
                { "11,5 days", new TimeSpan(11, 12, 13, 14, 15), 1 },
                { "12,2 hours", new TimeSpan(0, 12, 13, 14, 15), 1 },
                { "13,2 min", new TimeSpan(0, 0, 13, 14, 15), 1 },
                { "14,0 sec", new TimeSpan(0, 0, 0, 14, 15), 1 },
                { "15,0 ms", new TimeSpan(0, 0, 0, 0, 15), 1 },
                { "11,51 days", new TimeSpan(11, 12, 13, 14, 15), 2 },
                { "12,21 hours", new TimeSpan(0, 12, 13, 14, 15), 2 },
                { "13,23 min", new TimeSpan(0, 0, 13, 14, 15), 2 },
                { "14,02 sec", new TimeSpan(0, 0, 0, 14, 15), 2 },
                { "15,00 ms", new TimeSpan(0, 0, 0, 0, 15), 2 },
                { "11,509 days", new TimeSpan(11, 12, 13, 14, 15), 3 },
                { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15), 3 },
                { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), 3 },
                { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), 3 },
                { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), 3 },
            };
    }
}