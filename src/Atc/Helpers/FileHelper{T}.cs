namespace Atc.Helpers;

/// <summary>
/// FileHelper.
/// </summary>
/// <typeparam name="T">The model.</typeparam>
[SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "OK.")]
[SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "OK.")]
public static class FileHelper<T>
    where T : class
{
    /// <summary>Read the json file and deserialize to the specified type.</summary>
    /// <param name="fileInfo">The file.</param>
    /// <returns>The model.</returns>
    public static T? ReadJsonFileToModel(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        var serializeOptions = JsonSerializerOptionsFactory.Create();
        using var stream = new StreamReader(fileInfo.FullName);
        var json = stream.ReadToEnd();
        return JsonSerializer.Deserialize<T>(json, serializeOptions);
    }

    /// <summary>Read the json file and deserialize to the specified type.</summary>
    /// <param name="fileInfo">The file.</param>
    /// <returns>The model.</returns>
    public static Task<T?> ReadJsonFileAndDeserializeAsync(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        return InvokeReadJsonFileToModelAsync(fileInfo);
    }

    /// <summary>Write the model to a json file.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="model">The model.</param>
    public static void WriteModelToJsonFile(
        FileInfo fileInfo,
        T model)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        var serializeOptions = JsonSerializerOptionsFactory.Create();
        var json = JsonSerializer.Serialize(model, serializeOptions);
        FileHelper.WriteAllText(fileInfo, json);
    }

    /// <summary>Write the model to a json file.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="model">The model.</param>
    public static Task WriteModelToJsonFileAsync(
        FileInfo fileInfo,
        T model)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        var serializeOptions = JsonSerializerOptionsFactory.Create();
        var json = JsonSerializer.Serialize(model, serializeOptions);
        return FileHelper.WriteAllTextAsync(fileInfo, json);
    }

    private static async Task<T?> InvokeReadJsonFileToModelAsync(
        FileSystemInfo fileInfo)
    {
        var serializeOptions = JsonSerializerOptionsFactory.Create();
        using var stream = new StreamReader(fileInfo.FullName);
        var json = await stream.ReadToEndAsync();
        return JsonSerializer.Deserialize<T>(json, serializeOptions);
    }
}