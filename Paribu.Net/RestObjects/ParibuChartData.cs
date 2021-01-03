using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    public class ParibuChartData
    {
        public string Market { get; set; }

        public string Interval { get; set; }

        public List<ParibuCandle> Candles { get; set; }

        public ParibuChartData()
        {
            Candles = new List<ParibuCandle>();
        }
    } 
    
    public class ParibuCandle
    {
        public int OpenTime { get; set; }

        public DateTime OpenDateTime { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal Volume { get; set; }
    }

    internal class ChartData
    {
        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("t")]
        public IEnumerable<int> OpenTimeData { get; set; }

        [JsonProperty("c")]
        public IEnumerable<decimal> ClosePriceData { get; set; }

        [JsonProperty("v")]
        public IEnumerable<decimal> VolumeData { get; set; }
    }
}