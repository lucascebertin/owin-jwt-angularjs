using Microsoft.AspNet.SignalR;

namespace Playground.Owin.Jwt.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
