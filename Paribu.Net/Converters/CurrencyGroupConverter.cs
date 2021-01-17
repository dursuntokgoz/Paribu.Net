using CryptoExchange.Net.Converters;
using Paribu.Net.Enums;
using System.Collections.Generic;

namespace Paribu.Net.Converters
{
    public class CurrencyGroupConverter : BaseConverter<ParibuCurrencyGroup>
    {
        public CurrencyGroupConverter() : this(true) { }
        public CurrencyGroupConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<ParibuCurrencyGroup, string>> Mapping => new List<KeyValuePair<ParibuCurrencyGroup, string>>
        {
            new KeyValuePair<ParibuCurrencyGroup, string>(ParibuCurrencyGroup.Fiat, "fiat"),
            new KeyValuePair<ParibuCurrencyGroup, string>(ParibuCurrencyGroup.Crypto, "crypto"),
            new KeyValuePair<ParibuCurrencyGroup, string>(ParibuCurrencyGroup.FanToken, "fantoken"),
        };
    }
}