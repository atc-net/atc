// ReSharper disable once CheckNamespace
namespace System.Net.Http;

public static class HttpResponseMessageExtensions
{
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