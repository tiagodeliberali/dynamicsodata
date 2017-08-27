using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DynamicsOData.Models;
using DynamicsOData.Models.DynamicsEntities;
using Microsoft.Extensions.Options;

namespace DynamicsOData.Services
{
    public class ODataService : IODataService
    {
        private ClaimsPrincipal user;
        private ODataOptions odataOptions;
        private string customerGroupListUrl;
        private string customerByGroupUrl;
        private string customerByIdUrl;

        public ODataService(IPrincipal user, IOptions<ODataOptions> odataOptions)
        {
            this.user = user as ClaimsPrincipal;
            this.odataOptions = odataOptions.Value;

            customerGroupListUrl = this.odataOptions.BaseUrl + "/data/CustomerGroups";
            customerByGroupUrl = this.odataOptions.BaseUrl + "/data/Customers?$filter=CustomerGroupId%20eq%20%27{0}%27";
            customerByIdUrl = this.odataOptions.BaseUrl + "/data/Customers?$filter=CustomerAccount%20eq%20%27{0}%27";
    }

        public async Task<List<CustomerGroup>> GetCustomerGroups()
        {
            return await GetODataEntity<List<CustomerGroup>>(customerGroupListUrl);
        }

        public async Task<List<Customer>> GetCustomersByGroup(string customerGroupId)
        {
            return await GetODataEntity<List<Customer>>(string.Format(customerByGroupUrl, customerGroupId));
        }

        public async Task<Customer> GetCustomersById(string customerAccount)
        {
            var customerList = await GetODataEntity<List<Customer>>(string.Format(customerByIdUrl, customerAccount));

            return customerList.FirstOrDefault();
        }

        public async Task<T> GetODataEntity<T>(string url)
        {
            string responseString = await RequestODataString(url);

            var resultObject = JsonConvert.DeserializeObject<OData<T>>(responseString);

            return resultObject.Value;
        }

        private async Task<string> RequestODataString(string url)
        {
            string accessToken = GetAccessToken();

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

        private string GetAccessToken()
        {
            var accessTokenClaim = user.FindFirst(ApplicationUser.AccessTokenClaimType);

            if (accessTokenClaim == null)
                throw new ODataException("Access token not found in user claims.");

            string accessToken = accessTokenClaim.Value;
            return accessToken;
        }
    }
}
