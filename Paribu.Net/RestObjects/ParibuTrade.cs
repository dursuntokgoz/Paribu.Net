using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using Paribu.Net.Converters;
using Paribu.Net.Enums;
using System;

namespace Paribu.Net.RestObjects
{
    public class ParibuTrade
    {
        [JsonProperty("timestamp"), JsonConverter(typeof(TimestampSecondsConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("trade"), JsonConverter(typeof(TradeSideConverter))]
        public ParibuTradeSide Side { get; set; }
    }
}