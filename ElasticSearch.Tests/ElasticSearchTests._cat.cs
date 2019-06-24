using Newtonsoft.Json.Linq;
using Songhay.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Songhay.Tests;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"json\GetServerClusterNodes_Test.json")]
        public async Task GetServerClusterNodes_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.ApplicationJson));

            var response = await GetServerResponseAsync(request);
            j["output"] = JArray.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"json\GetServerHealth_Test.json")]
        public async Task GetServerHealth_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.ApplicationJson));

            var response = await GetServerResponseAsync(request);
            j["output"] = JArray.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"json\GetServerIndices_Test.json")]
        public async Task GetServerIndices_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.ApplicationJson));

            var response = await GetServerResponseAsync(request);
            j["output"] = JArray.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }
    }
}
