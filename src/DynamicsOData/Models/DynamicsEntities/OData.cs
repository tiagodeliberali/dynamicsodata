using Newtonsoft.Json;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class OData<T>
    {
        [JsonProperty("@odata.context")]
        public string OdataContex { get; set; }

        public T Value { get; set; }
    }
}
