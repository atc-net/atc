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
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerOptions);
        }
    }
}