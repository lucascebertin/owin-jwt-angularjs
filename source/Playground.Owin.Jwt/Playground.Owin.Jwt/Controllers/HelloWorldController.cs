using Microsoft.AspNet.SignalR;
using Playground.Owin.Jwt.Hubs;
using Playground.Owin.Jwt.Models.Abstractions;
using System.Web.Http;

namespace Playground.Owin.Jwt.Controllers
{
    public class HelloWorldController : ApiController
    {
        private readonly ITest _Test;

        public HelloWorldController()
        {

        }

        //public HelloWorldController(ITest test)
        //{
        //    _Test = test;
        //}

        public IHttpActionResult Get(int? id = null)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hub.Clients.All.addMessage("id", id.HasValue ? id.Value.ToString() : "null");
            return Ok();
        }

        public IHttpActionResult Post()
        {
            return Ok();
        }

        public IHttpActionResult Put(int id)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
