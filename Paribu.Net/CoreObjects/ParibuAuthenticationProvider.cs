using CryptoExchange.Net.Authentication;
using System;

namespace Paribu.Net.CoreObjects
{
    public class ParibuAuthenticationProvider : AuthenticationProvider
    {
        public ParibuAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Key == null || credentials.Secret == null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");
        }
    }
}