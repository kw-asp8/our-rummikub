using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Common
{
    public enum PacketType
    {
        SB_StartGame = 0,
        SB_SendChat,
        CB_SendChat
    }

    [Serializable]
    public class StartGamePacket : Packet
    {
        public StartGamePacket() : base(PacketType.SB_StartGame)
        {
            
        }
    }

    [Serializable]
    public class SendChatToServerPacket : Packet
    {
        public string Message { get; private set; }

        public SendChatToServerPacket(string message) : base(PacketType.SB_SendChat)
        {
            this.Message = message;
        }
    }

    [Serializable]
    public class SendChatToClientPacket : Packet
    {
        public string Message { get; private set; }

        public SendChatToClientPacket(string message) : base(PacketType.CB_SendChat)
        {
            this.Message = message;
        }
    }

    [Serializable]
    public class Packet
    {
        public PacketType Type { get; private set; }

        public Packet(PacketType type)
        {
            this.Type = type;
        }

        public static byte[] Serialize(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream(1024 * 4);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }

        public static Object Deserialize(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(1024 * 4);
            foreach (byte b in bytes)
            {
                memoryStream.WriteByte(b);
            }

            memoryStream.Position = 0;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Object obj = binaryFormatter.Deserialize(memoryStream);
            memoryStream.Close();
            return obj;
        }
    }
}
