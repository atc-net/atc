// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForEnumTranslation
{
    public static TheoryData<BooleanOperatorType, int, List<KeyValuePair<int, string>>> BooleanOperatorTypeData
        => new()
        {
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "And"),
                    new(2, "Or"),
                    new(3, "Not"),
                    new(4, "Near"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "And"),
                    new(2, "Or"),
                    new(3, "Not"),
                    new(4, "Near"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Og"),
                    new(2, "Eller"),
                    new(3, "Ikke"),
                    new(4, "Tæt"),
                }
            },
            {
                BooleanOperatorType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Und"),
                    new(2, "Oder"),
                    new(3, "Nicht"),
                    new(4, "Nah"),
                }
            },
        };

    public static TheoryData<CollectionActionType, int, List<KeyValuePair<int, string>>> CollectionActionTypeData
        => new()
        {
            {
                CollectionActionType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Added"),
                    new(2, "Updated"),
                    new(3, "Removed"),
                    new(4, "Cleared"),
                    new(5, "Saved"),
                    new(6, "Loaded"),
                }
            },
            {
                CollectionActionType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Added"),
                    new(2, "Updated"),
                    new(3, "Removed"),
                    new(4, "Cleared"),
                    new(5, "Saved"),
                    new(6, "Loaded"),
                }
            },
            {
                CollectionActionType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Tilføjet"),
                    new(2, "Opdateret"),
                    new(3, "Fjernet"),
                    new(4, "Ryddet"),
                    new(5, "Gemt"),
                    new(6, "Indlæst"),
                }
            },
            {
                CollectionActionType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Hinzugefügt"),
                    new(2, "Aktualisiert"),
                    new(3, "Entfernt"),
                    new(4, "Geklärt"),
                    new(5, "Gespeichert"),
                    new(6, "Geladen"),
                }
            },
        };

    public static TheoryData<DateTimeDiffCompareType, int, List<KeyValuePair<int, string>>> DateTimeDiffCompareTypeData
        => new()
        {
            {
                DateTimeDiffCompareType.Year,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Ticks"),
                    new(1, "Milliseconds"),
                    new(2, "Seconds"),
                    new(3, "Minutes"),
                    new(4, "Hours"),
                    new(5, "Days"),
                    new(6, "Year"),
                    new(7, "Quartal"),
                }
            },
            {
                DateTimeDiffCompareType.Year,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Ticks"),
                    new(1, "Milliseconds"),
                    new(2, "Seconds"),
                    new(3, "Minutes"),
                    new(4, "Hours"),
                    new(5, "Days"),
                    new(6, "Year"),
                    new(7, "Quartal"),
                }
            },
            {
                DateTimeDiffCompareType.Year,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Tidsmærke"),
                    new(1, "Millisekunder"),
                    new(2, "Sekunder"),
                    new(3, "Minutter"),
                    new(4, "Timer"),
                    new(5, "Dage"),
                    new(6, "År"),
                    new(7, "Quartal"),
                }
            },
            {
                DateTimeDiffCompareType.Year,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Ticks"),
                    new(1, "Millisekunden"),
                    new(2, "Sekunden"),
                    new(3, "Minuten"),
                    new(4, "Stunden"),
                    new(5, "Tage"),
                    new(6, "Jahr"),
                    new(7, "Quartal"),
                }
            },
        };

    public static TheoryData<DropDownFirstItemType, int, List<KeyValuePair<int, string>>> DropDownFirstItemTypeData
        => new()
        {
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(-1, "None"),
                    new(-2, "Blank"),
                    new(-3, "-- Select --"),
                    new(-4, "-- All --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(-1, "None"),
                    new(-2, "Blank"),
                    new(-3, "-- Select --"),
                    new(-4, "-- All --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(-1, "None"),
                    new(-2, "Blank"),
                    new(-3, "-- Vælg --"),
                    new(-4, "-- Alle --"),
                }
            },
            {
                DropDownFirstItemType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(-1, "None"),
                    new(-2, "Blank"),
                    new(-3, "-- Wählen --"),
                    new(-4, "-- Alles --"),
                }
            },
        };

    public static TheoryData<FileSystemWatcherChangeType, int, List<KeyValuePair<int, string>>> FileSystemWatcherChangeTypeData
        => new()
        {
            {
                FileSystemWatcherChangeType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Added"),
                    new(2, "Deleted"),
                    new(4, "Renamed"),
                    new(8, "Changed"),
                    new(15, "All"),
                }
            },
            {
                FileSystemWatcherChangeType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Added"),
                    new(2, "Deleted"),
                    new(4, "Renamed"),
                    new(8, "Changed"),
                    new(15, "All"),
                }
            },
            {
                FileSystemWatcherChangeType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Tilføjet"),
                    new(2, "Slettet"),
                    new(4, "Omdøbt"),
                    new(8, "Ændret"),
                    new(15, "Alle"),
                }
            },
            {
                FileSystemWatcherChangeType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Hinzugefügt"),
                    new(2, "Gelöscht"),
                    new(4, "Umbenannt"),
                    new(8, "Geändert"),
                    new(15, "Alles"),
                }
            },
        };

    public static TheoryData<ForwardReverseType, int, List<KeyValuePair<int, string>>> ForwardReverseTypeData
        => new()
        {
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Forward"),
                    new(2, "Reverse"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Forward"),
                    new(2, "Reverse"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Fremad"),
                    new(2, "Tilbage"),
                }
            },
            {
                ForwardReverseType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Vorwärts"),
                    new(2, "Rückwärts"),
                }
            },
        };

    public static TheoryData<IdentityRoleType, int, List<KeyValuePair<int, string>>> IdentityRoleTypeData
        => new()
        {
            {
                IdentityRoleType.Anonymous,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Anonymous"),
                    new(2, "User"),
                    new(4, "Super User"),
                    new(8, "Administrator"),
                    new(16, "Super Administrator"),
                }
            },
            {
                IdentityRoleType.Anonymous,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Anonymous"),
                    new(2, "User"),
                    new(4, "Super User"),
                    new(8, "Administrator"),
                    new(16, "Super Administrator"),
                }
            },
            {
                IdentityRoleType.Anonymous,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Anonym"),
                    new(2, "Bruger"),
                    new(4, "Super Bruger"),
                    new(8, "Administrator"),
                    new(16, "Super Administrator"),
                }
            },
            {
                IdentityRoleType.Anonymous,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Anonym"),
                    new(2, "Benutzer"),
                    new(4, "Super Benutzer"),
                    new(8, "Administrator"),
                    new(16, "Super Administrator"),
                }
            },
        };

    public static TheoryData<InsertRemoveType, int, List<KeyValuePair<int, string>>> InsertRemoveTypeData
        => new()
        {
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Insert"),
                    new(2, "Remove"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Insert"),
                    new(2, "Remove"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Indsæt"),
                    new(2, "Fjern"),
                }
            },
            {
                InsertRemoveType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Legen"),
                    new(2, "Entfernen"),
                }
            },
        };

    public static TheoryData<LeftRightType, int, List<KeyValuePair<int, string>>> LeftRightTypeData
        => new()
        {
            {
                LeftRightType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Left"),
                    new(2, "Right"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Left"),
                    new(2, "Right"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Venstre"),
                    new(2, "Højre"),
                }
            },
            {
                LeftRightType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Links"),
                    new(2, "Rechts"),
                }
            },
        };

    public static TheoryData<LogCategoryType, int, List<KeyValuePair<int, string>>> LogCategoryTypeData
        => new()
        {
            {
                LogCategoryType.Critical,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Critical"),
                    new(1, "Error"),
                    new(2, "Warning"),
                    new(3, "Security"),
                    new(4, "Audit"),
                    new(5, "Service"),
                    new(6, "UI"),
                    new(7, "Information"),
                    new(8, "Debug"),
                    new(9, "Trace"),
                }
            },
            {
                LogCategoryType.Critical,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Critical"),
                    new(1, "Error"),
                    new(2, "Warning"),
                    new(3, "Security"),
                    new(4, "Audit"),
                    new(5, "Service"),
                    new(6, "UI"),
                    new(7, "Information"),
                    new(8, "Debug"),
                    new(9, "Trace"),
                }
            },
            {
                LogCategoryType.Critical,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Kritisk"),
                    new(1, "Fejl"),
                    new(2, "Advarsel"),
                    new(3, "Sikkerhed"),
                    new(4, "Revision"),
                    new(5, "Tjenesten"),
                    new(6, "UI"),
                    new(7, "Information"),
                    new(8, "Fejlsøg"),
                    new(9, "Trace"),
                }
            },
            {
                LogCategoryType.Critical,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(0, "Kritisch"),
                    new(1, "Fehler"),
                    new(2, "Warnung"),
                    new(3, "Sicherheit"),
                    new(4, "Prüfung"),
                    new(5, "Service"),
                    new(6, "UI"),
                    new(7, "Information"),
                    new(8, "Debuggen"),
                    new(9, "Spur"),
                }
            },
        };

    public static TheoryData<OnOffType, int, List<KeyValuePair<int, string>>> OnOffTypeData
        => new()
        {
            {
                OnOffType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Off"),
                    new(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Off"),
                    new(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Off"),
                    new(2, "On"),
                }
            },
            {
                OnOffType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Off"),
                    new(2, "On"),
                }
            },
        };

    public static TheoryData<SortDirectionType, int, List<KeyValuePair<int, string>>> SortDirectionTypeData
        => new()
        {
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Ascending"),
                    new(2, "Descending"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Ascending"),
                    new(2, "Descending"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Stigende"),
                    new(2, "Faldende"),
                }
            },
            {
                SortDirectionType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Aufsteigend"),
                    new(2, "Absteigend"),
                }
            },
        };

    public static TheoryData<TriggerActionType, int, List<KeyValuePair<int, string>>> TriggerActionTypeData
        => new()
        {
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Insert"),
                    new(2, "Update"),
                    new(3, "Delete"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Insert"),
                    new(2, "Update"),
                    new(3, "Delete"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Indsæt"),
                    new(2, "Opdatering"),
                    new(3, "Slette"),
                }
            },
            {
                TriggerActionType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Einfügen"),
                    new(2, "Aktualisieren"),
                    new(3, "Löschen"),
                }
            },
        };

    public static TheoryData<UpDownType, int, List<KeyValuePair<int, string>>> UpDownTypeData
        => new()
        {
            {
                UpDownType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Up"),
                    new(2, "Down"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Up"),
                    new(2, "Down"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Op"),
                    new(2, "Ned"),
                }
            },
            {
                UpDownType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Nach oben"),
                    new(2, "Nach unten"),
                }
            },
        };

    public static TheoryData<YesNoType, int, List<KeyValuePair<int, string>>> YesNoTypeData
        => new()
        {
            {
                YesNoType.None,
                GlobalizationLcidConstants.UnitedStates,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "No"),
                    new(2, "Yes"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.GreatBritain,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "No"),
                    new(2, "Yes"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.Denmark,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Nej"),
                    new(2, "Ja"),
                }
            },
            {
                YesNoType.None,
                GlobalizationLcidConstants.Germany,
                new List<KeyValuePair<int, string>>
                {
                    new(1, "Keine"),
                    new(2, "Ja"),
                }
            },
        };
}