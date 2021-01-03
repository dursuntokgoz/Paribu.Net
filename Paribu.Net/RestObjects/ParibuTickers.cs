using Newtonsoft.Json;
using Paribu.Net.Attributes;
using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    [JsonConverter(typeof(TypedDataConverter<ParibuTickers>))]
    public class ParibuTickers
    {
        [TypedData]
        public Dictionary<string, ParibuTicker> Data { get; set; }
    }

    public class ParibuTicker
    {
        [JsonProperty("lowestAsk")]
        public decimal LowestAsk { get; set; }

        [JsonProperty("highestBid")]
        public decimal HighestBid { get; set; }

        [JsonProperty("low24hr")]
        public decimal Low24H { get; set; }

        [JsonProperty("high24hr")]
        public decimal High24H { get; set; }

        [JsonProperty("avg24hr")]
        public decimal Average24H { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("change")]
        public decimal Change { get; set; }

        [JsonProperty("percentChange")]
        public decimal PercentChange { get; set; }

        //[JsonProperty("chartData")]
        //public IEnumerable<decimal> ChartData { get; set; }
    }
}
