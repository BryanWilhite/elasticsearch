using Newtonsoft.Json.Linq;
using Songhay.Models;
using Songhay.Tests;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ElasticSearch.Tests
{
    public partial class ElasticSearchTests
    {
        /// <summary>
        /// POSTs a new customer in an index generated on the fly (when it does not exist).
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// Running this POST repeatedly will add multiple documents with auto-generated IDs.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PostCustomer_Test.json")]
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
        /// POSTs an update to the specified customer generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// This operation uses <c>refresh=wait_for</c> to ensure that the caller waits for the index to refresh after the update.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PostCustomerById_Test.json")]
        public async Task PostCustomerById_Test(FileSystemInfo ioFile)
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
        /// POSTs an update to the specified customer proprty added
        /// in <see cref="ElasticSearchTests.PostCustomerById_Test(FileSystemInfo)"/>
        /// with a painless script.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PostCustomerPainlessById_Test.json")]
        public async Task PostCustomerPainlessById_Test(FileSystemInfo ioFile)
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
        /// POSTs an update by query for the data generated
        /// by <see cref="ElasticSearchTests.PostCustomer_Test(FileSystemInfo)"/>.
        /// with a painless script.
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// This operation uses <c>refresh=true</c> to ensure that the caller waits for the index to refresh after the update.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PostCustomerUpdateByQuery_Test.json")]
        public async Task PostCustomerUpdateByQuery_Test(FileSystemInfo ioFile)
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
    }
}
