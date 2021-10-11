using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Atc.Tests.XUnitTestData
{
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1509:OpeningBracesMustNotBePrecededByBlankLine", Justification = "OK.")]
    internal static class TestMemberDataForEnum
    {
        public static TheoryData<DayOfWeek, int, DropDownFirstItemType, bool, bool, SortDirectionType, bool, bool> DayOfWeekData
            => new TheoryData<DayOfWeek, int, DropDownFirstItemType, bool, bool, SortDirectionType, bool, bool>
            {
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 6, DropDownFirstItemType.None, true, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, false, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 6, DropDownFirstItemType.None, false, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, true, false },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, false, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.None, true, true, SortDirectionType.None, false, false },

                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.Blank, true, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, false, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.Blank, false, false, SortDirectionType.None, true, true },

                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, true, false },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, false, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.Blank, true, true, SortDirectionType.None, false, false },

                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.PleaseSelect, true, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, false, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.PleaseSelect, false, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, true, false },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, false, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.PleaseSelect, true, true, SortDirectionType.None, false, false },

                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.IncludeAll, true, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, false, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 7, DropDownFirstItemType.IncludeAll, false, false, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, true, false },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, false, true },
                { DayOfWeek.Sunday, 8, DropDownFirstItemType.IncludeAll, true, true, SortDirectionType.None, false, false },
            };
    }
}