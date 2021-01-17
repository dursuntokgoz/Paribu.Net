using Newtonsoft.Json;

namespace Paribu.Net.CoreObjects
{
    public class ParibuApiResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
