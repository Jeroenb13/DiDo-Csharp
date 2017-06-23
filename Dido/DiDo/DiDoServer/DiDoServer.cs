using DiDoCommon.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiDoServer
{
    public class DiDoServer
    {
        private readonly List<ConnectionHandler> clientConnections = new List<ConnectionHandler>();
        private readonly ManualResetEvent connectionEstablished = new ManualResetEvent(false);

        public void Listen(IPAddress listenAddress, UInt16 port)
        {
            Socket serverSocket = null;
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(listenAddress, port));
                serverSocket.Listen(128);

                while (true)
                {
                    this.connectionEstablished.Reset();

                    serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);

                    this.connectionEstablished.WaitOne();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            this.connectionEstablished.Set();

            try
            {
                Socket serverSocket = (Socket)ar.AsyncState;
                Socket clientSocket = serverSocket.EndAccept(ar);
                ConnectionHandler connHandler = new ConnectionHandler(clientSocket);
                this.clientConnections.Add(connHandler);

                Console.WriteLine("Client connected");

                connHandler.ReceiveBuffer = new byte[4];
                clientSocket.BeginReceive(connHandler.ReceiveBuffer, 0, connHandler.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(HeaderCallback), connHandler);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private void HeaderCallback(IAsyncResult ar)
        {
            try
            {
                int received = 0;
                ConnectionHandler connHandler = (ConnectionHandler)ar.AsyncState;
                received = connHandler.ClientSocket.EndReceive(ar);

                if (received == 0)
                {
                    return;
                }

                HeapByteBuf headerBuffer = new HeapByteBuf(connHandler.ReceiveBuffer, received);

                ushort type = headerBuffer.ReadUnsignedShort();
                ushort length = headerBuffer.ReadUnsignedShort();

                connHandler.ParsingPacket = true;
                connHandler.ParsingPacketId = type;

                connHandler.ReceiveBuffer = new byte[length];
                connHandler.ClientSocket.BeginReceive(connHandler.ReceiveBuffer, 0, connHandler.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(BodyCallback), connHandler);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private void BodyCallback(IAsyncResult ar)
        {
            try
            {
                int received = 0;
                ConnectionHandler connHandler = (ConnectionHandler)ar.AsyncState;
                received = connHandler.ClientSocket.EndReceive(ar);

                if (received == 0)
                {
                    return;
                }

                HeapByteBuf bodyBuffer = new HeapByteBuf(connHandler.ReceiveBuffer, received);

                connHandler.ParsePacket(bodyBuffer);

                connHandler.ParsingPacket = false;
                connHandler.ReceiveBuffer = new byte[4];
                connHandler.ClientSocket.BeginReceive(connHandler.ReceiveBuffer, 0, connHandler.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(HeaderCallback), connHandler);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }
    }
}
