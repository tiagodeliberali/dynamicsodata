using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicsOData.Models.DynamicsEntities;

namespace DynamicsOData.Services
{
    public interface IODataService
    {
        Task<List<CustomerGroup>> GetCustomerGroups();
        Task<List<Customer>> GetCustomersByGroup(string customerGroupId);
        Task<List<Customer>> GetCustomers();
    }
}