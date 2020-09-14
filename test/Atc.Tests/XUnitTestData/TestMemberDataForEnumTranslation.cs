using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForEnumTranslation
    {
        public static IEnumerable<object[]> BooleanOperatorTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    BooleanOperatorType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "And"),
                        new KeyValuePair<int, string>(2, "Or"),
                        new KeyValuePair<int, string>(3, "Not"),
                        new KeyValuePair<int, string>(4, "Near"),
                    },
                },
                new object[]
                {
                    BooleanOperatorType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "And"),
                        new KeyValuePair<int, string>(2, "Or"),
                        new KeyValuePair<int, string>(3, "Not"),
                        new KeyValuePair<int, string>(4, "Near"),
                    },
                },
                new object[]
                {
                    BooleanOperatorType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Og"),
                        new KeyValuePair<int, string>(2, "Eller"),
                        new KeyValuePair<int, string>(3, "Ikke"),
                        new KeyValuePair<int, string>(4, "Tæt"),
                    },
                },
                new object[]
                {
                    BooleanOperatorType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Und"),
                        new KeyValuePair<int, string>(2, "Oder"),
                        new KeyValuePair<int, string>(3, "Nicht"),
                        new KeyValuePair<int, string>(4, "Nah"),
                    },
                },
            };

        public static IEnumerable<object[]> CollectionActionTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    CollectionActionType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Added"),
                        new KeyValuePair<int, string>(2, "Updated"),
                        new KeyValuePair<int, string>(3, "Removed"),
                        new KeyValuePair<int, string>(4, "Cleared"),
                        new KeyValuePair<int, string>(5, "Saved"),
                        new KeyValuePair<int, string>(6, "Loaded"),
                    },
                },
                new object[]
                {
                    CollectionActionType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Added"),
                        new KeyValuePair<int, string>(2, "Updated"),
                        new KeyValuePair<int, string>(3, "Removed"),
                        new KeyValuePair<int, string>(4, "Cleared"),
                        new KeyValuePair<int, string>(5, "Saved"),
                        new KeyValuePair<int, string>(6, "Loaded"),
                    },
                },
                new object[]
                {
                    CollectionActionType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Tilføjet"),
                        new KeyValuePair<int, string>(2, "Opdateret"),
                        new KeyValuePair<int, string>(3, "Fjernet"),
                        new KeyValuePair<int, string>(4, "Ryddet"),
                        new KeyValuePair<int, string>(5, "Gemt"),
                        new KeyValuePair<int, string>(6, "Indlæst"),
                    },
                },
                new object[]
                {
                    CollectionActionType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Hinzugefügt"),
                        new KeyValuePair<int, string>(2, "Aktualisiert"),
                        new KeyValuePair<int, string>(3, "Entfernt"),
                        new KeyValuePair<int, string>(4, "Geklärt"),
                        new KeyValuePair<int, string>(5, "Gespeichert"),
                        new KeyValuePair<int, string>(6, "Geladen"),
                    },
                },
            };

        public static IEnumerable<object[]> DateTimeDiffCompareTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    DateTimeDiffCompareType.Year,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Ticks"),
                        new KeyValuePair<int, string>(1, "Milliseconds"),
                        new KeyValuePair<int, string>(2, "Seconds"),
                        new KeyValuePair<int, string>(3, "Minutes"),
                        new KeyValuePair<int, string>(4, "Hours"),
                        new KeyValuePair<int, string>(5, "Days"),
                        new KeyValuePair<int, string>(6, "Year"),
                        new KeyValuePair<int, string>(7, "Quartal"),
                    },
                },
                new object[]
                {
                    DateTimeDiffCompareType.Year,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Ticks"),
                        new KeyValuePair<int, string>(1, "Milliseconds"),
                        new KeyValuePair<int, string>(2, "Seconds"),
                        new KeyValuePair<int, string>(3, "Minutes"),
                        new KeyValuePair<int, string>(4, "Hours"),
                        new KeyValuePair<int, string>(5, "Days"),
                        new KeyValuePair<int, string>(6, "Year"),
                        new KeyValuePair<int, string>(7, "Quartal"),
                    },
                },
                new object[]
                {
                    DateTimeDiffCompareType.Year,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Tidsmærke"),
                        new KeyValuePair<int, string>(1, "Millisekunder"),
                        new KeyValuePair<int, string>(2, "Sekunder"),
                        new KeyValuePair<int, string>(3, "Minutter"),
                        new KeyValuePair<int, string>(4, "Timer"),
                        new KeyValuePair<int, string>(5, "Dage"),
                        new KeyValuePair<int, string>(6, "År"),
                        new KeyValuePair<int, string>(7, "Quartal"),
                    },
                },
                new object[]
                {
                    DateTimeDiffCompareType.Year,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Ticks"),
                        new KeyValuePair<int, string>(1, "Millisekunden"),
                        new KeyValuePair<int, string>(2, "Sekunden"),
                        new KeyValuePair<int, string>(3, "Minuten"),
                        new KeyValuePair<int, string>(4, "Stunden"),
                        new KeyValuePair<int, string>(5, "Tage"),
                        new KeyValuePair<int, string>(6, "Jahr"),
                        new KeyValuePair<int, string>(7, "Quartal"),
                    },
                },
            };

        public static IEnumerable<object[]> DropDownFirstItemTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    DropDownFirstItemType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(-1, "None"),
                        new KeyValuePair<int, string>(-2, "Blank"),
                        new KeyValuePair<int, string>(-3, "-- Select --"),
                        new KeyValuePair<int, string>(-4, "-- All --"),
                    },
                },
                new object[]
                {
                    DropDownFirstItemType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(-1, "None"),
                        new KeyValuePair<int, string>(-2, "Blank"),
                        new KeyValuePair<int, string>(-3, "-- Select --"),
                        new KeyValuePair<int, string>(-4, "-- All --"),
                    },
                },
                new object[]
                {
                    DropDownFirstItemType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(-1, "None"),
                        new KeyValuePair<int, string>(-2, "Blank"),
                        new KeyValuePair<int, string>(-3, "-- Vælg --"),
                        new KeyValuePair<int, string>(-4, "-- Alle --"),
                    },
                },
                new object[]
                {
                    DropDownFirstItemType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(-1, "None"),
                        new KeyValuePair<int, string>(-2, "Blank"),
                        new KeyValuePair<int, string>(-3, "-- Wählen --"),
                        new KeyValuePair<int, string>(-4, "-- Alles --"),
                    },
                },
            };

        public static IEnumerable<object[]> FileSystemWatcherChangeTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    FileSystemWatcherChangeType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Added"),
                        new KeyValuePair<int, string>(2, "Deleted"),
                        new KeyValuePair<int, string>(4, "Renamed"),
                        new KeyValuePair<int, string>(8, "Changed"),
                        new KeyValuePair<int, string>(15, "All"),
                    },
                },
                new object[]
                {
                    FileSystemWatcherChangeType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Added"),
                        new KeyValuePair<int, string>(2, "Deleted"),
                        new KeyValuePair<int, string>(4, "Renamed"),
                        new KeyValuePair<int, string>(8, "Changed"),
                        new KeyValuePair<int, string>(15, "All"),
                    },
                },
                new object[]
                {
                    FileSystemWatcherChangeType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Tilføjet"),
                        new KeyValuePair<int, string>(2, "Slettet"),
                        new KeyValuePair<int, string>(4, "Omdøbt"),
                        new KeyValuePair<int, string>(8, "Ændret"),
                        new KeyValuePair<int, string>(15, "Alle"),
                    },
                },
                new object[]
                {
                    FileSystemWatcherChangeType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Hinzugefügt"),
                        new KeyValuePair<int, string>(2, "Gelöscht"),
                        new KeyValuePair<int, string>(4, "Umbenannt"),
                        new KeyValuePair<int, string>(8, "Geändert"),
                        new KeyValuePair<int, string>(15, "Alles"),
                    },
                },
            };

        public static IEnumerable<object[]> ForwardReverseTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    ForwardReverseType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Forward"),
                        new KeyValuePair<int, string>(2, "Reverse"),
                    },
                },
                new object[]
                {
                    ForwardReverseType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Forward"),
                        new KeyValuePair<int, string>(2, "Reverse"),
                    },
                },
                new object[]
                {
                    ForwardReverseType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Fremad"),
                        new KeyValuePair<int, string>(2, "Tilbage"),
                    },
                },
                new object[]
                {
                    ForwardReverseType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Vorwärts"),
                        new KeyValuePair<int, string>(2, "Rückwärts"),
                    },
                },
            };

        public static IEnumerable<object[]> IdentityRoleTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    IdentityRoleType.Anonymous,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Anonymous"),
                        new KeyValuePair<int, string>(2, "User"),
                        new KeyValuePair<int, string>(4, "Super User"),
                        new KeyValuePair<int, string>(8, "Administrator"),
                        new KeyValuePair<int, string>(16, "Super Administrator"),
                    },
                },
                new object[]
                {
                    IdentityRoleType.Anonymous,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Anonymous"),
                        new KeyValuePair<int, string>(2, "User"),
                        new KeyValuePair<int, string>(4, "Super User"),
                        new KeyValuePair<int, string>(8, "Administrator"),
                        new KeyValuePair<int, string>(16, "Super Administrator"),
                    },
                },
                new object[]
                {
                    IdentityRoleType.Anonymous,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Anonym"),
                        new KeyValuePair<int, string>(2, "Bruger"),
                        new KeyValuePair<int, string>(4, "Super Bruger"),
                        new KeyValuePair<int, string>(8, "Administrator"),
                        new KeyValuePair<int, string>(16, "Super Administrator"),
                    },
                },
                new object[]
                {
                    IdentityRoleType.Anonymous,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Anonym"),
                        new KeyValuePair<int, string>(2, "Benutzer"),
                        new KeyValuePair<int, string>(4, "Super Benutzer"),
                        new KeyValuePair<int, string>(8, "Administrator"),
                        new KeyValuePair<int, string>(16, "Super Administrator"),
                    },
                },
            };

        public static IEnumerable<object[]> InsertRemoveTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    InsertRemoveType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Insert"),
                        new KeyValuePair<int, string>(2, "Remove"),
                    },
                },
                new object[]
                {
                    InsertRemoveType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Insert"),
                        new KeyValuePair<int, string>(2, "Remove"),
                    },
                },
                new object[]
                {
                    InsertRemoveType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Indsæt"),
                        new KeyValuePair<int, string>(2, "Fjern"),
                    },
                },
                new object[]
                {
                    InsertRemoveType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Legen"),
                        new KeyValuePair<int, string>(2, "Entfernen"),
                    },
                },
            };

        public static IEnumerable<object[]> LeftRightTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    LeftRightType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Left"),
                        new KeyValuePair<int, string>(2, "Right"),
                    },
                },
                new object[]
                {
                    LeftRightType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Left"),
                        new KeyValuePair<int, string>(2, "Right"),
                    },
                },
                new object[]
                {
                    LeftRightType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Venstre"),
                        new KeyValuePair<int, string>(2, "Højre"),
                    },
                },
                new object[]
                {
                    LeftRightType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Links"),
                        new KeyValuePair<int, string>(2, "Rechts"),
                    },
                },
            };

        public static IEnumerable<object[]> LogCategoryTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    LogCategoryType.Critical,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Critical"),
                        new KeyValuePair<int, string>(1, "Error"),
                        new KeyValuePair<int, string>(2, "Warning"),
                        new KeyValuePair<int, string>(3, "Security"),
                        new KeyValuePair<int, string>(4, "Audit"),
                        new KeyValuePair<int, string>(5, "Service"),
                        new KeyValuePair<int, string>(6, "UI"),
                        new KeyValuePair<int, string>(7, "Information"),
                        new KeyValuePair<int, string>(8, "Debug"),
                        new KeyValuePair<int, string>(9, "Trace"),
                    },
                },
                new object[]
                {
                    LogCategoryType.Critical,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Critical"),
                        new KeyValuePair<int, string>(1, "Error"),
                        new KeyValuePair<int, string>(2, "Warning"),
                        new KeyValuePair<int, string>(3, "Security"),
                        new KeyValuePair<int, string>(4, "Audit"),
                        new KeyValuePair<int, string>(5, "Service"),
                        new KeyValuePair<int, string>(6, "UI"),
                        new KeyValuePair<int, string>(7, "Information"),
                        new KeyValuePair<int, string>(8, "Debug"),
                        new KeyValuePair<int, string>(9, "Trace"),
                    },
                },
                new object[]
                {
                    LogCategoryType.Critical,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Kritisk"),
                        new KeyValuePair<int, string>(1, "Fejl"),
                        new KeyValuePair<int, string>(2, "Advarsel"),
                        new KeyValuePair<int, string>(3, "Sikkerhed"),
                        new KeyValuePair<int, string>(4, "Revision"),
                        new KeyValuePair<int, string>(5, "Tjenesten"),
                        new KeyValuePair<int, string>(6, "UI"),
                        new KeyValuePair<int, string>(7, "Information"),
                        new KeyValuePair<int, string>(8, "Fejlsøg"),
                        new KeyValuePair<int, string>(9, "Trace"),
                    },
                },
                new object[]
                {
                    LogCategoryType.Critical,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(0, "Kritisch"),
                        new KeyValuePair<int, string>(1, "Fehler"),
                        new KeyValuePair<int, string>(2, "Warnung"),
                        new KeyValuePair<int, string>(3, "Sicherheit"),
                        new KeyValuePair<int, string>(4, "Prüfung"),
                        new KeyValuePair<int, string>(5, "Service"),
                        new KeyValuePair<int, string>(6, "UI"),
                        new KeyValuePair<int, string>(7, "Information"),
                        new KeyValuePair<int, string>(8, "Debuggen"),
                        new KeyValuePair<int, string>(9, "Spur"),
                    },
                },
            };

        public static IEnumerable<object[]> OnOffTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    OnOffType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Off"),
                        new KeyValuePair<int, string>(2, "On"),
                    },
                },
                new object[]
                {
                    OnOffType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Off"),
                        new KeyValuePair<int, string>(2, "On"),
                    },
                },
                new object[]
                {
                    OnOffType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Off"),
                        new KeyValuePair<int, string>(2, "On"),
                    },
                },
                new object[]
                {
                    OnOffType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Off"),
                        new KeyValuePair<int, string>(2, "On"),
                    },
                },
            };

        public static IEnumerable<object[]> SortDirectionTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    SortDirectionType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Ascending"),
                        new KeyValuePair<int, string>(2, "Descending"),
                    },
                },
                new object[]
                {
                    SortDirectionType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Ascending"),
                        new KeyValuePair<int, string>(2, "Descending"),
                    },
                },
                new object[]
                {
                    SortDirectionType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Stigende"),
                        new KeyValuePair<int, string>(2, "Faldende"),
                    },
                },
                new object[]
                {
                    SortDirectionType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Aufsteigend"),
                        new KeyValuePair<int, string>(2, "Absteigend"),
                    },
                },
            };

        public static IEnumerable<object[]> TriggerActionTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    TriggerActionType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Insert"),
                        new KeyValuePair<int, string>(2, "Update"),
                        new KeyValuePair<int, string>(3, "Delete"),
                    },
                },
                new object[]
                {
                    TriggerActionType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Insert"),
                        new KeyValuePair<int, string>(2, "Update"),
                        new KeyValuePair<int, string>(3, "Delete"),
                    },
                },
                new object[]
                {
                    TriggerActionType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Indsæt"),
                        new KeyValuePair<int, string>(2, "Opdatering"),
                        new KeyValuePair<int, string>(3, "Slette"),
                    },
                },
                new object[]
                {
                    TriggerActionType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Einfügen"),
                        new KeyValuePair<int, string>(2, "Aktualisieren"),
                        new KeyValuePair<int, string>(3, "Löschen"),
                    },
                },
            };

        public static IEnumerable<object[]> UpDownTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    UpDownType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Up"),
                        new KeyValuePair<int, string>(2, "Down"),
                    },
                },
                new object[]
                {
                    UpDownType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Up"),
                        new KeyValuePair<int, string>(2, "Down"),
                    },
                },
                new object[]
                {
                    UpDownType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Op"),
                        new KeyValuePair<int, string>(2, "Ned"),
                    },
                },
                new object[]
                {
                    UpDownType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Nach oben"),
                        new KeyValuePair<int, string>(2, "Nach unten"),
                    },
                },
            };

        public static IEnumerable<object[]> YesNoTypeData =>
            new List<object[]>
            {
                new object[]
                {
                    YesNoType.None,
                    GlobalizationLcidConstants.UnitedStates,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "No"),
                        new KeyValuePair<int, string>(2, "Yes"),
                    },
                },
                new object[]
                {
                    YesNoType.None,
                    GlobalizationLcidConstants.GreatBritain,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "No"),
                        new KeyValuePair<int, string>(2, "Yes"),
                    },
                },
                new object[]
                {
                    YesNoType.None,
                    GlobalizationLcidConstants.Denmark,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Nej"),
                        new KeyValuePair<int, string>(2, "Ja"),
                    },
                },
                new object[]
                {
                    YesNoType.None,
                    GlobalizationLcidConstants.Germany,
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Keine"),
                        new KeyValuePair<int, string>(2, "Ja"),
                    },
                },
            };
    }
}