using Newtonsoft.Json;
using Paribu.Net.Attributes;
using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    public class ParibuMarketData
    {
        public ParibuOrderBook OrderBook { get; set; }

        public IEnumerable<ParibuTrade> Trades { get; set; }

        public ParibuChartData ChartData { get; set; }
    }

    public class MarketData
    {
        [JsonProperty("orderBook")]
        public MarketDataOrderBook OrderBook { get; set; }

        [JsonProperty("marketMatches")]
        public IEnumerable<ParibuTrade> Trades { get; set; }

        [JsonProperty("charts")]
        public ChartData ChartData { get; set; }
    }

    public class MarketDataOrderBook
    {
        [JsonProperty("buy")]
        public MarketDataOrderBookList Bids { get; set; }

        [JsonProperty("sell")]
        public MarketDataOrderBookList Asks { get; set; }
    }

    [JsonConverter(typeof(TypedDataConverter<MarketDataOrderBookList>))]
    public class MarketDataOrderBookList
    {
        [TypedData]
        public Dictionary<decimal, decimal> Data { get; set; }
    }

}