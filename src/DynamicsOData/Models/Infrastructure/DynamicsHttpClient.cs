using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<HttpResponseMessage> PathToUrl(string url, string accessToken, string serializedEntity)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Add("OData-MaxVersion", "4.0");
            request.Headers.Add("OData-Version", "4.0");

            request.Content = new StringContent(serializedEntity, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }
    }
}
