using Microsoft.Owin.FileSystems;
using System.Collections.Generic;

namespace Playground.Owin.Jwt.Infrastructure
{
    public class WebPhysicalFileSystem : IFileSystem
    {
        private PhysicalFileSystem InnerFileSystem { get; set; }
        private string Default { get; set; }

        public WebPhysicalFileSystem(string root, string defaultFile = "index.html")
        {
            InnerFileSystem = new PhysicalFileSystem(root);
            Default = defaultFile;
        }

        public bool TryGetDirectoryContents(string subpath, out IEnumerable<IFileInfo> contents)
        {
            if (InnerFileSystem.TryGetDirectoryContents(subpath, out contents))
            {
                return true;
            }

            string defaultPath = System.IO.Path.Combine(InnerFileSystem.Root, Default);
            return InnerFileSystem.TryGetDirectoryContents(defaultPath, out contents);
        }

        public bool TryGetFileInfo(string subpath, out IFileInfo fileInfo)
        {
            if (InnerFileSystem.TryGetFileInfo(subpath, out fileInfo))
            {
                return true;
            }

            string defaultPath = System.IO.Path.Combine(InnerFileSystem.Root, Default);
            return InnerFileSystem.TryGetFileInfo(defaultPath, out fileInfo);
        }
    }
}