using Newtonsoft.Json;
using Paribu.Net.Converters;
using Paribu.Net.Enums;

namespace Paribu.Net.RestObjects
{
    public class ParibuMarket
    {
        [JsonProperty("pairs")]
        public string Pairs { get; set; }

        [JsonProperty("active")]
        public bool active { get; set; }
        
        [JsonProperty("minAmount")]
        public decimal minAmount { get; set; }
        
        [JsonProperty("maxAmount")]
        public decimal maxAmount { get; set; }
        
        [JsonProperty("mDecimals")]
        public int mDecimals { get; set; }
        
        [JsonProperty("pDecimals")]
        public int pDecimals { get; set; }
        
        [JsonProperty("group"), JsonConverter(typeof(MarketGroupConverter))]
        public ParibuMarketGroup Group { get; set; }
    }
}
