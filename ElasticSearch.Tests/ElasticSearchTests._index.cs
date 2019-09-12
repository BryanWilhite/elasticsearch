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
        /// DELETEs the customer index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\DeleteCustomerIndex_Test.json")]
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
        /// DELETEs the customer index generated
        /// in <see cref="ElasticSearchTests.PostCustomerIndexCopy_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\DeleteCustomerIndexCopy_Test.json")]
        public async Task DeleteCustomerIndexCopy_Test(FileSystemInfo ioFile)
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
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetAllCustomers.json")]
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
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetCustomerIndex_Test.json")]
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
        /// GETs customer data by query from the index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// Depends on data from <see cref="ElasticSearchTests.PostCustomer_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        /// <remarks>
        /// This operation will work as expected for POST or GET methods.
        /// This operation will work as expected for <c>customer/_search</c> or just <c>_search</c>.
        /// The query is a lowercase term because text fields are analyzed
        /// (see https://www.elastic.co/guide/en/elasticsearch/reference/6.6/query-dsl-term-query.html).
        /// For example the term <c>Jane</c> will return no documents while <c>jane</c> will.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\GetCustomersByQuery.json")]
        public async Task GetCustomersByQuery(FileSystemInfo ioFile)
        {
            var j = GetIoJObject(ioFile);
            var uri = GetInputUri(j["input"]["uri"]);
            var body = JObject.FromObject(j["input"]["body"]);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Clear();
            request.Content = new StringContent(body.ToString(), Encoding.UTF8, MimeTypes.ApplicationJson);

            var response = await GetServerResponseAsync(request);
            j["output"] = JObject.Parse(response);

            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// POSTs a request for a copy of the index generated (with <c>_reindex</c>)
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile"></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PostCustomerIndexCopy_Test.json")]
        public async Task PostCustomerIndexCopy_Test(FileSystemInfo ioFile)
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
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\json\PutCustomerInNewIndex_Test.json")]
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
