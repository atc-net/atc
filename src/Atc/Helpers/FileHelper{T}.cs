// ReSharper disable GrammarMistakeInComment
namespace Atc.Helpers;

/// <summary>
/// JSON file helper for reading/writing a model of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The model type to serialize/deserialize.</typeparam>
/// <remarks>
/// - Uses <see cref="JsonSerializer"/>.
/// - Default overloads obtain options from <c>JsonSerializerOptionsFactory.Create()</c>.
/// - Read methods require the file to exist; otherwise a <see cref="FileNotFoundException"/> is thrown.
/// - Write methods overwrite the destination file if it exists.
/// - Text I/O uses UTF-8 encoding.
/// </remarks>
/// <example>
/// <code>
/// var fi = new FileInfo("settings.json");
/// var settings = FileHelper&lt;AppSettings&gt;.ReadJsonFileToModel(fi);
///
/// // Modify and save
/// FileHelper&lt;AppSettings&gt;.WriteModelToJsonFile(fi, settings);
/// </code>
/// </example>
/// <seealso cref="FileHelper"/>
[SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "OK.")]
[SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "OK.")]
public static class FileHelper<T>
    where T : class
{
    /// <summary>
    /// Reads the JSON file and deserializes it to <typeparamref name="T"/> using default serializer options.
    /// </summary>
    /// <param name="fileInfo">The JSON file to read.</param>
    /// <returns>The deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    /// <exception cref="JsonException">Thrown if the content is not valid JSON for <typeparamref name="T"/>.</exception>
    public static T? ReadJsonFileToModel(FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        return ReadJsonFileToModel(
            fileInfo,
            JsonSerializerOptionsFactory.Create());
    }

    /// <summary>
    /// Reads the JSON file and deserializes it to <typeparamref name="T"/> using the provided serializer options.
    /// </summary>
    /// <param name="fileInfo">The JSON file to read.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <returns>The deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    /// <exception cref="JsonException">Thrown if the content is not valid JSON for <typeparamref name="T"/>.</exception>
    public static T? ReadJsonFileToModel(
        FileInfo fileInfo,
        JsonSerializerOptions serializeOptions)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        var json = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);
        return JsonSerializer.Deserialize<T>(json, serializeOptions);
    }

    /// <summary>
    /// Deserializes JSON from a readable stream to <typeparamref name="T"/> using default serializer options.
    /// </summary>
    /// <param name="utf8Json">A readable stream containing UTF-8 encoded JSON. The stream is NOT disposed.</param>
    /// <returns>The deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not readable.</exception>
    /// <exception cref="JsonException">Thrown if the content is not valid JSON for <typeparamref name="T"/>.</exception>
    public static T? ReadJsonFileToModel(Stream utf8Json)
        => ReadJsonFileToModel(
            utf8Json,
            JsonSerializerOptionsFactory.Create());

    /// <summary>
    /// Deserializes JSON from a readable stream to <typeparamref name="T"/> using the provided options.
    /// </summary>
    /// <param name="utf8Json">A readable stream containing UTF-8 encoded JSON. The stream is NOT disposed.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <returns>The deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not readable.</exception>
    /// <exception cref="JsonException">Thrown if the JSON is invalid for <typeparamref name="T"/>.</exception>
    public static T? ReadJsonFileToModel(
        Stream utf8Json,
        JsonSerializerOptions serializeOptions)
    {
        if (utf8Json is null)
        {
            throw new ArgumentNullException(nameof(utf8Json));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!utf8Json.CanRead)
        {
            throw new ArgumentException("Stream must be readable.", nameof(utf8Json));
        }

        // .NET 6+ has stream overload; avoids buffering
        return JsonSerializer.Deserialize<T>(utf8Json, serializeOptions);
    }

    /// <summary>
    /// Asynchronously reads the JSON file and deserializes it to <typeparamref name="T"/> using default serializer options.
    /// </summary>
    /// <param name="fileInfo">The JSON file to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task whose result is the deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    /// <exception cref="JsonException">Thrown if the content is not valid JSON for <typeparamref name="T"/>.</exception>
    public static Task<T?> ReadJsonFileToModelAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        return ReadJsonFileToModelAsync(
            fileInfo,
            JsonSerializerOptionsFactory.Create(),
            cancellationToken);
    }

    /// <summary>
    /// Asynchronously reads the JSON file and deserializes it to <typeparamref name="T"/> using the provided serializer options.
    /// </summary>
    /// <param name="fileInfo">The JSON file to read.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task whose result is the deserialized model, or <see langword="null"/> if the payload is JSON <see langword="null"/> .
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    /// <exception cref="JsonException">Thrown if the content is not valid JSON for <typeparamref name="T"/>.</exception>
    public static Task<T?> ReadJsonFileToModelAsync(
        FileInfo fileInfo,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(fileInfo.FullName);
        }

        return InvokeReadJsonFileToModelAsync(
            fileInfo,
            serializeOptions,
            cancellationToken);
    }

    /// <summary>
    /// Asynchronously deserializes JSON from a readable stream to <typeparamref name="T"/> using default serializer options.
    /// </summary>
    /// <param name="utf8Json">A readable stream containing UTF-8 encoded JSON. The stream is NOT disposed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task whose result is the deserialized model, or <see langword="null"/> if the payload is JSON <c>null</c>.
    /// </returns>
    public static Task<T?> ReadJsonFileToModelAsync(
        Stream utf8Json,
        CancellationToken cancellationToken = default)
        => ReadJsonFileToModelAsync(
            utf8Json,
            JsonSerializerOptionsFactory.Create(),
            cancellationToken);

    /// <summary>
    /// Asynchronously deserializes JSON from a readable stream to <typeparamref name="T"/> using the provided options.
    /// </summary>
    /// <param name="utf8Json">A readable stream containing UTF-8 encoded JSON. The stream is NOT disposed.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task whose result is the deserialized model, or <see langword="null"/> if the payload is JSON <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not readable.</exception>
    /// <exception cref="JsonException">Thrown if the JSON is invalid for <typeparamref name="T"/>.</exception>
    public static async Task<T?> ReadJsonFileToModelAsync(
        Stream utf8Json,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
    {
        if (utf8Json is null)
        {
            throw new ArgumentNullException(nameof(utf8Json));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!utf8Json.CanRead)
        {
            throw new ArgumentException("Stream must be readable.", nameof(utf8Json));
        }

        return await JsonSerializer
            .DeserializeAsync<T>(utf8Json, serializeOptions, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using default serializer options.
    /// </summary>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static void WriteModelToJsonFile(
        FileInfo fileInfo,
        T model)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        WriteModelToJsonFile(
            fileInfo,
            model,
            JsonSerializerOptionsFactory.Create());
    }

    /// <summary>
    /// Writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using the provided serializer options.
    /// </summary>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    public static void WriteModelToJsonFile(
        FileInfo fileInfo,
        T model,
        JsonSerializerOptions serializeOptions)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        var json = JsonSerializer.Serialize(model, serializeOptions);
        FileHelper.WriteAllText(fileInfo, json);
    }

    /// <summary>
    /// Serializes <paramref name="model"/> as JSON to a writable stream using default serializer options.
    /// </summary>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON. The stream is NOT disposed.</param>
    /// <param name="model">The model instance to serialize.</param>
    public static void WriteModelToJsonFile(
        Stream utf8Json,
        T model)
        => WriteModelToJsonFile(
            utf8Json,
            model,
            JsonSerializerOptionsFactory.Create());

    /// <summary>
    /// Serializes <paramref name="model"/> as JSON to a writable stream using the provided options.
    /// </summary>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON. The stream is NOT disposed.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static void WriteModelToJsonFile(
        Stream utf8Json,
        T model,
        JsonSerializerOptions serializeOptions)
    {
        if (utf8Json is null)
        {
            throw new ArgumentNullException(nameof(utf8Json));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!utf8Json.CanWrite)
        {
            throw new ArgumentException("Stream must be writable.", nameof(utf8Json));
        }

        JsonSerializer.Serialize(utf8Json, model, serializeOptions);
    }

    /// <summary>
    /// Asynchronously writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using default serializer options.
    /// </summary>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static Task WriteModelToJsonFileAsync(
        FileInfo fileInfo,
        T model,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        var serializeOptions = JsonSerializerOptionsFactory.Create();
        return WriteModelToJsonFileAsync(fileInfo, model, serializeOptions, cancellationToken);
    }

    /// <summary>
    /// Asynchronously writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using the provided serializer options.
    /// </summary>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    public static Task WriteModelToJsonFileAsync(
        FileInfo fileInfo,
        T model,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        var json = JsonSerializer.Serialize(model, serializeOptions);
        return FileHelper.WriteAllTextAsync(fileInfo, json, cancellationToken);
    }

    /// <summary>
    /// Asynchronously serializes <paramref name="model"/> as JSON to a writable stream using default serializer options.
    /// </summary>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON. The stream is NOT disposed.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    public static Task WriteModelToJsonFileAsync(
        Stream utf8Json,
        T model,
        CancellationToken cancellationToken = default)
        => WriteModelToJsonFileAsync(
            utf8Json,
            model,
            JsonSerializerOptionsFactory.Create(),
            cancellationToken);

    /// <summary>
    /// Asynchronously serializes <paramref name="model"/> as JSON to a writable stream using the provided options.
    /// </summary>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON. The stream is NOT disposed.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static Task WriteModelToJsonFileAsync(
        Stream utf8Json,
        T model,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
    {
        if (utf8Json is null)
        {
            throw new ArgumentNullException(nameof(utf8Json));
        }

        if (serializeOptions is null)
        {
            throw new ArgumentNullException(nameof(serializeOptions));
        }

        if (!utf8Json.CanWrite)
        {
            throw new ArgumentException("Stream must be writable.", nameof(utf8Json));
        }

        return JsonSerializer.SerializeAsync(utf8Json, model, serializeOptions, cancellationToken);
    }

    /// <summary>
    /// Internal implementation for async JSON read used by <see cref="ReadJsonFileToModelAsync(FileInfo, CancellationToken)"/>
    /// and <see cref="ReadJsonFileToModelAsync(FileInfo, JsonSerializerOptions, CancellationToken)"/>.
    /// </summary>
    private static async Task<T?> InvokeReadJsonFileToModelAsync(
        FileSystemInfo fileInfo,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken)
    {
        var json = await File
            .ReadAllTextAsync(fileInfo.FullName, Encoding.UTF8, cancellationToken)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(json, serializeOptions);
    }
}