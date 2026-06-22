namespace Atc.Serialization;

/// <summary>
/// Provides async stream-based serialization and deserialization helpers using <see cref="System.Text.Json.JsonSerializer"/>.
/// </summary>
/// <remarks>
/// All overloads that omit <see cref="JsonSerializerOptions"/> use
/// <see cref="JsonSerializerOptionsFactory"/> default options.
/// </remarks>
public static class JsonSerializerHelper
{
    /// <summary>
    /// Asynchronously deserializes a value of type <typeparamref name="T"/> from the specified UTF-8 JSON stream
    /// using the default serializer options.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The UTF-8 encoded JSON stream to read from.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the deserialized value,
    /// or <see langword="null"/> if the stream contains a JSON null literal.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static async Task<T?> DeserializeFromStreamAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        return await JsonSerializer
            .DeserializeAsync<T>(stream, JsonSerializerOptionsFactory.Create(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously deserializes a value of type <typeparamref name="T"/> from the specified UTF-8 JSON stream
    /// using the provided serializer options.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The UTF-8 encoded JSON stream to read from.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use during deserialization.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the deserialized value,
    /// or <see langword="null"/> if the stream contains a JSON null literal.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> or <paramref name="options"/> is <see langword="null"/>.</exception>
    public static async Task<T?> DeserializeFromStreamAsync<T>(
        Stream stream,
        JsonSerializerOptions options,
        CancellationToken cancellationToken = default)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        return await JsonSerializer
            .DeserializeAsync<T>(stream, options, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously serializes <paramref name="value"/> as UTF-8 JSON into the specified stream
    /// using the default serializer options.
    /// </summary>
    /// <typeparam name="T">The type of the value to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <param name="stream">The stream to write JSON into.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static Task SerializeToStreamAsync<T>(
        T value,
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        return JsonSerializer.SerializeAsync(stream, value, JsonSerializerOptionsFactory.Create(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously serializes <paramref name="value"/> as UTF-8 JSON into the specified stream
    /// using the provided serializer options.
    /// </summary>
    /// <typeparam name="T">The type of the value to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <param name="stream">The stream to write JSON into.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use during serialization.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> or <paramref name="options"/> is <see langword="null"/>.</exception>
    public static Task SerializeToStreamAsync<T>(
        T value,
        Stream stream,
        JsonSerializerOptions options,
        CancellationToken cancellationToken = default)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        return JsonSerializer.SerializeAsync(stream, value, options, cancellationToken);
    }
}