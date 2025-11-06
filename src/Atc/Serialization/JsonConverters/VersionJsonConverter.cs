// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="Version"/> objects to and from their string representation.
/// </summary>
/// <remarks>
/// This converter supports reading <see cref="Version"/> from both string format (e.g., "1.2.3.4") and object format
/// with internal fields (_Major, _Minor, _Build, _Revision). During writing, <see cref="Version"/> is always serialized
/// as a string. If parsing fails, a default empty <see cref="Version"/> is returned.
/// </remarks>
public sealed class VersionJsonConverter : JsonConverter<Version>
{
    /// <inheritdoc />
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public override Version Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        try
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            switch (jsonDocument.RootElement.ValueKind)
            {
                case JsonValueKind.Object:
                {
                    var major = jsonDocument.RootElement.GetProperty("_Major").GetInt32();
                    var minor = jsonDocument.RootElement.GetProperty("_Minor").GetInt32();
                    var build = jsonDocument.RootElement.GetProperty("_Build").GetInt32();
                    var revision = jsonDocument.RootElement.GetProperty("_Revision").GetInt32();
                    return new Version(major, minor, build, revision);
                }

                case JsonValueKind.String:
                    var str = jsonDocument.RootElement.GetString()!;
                    if (str.TryParseVersion(out var read))
                    {
                        return read;
                    }

                    break;
            }
        }
        catch
        {
            // Ignore
        }

        return new Version();
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        Version value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        writer.WriteStringValue(value.ToString());
    }
}