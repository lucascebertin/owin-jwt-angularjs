using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Playground.Owin.Jwt.Hubs
{
    [Authorize]
    public class SecuredHub : Hub
    {
        public override Task OnConnected()
        {
            var h = Context.Headers;
            return base.OnConnected();
        }

        public void Secret(string data)
        {
            Clients.Caller.replySecret($"this is a secret: {data}");
        }
    }
}
