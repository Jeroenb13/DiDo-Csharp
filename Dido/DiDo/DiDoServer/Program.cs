using System.Net;

namespace DiDoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            DiDoServer server = new DiDoServer(IPAddress.Any, 13000);
            server.Start();
        }
    }
}
