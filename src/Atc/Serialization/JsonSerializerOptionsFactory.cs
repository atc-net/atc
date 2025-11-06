// ReSharper disable MemberCanBePrivate.Global
namespace Atc.Serialization;

/// <summary>
/// Factory class for creating preconfigured <see cref="JsonSerializerOptions"/> instances.
/// </summary>
/// <remarks>
/// This factory provides convenient methods to create <see cref="JsonSerializerOptions"/> with common settings
/// and custom converters. It supports both parameter-based and settings-based configuration.
/// </remarks>
public static class JsonSerializerOptionsFactory
{
    /// <summary>
    /// Creates a new <see cref="JsonSerializerOptions"/> instance with the specified parameters.
    /// </summary>
    /// <param name="useCamelCase">If true, uses camelCase for property names. Default is true.</param>
    /// <param name="ignoreNullValues">If true, ignores null values during serialization. Default is true.</param>
    /// <param name="propertyNameCaseInsensitive">If true, property name matching is case-insensitive. Default is true.</param>
    /// <param name="writeIndented">If true, writes indented JSON output. Default is true.</param>
    /// <returns>A configured <see cref="JsonSerializerOptions"/> instance.</returns>
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

    /// <summary>
    /// Creates a new <see cref="JsonSerializerOptions"/> instance using the specified settings.
    /// </summary>
    /// <param name="settings">The settings to use for configuration.</param>
    /// <returns>A configured <see cref="JsonSerializerOptions"/> instance with converters registered as specified in the settings.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="settings"/> is null.</exception>
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
            jsonSerializerOptions.Converters.Add(new TimeSpanJsonConverter());
        }

        if (settings.UseConverterDatetimeOffsetMinToNull)
        {
            jsonSerializerOptions.Converters.Add(new DateTimeOffsetMinToNullJsonConverter());
        }

        if (settings.UseConverterUnixDatetimeOffset)
        {
            jsonSerializerOptions.Converters.Add(new UnixDateTimeOffsetJsonConverter());
        }

        if (settings.UseConverterVersion)
        {
            jsonSerializerOptions.Converters.Add(new VersionJsonConverter());
        }

        return jsonSerializerOptions;
    }
}