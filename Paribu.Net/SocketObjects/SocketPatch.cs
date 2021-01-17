using Newtonsoft.Json;
using Paribu.Net.Attributes;
using System.Collections.Generic;

namespace Paribu.Net.SocketObjects
{
    public class SocketPatch<T>
    {
        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("patch")]
        public T Patch { get; set; }
    }

    public class SocketMerge<T>
    {
        [JsonProperty("unset")]
        public IEnumerable<string> Unset { get; set; }

        [JsonProperty("merge")]
        public T Merge { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    [JsonConverter(typeof(TypedDataConverter<SocketTickers>))]
    public class SocketTickers
    {
        [TypedData]
        public Dictionary<string, ParibuSocketTicker> Data { get; set; }
    }

    public class SocketOrderBook
    {
        [JsonProperty("buy")]
        public SocketOrderBookEntries Bids { get; set; }

        [JsonProperty("sell")]
        public SocketOrderBookEntries Asks { get; set; }
    }

    [JsonConverter(typeof(TypedDataConverter<SocketOrderBookEntries>))]
    public class SocketOrderBookEntries
    {
        [TypedData]
        public Dictionary<decimal, decimal> Data { get; set; }
    }

}