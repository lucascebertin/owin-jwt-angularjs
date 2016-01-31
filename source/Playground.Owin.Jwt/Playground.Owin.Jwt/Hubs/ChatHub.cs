using Microsoft.AspNet.SignalR;
using Playground.Owin.Jwt.Models.Abstractions;

namespace Playground.Owin.Jwt.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ITest _Test;

        public ChatHub(ITest test)
        {
            _Test = test;
        }

        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
