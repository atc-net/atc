using System.Text.Json;
using System.Text.Json.Serialization;
using Atc.Serialization.JsonConverters;

namespace Atc.Serialization
{
    public static class JsonSerializerOptionsFactory
    {
        private static JsonSerializerOptions? jsonSerializerOptions;

        public static JsonSerializerOptions Create(
            bool useCamelCase = true,
            bool ignoreNullValues = true,
            bool propertyNameCaseInsensitive = true,
            bool writeIndented = true)
        {
            if (jsonSerializerOptions is not null)
            {
                return jsonSerializerOptions;
            }

            jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = ignoreNullValues,
                PropertyNameCaseInsensitive = propertyNameCaseInsensitive,
                WriteIndented = writeIndented,
            };

            if (useCamelCase)
            {
                jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }

            jsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            return jsonSerializerOptions;
        }
    }
}
