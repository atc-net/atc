using System.Text.Json;
using Atc.Serialization;

namespace Atc.Rest.FluentAssertions.Tests.XUnitTestData
{
    public static class TestJsonSerializer
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = JsonSerializerOptionsFactory.Create();

        public static string Serialize<T>(T content) => JsonSerializer.Serialize(content, JsonSerializerOptions);
    }
}