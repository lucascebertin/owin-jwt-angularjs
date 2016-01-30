using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Playground.Owin.Jwt.Infrastructure
{
    public class OAuthProvider : OAuthAuthorizationServerProvider, IOAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity("otc");
            var username = context.OwinContext.Get<string>("otc:username");
            identity.AddClaim(new Claim(ClaimTypes.Name, username)); 
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            context.Validated(identity);
            return Task.FromResult(0);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var settings = ConfigurationManager.AppSettings;
                
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];

                if (username == settings["username"] && password == settings["password"])
                {
                    context.OwinContext.Set("otc:username", username);
                    context.Validated();
                }
                else
                {
                    context.SetError("Invalid credentials");
                    context.Rejected();
                }
            }
            catch
            {
                context.SetError("Server error");
                context.Rejected();
            }
            return Task.FromResult(0);
        }
    }
}