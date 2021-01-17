using CryptoExchange.Net.Converters;
using Paribu.Net.Enums;
using System.Collections.Generic;

namespace Paribu.Net.Converters
{
    public class MarketGroupConverter : BaseConverter<ParibuMarketGroup>
    {
        public MarketGroupConverter() : this(true) { }
        public MarketGroupConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<ParibuMarketGroup, string>> Mapping => new List<KeyValuePair<ParibuMarketGroup, string>>
        {
            new KeyValuePair<ParibuMarketGroup, string>(ParibuMarketGroup.CryptoTL, "crypto-tl"),
            new KeyValuePair<ParibuMarketGroup, string>(ParibuMarketGroup.FanTokenCHZ, "fantoken-chz"),
        };
    }
}