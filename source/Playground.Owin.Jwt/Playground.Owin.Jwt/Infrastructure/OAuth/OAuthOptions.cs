using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Playground.Owin.Jwt.Infrastructure
{
    public class OAuthOptions : OAuthAuthorizationServerOptions
    {
        public OAuthOptions()
        {
            TokenEndpointPath = new PathString("/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new JwtFormat(this);
            Provider = new OAuthProvider();
            AllowInsecureHttp = true;
        }
    }
}