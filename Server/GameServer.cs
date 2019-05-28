using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GameServer
    {
        private ConnectionServer conServer;
        public Game Game { get; private set; } = new Game();

        public GameServer()
        {
            conServer = new ConnectionServer(IPAddress.Parse("127.0.0.1"), 7777);
            conServer.RegisterPacketHandler(PacketType.SB_Login, (connection, packet) =>
            {
                var login = (LoginPacket)packet;

                if (Game.Room.Players.Count < Room.MaxPlayers)
                {
                    Player player = new Player(connection, login.Nickname);
                    Game.Room.AddPlayer(player);

                    SendRoomStatus();
                    SendGameStatus();

                    Console.WriteLine(player.Nickname + " has logged in.");
                }
                else
                {
                    //TODO Send login fail packet
                    Console.WriteLine(login.Nickname + " has failed to log in: The room is full.");
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_StartGame, (connection, packet) =>
            {
                var startGame = (StartGamePacket)packet;
                Player player = Game.PlayerOf(connection);

                if (player == Game.GetManager())
                {
                    Game.Start();
                    SendGameStatus();

                    Console.WriteLine(player.Nickname + " has started the game!");
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_UpdateTable, (connection, packet) =>
            {
                var updateTable = (UpdateTablePacket)packet;
                Player player = Game.PlayerOf(connection);

                if (player == Game.CurrentPlayer)
                {
                    //TODO verify the table
                    Game.Table[updateTable.I, updateTable.J] = updateTable.Tile;
                    SendTable(player);
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_UpdatePrivateTiles, (connection, packet) =>
            {
                var updatePrivateTiles = (UpdatePrivateTilesPacket)packet;
                Player player = Game.PlayerOf(connection);

                //TODO verify the holding tiles
                player.HoldingTiles = updatePrivateTiles.HoldingTiles;
            });
            conServer.RegisterPacketHandler(PacketType.SB_NextTurn, (connection, packet) =>
            {
                var nextTurn = (NextTurnPacket)packet;
                Player player = Game.PlayerOf(connection);

                if (player == Game.CurrentPlayer)
                {
                    if (!Game.HasAnyInvalidTileSet())
                    {
                        Game.NextTurn();
                        SendGameStatus();

                        Console.WriteLine("Now " + Game.CurrentPlayer.Nickname + "'s turn.");
                    }
                    else
                    {
                        Console.WriteLine(player.Nickname + " has failed to change turn: There's a invalid tile set.");
                    }
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_SendChat, (connection, packet) =>
            {
                var sendChatToServer = (SendChatToServerPacket)packet;
                Player player = Game.PlayerOf(connection);

                Console.WriteLine("<" + player.Nickname + ">: " + sendChatToServer.Message);
                SendChat(player.Nickname, sendChatToServer.Message);
            });

            conServer.OnDisconnect.Add((connection) =>
            {
                Player player = Game.PlayerOf(connection);
                Game.Room.RemovePlayer(player);

                SendRoomStatus();
                SendGameStatus();

                Console.WriteLine(player.Nickname + " has logged out.");
            });
        }

        public void Start()
        {
            conServer.Start();
        }

        public void Stop()
        {
            conServer.Stop();
        }

        public void SendRoomStatus()
        {
            RoomStatus roomStatus = Game.Room.ToStatus();
            var sendRoomStatus = new SendRoomStatusPacket(roomStatus);

            foreach (Connection everyCon in conServer.Connections)
            {
                everyCon.Send(sendRoomStatus);
            }
        }

        public void SendGameStatus()
        {
            GameStatus gameStatus = Game.ToStatus();
            var sendGameStatus = new SendGameStatusPacket(gameStatus);

            foreach (Player player in Game.Room.Players)
            {
                player.Connection.Send(sendGameStatus);
            }
        }

        public void SendTable(Player excluded = null)
        {
            var sendTable = new SendTablePacket(Game.Table);

            foreach (Player player in Game.Room.Players)
            {
                if (player != excluded)
                    player.Connection.Send(sendTable);
            }
        }

        public void SendChat(string nickname, string message)
        {
            var sendChatToClient = new SendChatToClientPacket(nickname, message);
            foreach (Connection everyCon in conServer.Connections)
            {
                everyCon.Send(sendChatToClient);
            }
        }

        public void SendGameOver()
        {
            List<PlayerInfo> ranking =
                (from player in Game.Room.Players
                 orderby player.Nickname //TODO orderby game.ScoreOf(player)
                 select player.ToInfo())
                 .ToList();
            var endGame = new EndGamePacket(ranking);

            foreach (Connection everyCon in conServer.Connections)
            {
                everyCon.Send(endGame);
            }
        }
    }
}
