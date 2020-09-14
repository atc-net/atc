using System;
using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForEnum
    {
        public static IEnumerable<object[]> DayOfWeekData =>
            new List<object[]>
            {
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 6, DropDownFirstItemType.None, true, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, false, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 6, DropDownFirstItemType.None, false, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, false },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, false, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, false, false },

                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.Blank, true, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, false, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.Blank, false, false, SortDirectionType.None, true, true },

                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, false },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, false, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, false, false },

                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.PleaseSelect, true, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, false, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.PleaseSelect, false, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, false },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, false, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, false, false },

                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.IncludeAll, true, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, false, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 7, DropDownFirstItemType.IncludeAll, false, false, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, false },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, false, true },
                new object[] { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, false, false },
            };
    }
}