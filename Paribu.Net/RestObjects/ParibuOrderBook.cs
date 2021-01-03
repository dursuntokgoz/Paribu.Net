using System.Collections.Generic;

namespace Paribu.Net.RestObjects
{
    public class ParibuOrderBook
    {
        public List<ParibuOrderBookEntry> Bids { get; set; }

        public List<ParibuOrderBookEntry> Asks { get; set; }

        public ParibuOrderBook()
        {
            Bids = new List<ParibuOrderBookEntry>();
            Asks = new List<ParibuOrderBookEntry>();
        }
    }

    public class ParibuOrderBookEntry
    {
        public decimal Amount { get; set; }
     
        public decimal Price { get; set; }
    }
}