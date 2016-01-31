using DryIoc;
using DryIoc.SignalR;
using DryIoc.WebApi;
using Microsoft.AspNet.SignalR;
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
            var webApiConfig = new HttpConfiguration();
            var hubConfig = new HubConfiguration
            {
                EnableJSONP = true,
                EnableJavaScriptProxies = true
            };

            webApiConfig.MapHttpAttributeRoutes();
            webApiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            webApiConfig.EnableCors(
                new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE, PATCH")
            );

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = new WebPhysicalFileSystem(".\\wwwroot")
            };

            //******************
            var container = new Container();
            container.WithWebApi(webApiConfig);
            container.WithSignalR(hubConfig);
            //******************

            app.UseErrorPage(ErrorPageOptions.ShowAll)
                .UseCors(CorsOptions.AllowAll)
                .UseOAuthAuthorizationServer(new OAuthOptions())
                .UseJwtBearerAuthentication(new JwtOptions())
                .UseAngularServer("/", "/index.html")
                .UseFileServer(options)
                .UseWebApi(webApiConfig)
                .MapSignalR(hubConfig);
        }
    }
}
