using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ElasticSearch.Tests.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<JContainer> ToJContainerAsync(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content.TrimStart().StartsWith('[') ?
                JArray.Parse(content) as JContainer
                :
                JObject.Parse(content) as JContainer
                ;
        }
    }
}
