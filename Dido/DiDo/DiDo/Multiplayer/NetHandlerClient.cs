using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DiDoCommon.Network.Packet;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using DiDoCommon.Network;

namespace DiDo.Multiplayer
{
    class NetHandlerClient
    {
        private readonly HostName address;
        private readonly ushort port;

        private StreamSocket socket;

        public NetHandlerClient(HostName address, ushort port)
        {
            this.address = address;
            this.port = port;
        }

        public async Task ConnectAsync()
        {
            this.socket = new StreamSocket();

            await this.socket.ConnectAsync(this.address, this.port.ToString());
        }

        internal async Task SendPacketAsync(AbstractPacket packet)
        {
            DataWriter writer;
            
            using (writer = new DataWriter(socket.OutputStream))
            {
                writer.ByteOrder = ByteOrder.BigEndian;

                HeapByteBuf dataBuf = new HeapByteBuf(16, 4096);
                packet.WriteTo(dataBuf);

                writer.WriteUInt16(packet.Id);
                writer.WriteUInt16((ushort) dataBuf.WriterIndex);
                writer.WriteBytes(dataBuf.GetBackingArray());
                
                try
                {
                    await writer.StoreAsync();
                }
                catch (Exception exception)
                {}

                await writer.FlushAsync();
                writer.DetachStream();
            }
        }

        internal async void ReadAsync()
        {
            DataReader reader;
            StringBuilder strBuilder;

            using (reader = new DataReader(socket.InputStream))
            {
                strBuilder = new StringBuilder();
                reader.ByteOrder = ByteOrder.BigEndian;

                await reader.LoadAsync(4);

                ushort packetId = reader.ReadUInt16();
                ushort length = reader.ReadUInt16();

                await reader.LoadAsync(length);

                byte[] data = new byte[length];
                reader.ReadBytes(data);

                HeapByteBuf buf = new HeapByteBuf(data, length);
                this.ParsePacket(buf, packetId);

                reader.DetachStream();
            }
        }

        internal void ParsePacket(HeapByteBuf body, ushort packetId)
        {
            AbstractPacket packet = PacketRegistry.CreateInstance(packetId);
            packet.ReadFrom(body);
            this.HandlePacket(packet);
        }

        internal void HandlePacket(AbstractPacket packet)
        {
            if (packet is PacketPlayerLogin)
            {
                PacketPlayerLogin p = (PacketPlayerLogin)packet;
                //p.Username
            }
        }
    }
}
