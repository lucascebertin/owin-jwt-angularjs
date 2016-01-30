using Microsoft.Owin.Security.Jwt;
using System;

namespace Playground.Owin.Jwt.Infrastructure
{
    public class JwtOptions : JwtBearerAuthenticationOptions
    {
        public JwtOptions()
        {
            var issuer = "localhost";
            var audience = "all";
            var key = Convert.FromBase64String("VUh4TnRZTVJZd3ZmcE8xZFM1cFdMS0wwTTJEZ09qNDBFYk40U29CV2dmYw==");

            AllowedAudiences = new[] { audience };
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(issuer, key)
            };
        }
    }
}