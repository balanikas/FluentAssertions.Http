using System;
using System.Net.Http;
using Newtonsoft.Json;


namespace FluentAssertions.Http
{
    public static class HttpResponseMessageExtensions
    {
        internal static string GetContent(this HttpResponseMessage response) => response.Content.ReadAsStringAsync().Result;

        internal static T GetContentAs<T>(this HttpResponseMessage response) => JsonConvert.DeserializeObject<T>(response.GetContent());

        public static HttpResponseMessageAssertions Should(this HttpResponseMessage instance) => new HttpResponseMessageAssertions(instance);
    }
}
