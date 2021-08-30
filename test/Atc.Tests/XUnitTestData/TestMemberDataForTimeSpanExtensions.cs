using System;
using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForTimeSpanExtensions
    {
        public static IEnumerable<object[]> GetPrettyTime()
        {
            var list = new List<object[]>
            {
                new object[] { "11,509 days", new TimeSpan(11, 12, 13, 14, 15) },
                new object[] { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15) },
                new object[] { "13,234 min", new TimeSpan(0, 0, 13, 14, 15) },
                new object[] { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15) },
                new object[] { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15) },
            };

            return list;
        }

        public static IEnumerable<object[]> GetPrettyTimeWithDecimalPrecision()
        {
            var list = new List<object[]>
            {
                new object[] { "11,5 days", new TimeSpan(11, 12, 13, 14, 15), 1 },
                new object[] { "12,2 hours", new TimeSpan(0, 12, 13, 14, 15), 1 },
                new object[] { "13,2 min", new TimeSpan(0, 0, 13, 14, 15), 1 },
                new object[] { "14,0 sec", new TimeSpan(0, 0, 0, 14, 15), 1 },
                new object[] { "15,0 ms", new TimeSpan(0, 0, 0, 0, 15), 1 },
                new object[] { "11,51 days", new TimeSpan(11, 12, 13, 14, 15), 2 },
                new object[] { "12,21 hours", new TimeSpan(0, 12, 13, 14, 15), 2 },
                new object[] { "13,23 min", new TimeSpan(0, 0, 13, 14, 15), 2 },
                new object[] { "14,02 sec", new TimeSpan(0, 0, 0, 14, 15), 2 },
                new object[] { "15,00 ms", new TimeSpan(0, 0, 0, 0, 15), 2 },
                new object[] { "11,509 days", new TimeSpan(11, 12, 13, 14, 15), 3 },
                new object[] { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15), 3 },
                new object[] { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), 3 },
                new object[] { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), 3 },
                new object[] { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), 3 },
            };

            return list;
        }
    }
}