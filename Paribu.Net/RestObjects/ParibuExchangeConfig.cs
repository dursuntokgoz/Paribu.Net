using Newtonsoft.Json;
using Paribu.Net.Attributes;
using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    public class ParibuExchangeConfig
    {
        [JsonProperty("easyMarkets")]
        public ParibuEasyMarkets EasyMarkets { get; set; }

        [JsonProperty("bankAccounts")]
        public ParibuBankAccounts BankAccounts { get; set; }
        
        [JsonProperty("papara")]
        public ParibuPapara Papara { get; set; }
        
        [JsonProperty("appVersions")]
        public ParibuAppVersion AppVersions { get; set; }
    }   
    
    [JsonConverter(typeof(TypedDataConverter<ParibuEasyMarkets>))]
    public class ParibuEasyMarkets
    {
        [TypedData]
        public Dictionary<string, ParibuLimit> Data { get; set; }
    }
    
    [JsonConverter(typeof(TypedDataConverter<ParibuBankAccounts>))]
    public class ParibuBankAccounts
    {
        [TypedData]
        public Dictionary<string, IEnumerable< ParibuBankAccount>> Data { get; set; }
    }
    
    public class ParibuLimit
    {
        [JsonProperty("limit")]
        public decimal Limit { get; set; }
    }
    
    public class ParibuBankAccount
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("iban")]
        public string IBAN { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
    
    public class ParibuAppVersion
    {
        [JsonProperty("latest")]
        public int Latest { get; set; }

        [JsonProperty("minRequired")]
        public int MinRequired { get; set; }
    }

    public class ParibuPapara
    {
        [JsonProperty("maxWithdraw")]
        public decimal MaxWithdraw { get; set; }
        
        [JsonProperty("minWithdraw")]
        public decimal MinWithdraw { get; set; }
        
        [JsonProperty("maxDeposit")]
        public decimal MaxDeposit { get; set; }
        
        [JsonProperty("minDeposit")]
        public decimal MinDeposit { get; set; }
        
        [JsonProperty("feePercent")]
        public decimal FeePercent { get; set; }
        
        [JsonProperty("taxPercent")]
        public decimal TaxPercent { get; set; }
        
        [JsonProperty("feeMaxCap")]
        public decimal FeeMaxCap { get; set; }
    }
}
