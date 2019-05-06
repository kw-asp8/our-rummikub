using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    delegate void PacketHandler(Connection connection, Packet packet);

    class ConnectionClient : IConnectionOwner
    {
        private Dictionary<PacketType, List<PacketHandler>> packetHandlers
            = new Dictionary<PacketType, List<PacketHandler>>();

        public Connection Connection { get; private set; }

        public bool Connect(IPAddress ipAddress, int port)
        {
            Contract.Requires(Connection == null);

            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, port);

                if (tcpClient.Connected)
                {
                    Connection = new Connection(this, tcpClient.GetStream());
                    Connection.StartListening();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            Contract.Requires(Connection != null && !Connection.IsClosed);

            Connection.Dispose();
            Connection = null;
        }

        public void RegisterPacketHandler(PacketType packetType, PacketHandler handler)
        {
            Contract.Requires(handler != null);

            if (!packetHandlers.ContainsKey(packetType))
                packetHandlers[packetType] = new List<PacketHandler>();

            packetHandlers[packetType].Add(handler);
        }
        public void UnregisterPacketHandler(PacketType packetType, PacketHandler handler)
        {
            Contract.Requires(handler != null);
            Contract.Requires(packetHandlers.ContainsKey(packetType));

            packetHandlers[packetType].Remove(handler);
        }

        public void Handle(Connection connection, Packet packet)
        {
            if (packetHandlers.ContainsKey(packet.Type))
            {
                foreach (PacketHandler handler in packetHandlers[packet.Type])
                {
                    handler(connection, packet);
                }
            }
        }
    }
}
