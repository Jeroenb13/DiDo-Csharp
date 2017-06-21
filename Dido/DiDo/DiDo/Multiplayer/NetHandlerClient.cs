using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace DiDo.Multiplayer
{
    class NetHandlerClient
    {
        private readonly HostName address;
        private readonly ushort port;

        public NetHandlerClient(HostName address, ushort port)
        {
            this.address = address;
            this.port = port;
        }

        public async Task ConnectAsync()
        {
            StreamSocket socket = new StreamSocket();

            await socket.ConnectAsync(this.address, this.port.ToString());
            
            Stream streamOut = socket.OutputStream.AsStreamForWrite();
            StreamWriter writer = new StreamWriter(streamOut);
            string request = "test";
            await writer.WriteLineAsync(request);
            await writer.FlushAsync();

            //Read data from the echo server.
            Stream streamIn = socket.InputStream.AsStreamForRead();
            StreamReader reader = new StreamReader(streamIn);
            string response = await reader.ReadLineAsync();
        }
    }
}
