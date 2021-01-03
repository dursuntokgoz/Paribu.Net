using Newtonsoft.Json;

namespace Paribu.Net.RestObjects
{
    public class ParibuDisplayGroups
    {
        [JsonProperty("marketGroups")]
        public ParibuDisplayMarketGroups MarketGroups { get; set; }
        
        [JsonProperty("currencyGroups")]
        public ParibuDisplayCurrencyGroups CurrencyGroups { get; set; }
    }

    public class ParibuDisplayMarketGroups
    {
        [JsonProperty("crypto-tl")]
        public ParibuDisplayMarketGroup CryptoTL { get; set; }
        
        [JsonProperty("fantoken-chz")]
        public ParibuDisplayMarketGroup FanTokenCHZ { get; set; }
    }

    public class ParibuDisplayMarketGroup
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("tab")]
        public string Tab { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        
        [JsonProperty("sorter")]
        public int SortNumber { get; set; }
    }

    public class ParibuDisplayCurrencyGroups
    {
        [JsonProperty("fiat")]
        public ParibuDisplayCurrencyGroup Fiat { get; set; }

        [JsonProperty("crypto")]
        public ParibuDisplayCurrencyGroup Crypto { get; set; }

        [JsonProperty("fantoken")]
        public ParibuDisplayCurrencyGroup FanToken { get; set; }
    }

    public class ParibuDisplayCurrencyGroup
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("sorter")]
        public int SortNumber { get; set; }
    }
}
