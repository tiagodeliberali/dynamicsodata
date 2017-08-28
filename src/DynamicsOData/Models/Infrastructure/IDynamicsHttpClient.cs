using System.Net.Http;
using System.Threading.Tasks;

namespace DynamicsOData.Models.Infrastructure
{
    public interface IDynamicsHttpClient
    {
        Task<string> GetStringFromUrl(string url, string accessToken);
        Task<HttpResponseMessage> PathToUrl(string url, string accessToken, string serializedEntity);
    }
}