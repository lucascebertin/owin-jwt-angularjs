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
