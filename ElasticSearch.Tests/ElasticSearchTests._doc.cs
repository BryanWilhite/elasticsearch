using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ElasticSearch.Tests.Extensions;
using Songhay.Tests;
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
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Post);
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
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Post);
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
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Post);
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
            var j = await ioFile.ReturnServerResponseFromBodyAsync(HttpMethod.Post);
            File.WriteAllText(ioFile.FullName, j.ToString());
        }
    }
}
