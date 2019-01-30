using Newtonsoft.Json.Linq;
using SonghayCore.xUnit;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        static ElasticSearchTests() => HttpClient = new HttpClient();

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\GetServerInfo_Test.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task GetServerInfo_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        private static async Task<string> GetServerResponseAsync(HttpRequestMessage request)
        {
            var response = await HttpClient.SendAsync(request);

            Assert.True(response.IsSuccessStatusCode, "The expected success code is not here.");

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private static Uri GetInputUri(JToken jToken)
        {
            var input = jToken?.Value<string>();
            Assert.False(string.IsNullOrEmpty(input), "The expected input URI is not here.");

            return new Uri(input, UriKind.Absolute);
        }

        private static JObject GetIoJObject(FileSystemInfo ioFile)
        {
            var json = File.ReadAllText(ioFile.FullName);
            return JObject.Parse(json);
        }

        private static readonly HttpClient HttpClient;
    }
}
