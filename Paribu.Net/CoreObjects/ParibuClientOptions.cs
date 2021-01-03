using CryptoExchange.Net.Objects;

namespace Paribu.Net.CoreObjects
{
    public class ParibuClientOptions: RestClientOptions
    {
        public ParibuClientOptions():base("https://www.paribu.com")
        {
        }

        public ParibuClientOptions Copy()
        {
            return Copy<ParibuClientOptions>();
        }
    }
}
