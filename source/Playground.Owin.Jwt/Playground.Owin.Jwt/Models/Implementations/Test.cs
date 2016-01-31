using Playground.Owin.Jwt.Models.Abstractions;
using System.Diagnostics;

namespace Playground.Owin.Jwt.Models.Implementations
{
    public class Test : ITest
    {
        public void TestIt()
        {
            Debug.WriteLine("test");
        }
    }
}
