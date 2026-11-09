namespace Atc.Tests.Serialization.XUnitTestTypes;

[SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "OK - false/positive")]
public enum TestSessionState
{
    [JsonStringEnumMemberName("in-progress")]
    InProgress,

    [JsonStringEnumMemberName("done")]
    [EnumMember(Value = "completed")]
    Completed,

    [EnumMember(Value = "cancelled-by-user")]
    Cancelled,

    Pending,
}