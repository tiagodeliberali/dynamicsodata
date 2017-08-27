using Newtonsoft.Json;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class CustomerGroup
    {
        [JsonProperty("@odata.etag")]
        public string Etag { get; set; }

        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }

        public string CustomerGroupId { get; set; }
        public string Description { get; set; }
        public string DefaultDimensionDisplayValue { get; set; }
        public string ClearingPeriodPaymentTermName { get; set; }
        public string PaymentTermId { get; set; }
        public string IsSalesTaxIncludedInPrice { get; set; }
        public string WriteOffReason { get; set; }
        public string TaxGroupId { get; set; }
    }
}
