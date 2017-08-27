using System.Threading.Tasks;

namespace DynamicsOData.Models.Infrastructure
{
    public interface IDynamicsHttpClient
    {
        Task<string> GetStringFromUrl(string url, string accessToken);
    }
}