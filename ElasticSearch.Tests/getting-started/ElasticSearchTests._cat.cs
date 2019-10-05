using System.IO;
using System.Threading.Tasks;
using ElasticSearch.Tests.Extensions;
using Songhay.Tests;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetServerClusterNodes_Test.json")]
        public async Task GetServerClusterNodes_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetServerHealth_Test.json")]
        public async Task GetServerHealth_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }

        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetServerIndices_Test.json")]
        public async Task GetServerIndices_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.GetServerResponseWithJsonAcceptHeaderAsync();
            var content = j.ToString();
            this._testOutputHelper.WriteLine(content);

            File.WriteAllText(ioFile.FullName, content);
        }
    }
}
