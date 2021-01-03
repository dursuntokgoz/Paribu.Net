using Newtonsoft.Json;

namespace Paribu.Net.RestObjects
{
    public class ParibuBanner
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [JsonProperty("buttonHref")]
        public string ButtonHref { get; set; }

        [JsonProperty("navigateTo")]
        public ParibuBannerNavigate NavigateTo { get; set; }
    }

    public class ParibuBannerNavigate
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("arguments")]
        public ParibuBannerNavigateArguments Arguments { get; set; }
    }

    public class ParibuBannerNavigateArguments
    {
        [JsonProperty("screen")]
        public string Screen { get; set; }

        [JsonProperty("params")]
        public ParibuBannerNavigateArgumentsParams Params { get; set; }
    }

    public class ParibuBannerNavigateArgumentsParams
    {
        [JsonProperty("marketKey")]
        public string MarketKey { get; set; }
    }
}
