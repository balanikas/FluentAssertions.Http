using System.Net.Http;
using System.Text.Json;

namespace FluentAssertions.Http.Internal
{
    internal static class HttpResponseMessageExtensions
    {
        private static readonly JsonSerializerOptions SerializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        internal static string GetContent(
            this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        internal static T GetContentAs<T>(
            this HttpResponseMessage response)
        {
            return JsonSerializer.Deserialize<T>(response.GetContent(), SerializationOptions);
        }
    }
}