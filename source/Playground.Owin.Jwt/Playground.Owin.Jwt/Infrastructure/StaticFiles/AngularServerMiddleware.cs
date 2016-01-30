using Microsoft.Owin.StaticFiles;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFunc = System.Func<
       System.Collections.Generic.IDictionary<string, object>,
       System.Threading.Tasks.Task>; 

namespace Playground.Owin.Jwt.Infrastructure
{
    public class AngularServerMiddleware
    {
        private readonly AngularServerOptions _options;
        private readonly AppFunc _next;
        private readonly StaticFileMiddleware _innerMiddleware;

        public AngularServerMiddleware(AppFunc next, AngularServerOptions options)
        {
            _next = next;
            _options = options;

            _innerMiddleware = new StaticFileMiddleware(next, options.FileServerOptions.StaticFileOptions);
        }

        public async Task Invoke(IDictionary<string, object> arg)
        {
            await _innerMiddleware.Invoke(arg);

            if ((int)arg["owin.ResponseStatusCode"] == 404 && _options.Html5Mode)
            {
                arg["owin.RequestPath"] = _options.EntryPath.Value;
                await _innerMiddleware.Invoke(arg);
            }
        }
    }
}