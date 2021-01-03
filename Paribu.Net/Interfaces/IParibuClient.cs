using CryptoExchange.Net.Objects;
using Paribu.Net.RestObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Paribu.Net.Interfaces
{
    public interface IParibuClient
    {
        IEnumerable<ParibuBanner> GetBanners(CancellationToken ct = default);
        ParibuChartData GetCandles(string pair, CancellationToken ct = default);
        Dictionary<string, ParibuCurrency> GetCurrencies(CancellationToken ct = default);
        ParibuDisplayGroups GetDisplayGroups(CancellationToken ct = default);
        ParibuExchangeConfig GetExchangeConfig(CancellationToken ct = default);
        WebCallResult<ParibuInitials> GetInitials(CancellationToken ct = default);
        Task<WebCallResult<ParibuInitials>> GetInitialsAsync(CancellationToken ct = default);
        Dictionary<string, ParibuInitialTicker> GetInitialTickers(CancellationToken ct = default);
        WebCallResult<ParibuMarketData> GetMarketData(string pair, CancellationToken ct = default);
        Task<WebCallResult<ParibuMarketData>> GetMarketDataAsync(string pair, CancellationToken ct = default);
        Dictionary<string, ParibuMarket> GetMarkets(CancellationToken ct = default);
        ParibuOrderBook GetOrderBook(string pair, CancellationToken ct = default);
        WebCallResult<Dictionary<string, ParibuTicker>> GetTickers(CancellationToken ct = default);
        Task<WebCallResult<Dictionary<string, ParibuTicker>>> GetTickersAsync(CancellationToken ct = default);
        IEnumerable<ParibuTrade> GetTrades(string pair, CancellationToken ct = default);
    }
}
