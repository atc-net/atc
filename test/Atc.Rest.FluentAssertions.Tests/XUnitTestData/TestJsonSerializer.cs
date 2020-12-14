using System.Text.Json;
using System.Text.Json.Serialization;

namespace Atc.Rest.FluentAssertions.Tests.XUnitTestData
{
    public static class TestJsonSerializer
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() },
        };

        public static string Serialize<T>(T content) => JsonSerializer.Serialize(content, jsonSerializerOptions);
    }
}