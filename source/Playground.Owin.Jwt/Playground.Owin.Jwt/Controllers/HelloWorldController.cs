using Microsoft.AspNet.SignalR;
using Playground.Owin.Jwt.Hubs;
using System.Web.Http;

namespace Playground.Owin.Jwt.Controllers
{
    public class HelloWorldController : ApiController
    {
        public HelloWorldController()
        {

        }

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
