using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.IdentityModel.Tokens;

namespace Playground.Owin.Jwt.Infrastructure
{
    public class JwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly OAuthAuthorizationServerOptions _options;

        public JwtFormat(OAuthAuthorizationServerOptions options)
        {
            _options = options;
        }

        public string SignatureAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"; }
        }

        public string DigestAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmlenc#sha256"; }
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var issuer = "localhost";
            var audience = "all";
            var key = Convert.FromBase64String("VUh4TnRZTVJZd3ZmcE8xZFM1cFdMS0wwTTJEZ09qNDBFYk40U29CV2dmYw==");
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_options.AccessTokenExpireTimeSpan.TotalMinutes);
            var signingCredentials = new SigningCredentials(
                new InMemorySymmetricSecurityKey(key),
                SignatureAlgorithm,
                DigestAlgorithm
            );

            var token = new JwtSecurityToken(
                issuer, 
                audience, 
                data.Identity.Claims,
                now, 
                expires, 
                signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}