using Microsoft.AspNet.SignalR;

namespace Playground.Owin.Jwt.Hubs
{
    [Authorize]
    public class SecuredHub : Hub
    {
        public void Secret(string data)
        {
            Clients.Caller.replySecret($"this is a secret: {data}");
        }
    }
}
