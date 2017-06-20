using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Multiplayer
{
    class NetHandlerClient
    {
        private readonly IPAddress address;
        private readonly ushort port;

        public NetHandlerClient(IPAddress address, ushort port)
        {
            this.address = address;
            this.port = port;
        }

        public void Connect()
        {

        }
    }
}
