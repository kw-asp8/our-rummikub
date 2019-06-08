using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Common
{
    public enum PacketType
    {
        SB_Login = 0,
        SB_StartGame,
        SB_UpdateTable,
        SB_UpdatePrivateTiles,
        SB_RequestRollback,
        SB_NextTurn,
        SB_SendChat,

        CB_Login,
        CB_SendRoomStatus,
        CB_SendGameStatus,
        CB_SendTable,
        CB_SendPrivateTiles,
        CB_SendChat,
        CB_EndGame
    }

    [Serializable]
    public class LoginPacket : Packet
    {
        public string Nickname { get; private set; }

        public LoginPacket(string nickname) : base(PacketType.SB_Login)
        {
            Nickname = nickname;
        }
    }

    [Serializable]
    public class StartGamePacket : Packet
    {
        public StartGamePacket() : base(PacketType.SB_StartGame)
        {
        }
    }

    [Serializable]
    public class UpdateTablePacket : Packet
    {
        public Tile[,] Table { get; private set; }

        public UpdateTablePacket(Tile[,] table) : base(PacketType.SB_UpdateTable)
        {
            Table = table;
        }
    }

    [Serializable]
    public class UpdatePrivateTilesPacket : Packet
    {
        public List<Tile> HoldingTiles { get; private set; }

        public UpdatePrivateTilesPacket(List<Tile> holdingTiles) : base(PacketType.SB_UpdatePrivateTiles)
        {
            HoldingTiles = holdingTiles;
        }
    }

    [Serializable]
    public class RequestRollbackPacket : Packet
    {
        public RequestRollbackPacket() : base(PacketType.SB_RequestRollback)
        {
        }
    }

    [Serializable]
    public class NextTurnPacket : Packet
    {
        public NextTurnPacket() : base(PacketType.SB_NextTurn)
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
    public class SendLoginPacket : Packet
    {
        public bool Success { get; private set; }

        public SendLoginPacket(bool success) : base(PacketType.CB_Login)
        {
            Success = success;
        }
    }

    [Serializable]
    public class SendRoomStatusPacket : Packet
    {
        public RoomStatus RoomStatus { get; private set; }

        public SendRoomStatusPacket(RoomStatus roomStatus) : base(PacketType.CB_SendRoomStatus)
        {
            RoomStatus = roomStatus;
        }
    }

    [Serializable]
    public class SendGameStatusPacket : Packet
    {
        public GameStatus GameStatus { get; private set; }

        public SendGameStatusPacket(GameStatus gameStatus) : base(PacketType.CB_SendGameStatus)
        {
            GameStatus = gameStatus;
        }
    }

    [Serializable]
    public class SendTablePacket : Packet
    {
        public Tile[,] Table { get; private set; }

        public SendTablePacket(Tile[,] table) : base(PacketType.CB_SendTable)
        {
            Table = table;
        }
    }


    [Serializable]
    public class SendPrivateTilesPacket : Packet
    {
        public List<Tile> HoldingTiles { get; private set; }

        public SendPrivateTilesPacket(List<Tile> holdingTiles) : base(PacketType.CB_SendPrivateTiles)
        {
            HoldingTiles = holdingTiles;
        }
    }

    [Serializable]
    public class SendChatToClientPacket : Packet
    {
        public string PlayerName { get; private set; }

        public string Message { get; private set; }

        public SendChatToClientPacket(string playerName, string message) : base(PacketType.CB_SendChat)
        {
            this.PlayerName = playerName;
            this.Message = message;
        }
    }

    [Serializable]
    public class EndGamePacket : Packet
    {
        public List<PlayerInfo> Ranking { get; private set; }

        public EndGamePacket(List<PlayerInfo> ranking) : base(PacketType.CB_EndGame)
        {
            Ranking = ranking;
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
