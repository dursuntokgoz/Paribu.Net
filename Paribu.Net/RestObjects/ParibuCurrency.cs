using Newtonsoft.Json;
using Paribu.Net.Converters;
using Paribu.Net.Enums;

namespace Paribu.Net.RestObjects
{
    public class ParibuCurrency
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type"), JsonConverter(typeof(CurrencyTypeConverter))]
        public ParibuCurrencyType Type { get; set; }

        [JsonProperty("group"), JsonConverter(typeof(CurrencyGroupConverter))]
        public ParibuCurrencyGroup Group { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("displayDecimals")]
        public int DisplayDecimals { get; set; }

        [JsonProperty("deposit")]
        public ParibuCurrencyDeposit DepositOptions { get; set; }

        [JsonProperty("withdraw")]
        public ParibuCurrencyWithdraw WithdrawOptions { get; set; }
    }

    public class ParibuCurrencyDeposit
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("addressesAllowed")]
        public int AddressesAllowed { get; set; }

        [JsonProperty("confirmationsRequired")]
        public int ConfirmationsRequired { get; set; }
    }

    public class ParibuCurrencyWithdraw
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("minAmount")]
        public decimal MinAmount { get; set; }

        [JsonProperty("maxAmount")]
        public decimal MaxAmount { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("decimals")]
        public int Decimals { get; set; }
    }
}
