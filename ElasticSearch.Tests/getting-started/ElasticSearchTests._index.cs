using ElasticSearch.Tests.Extensions;
using Songhay.Tests;
using System.IO;
using System.Net.Http;
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
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\DeleteCustomerIndex_Test.json")]
        public async Task DeleteCustomerIndex_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseAsync(HttpMethod.Delete);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// DELETEs the customer index generated
        /// in <see cref="ElasticSearchTests.PostCustomerIndexCopy_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\DeleteCustomerIndexCopy_Test.json")]
        public async Task DeleteCustomerIndexCopy_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseAsync(HttpMethod.Delete);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// GETs all the customer documents with <c>_search</c>.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetAllCustomers.json")]
        public async Task GetAllCustomers_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseAsync(HttpMethod.Get);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// GETs the customer index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetCustomerIndex_Test.json")]
        public async Task GetCustomerIndex_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseAsync(HttpMethod.Get);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// GETs customer data by query from the index generated
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// Depends on data from <see cref="ElasticSearchTests.PostCustomer_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        /// <remarks>
        /// This operation will work as expected for POST or GET methods.
        /// This operation will work as expected for <c>customer/_search</c> or just <c>_search</c>.
        /// The query is a lowercase term because text fields are analyzed
        /// (see https://www.elastic.co/guide/en/elasticsearch/reference/6.6/query-dsl-term-query.html).
        /// For example the term <c>Jane</c> will return no documents while <c>jane</c> will.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\GetCustomersByQuery.json")]
        public async Task GetCustomersByQuery(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Get);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// POSTs a request for a copy of the index generated (with <c>_reindex</c>)
        /// in <see cref="ElasticSearchTests.PutCustomerInNewIndex_Test(FileSystemInfo)"/>.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\PostCustomerIndexCopy_Test.json")]
        public async Task PostCustomerIndexCopy_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Post);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }

        /// <summary>
        /// PUTs a new customer in an index generated on the fly.
        /// </summary>
        /// <param name="ioFile">the <cref="FileSystemInfo" /></param>
        /// <remarks>
        /// Running this PUT repeatedly does not add multiple documents.
        /// This is because an ID is specified in the URI.
        /// </remarks>
        [Theory]
        [ProjectFileData(typeof(ElasticSearchTests), @"..\..\..\getting-started\json\PutCustomerInNewIndex_Test.json")]
        public async Task PutCustomerInNewIndex_Test(FileSystemInfo ioFile)
        {
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Put);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }
    }
}
