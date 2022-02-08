namespace Atc.Tests;

public class EnumTranslationTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForEnumTranslation.BooleanOperatorTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.CollectionActionTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.DateTimeDiffCompareTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.DropDownFirstItemTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.FileSystemWatcherChangeTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.ForwardReverseTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.IdentityRoleTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.InsertRemoveTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.LeftRightTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.LogCategoryTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.OnOffTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.SortDirectionTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.TriggerActionTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.UpDownTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    [MemberData(nameof(TestMemberDataForEnumTranslation.YesNoTypeData), MemberType = typeof(TestMemberDataForEnumTranslation))]
    public void ToDictionary<T>(T dummyForT, int arrangeUiLcid, List<KeyValuePair<int, string>> expectedKeyValues)
        where T : System.Enum
    {
        object dummyAssignment = dummyForT;

        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);
        var type = dummyAssignment.GetType();
        var includeDefault =
            type == typeof(DateTimeDiffCompareType) ||
            type == typeof(LogCategoryType);

        // Act
        var actual = Enum<T>.ToDictionary(DropDownFirstItemType.None, useDescriptionAttribute: true, includeDefault: includeDefault);

        // Assert
        actual.Should()
            .NotBeNull()
            .And.HaveCount(expectedKeyValues.Count)
            .And.Contain(expectedKeyValues);
    }
}