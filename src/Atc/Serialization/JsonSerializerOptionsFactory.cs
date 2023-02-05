// ReSharper disable MemberCanBePrivate.Global
namespace Atc.Serialization;

public static class JsonSerializerOptionsFactory
{
    public static JsonSerializerOptions Create(
        bool useCamelCase = true,
        bool ignoreNullValues = true,
        bool propertyNameCaseInsensitive = true,
        bool writeIndented = true)
    {
        var settings = new JsonSerializerFactorySettings
        {
            UseCamelCase = useCamelCase,
            IgnoreNullValues = ignoreNullValues,
            PropertyNameCaseInsensitive = propertyNameCaseInsensitive,
            WriteIndented = writeIndented,
        };

        return Create(settings);
    }

    public static JsonSerializerOptions Create(JsonSerializerFactorySettings settings)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = settings.IgnoreNullValues
                ? JsonIgnoreCondition.WhenWritingNull
                : JsonIgnoreCondition.Never,
            PropertyNameCaseInsensitive = settings.PropertyNameCaseInsensitive,
            WriteIndented = settings.WriteIndented,
        };

        if (settings.UseCamelCase)
        {
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }

        if (settings.UseConverterEnumAsString)
        {
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        if (settings.UseConverterTimespan)
        {
            jsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
        }

        if (settings.UseConverterDatetimeOffsetMinToNull)
        {
            jsonSerializerOptions.Converters.Add(new JsonDateTimeOffsetMinToNullConverter());
        }

        if (settings.UseConverterUnixDatetimeOffset)
        {
            jsonSerializerOptions.Converters.Add(new JsonUnixDateTimeOffsetConverter());
        }

        if (settings.UseConverterVersion)
        {
            jsonSerializerOptions.Converters.Add(new JsonVersionConverter());
        }

        return jsonSerializerOptions;
    }
}