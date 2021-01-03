using Newtonsoft.Json;

namespace Paribu.Net.CoreObjects
{
    internal class ParibuApiResponse<T>
    {
        [JsonProperty("success")]
        internal bool Success { get; set; }

        [JsonProperty("message")]
        internal string ErrorMessage { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
