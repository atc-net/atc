// ReSharper disable TailRecursiveCall
namespace Atc.Serialization;

public class DynamicJson
{
    public IDictionary<string, object?> JsonDictionary { get; private set; } = new Dictionary<string, object?>(StringComparer.Ordinal);

    public DynamicJson()
    {
        SerializableAndSetJsonDictionary("{}");
    }

    public DynamicJson(
        string jsonString)
    {
        if (jsonString is null)
        {
            throw new ArgumentNullException(nameof(jsonString));
        }

        if (!jsonString.IsFormatJson())
        {
            throw new FormatException($"{nameof(jsonString)} is not valid json format.");
        }

        SerializableAndSetJsonDictionary(jsonString);
    }

    public DynamicJson(
        FileInfo jsonFile)
    {
        if (jsonFile is null)
        {
            throw new ArgumentNullException(nameof(jsonFile));
        }

        var jsonString = FileHelper.ReadAllText(jsonFile);
        if (!jsonString.IsFormatJson())
        {
            throw new FormatException($"{nameof(jsonString)} is not valid json format.");
        }

        SerializableAndSetJsonDictionary(jsonString);
    }

    public object? GetValue(
        string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var segments = path.Split('.');
        return GetValueRecursive(
            JsonDictionary,
            segments,
            0);
    }

    public (bool IsSucceeded, string? ErrorMessage) SetValue(
        string path,
        object? value,
        bool createKeyIfNotExist = true)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var segments = path.Split('.');
        return SetValueRecursive(
            JsonDictionary,
            segments,
            0,
            value,
            createKeyIfNotExist);
    }

    public (bool IsSucceeded, string? ErrorMessage) RemovePath(
        string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var keysToRemove = JsonDictionary
            .Keys
            .Where(x => x.StartsWith(path, StringComparison.Ordinal))
            .ToList();

        if (keysToRemove.Count == 0)
        {
            return (
                IsSucceeded: false,
                ErrorMessage: $"The path does not exist: {path}");
        }

        foreach (var key in keysToRemove)
        {
            JsonDictionary.Remove(key);
        }

        return (
            IsSucceeded: true,
            ErrorMessage: null);
    }

    public string ToJson(
        bool orderByKey = false)
        => ToJson(
            JsonSerializerOptionsFactory.Create(),
            orderByKey);

    public string ToJson(
        JsonSerializerOptions serializerOptions,
        bool orderByKey = false)
        => orderByKey
            ? JsonSerializer.Serialize(
                new SortedDictionary<string, object?>(JsonDictionary, StringComparer.Ordinal),
                serializerOptions)
            : JsonSerializer.Serialize(
                JsonDictionary,
                serializerOptions);

    public override string ToString()
        => ToJson();

    public string ToString(
        JsonSerializerOptions serializerOptions)
        => ToJson(serializerOptions);

    private void SerializableAndSetJsonDictionary(
        string jsonString)
    {
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new JsonElementObjectConverter());

        JsonDictionary = JsonSerializer.Deserialize<Dictionary<string, object?>>(jsonString, jsonSerializerOptions)!;
    }

    private static object? GetValueRecursive(
        IDictionary<string, object?> currentDict,
        IReadOnlyList<string> segments,
        int index)
    {
        var key = segments[index];

        if (index == segments.Count - 1)
        {
            return currentDict.TryGetValue(key, out var value)
                ? value
                : null;
        }

        if (currentDict[key] is Dictionary<string, object?> nestedDict)
        {
            return GetValueRecursive(
                nestedDict,
                segments,
                index + 1);
        }

        return null;
    }

    private static (bool IsSucceeded, string? ErrorMessage) SetValueRecursive(
        IDictionary<string, object?> currentDict,
        IReadOnlyList<string> segments,
        int index,
        object? value,
        bool createKeyIfNotExist)
    {
        var key = segments[index];

        if (index == segments.Count - 1)
        {
            currentDict[key] = value;
            return (
                IsSucceeded: true,
                ErrorMessage: null);
        }

        if (createKeyIfNotExist &&
            !currentDict.ContainsKey(key))
        {
            currentDict.Add(key, new Dictionary<string, object?>(StringComparer.Ordinal));
        }

        if (currentDict[key] is Dictionary<string, object?> nestedDict)
        {
            return SetValueRecursive(
                nestedDict,
                segments,
                index + 1,
                value,
                createKeyIfNotExist);
        }

        var errorInPath = string.Join('.', segments, 0, index + 1);
        return (
            IsSucceeded: false,
            ErrorMessage: $"The path does not exist: {errorInPath}");
    }
}