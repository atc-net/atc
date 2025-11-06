// ReSharper disable once CheckNamespace
namespace System.Net.Http;

/// <summary>
/// Extension methods for <see cref="HttpResponseMessage"/> to simplify JSON deserialization.
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    /// Deserializes the HTTP response content to the specified type using JSON.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response content to.</typeparam>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <param name="jsonSerializerOptions">Optional JSON serializer options. Uses default options if not specified.</param>
    /// <returns>A task representing the asynchronous operation, containing the deserialized object.</returns>
    /// <exception cref="SerializationException">Thrown when deserialization fails.</exception>
    public static Task<T> DeserializeAsync<T>(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        ArgumentNullException.ThrowIfNull(httpResponseMessage);

        return InvokeDeserializeAsync<T>(httpResponseMessage, jsonSerializerOptions);
    }

    private static async Task<T> InvokeDeserializeAsync<T>(HttpResponseMessage httpResponseMessage, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        jsonSerializerOptions ??= JsonSerializerOptionsFactory.Create();

        var content = await httpResponseMessage.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        try
        {
            return JsonSerializer.Deserialize<T>(content, jsonSerializerOptions)!;
        }
        catch (Exception ex)
        {
            throw new SerializationException(content, ex);
        }
    }
}