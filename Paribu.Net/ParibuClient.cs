using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json.Linq;
using Paribu.Net.CoreObjects;
using Paribu.Net.Helpers;
using Paribu.Net.Interfaces;
using Paribu.Net.RestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Paribu.Net
{
    public class ParibuClient : RestClient, IRestClient, IParibuClient
    {
        #region Fields
        protected static ParibuClientOptions defaultOptions = new ParibuClientOptions();
        protected static ParibuClientOptions DefaultOptions => defaultOptions.Copy();

        // Endpoints
        protected const string Endpoints_Public_Initials = "app/initials";
        protected const string Endpoints_Public_Markets = "app/markets/{pair}";
        protected const string Endpoints_Public_Ticker = "ticker";
        #endregion

        #region Constructor / Destructor
        /// <summary>
        /// Create a new instance of ParibuClient using the default options
        /// </summary>
        public ParibuClient() : this(DefaultOptions)
        {
            requestBodyFormat = RequestBodyFormat.FormData;
        }

        /// <summary>
        /// Create a new instance of the ParibuClient with the provided options
        /// </summary>
        public ParibuClient(ParibuClientOptions options) : base("Paribu", options, null)
        {
            requestBodyFormat = RequestBodyFormat.FormData;
            arraySerialization = ArrayParametersSerialization.MultipleValues;
        }
        #endregion

        #region Core Methods
        /// <summary>
        /// Sets the default options to use for new clients
        /// </summary>
        /// <param name="options">The options to use for new clients</param>
        public static void SetDefaultOptions(ParibuClientOptions options)
        {
            defaultOptions = options;
        }
        #endregion

        #region Api Methods
        public virtual IEnumerable<ParibuBanner> GetBanners(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.Banners;
        public virtual ParibuDisplayGroups GetDisplayGroups(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.DisplayGroups;
        public virtual ParibuExchangeConfig GetExchangeConfig(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.ExchangeConfig;
        public virtual Dictionary<string, ParibuCurrency> GetCurrencies(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.Currencies.Data;
        public virtual Dictionary<string, ParibuMarket> GetMarkets(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.Markets.Data;
        public virtual Dictionary<string, ParibuInitialTicker> GetInitialTickers(CancellationToken ct = default) => GetInitialsAsync(ct).Result.Data.Tickers.Data;
        public virtual WebCallResult<ParibuInitials> GetInitials(CancellationToken ct = default) => GetInitialsAsync(ct).Result;
        public virtual async Task<WebCallResult<ParibuInitials>> GetInitialsAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<ParibuApiResponse<ParibuInitials>>(GetUrl(Endpoints_Public_Initials), method: HttpMethod.Get, cancellationToken: ct, checkResult: false, signed: false).ConfigureAwait(false);
            if (!result.Success) return WebCallResult<ParibuInitials>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);

            return new WebCallResult<ParibuInitials>(result.ResponseStatusCode, result.ResponseHeaders, result.Data.Data, null);
        }

        public virtual WebCallResult<Dictionary<string, ParibuTicker>> GetTickers(CancellationToken ct = default) => GetTickersAsync(ct).Result;
        public virtual async Task<WebCallResult<Dictionary<string, ParibuTicker>>> GetTickersAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<ParibuTickers>(GetUrl(Endpoints_Public_Ticker), method: HttpMethod.Get, cancellationToken: ct, checkResult: false, signed: false).ConfigureAwait(false);
            if (!result.Success) return WebCallResult<Dictionary<string, ParibuTicker>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);

            return new WebCallResult<Dictionary<string, ParibuTicker>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data.Data, null);
        }

        public virtual ParibuChartData GetCandles(string pair, CancellationToken ct = default) => GetMarketDataAsync(pair, ct).Result.Data.ChartData;
        public virtual ParibuOrderBook GetOrderBook(string pair, CancellationToken ct = default) => GetMarketDataAsync(pair, ct).Result.Data.OrderBook;
        public virtual IEnumerable<ParibuTrade> GetTrades(string pair, CancellationToken ct = default) => GetMarketDataAsync(pair, ct).Result.Data.Trades;
        public virtual WebCallResult<ParibuMarketData> GetMarketData(string pair, CancellationToken ct = default) => GetMarketDataAsync(pair, ct).Result;
        public virtual async Task<WebCallResult<ParibuMarketData>> GetMarketDataAsync(string pair, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "interval", "1d" },
            };
            var result = await SendRequest<ParibuApiResponse<MarketData>>(GetUrl(Endpoints_Public_Markets.Replace("{pair}", pair.ToLower())), method: HttpMethod.Get, cancellationToken: ct, checkResult: false, signed: false, parameters: parameters).ConfigureAwait(false);
            if (!result.Success) return WebCallResult<ParibuMarketData>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);

            var pmd = new ParibuMarketData
            {
                ChartData = new ParibuChartData(),
                OrderBook = new ParibuOrderBook(),
                Trades = result.Data.Data.Trades,
            };

            // Candles
            var min = result.Data.Data.ChartData.OpenTimeData.Count();
            min = Math.Min(min, result.Data.Data.ChartData.VolumeData.Count());
            min = Math.Min(min, result.Data.Data.ChartData.ClosePriceData.Count());
            pmd.ChartData.Market = result.Data.Data.ChartData.Market;
            pmd.ChartData.Interval = result.Data.Data.ChartData.Interval;
            for (var i = 0; i < min; i++)
            {
                pmd.ChartData.Candles.Add(new ParibuCandle
                {
                    OpenTime = result.Data.Data.ChartData.OpenTimeData.ElementAt(i),
                    OpenDateTime = result.Data.Data.ChartData.OpenTimeData.ElementAt(i).FromUnixTimeSeconds(),
                    ClosePrice = result.Data.Data.ChartData.ClosePriceData.ElementAt(i),
                    Volume = result.Data.Data.ChartData.VolumeData.ElementAt(i),
                });
            }

            // Order Book
            foreach (var ask in result.Data.Data.OrderBook.Asks.Data) pmd.OrderBook.Asks.Add(new ParibuOrderBookEntry { Price = ask.Key, Amount = ask.Value });
            foreach (var bid in result.Data.Data.OrderBook.Bids.Data) pmd.OrderBook.Bids.Add(new ParibuOrderBookEntry { Price = bid.Key, Amount = bid.Value });

            return new WebCallResult<ParibuMarketData>(result.ResponseStatusCode, result.ResponseHeaders, pmd, null);
        }
        #endregion

        #region Protected Methods
        protected override Error ParseErrorResponse(JToken error)
        {
            return this.ParibuParseErrorResponse(error);
        }
        protected virtual Error ParibuParseErrorResponse(JToken error)
        {
            if (error["message"] == null)
                return new ServerError(error.ToString());

            return new ServerError((string)error["message"]);
        }

        protected virtual Uri GetUrl(string endpoint)
        {
            return new Uri($"{BaseAddress.TrimEnd('/')}/{endpoint}");
        }
        #endregion

    }
}
