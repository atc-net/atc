// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForEnumTranslation
{
    public static TheoryData<BooleanOperatorType, int, List<KeyValuePair<int, string>>> BooleanOperatorTypeData
        => new TheoryData<BooleanOperatorType, int, List<KeyValuePair<int, string>>>
        {
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "And"),
                    new KeyValuePair<int, string>(2, "Or"),
                    new KeyValuePair<int, string>(3, "Not"),
                    new KeyValuePair<int, string>(4, "Near"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "And"),
                    new KeyValuePair<int, string>(2, "Or"),
                    new KeyValuePair<int, string>(3, "Not"),
                    new KeyValuePair<int, string>(4, "Near"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Og"),
                    new KeyValuePair<int, string>(2, "Eller"),
                    new KeyValuePair<int, string>(3, "Ikke"),
                    new KeyValuePair<int, string>(4, "Tæt"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Und"),
                    new KeyValuePair<int, string>(2, "Oder"),
                    new KeyValuePair<int, string>(3, "Nicht"),
                    new KeyValuePair<int, string>(4, "Nah"),
                }
            },
        };

    public static TheoryData<CollectionActionType, int, List<KeyValuePair<int, string>>> CollectionActionTypeData
        => new TheoryData<CollectionActionType, int, List<KeyValuePair<int, string>>>
        {
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
                }
            },
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
                }
            },
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
                }
            },
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
                }
            },
        };

    public static TheoryData<DateTimeDiffCompareType, int, List<KeyValuePair<int, string>>> DateTimeDiffCompareTypeData
        => new TheoryData<DateTimeDiffCompareType, int, List<KeyValuePair<int, string>>>
        {
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
                }
            },
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
                }
            },
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
                }
            },
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
                }
            },
        };

    public static TheoryData<DropDownFirstItemType, int, List<KeyValuePair<int, string>>> DropDownFirstItemTypeData
        => new TheoryData<DropDownFirstItemType, int, List<KeyValuePair<int, string>>>
        {
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(-1, "None"),
                    new KeyValuePair<int, string>(-2, "Blank"),
                    new KeyValuePair<int, string>(-3, "-- Select --"),
                    new KeyValuePair<int, string>(-4, "-- All --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(-1, "None"),
                    new KeyValuePair<int, string>(-2, "Blank"),
                    new KeyValuePair<int, string>(-3, "-- Select --"),
                    new KeyValuePair<int, string>(-4, "-- All --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(-1, "None"),
                    new KeyValuePair<int, string>(-2, "Blank"),
                    new KeyValuePair<int, string>(-3, "-- Vælg --"),
                    new KeyValuePair<int, string>(-4, "-- Alle --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(-1, "None"),
                    new KeyValuePair<int, string>(-2, "Blank"),
                    new KeyValuePair<int, string>(-3, "-- Wählen --"),
                    new KeyValuePair<int, string>(-4, "-- Alles --"),
                }
            },
        };

    public static TheoryData<FileSystemWatcherChangeType, int, List<KeyValuePair<int, string>>> FileSystemWatcherChangeTypeData
        => new TheoryData<FileSystemWatcherChangeType, int, List<KeyValuePair<int, string>>>
        {
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
                }
            },
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
                }
            },
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
                }
            },
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
                }
            },
        };

    public static TheoryData<ForwardReverseType, int, List<KeyValuePair<int, string>>> ForwardReverseTypeData
        => new TheoryData<ForwardReverseType, int, List<KeyValuePair<int, string>>>
        {
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Forward"),
                    new KeyValuePair<int, string>(2, "Reverse"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Forward"),
                    new KeyValuePair<int, string>(2, "Reverse"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Fremad"),
                    new KeyValuePair<int, string>(2, "Tilbage"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Vorwärts"),
                    new KeyValuePair<int, string>(2, "Rückwärts"),
                }
            },
        };

    public static TheoryData<IdentityRoleType, int, List<KeyValuePair<int, string>>> IdentityRoleTypeData
        => new TheoryData<IdentityRoleType, int, List<KeyValuePair<int, string>>>
        {
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
                }
            },
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
                }
            },
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
                }
            },
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
                }
            },
        };

    public static TheoryData<InsertRemoveType, int, List<KeyValuePair<int, string>>> InsertRemoveTypeData
        => new TheoryData<InsertRemoveType, int, List<KeyValuePair<int, string>>>
        {
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Insert"),
                    new KeyValuePair<int, string>(2, "Remove"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Insert"),
                    new KeyValuePair<int, string>(2, "Remove"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Indsæt"),
                    new KeyValuePair<int, string>(2, "Fjern"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Legen"),
                    new KeyValuePair<int, string>(2, "Entfernen"),
                }
            },
        };

    public static TheoryData<LeftRightType, int, List<KeyValuePair<int, string>>> LeftRightTypeData
        => new TheoryData<LeftRightType, int, List<KeyValuePair<int, string>>>
        {
            {
                LeftRightType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Left"),
                    new KeyValuePair<int, string>(2, "Right"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Left"),
                    new KeyValuePair<int, string>(2, "Right"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Venstre"),
                    new KeyValuePair<int, string>(2, "Højre"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Links"),
                    new KeyValuePair<int, string>(2, "Rechts"),
                }
            },
        };

    public static TheoryData<LogCategoryType, int, List<KeyValuePair<int, string>>> LogCategoryTypeData
        => new TheoryData<LogCategoryType, int, List<KeyValuePair<int, string>>>
        {
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
                }
            },
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
                }
            },
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
                }
            },
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
                }
            },
        };

    public static TheoryData<OnOffType, int, List<KeyValuePair<int, string>>> OnOffTypeData
        => new TheoryData<OnOffType, int, List<KeyValuePair<int, string>>>
        {
            {
                OnOffType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Off"),
                    new KeyValuePair<int, string>(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Off"),
                    new KeyValuePair<int, string>(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Off"),
                    new KeyValuePair<int, string>(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Off"),
                    new KeyValuePair<int, string>(2, "On"),
                }
            },
        };

    public static TheoryData<SortDirectionType, int, List<KeyValuePair<int, string>>> SortDirectionTypeData
        => new TheoryData<SortDirectionType, int, List<KeyValuePair<int, string>>>
        {
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Ascending"),
                    new KeyValuePair<int, string>(2, "Descending"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Ascending"),
                    new KeyValuePair<int, string>(2, "Descending"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Stigende"),
                    new KeyValuePair<int, string>(2, "Faldende"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Aufsteigend"),
                    new KeyValuePair<int, string>(2, "Absteigend"),
                }
            },
        };

    public static TheoryData<TriggerActionType, int, List<KeyValuePair<int, string>>> TriggerActionTypeData
        => new TheoryData<TriggerActionType, int, List<KeyValuePair<int, string>>>
        {
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Insert"),
                    new KeyValuePair<int, string>(2, "Update"),
                    new KeyValuePair<int, string>(3, "Delete"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Insert"),
                    new KeyValuePair<int, string>(2, "Update"),
                    new KeyValuePair<int, string>(3, "Delete"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Indsæt"),
                    new KeyValuePair<int, string>(2, "Opdatering"),
                    new KeyValuePair<int, string>(3, "Slette"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Einfügen"),
                    new KeyValuePair<int, string>(2, "Aktualisieren"),
                    new KeyValuePair<int, string>(3, "Löschen"),
                }
            },
        };

    public static TheoryData<UpDownType, int, List<KeyValuePair<int, string>>> UpDownTypeData
        => new TheoryData<UpDownType, int, List<KeyValuePair<int, string>>>
        {
            {
                UpDownType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Up"),
                    new KeyValuePair<int, string>(2, "Down"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Up"),
                    new KeyValuePair<int, string>(2, "Down"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Op"),
                    new KeyValuePair<int, string>(2, "Ned"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Nach oben"),
                    new KeyValuePair<int, string>(2, "Nach unten"),
                }
            },
        };

    public static TheoryData<YesNoType, int, List<KeyValuePair<int, string>>> YesNoTypeData
        => new TheoryData<YesNoType, int, List<KeyValuePair<int, string>>>
        {
            {
                YesNoType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "No"),
                    new KeyValuePair<int, string>(2, "Yes"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "No"),
                    new KeyValuePair<int, string>(2, "Yes"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Nej"),
                    new KeyValuePair<int, string>(2, "Ja"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Keine"),
                    new KeyValuePair<int, string>(2, "Ja"),
                }
            },
        };
}