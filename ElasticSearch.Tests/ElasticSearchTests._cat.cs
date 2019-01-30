using Newtonsoft.Json.Linq;
using Songhay.Models;
using SonghayCore.xUnit;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\GetServerClusterNodes_Test.json"
            },
            numberOfDirectoryLevels: 3)]
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
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\GetServerHealth_Test.json"
            },
            numberOfDirectoryLevels: 3)]
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
    }
}
