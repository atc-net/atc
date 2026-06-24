namespace Atc.Rest.AwesomeAssertions.Tests.XUnitTestData
{
    internal static class TestJsonSerializer
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = JsonSerializerOptionsFactory.Create();

        public static string Serialize<T>(T content)
            => JsonSerializer.Serialize(content, JsonSerializerOptions);
    }
}