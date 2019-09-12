using Newtonsoft.Json.Linq;
using Songhay.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Songhay.Tests;
using Xunit;
using ElasticSearch.Tests.Extensions;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetServerClusterNodes_Test.json")]
        public async Task GetServerClusterNodes_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetServerHealth_Test.json")]
        public async Task GetServerHealth_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetServerIndices_Test.json")]
        public async Task GetServerIndices_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }
    }
}
