using System;
using System.Collections.Generic;
using System.Text;

namespace DiDoCommon.Network.Packet
{
    class PacketPlayerLogin : AbstractPacket
    {
        public string Username { get; set; }

        public PacketPlayerLogin() { }

        public PacketPlayerLogin(string username)
        {
            this.Username = username;
        }

        public override void ReadFrom(HeapByteBuf buffer)
        {
            this.Username = buffer.ReadString();
        }

        public override void WriteTo(HeapByteBuf buffer)
        {
            buffer.WriteString(this.Username);
        }
    }
}
