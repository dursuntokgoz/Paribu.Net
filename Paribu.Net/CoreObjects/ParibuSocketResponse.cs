using Newtonsoft.Json;

namespace Paribu.Net.CoreObjects
{
    public class ParibuSocketResponse
    {
        [JsonProperty("event")]
        internal string Event { get; set; }

        [JsonProperty("data")]
        internal string Data { get; set; }

        [JsonProperty("channel")]
        internal string Channel { get; set; }
    }
}
