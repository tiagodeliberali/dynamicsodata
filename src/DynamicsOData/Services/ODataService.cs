using DynamicsOData.Models;
using DynamicsOData.Models.DynamicsEntities;
using DynamicsOData.Models.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DynamicsOData.Services
{
    public class ODataService : IODataService
    {
        private ClaimsPrincipal user;
        private ODataOptions odataOptions;
        private IDynamicsHttpClient httpClient;
        private string customerGroupUrl;
        private string customerUrl;
        private string customerByGroupUrl;
        private string customerByIdUrl;

        public ODataService(IPrincipal user, IDynamicsHttpClient httpClient, IOptions<ODataOptions> odataOptions)
        {
            this.user = user as ClaimsPrincipal;
            this.odataOptions = odataOptions.Value;
            this.httpClient = httpClient;

            customerGroupUrl = this.odataOptions.BaseUrl + "/data/CustomerGroups";
            customerUrl = this.odataOptions.BaseUrl + "/data/Customers";
            customerByGroupUrl = this.odataOptions.BaseUrl + customerUrl + "?$filter=CustomerGroupId%20eq%20%27{0}%27";
    }

        public async Task<List<CustomerGroup>> GetCustomerGroups()
        {
            return await GetODataEntity<List<CustomerGroup>>(customerGroupUrl);
        }

        public async Task<List<Customer>> GetCustomersByGroup(string customerGroupId)
        {
            return await GetODataEntity<List<Customer>>(string.Format(customerByGroupUrl, customerGroupId));
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await GetODataEntity<List<Customer>>(customerUrl);
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

            return await httpClient.GetStringFromUrl(url, accessToken);
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
