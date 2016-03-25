using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Playground.Owin.Jwt.Models.Abstractions;

namespace Playground.Owin.Jwt.Hubs
{
    public class ChatHub : Hub, IHub
    {
        private readonly ITest _test;

        public ChatHub(ITest test)
        {
            _test = test;
        }

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}
