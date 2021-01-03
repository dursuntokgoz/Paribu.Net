using CryptoExchange.Net.Objects;

namespace Paribu.Net.CoreObjects
{
    public class ParibuSocketClientOptions : SocketClientOptions
    {
        public ParibuSocketClientOptions(): base("wss://ws-eu.pusher.com/app/{appid}?protocol=7&client=js&version=5.1.1&flash=false")
        {
            SocketSubscriptionsCombineTarget = 1;
        }

        public ParibuSocketClientOptions Copy()
        {
            var copy = Copy<ParibuSocketClientOptions>();
            return copy;
        }
    }
}
