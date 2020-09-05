using System;
using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal class TestMemberDataForDateTimeExtensions
    {
        public static IEnumerable<object[]> GetPrettyTimeDiff()
        {
            DateTime unitTestEnd = DateTime.Now;

            List<object[]> list = new List<object[]>
            {
                new object[] { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15) },
                new object[] { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15) },
                new object[] { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15) },
                new object[] { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15) },
                new object[] { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15) },
            };

            return list;
        }

        public static IEnumerable<object[]> GetPrettyTimeDiffWithDecimalPrecision()
        {
            DateTime unitTestEnd = DateTime.Now;

            List<object[]> list = new List<object[]>
            {
                new object[] { "11,5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1 },
                new object[] { "12,2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 1 },
                new object[] { "13,2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1 },
                new object[] { "14,0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 1 },
                new object[] { "15,0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 1 },
                new object[] { "11,51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2 },
                new object[] { "12,21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 2 },
                new object[] { "13,23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2 },
                new object[] { "14,02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 2 },
                new object[] { "15,00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 2 },
                new object[] { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3 },
                new object[] { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 3 },
                new object[] { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3 },
                new object[] { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 3 },
                new object[] { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 3 },
            };

            return list;
        }

        public static IEnumerable<object[]> GetPrettyTimeDiffWithEnd()
        {
            DateTime unitTestEnd = DateTime.Now;

            List<object[]> list = new List<object[]>
            {
                new object[] { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
                new object[] { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd },
                new object[] { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
                new object[] { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd },
                new object[] { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd },
            };

            return list;
        }

        public static IEnumerable<object[]> GetPrettyTimeDiffWithEndNowAndDecimalPrecision()
        {
            DateTime unitTestEnd = DateTime.Now;

            List<object[]> list = new List<object[]>
            {
                new object[] { "11,5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
                new object[] { "12,2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 1 },
                new object[] { "13,2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
                new object[] { "14,0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1 },
                new object[] { "15,0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 1 },
                new object[] { "11,51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
                new object[] { "12,21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 2 },
                new object[] { "13,23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
                new object[] { "14,02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2 },
                new object[] { "15,00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 2 },
                new object[] { "11,509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
                new object[] { "12,213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 3 },
                new object[] { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
                new object[] { "14,015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3 },
                new object[] { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 3 },
            };

            return list;
        }
    }
}