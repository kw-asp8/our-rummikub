using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class GameServer
    {
        private ConnectionServer conServer;
        public Game Game { get; private set; } = new Game();

        private CancellationTokenSource turnTimer;

        public GameServer()
        {
            conServer = new ConnectionServer(IPAddress.Parse(Properties.Settings.Default.ip),
                Int32.Parse(Properties.Settings.Default.port));
            conServer.RegisterPacketHandler(PacketType.SB_Login, (connection, packet) =>
            {
                var login = (LoginPacket)packet;
                bool success = true;
                Player player = new Player(connection, login.Nickname);

                if (Game.Room.Players.Count < Room.MaxPlayers)
                {
                    foreach (Player p in Game.Room.Players)
                    {
                        if (player.Nickname == p.Nickname)
                        {
                            success = false;
                            Console.WriteLine(login.Nickname + " has failed to log in: Already exists nickname.");
                            break;
                        }
                    }

                    var sendLoginStatus = new SendLoginPacket(success);
                    player.Connection.Send(sendLoginStatus);
                    if (success)
                    {
                        Game.Room.AddPlayer(player);
                        Console.WriteLine(player.Nickname + " has logged in.");
                        SendRoomStatus();
                        SendGameStatus();
                    }
                }
                else//TODO Send login fail packet
                {
                    success = false;
                    var sendLoginStatus = new SendLoginPacket(success);
                    player.Connection.Send(sendLoginStatus);
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
                    SendRoomStatus();

                    Console.WriteLine(player.Nickname + " has started the game!");
                    InitTurnTimer();

                    foreach (Player everyone in Game.Room.Players)
                    {
                        everyone.Connection.Send(new SendPrivateTilesPacket(everyone.HoldingTiles));
                    }
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_UpdateTable, (connection, packet) =>
            {
                var updateTable = (UpdateTablePacket)packet;
                Player player = Game.PlayerOf(connection);

                if (player == Game.CurrentPlayer)
                {
                    //TODO verify the table
                    Game.Table = updateTable.Table;
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
            conServer.RegisterPacketHandler(PacketType.SB_RequestRollback, (connection, packet) =>
            {
                Player player = Game.PlayerOf(connection);

                if (player == Game.CurrentPlayer)
                {
                    Game.Rollback();

                    SendTable();
                    SendPrivateTilesTo(Game.CurrentPlayer);

                    Console.WriteLine(Game.CurrentPlayer.Nickname + " has rollbacked the table.");
                }
            });
            conServer.RegisterPacketHandler(PacketType.SB_NextTurn, (connection, packet) =>
            {
                var nextTurn = (NextTurnPacket)packet;
                Player player = Game.PlayerOf(connection);

                if (player == Game.CurrentPlayer)
                {
                    TryNextTurn();
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

                if (Game.IsEnabled && Game.Room.Players.Count <= 1)
                {
                    EndGame();
                }
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

        public void TryNextTurn()
        {
            CancelTurnTimer();

            bool hasPlacedAnyTile = Game.PreviousHoldingTiles.Count > Game.CurrentPlayer.HoldingTiles.Count;
            if (!Game.HasAnyInvalidTileSet())
            {
                if (!hasPlacedAnyTile)
                {
                    if (Game.CurrentPlayer.HoldingTiles.Count < Game.MaxTileNum)
                    {
                        if (Game.Dummy.Count > 0)
                        {
                            Game.CurrentPlayer.HoldingTiles.Add(Game.PopDummy());
                        }
                    }
                }
            }
            else
            {
                Game.Rollback();
                SendTable();
                for (int i = 0; i < 3; i++)
                {
                    if (Game.CurrentPlayer.HoldingTiles.Count >= Game.MaxTileNum)
                        break;
                    if (Game.Dummy.Count == 0)
                        break;
                    Game.CurrentPlayer.HoldingTiles.Add(Game.PopDummy());
                }

                Console.WriteLine(Game.CurrentPlayer.Nickname + " has failed to make valid tile-sets.");
            }
            SendPrivateTilesTo(Game.CurrentPlayer);

            if (Game.CanEndGame())
            {
                EndGame();
            }
            else
            {
                Game.NextTurn();
                SendGameStatus();
                SendRoomStatus();

                InitTurnTimer();

                Console.WriteLine("Now " + Game.CurrentPlayer.Nickname + "'s turn.");
            }
        }

        public void EndGame()
        {
            Game.End();
            SendGameOver();

            Player winner = Game.Room.Players.OrderBy(player => player.GetScore()).First();
            Console.WriteLine("Gameover: " + winner.Nickname + " has won!");
        }

        public void CancelTurnTimer()
        {
            if (turnTimer != null && !turnTimer.IsCancellationRequested)
            {
                turnTimer.Cancel();
                turnTimer.Dispose();
            }
        }

        public void InitTurnTimer()
        {
            turnTimer = new CancellationTokenSource();
            CancellationToken token = turnTimer.Token;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(60 * 1000);

                if (!token.IsCancellationRequested)
                {
                    TryNextTurn();
                    //TODO 마우스에 집어져 있는 타일 제거
                }
            }, token);
        }

        public void SendRoomStatus()
        {
            RoomStatus roomStatus = Game.Room.ToStatus();
            var sendRoomStatus = new SendRoomStatusPacket(roomStatus);

            foreach (Player player in Game.Room.Players)
            {
                player.Connection.Send(sendRoomStatus);
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

        public void SendPrivateTilesTo(Player player)
        {
            var sendPrivateTiles = new SendPrivateTilesPacket(player.HoldingTiles);
            player.Connection.Send(sendPrivateTiles);
        }

        public void SendChat(string nickname, string message)
        {
            var sendChatToClient = new SendChatToClientPacket(nickname, message);
            foreach (Player player in Game.Room.Players)
            {
                player.Connection.Send(sendChatToClient);
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

            foreach (Player player in Game.Room.Players)
            {
                player.Connection.Send(endGame);
            }
        }
    }
}
