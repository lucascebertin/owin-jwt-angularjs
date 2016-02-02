using Microsoft.Owin;
using System.Threading.Tasks;

namespace Playground.Owin.Jwt.Infrastructure.QueryStrings
{
    public class OwinMiddleWareQueryStringExtractor : OwinMiddleware
    {
        public OwinMiddleWareQueryStringExtractor(OwinMiddleware next)
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.Path.Value.StartsWith("/signalr"))
            {
                string bearerToken = context.Request.Query.Get("bearer_token");
                if (bearerToken != null)
                {
                    string[] authorization = { "Bearer " + bearerToken };
                    context.Request.Headers.Add("Authorization", authorization);
                }
            }

            await Next.Invoke(context);
        }
    }
}
