namespace Atc.Tests.Serialization.XUnitTestTypes;

[SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "OK - false/positive")]
[SuppressMessage("Naming", "CA1700:Do not name enum values 'Reserved'", Justification = "OK - For testing.")]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChargePointState
{
    [EnumMember(Value = "available")]
    Available,

    [EnumMember(Value = "busy")]
    Busy,

    [EnumMember(Value = "busy-blocked")]
    BusyBlocked,

    [EnumMember(Value = "busy-charging")]
    BusyCharging,

    [EnumMember(Value = "busy-non-charging")]
    BusyNonCharging,

    [EnumMember(Value = "busy-non-released")]
    BusyNonReleased,

    [EnumMember(Value = "busy-reserved")]
    BusyReserved,

    [EnumMember(Value = "busy-scheduled")]
    BusyScheduled,

    [EnumMember(Value = "error")]
    Error,

    [EnumMember(Value = "disconnected")]
    Disconnected,

    [EnumMember(Value = "passive")]
    Passive,

    [EnumMember(Value = "maintenance")]
    Maintenance,

    [EnumMember(Value = "other")]
    Other,

    TestWithoutEnumMember,
}