using DynamicsOData.Models.DynamicsEntities;
using System.Collections.Generic;

namespace DynamicsOData.Models.CustomerGroupViewModel
{
    public class IndexCustomerGroupViewModel
    {
        public List<CustomerGroup> Groups { get; internal set; }
        public string CustomerGroupId { get; internal set; }
    }
}
