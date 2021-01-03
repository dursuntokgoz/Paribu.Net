using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Paribu.Net.CoreObjects;

namespace Paribu.Net.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rest Api Client
            var api = new ParibuClient();

            /* Initials Data */
            var p01 = api.GetInitials();
            var p02 = api.GetBanners();
            var p03 = api.GetDisplayGroups();
            var p04 = api.GetExchangeConfig();
            var p05 = api.GetCurrencies();
            var p06 = api.GetMarkets();
            var p07 = api.GetInitialTickers();

            /* Ticker Data */
            var p11 = api.GetTickers();

            /* Market Data */
            var p21 = api.GetMarketData("btc-tl");
            var p22 = api.GetCandles("btc-tl");
            var p23 = api.GetOrderBook("btc-tl");
            var p24 = api.GetTrades("btc-tl");

            // Web Socket Feeds Client
            var ws = new ParibuSocketClient();
            ws.SetPusherApplicationId("a68d528f48f652c94c88"); // Dont Change Application Id

            // Tickers
            var sub01 = ws.SubscribeToTickers((data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"Ticker State >> {data.Pair} " +
                        (data.Open.HasValue ? $"O:{data.Open} " : "") +
                        (data.High.HasValue ? $"H:{data.High} " : "") +
                        (data.Low.HasValue ? $"L:{data.Low} " : "") +
                        (data.Close.HasValue ? $"C:{data.Close} " : "") +
                        (data.Volume.HasValue ? $"V:{data.Volume} " : "") +
                        (data.Change.HasValue ? $"CH:{data.Change} " : "") +
                        (data.ChangePercent.HasValue ? $"CP:{data.ChangePercent} " : "") +
                        (data.Average24H.HasValue ? $"Avg:{data.Average24H} " : "") +
                        (data.VolumeQuote.HasValue ? $"G:{data.VolumeQuote} " : "") +
                        (data.Bid.HasValue ? $"Bid:{data.Bid} " : "") +
                        (data.Ask.HasValue ? $"Ask:{data.Ask} " : "") +
                        (data.EBid.HasValue ? $"EBid:{data.EBid} " : "") +
                        (data.EAsk.HasValue ? $"EAsk:{data.EAsk} " : "")
                        );
                }
            }, (data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"Ticker Prices >> {data.Pair} C:{data.Prices.Count()} P:{string.Join(',', data.Prices)}");
                }
            });

            // Order Book & Trades
            var sub02 = ws.SubscribeToMarketData("btc-tl", (data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"Book Update >> {data.Pair} " +
                        $"AsksToAdd:{data.AsksToAdd.Count} " +
                        $"BidsToAdd:{data.BidsToAdd.Count} " +
                        $"AsksToRemove:{data.AsksToRemove.Count} " +
                        $"BidsToRemove:{data.BidsToRemove.Count} "
                        );
                }
            }, (data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"New Trade >> {data.Pair} T:{data.Timestamp} P:{data.Price} A:{data.Amount} S:{data.Side}");
                }
            });

            // Unsubscribe
            _ = ws.Unsubscribe(sub02.Data);

            // Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}