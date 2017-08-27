using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DynamicsOData.Models.Infrastructure
{
    public class DynamicsHttpClient : IDynamicsHttpClient
    {
        public async Task<string> GetStringFromUrl(string url, string accessToken)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await client.SendAsync(request);

            string responseString = "";
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    responseString = await response.Content.ReadAsStringAsync();
                    break;
                case HttpStatusCode.Unauthorized:
                    throw new ODataException($"Please sign in again. {response.ReasonPhrase}");
                default:
                    throw new ODataException($"Error calling API. StatusCode=${response.StatusCode}");
            }

            return responseString;
        }
    }
}
