using DiDoCommon.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DiDoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("0.0.0.0");
                
                server = new TcpListener(localAddr, port);
                server.Start();
                
                Byte[] bytes = new Byte[256];
                String data = null;
                
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;
                    
                    NetworkStream stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);

                    while (true)
                    {
                        int type = reader.ReadInt16();
                        int length = reader.ReadInt16();
                        HeapByteBuf buf = new HeapByteBuf(reader.ReadBytes(length), length);

                        Console.WriteLine("Packet type: " + type + " length: " + length);
                    }
                    
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
