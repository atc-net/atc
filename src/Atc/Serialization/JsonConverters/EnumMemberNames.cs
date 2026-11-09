namespace Atc.Serialization.JsonConverters;

/// <summary>
/// The JSON names of the members of <typeparamref name="TEnum"/>, shared by the string-enum converters.
/// A member's name is its <see cref="JsonStringEnumMemberNameAttribute"/> value, else its
/// <see cref="EnumMemberAttribute"/> value, else the member name; reading also accepts the member name.
/// </summary>
/// <typeparam name="TEnum">The enum type.</typeparam>
internal static class EnumMemberNames<TEnum>
    where TEnum : Enum
{
    private static readonly Dictionary<string, TEnum> NameToValue = BuildNameToValue();
    private static readonly Dictionary<TEnum, string> ValueToName = BuildValueToName();
    private static readonly HashSet<TEnum> ExactNames = BuildExactNames();

    public static bool TryGetValue(
        string? name,
        out TEnum value)
    {
        if (name is not null && NameToValue.TryGetValue(name, out var found))
        {
            value = found;
            return true;
        }

        value = default!;
        return false;
    }

    public static void Write(
        Utf8JsonWriter writer,
        TEnum value,
        JsonSerializerOptions options)
    {
        var enumValue = ValueToName.TryGetValue(value, out var name) ? name : value.ToString();

        // A JsonStringEnumMemberName is the exact JSON name, as in System.Text.Json; other names follow the policy.
        if (ExactNames.Contains(value))
        {
            writer.WriteStringValue(enumValue);
            return;
        }

        writer.WriteStringValue(options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
            ? enumValue.EnsureFirstCharacterToLower()
            : enumValue.EnsureFirstCharacterToUpper());
    }

    private static string JsonName(FieldInfo field)
        => field.GetCustomAttribute<JsonStringEnumMemberNameAttribute>()?.Name ??
           field.GetCustomAttribute<EnumMemberAttribute>()?.Value ??
           field.Name;

    private static Dictionary<string, TEnum> BuildNameToValue()
    {
        var map = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var value = (TEnum)field.GetValue(null)!;
            map[JsonName(field)] = value;
            if (!map.ContainsKey(field.Name))
            {
                map[field.Name] = value;
            }
        }

        return map;
    }

    private static HashSet<TEnum> BuildExactNames()
    {
        var set = new HashSet<TEnum>();
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (field.GetCustomAttribute<JsonStringEnumMemberNameAttribute>() is not null)
            {
                set.Add((TEnum)field.GetValue(null)!);
            }
        }

        return set;
    }

    private static Dictionary<TEnum, string> BuildValueToName()
    {
        var map = new Dictionary<TEnum, string>();
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var value = (TEnum)field.GetValue(null)!;
            if (!map.ContainsKey(value))
            {
                map[value] = JsonName(field);
            }
        }

        return map;
    }
}