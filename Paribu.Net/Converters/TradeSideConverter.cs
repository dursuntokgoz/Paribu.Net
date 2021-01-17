using CryptoExchange.Net.Converters;
using Paribu.Net.Enums;
using System.Collections.Generic;

namespace Paribu.Net.Converters
{
    public class TradeSideConverter : BaseConverter<ParibuTradeSide>
    {
        public TradeSideConverter() : this(true) { }
        public TradeSideConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<ParibuTradeSide, string>> Mapping => new List<KeyValuePair<ParibuTradeSide, string>>
        {
            new KeyValuePair<ParibuTradeSide, string>(ParibuTradeSide.Buy, "buy"),
            new KeyValuePair<ParibuTradeSide, string>(ParibuTradeSide.Sell, "sell"),
        };
    }
}