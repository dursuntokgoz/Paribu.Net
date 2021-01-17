using Newtonsoft.Json;

namespace Paribu.Net.CoreObjects
{
    public class ParibuSocketResponse
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
