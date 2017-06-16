using System.Net;

namespace DiDoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            DiDoServer server = new DiDoServer();
            server.Listen(IPAddress.Any, 13000);
        }
    }
}
