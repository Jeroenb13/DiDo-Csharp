﻿using DiDoCommon.Network.Packet;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DiDoCommon.Network
{
    class ConnectionHandler
    {
        public Socket ClientSocket { get; private set; }
        public byte[] ReceiveBuffer { get; internal set; }
        public bool ParsingPacket { get; internal set; }
        public ushort ParsingPacketId { get; internal set; }

        public ConnectionHandler(Socket clientSocket)
        {
            this.ClientSocket = clientSocket;
            this.ParsingPacket = false;
        }
        
        internal void ParsePacket(HeapByteBuf body)
        {
            ushort type = this.ParsingPacketId;
            AbstractPacket packet = PacketRegistry.CreateInstance(type);
            packet.ReadFrom(body);
            this.HandlePacket(packet);
        }

        internal void HandlePacket(AbstractPacket packet)
        {
            if(packet is PacketPlayerLogin){
                PacketPlayerLogin p = (PacketPlayerLogin)packet;
                //p.Username
            }
        }
    }
}
