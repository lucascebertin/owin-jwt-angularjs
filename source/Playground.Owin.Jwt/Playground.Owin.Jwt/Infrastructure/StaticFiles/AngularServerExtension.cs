using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using AppFunc = System.Func<
       System.Collections.Generic.IDictionary<string, object>,
       System.Threading.Tasks.Task>;

namespace Playground.Owin.Jwt.Infrastructure
{
    public static class AngularServerExtension
    {

        public static IAppBuilder UseAngularServer(this IAppBuilder builder, string rootPath, string entryPath)
        {
            var options = new AngularServerOptions()
            {
                FileServerOptions = new FileServerOptions()
                {
                    EnableDirectoryBrowsing = false,
                    FileSystem = new PhysicalFileSystem(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootPath))
                },
                EntryPath = new PathString(entryPath)
            };

            builder.UseDefaultFiles(options.FileServerOptions.DefaultFilesOptions);

            return builder.Use(new Func<AppFunc, AppFunc>(next => new AngularServerMiddleware(next, options).Invoke));
        }
    }
}