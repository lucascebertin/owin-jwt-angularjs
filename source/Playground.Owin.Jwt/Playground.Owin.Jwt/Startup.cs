using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.StaticFiles;
using Owin;
using Playground.Owin.Jwt.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(Playground.Owin.Jwt.Startup))]

namespace Playground.Owin.Jwt
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors(
                new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE, PATCH")
            );

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = new WebPhysicalFileSystem(".\\wwwroot")
            };


            app.UseErrorPage(ErrorPageOptions.ShowAll)
                .UseCors(CorsOptions.AllowAll)
                .UseOAuthAuthorizationServer(new OAuthOptions())
                .UseJwtBearerAuthentication(new JwtOptions())
                .UseAngularServer("/", "/index.html")
                .UseFileServer(options)
                .UseWebApi(config);
        }
    }
}
