using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    delegate void PacketHandler(Connection connection, Packet packet);
    delegate void AcceptionHandler(Connection connection);

    class ConnectionServer : IConnectionOwner
    {
        private TcpListener tcpListener;
        private Thread acceptingThread = null;
        private Dictionary<PacketType, List<PacketHandler>> packetHandlers
            = new Dictionary<PacketType, List<PacketHandler>>();

        public HashSet<Connection> Connections { get; private set; } = new HashSet<Connection>();

        public List<AcceptionHandler> OnAccept { get; set; } = new List<AcceptionHandler>();

        public bool IsAlive { get; set; } = false;

        public ConnectionServer(IPAddress ipAddress, int port)
        {
            tcpListener = new TcpListener(ipAddress, port);
        }

        public void Start()
        {
            Contract.Requires(!this.IsAlive);
            Contract.Requires(acceptingThread == null);

            tcpListener.Start();

            acceptingThread = new Thread(new ThreadStart(AcceptClients));
            acceptingThread.Start();
            IsAlive = true;
        }

        public void Stop()
        {
            Contract.Requires(this.IsAlive);
            Contract.Requires(acceptingThread != null && acceptingThread.IsAlive);

            tcpListener.Stop();
            lock (Connections)
            {
                foreach (Connection connection in Connections)
                {
                    connection.Dispose();
                }
            }
            acceptingThread.Abort();
            acceptingThread = null;
            IsAlive = false;
        }

        private void AcceptClients()
        {
            while (true)
            {
                TcpClient client;
                try
                {
                    client = tcpListener.AcceptTcpClient();
                }
                catch
                {
                    break;
                }

                if (client.Connected)
                {
                    Connection connection = new Connection(this, client.GetStream());
                    connection.StartListening();

                    Connections.Add(connection);

                    foreach (AcceptionHandler handler in OnAccept)
                        handler(connection);

                    connection.OnDisconnect.Add((disconnectedConnection) =>
                    {
                        lock (Connections)
                        {
                            Connections.Remove(disconnectedConnection);
                        }
                    });
                    Console.WriteLine("Connected to a client!");
                }
            }
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
