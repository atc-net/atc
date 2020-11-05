using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Atc.Rest.FluentAssertions.Tests.XUnitTestData
{
    public static class TestDataAssertions
    {
        public static readonly IEnumerable<object[]> ErrorMessageContent = new[]
        {
            new object[] { JsonSerializer.Serialize(new ProblemDetails { Detail = "FOO" }) },
            new object[] { "FOO" },
        };
    }
}