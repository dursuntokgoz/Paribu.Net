using System.Collections.Generic;

namespace Paribu.Net.SocketObjects
{
    public class ParibuSocketOrderBook
    {
        public string Pair { get; set; }

        public List<ParibuSocketOrderBookEntry> BidsToAdd { get; set; }
        public List<ParibuSocketOrderBookEntry> BidsToRemove { get; set; }

        public List<ParibuSocketOrderBookEntry> AsksToAdd { get; set; }
        public List<ParibuSocketOrderBookEntry> AsksToRemove { get; set; }

        public ParibuSocketOrderBook()
        {
            BidsToAdd = new List<ParibuSocketOrderBookEntry>();
            BidsToRemove = new List<ParibuSocketOrderBookEntry>();
            AsksToAdd = new List<ParibuSocketOrderBookEntry>();
            AsksToRemove = new List<ParibuSocketOrderBookEntry>();
        }
    }

    public class ParibuSocketOrderBookEntry
    {
        public decimal Amount { get; set; }
     
        public decimal Price { get; set; }
    }
}