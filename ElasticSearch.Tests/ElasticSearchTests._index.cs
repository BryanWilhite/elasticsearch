using Newtonsoft.Json.Linq;
using Songhay.Models;
using SonghayCore.xUnit;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        /// <summary>
        /// DELETEs the customer index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\DeleteCustomerIndex_Test.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task DeleteCustomerIndex_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// GETs all the customer documents with <c>_search</c>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\GetAllCustomers.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task GetAllCustomers_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());

        }

        /// <summary>
        /// GETs the customer index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\GetCustomerIndex_Test.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task GetCustomerIndex_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// POSTs a new customer in an index generated on the fly (when it does not exist).
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// Running this POST repeatedly will add multiple documents with auto-generated IDs.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\PostCustomer_Test.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task PostCustomer_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);
            var body = JObject.FromObject(j["input"]["body"]);

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Clear();
            request.Content = new StringContent(body.ToString(), Encoding.UTF8, MimeTypes.ApplicationJson);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// PUTs a new customer in an index generated on the fly.
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// Running this PUT repeatedly does not add multiple documents.
        /// This is because an ID is specified in the URI.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests),
            new[]
            {
                @"json\PutCustomerInNewIndex_Test.json"
            },
            numberOfDirectoryLevels: 3)]
        public async Task PutCustomerInNewIndex_Test(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);
            var body = JObject.FromObject(j["input"]["body"]);

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Headers.Clear();
            request.Content = new StringContent(body.ToString(), Encoding.UTF8, MimeTypes.ApplicationJson);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }
    }
}
