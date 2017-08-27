using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class ODataOptions
    {
        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public string Tenant { get; set; }
        public string ClientId { get; set; }
    }
}
