using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Songhay.Tests;
using Xunit;
using Xunit.Abstractions;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        static ElasticSearchTests() => HttpClient = new HttpClient();

        public ElasticSearchTests(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),@"json\GetServerInfo_Test.json")]
        public async Task GetServerInfo_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        private async Task<string> GetServerResponseAsync(HttpRequestMessage request)
        {
            var response = await HttpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            this._testOutputHelper.WriteLine(content);

            Assert.True(response.IsSuccessStatusCode, "The expected success code is not here.");
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

        private readonly ITestOutputHelper _testOutputHelper;
    }
}
