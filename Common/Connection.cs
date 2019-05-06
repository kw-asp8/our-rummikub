using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common
{
    public class Connection : IDisposable
    {
        public const int BufferSize = 1024 * 4;

        private IConnectionOwner owner;
        private NetworkStream networkStream;
        private byte[] sendBuffer = new byte[BufferSize];
        private Thread listeningThread;

        public bool IsClosed { get; private set; } = false;

        public Connection(IConnectionOwner owner, NetworkStream networkStream)
        {
            Contract.Requires(owner != null);
            Contract.Requires(networkStream != null);

            this.owner = owner;
            this.networkStream = networkStream;
            for (int i = 0; i < BufferSize; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public void StartListening()
        {
            Contract.Requires(listeningThread == null);

            listeningThread = new Thread(new ThreadStart(ListenPacket));
            listeningThread.Start();
        }

        public void StopListening()
        {
            Contract.Requires(listeningThread != null && listeningThread.IsAlive);

            listeningThread.Abort();
            listeningThread = null;
        }

        public void Send(Packet packet)
        {
            Contract.Requires(packet != null);

            Packet.Serialize(packet).CopyTo(sendBuffer, 0);
            networkStream.Write(sendBuffer, 0, sendBuffer.Length);
            networkStream.Flush();

            for (int i = 0; i < BufferSize; i++)
            {
                sendBuffer[i] = 0;
            }
        }

        private void ListenPacket()
        {
            byte[] readBuffer = new byte[BufferSize];
            int packetLength = 0;

            while (true)
            {
                try
                {
                    packetLength = 0;
                    packetLength = networkStream.Read(readBuffer, 0, BufferSize);
                }
                catch
                {
                    break;
                }

                if (packetLength > 0)
                {
                    Packet packet = (Packet)Packet.Deserialize(readBuffer);
                    owner.Handle(this, packet);
                }
                else
                {
                    break;
                }
            }

            IsClosed = true;
            owner.HandleDisconnection(this);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    networkStream.Close();
                    StopListening();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
