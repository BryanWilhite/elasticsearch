using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Models;

namespace ElasticSearch.Tests.Extensions
{
    public static class FileSystemInfoExtensions
    {
        public static async Task<JContainer> GetServerResponseWithJsonAcceptHeaderAsync(this FileSystemInfo ioFile)
        {
            return await ioFile.ReturnServerResponseAsync(
                HttpMethod.Get,
                request =>
                {
                    request.Headers.Clear();
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.ApplicationJson));
                });
        }

        public static JObject GetIoJObject(this FileSystemInfo ioFile)
        {
            if(ioFile == null) throw new NullReferenceException($"The expected {nameof(FileSystemInfo)} is not here.");
            var json = File.ReadAllText(ioFile.FullName);
            return JObject.Parse(json);
        }

        public static async Task<JContainer> ReturnServerResponseAsync(this FileSystemInfo ioFile, HttpMethod method)
        {
            return await ioFile.ReturnServerResponseAsync(method, requestAction: null);
        }

        public static async Task<JContainer> ReturnServerResponseAsync(this FileSystemInfo ioFile, HttpMethod method, Action<HttpRequestMessage> requestAction)
        {
            var j = ioFile.GetIoJObject();
            var j_input = (j["input"] as JObject);
            var uri = j_input.GetJToken("uri", throwException: true).Value<string>();

            var request = new HttpRequestMessage(method, uri);
            requestAction?.Invoke(request);
            var response = await request.SendAsync();
            var content = await response.Content.ReadAsStringAsync();
            j["output"] = await response.ToJContainerAsync();

            return j;
        }

        public static async Task<JContainer> ReturnServerResponseFromBodyAsync(this FileSystemInfo ioFile, HttpMethod method)
        {
            var j = ioFile.GetIoJObject();
            var j_input = (j["input"] as JObject);
            var uri = j_input.GetJToken("uri", throwException: true).Value<string>();

            var body = JObject.FromObject(j_input["body"]);

            var request = new HttpRequestMessage(method, uri);
            request.Headers.Clear();
            var response = await request.SendBodyAsync(body?.ToString());
            j["output"] = await response.ToJContainerAsync();

            return j;
        }
    }
}