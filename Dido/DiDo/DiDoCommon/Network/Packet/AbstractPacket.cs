using System;
using System.Collections.Generic;
using System.Text;

namespace DiDoCommon.Network.Packet
{
    internal abstract class AbstractPacket
    {
        internal ushort Id { get; set; }

        public abstract void ReadFrom(HeapByteBuf buffer);

        public abstract void WriteTo(HeapByteBuf buffer);
    }
}
