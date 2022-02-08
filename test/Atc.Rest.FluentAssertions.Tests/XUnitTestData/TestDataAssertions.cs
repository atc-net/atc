namespace Atc.Rest.FluentAssertions.Tests.XUnitTestData;

public static class TestDataAssertions
{
    public static readonly IEnumerable<object[]> ErrorMessageContent = new[]
    {
        new object[] { new ProblemDetails { Detail = "FOO" } },
        new object[] { "FOO" },
    };
}