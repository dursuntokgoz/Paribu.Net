using Newtonsoft.Json;
using Paribu.Net.Attributes;
using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    public class ParibuInitials
    {
        [JsonProperty("config")]
        public ParibuExchangeConfig ExchangeConfig { get; set; }
        
        [JsonProperty("displayGroups")]
        public ParibuDisplayGroups DisplayGroups { get; set; }

        [JsonProperty("currencies")]
        public ParibuInitialsCurrencies Currencies { get; set; }

        [JsonProperty("markets")]
        public ParibuInitialsMarkets Markets { get; set; }
        
        [JsonProperty("ticker")]
        public ParibuInitialTickers Tickers { get; set; }

        [JsonProperty("bannerContent")]
        public IEnumerable<ParibuBanner> Banners { get; set; }
    }
    
    [JsonConverter(typeof(TypedDataConverter<ParibuInitialsCurrencies>))]
    public class ParibuInitialsCurrencies
    {
        [TypedData]
        public Dictionary<string, ParibuCurrency> Data { get; set; }
    }

    [JsonConverter(typeof(TypedDataConverter<ParibuInitialsMarkets>))]
    public class ParibuInitialsMarkets
    {
        [TypedData]
        public Dictionary<string, ParibuMarket> Data { get; set; }
    }

    [JsonConverter(typeof(TypedDataConverter<ParibuInitialTickers>))]
    public class ParibuInitialTickers
    {
        [TypedData]
        public Dictionary<string, ParibuInitialTicker> Data { get; set; }
    }

}
