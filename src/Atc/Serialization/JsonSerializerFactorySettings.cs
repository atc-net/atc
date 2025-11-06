namespace Atc.Serialization;

/// <summary>
/// Configuration settings for creating <see cref="JsonSerializerOptions"/> instances via <see cref="JsonSerializerOptionsFactory"/>.
/// </summary>
/// <remarks>
/// This class provides a strongly-typed way to configure JSON serialization behavior including naming policies,
/// null value handling, formatting, and custom converter registration. All settings have sensible defaults
/// optimized for typical API scenarios.
/// </remarks>
public class JsonSerializerFactorySettings
{
    /// <summary>
    /// Gets or sets a value indicating whether to read/write properties using camelCase.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool UseCamelCase { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to read/write properties and ignoring null values.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool IgnoreNullValues { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to read/write properties and ignoring casing.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool PropertyNameCaseInsensitive { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to read/write properties indented.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool WriteIndented { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to utilize enumAsStringConverter.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool UseConverterEnumAsString { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to utilize timespanConverter.
    /// </summary>
    /// <para>This setting is default set to true.</para>
    public bool UseConverterTimespan { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to utilize datetimeOffsetMinToNullConverter.
    /// </summary>
    /// <para>This setting is default set to false.</para>
    public bool UseConverterDatetimeOffsetMinToNull { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to utilize UnixDateTimeOffsetConverter.
    /// </summary>
    /// <para>This setting is default set to false.</para>
    public bool UseConverterUnixDatetimeOffset { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to utilize VersionConverter.
    /// </summary>
    /// <para>This setting is default set to false.</para>
    public bool UseConverterVersion { get; set; }
}