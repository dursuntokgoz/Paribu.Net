using CryptoExchange.Net.Converters;
using Paribu.Net.Enums;
using System.Collections.Generic;

namespace Paribu.Net.Converters
{
    internal class CurrencyTypeConverter : BaseConverter<ParibuCurrencyType>
    {
        public CurrencyTypeConverter() : this(true) { }
        public CurrencyTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<ParibuCurrencyType, string>> Mapping => new List<KeyValuePair<ParibuCurrencyType, string>>
        {
            new KeyValuePair<ParibuCurrencyType, string>(ParibuCurrencyType.Fiat, "fiat"),
            new KeyValuePair<ParibuCurrencyType, string>(ParibuCurrencyType.Crypto, "crypto"),
        };
    }
}