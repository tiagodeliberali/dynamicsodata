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
        private ILockEntityService lockEntityService;
        private string customerGroupUrl;
        private string customerUrl;
        private string customerByGroupUrl;

        public ODataService(IPrincipal user, IDynamicsHttpClient httpClient, IOptions<ODataOptions> odataOptions, ILockEntityService lockEntityService)
        {
            this.user = user as ClaimsPrincipal;
            this.odataOptions = odataOptions.Value;
            this.httpClient = httpClient;
            this.lockEntityService = lockEntityService;

            BuildUrls();
        }

        private void BuildUrls()
        {
            customerGroupUrl = odataOptions.BaseUrl + "/data/CustomerGroups";
            customerUrl = odataOptions.BaseUrl + "/data/Customers";

            customerByGroupUrl = customerUrl + "?$filter=CustomerGroupId%20eq%20%27{0}%27";
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

        public async Task UpdateCustomerGroup(CustomerGroup group)
        {
            await UpdateEntity<CustomerGroup>(group, customerGroupUrl, group.CustomerGroupId);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await UpdateEntity<Customer>(customer, customerUrl, customer.CustomerAccount);
        }

        private async Task UpdateEntity<T>(T entity, string url, string entityId)
        {
            await lockEntityService.CheckLock<T>(entityId, user.Identity.Name);

            var odataEntity = new OData<T>()
            {
                Value = entity
            };

            var serializedEntity = JsonConvert.SerializeObject(odataEntity, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var result = await httpClient.PostToUrl(url, GetAccessToken(), serializedEntity);
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
