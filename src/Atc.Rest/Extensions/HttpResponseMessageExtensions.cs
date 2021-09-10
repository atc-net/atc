using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System.Net.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static Task<T> DeserializeAsync<T>(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (httpResponseMessage == null)
            {
                throw new ArgumentNullException(nameof(httpResponseMessage));
            }

            return InvokeDeserializeAsync<T>(httpResponseMessage, jsonSerializerOptions);
        }

        private static async Task<T> InvokeDeserializeAsync<T>(HttpResponseMessage httpResponseMessage, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            jsonSerializerOptions ??= new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

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
}