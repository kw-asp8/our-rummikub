using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            ConnectionServer server = new ConnectionServer(IPAddress.Parse("127.0.0.1"), 7777);
            server.RegisterPacketHandler(PacketType.SB_SendChat, (connection, packet) =>
            {
                var sendChatToServer = (SendChatToServerPacket)packet;
                Console.WriteLine(sendChatToServer.Message);

                var sendChatToClient = new SendChatToClientPacket("annonymous", sendChatToServer.Message);
                foreach (Connection everyConnection in server.Connections)
                {
                    everyConnection.Send(sendChatToClient);
                }
            });

            server.Start();
            Console.WriteLine("Server has been started!");

            while (true)
            {
                //Console.Write("> ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "stop":
                        server.Stop();
                        Console.WriteLine("Server has been stopped.");
                        return;
                }
            }
        }
    }
}
