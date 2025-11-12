// ReSharper disable TailRecursiveCall
namespace Atc.Serialization;

/// <summary>
/// DynamicJson can update a json document by adding or removing elements by dot annotation.
/// </summary>
/// <example>
/// Load a json document and set a property value like the following:
/// <![CDATA[
/// var dynamicJson = new DynamicJson(json);
/// dynamicJson.SetValue("Property1.Property2", "StrValue2");
/// json = dynamicJson.ToJson();
/// ]]>
/// </example>
public class DynamicJson
{
    /// <summary>
    /// Gets the underlying JSON dictionary representation.
    /// </summary>
    /// <value>
    /// A dictionary containing the JSON structure where keys are property names and values can be primitives,
    /// nested dictionaries, or lists.
    /// </value>
    public IDictionary<string, object?> JsonDictionary { get; private set; } = new Dictionary<string, object?>(StringComparer.Ordinal);

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicJson"/> class with an empty JSON object.
    /// </summary>
    public DynamicJson()
    {
        SerializableAndSetJsonDictionary("{}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicJson"/> class from a JSON string.
    /// </summary>
    /// <param name="jsonString">The JSON string to parse.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonString"/> is null.</exception>
    /// <exception cref="FormatException">Thrown when <paramref name="jsonString"/> is not valid JSON format.</exception>
    public DynamicJson(string jsonString)
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

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicJson"/> class from a JSON file.
    /// </summary>
    /// <param name="jsonFile">The JSON file to read and parse.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonFile"/> is null.</exception>
    /// <exception cref="FormatException">Thrown when the file contents are not valid JSON format.</exception>
    public DynamicJson(FileInfo jsonFile)
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

    /// <summary>
    /// Gets the value at the specified path in the JSON structure.
    /// </summary>
    /// <param name="path">The dot-notation path to the value (e.g., "Property1.Property2" or "Array[0].Property").</param>
    /// <returns>The value at the specified path, or null if the path does not exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is null.</exception>
    public object? GetValue(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var segments = GetSegmentsFromPath(path);

        return GetValueRecursive(
            JsonDictionary,
            segments,
            0);
    }

    /// <summary>
    /// Sets the value at the specified path in the JSON structure.
    /// </summary>
    /// <param name="path">The dot-notation path to the value (e.g., "Property1.Property2" or "Array[0].Property").</param>
    /// <param name="value">The value to set at the specified path.</param>
    /// <param name="createKeyIfNotExist">If true, creates intermediate objects and properties as needed. Default is true.</param>
    /// <returns>A tuple indicating whether the operation succeeded and an error message if it failed.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is null.</exception>
    public (bool IsSucceeded, string? ErrorMessage) SetValue(
        string path,
        object? value,
        bool createKeyIfNotExist = true)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var segments = GetSegmentsFromPath(path);

        return SetValueRecursive(
            JsonDictionary,
            segments,
            0,
            value,
            createKeyIfNotExist);
    }

    /// <summary>
    /// Removes the property at the specified path from the JSON structure.
    /// </summary>
    /// <param name="path">The dot-notation path to the property to remove (e.g., "Property1.Property2").</param>
    /// <returns>A tuple indicating whether the operation succeeded and an error message if it failed.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is null.</exception>
    public (bool IsSucceeded, string? ErrorMessage) RemovePath(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var segments = GetSegmentsFromPath(path);

        return RemovePathRecursive(
            JsonDictionary,
            segments,
            0);
    }

    /// <summary>
    /// Converts the JSON structure to a JSON string representation.
    /// </summary>
    /// <param name="orderByKey">If true, sorts the JSON properties alphabetically by key. Default is false.</param>
    /// <returns>A JSON string representation of the structure.</returns>
    public string ToJson(bool orderByKey = false)
        => ToJson(
            JsonSerializerOptionsFactory.Create(),
            orderByKey);

    /// <summary>
    /// Converts the JSON structure to a JSON string representation using the specified serializer options.
    /// </summary>
    /// <param name="serializerOptions">The <see cref="JsonSerializerOptions"/> to use for serialization.</param>
    /// <param name="orderByKey">If true, sorts the JSON properties alphabetically by key. Default is false.</param>
    /// <returns>A JSON string representation of the structure.</returns>
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

    /// <inheritdoc />
    public override string ToString()
        => ToJson();

    /// <summary>
    /// Converts the JSON structure to a JSON string representation using the specified serializer options.
    /// </summary>
    /// <param name="serializerOptions">The <see cref="JsonSerializerOptions"/> to use for serialization.</param>
    /// <returns>A JSON string representation of the structure.</returns>
    public string ToString(JsonSerializerOptions serializerOptions)
        => ToJson(serializerOptions);

    private void SerializableAndSetJsonDictionary(string jsonString)
    {
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
        jsonSerializerOptions.Converters.Add(new ElementObjectJsonConverter());

        JsonDictionary = JsonSerializer.Deserialize<Dictionary<string, object?>>(jsonString, jsonSerializerOptions)!;
    }

    private static IReadOnlyList<string> GetSegmentsFromPath(string path)
        => path
            .Replace('[', '.')
            .Replace("]", string.Empty, StringComparison.Ordinal)
            .Split('.');

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

        if (TryHandleAsList(
                currentDict,
                segments,
                index,
                value,
                createKeyIfNotExist,
                out var result))
        {
            return result;
        }

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

        return (
            IsSucceeded: false,
            ErrorMessage: $"The path does not exist: {string.Join('.', segments, 0, index + 1)}");
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    private static bool TryHandleAsList(
        IDictionary<string, object?> currentDict,
        IReadOnlyList<string> segments,
        int index,
        object? value,
        bool createKeyIfNotExist,
        out (bool IsSucceeded, string? ErrorMessage) result)
    {
        result = (
            IsSucceeded: false,
            ErrorMessage: null);

        var key = segments[index];

        if (index >= segments.Count - 1 ||
            !NumberHelper.TryParseToInt(segments[index + 1], out var arrayIndex))
        {
            return false;
        }

        if (!currentDict.ContainsKey(key))
        {
            currentDict.Add(key, new List<object?>());
        }

        if (currentDict[key] is not List<object?> list)
        {
            return false;
        }

        if (arrayIndex < 0 ||
            arrayIndex > list.Count ||
            (!createKeyIfNotExist && arrayIndex == list.Count))
        {
            result = (
                IsSucceeded: false,
                ErrorMessage: $"The index is out of range: {string.Join('.', segments, 0, index + 2)}");

            return true;
        }

        if (arrayIndex == list.Count)
        {
            list.Add(new Dictionary<string, object?>(StringComparer.Ordinal));
        }

        if (index + 2 == segments.Count - 1)
        {
            result = SetListValue(
                segments,
                index,
                value,
                list,
                arrayIndex);

            return true;
        }

        if (list[arrayIndex] is Dictionary<string, object?> nestedDict)
        {
            result = SetValueRecursive(
                nestedDict,
                segments,
                index + 2,
                value,
                createKeyIfNotExist);

            return true;
        }

        result = (
            IsSucceeded: false,
            ErrorMessage: $"The path does not exist: {string.Join('.', segments, 0, index + 2)}");

        return true;
    }

    private static (bool IsSucceeded, string? ErrorMessage) SetListValue(
        IReadOnlyList<string> segments,
        int index,
        object? value,
        IList<object?> list,
        int arrayIndex)
    {
        if (list[arrayIndex] is Dictionary<string, object?> arrayDict)
        {
            arrayDict[segments[index + 2]] = value;

            return (
                IsSucceeded: true,
                ErrorMessage: null);
        }

        list[arrayIndex] = value;

        return (
            IsSucceeded: true,
            ErrorMessage: null);
    }

    private static (bool IsSucceeded, string? ErrorMessage) RemovePathRecursive(
        IDictionary<string, object?> currentDict,
        IReadOnlyList<string> segments,
        int index)
    {
        var key = segments[index];

        if (index == segments.Count - 1)
        {
            var keysToRemove = currentDict
                .Keys
                .Where(x => x.Equals(key, StringComparison.Ordinal))
                .ToList();

            if (keysToRemove.Count == 0)
            {
                return (
                    IsSucceeded: false,
                    ErrorMessage: "The path does not exist: nonexistentProperty");
            }

            foreach (var keyToRemove in keysToRemove)
            {
                currentDict.Remove(keyToRemove);
            }

            return (
                IsSucceeded: true,
                ErrorMessage: null);
        }

        if (currentDict[key] is Dictionary<string, object?> nestedDict)
        {
            return RemovePathRecursive(
                nestedDict,
                segments,
                index + 1);
        }

        return (
            IsSucceeded: false,
            ErrorMessage: $"The path does not exist: {string.Join('.', segments, 0, index + 1)}");
    }
}