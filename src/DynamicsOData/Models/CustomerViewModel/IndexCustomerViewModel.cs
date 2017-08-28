using DynamicsOData.Models.DynamicsEntities;
using System.Collections.Generic;

namespace DynamicsOData.Models.CustomerViewModel
{
    public class IndexCustomerViewModel
    {
        public List<Customer> Customers { get; internal set; }
        public string CustomerGroupId { get; internal set; }
        public string CustomerAccount { get; internal set; }
    }
}
