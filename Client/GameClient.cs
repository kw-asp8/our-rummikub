using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class GameClient
    {
        private ConnectionClient conClient = new ConnectionClient();
        private StartForm startForm;
        private GameForm gameForm;
        public ProfileForm profileForm;

        public GameClient()
        {
            conClient.RegisterPacketHandler(PacketType.CB_Login, (con, packet) => {
                var sendLoginStatus = (SendLoginPacket)packet;
                profileForm.Invoke(new MethodInvoker(() =>
                {
                    profileForm.UpdateLoginStatus(sendLoginStatus.Success);
                }));
            });
            conClient.RegisterPacketHandler(PacketType.CB_SendRoomStatus, (con, packet) => {
                while (gameForm == null || !gameForm.IsHandleCreated) ;

                var sendRoomStatus = (SendRoomStatusPacket)packet;
                gameForm.Invoke(new MethodInvoker(() =>
                {
                    gameForm.UpdateRoomStatus(sendRoomStatus.RoomStatus);
                }));
            });
            conClient.RegisterPacketHandler(PacketType.CB_SendGameStatus, (con, packet) => {
                while (gameForm == null) ;

                var sendGameStatus = (SendGameStatusPacket)packet;
                gameForm.UpdateGameStatus(sendGameStatus.GameStatus);
            });
            conClient.RegisterPacketHandler(PacketType.CB_SendTable, (con, packet) => {
                while (gameForm == null) ;

                var sendTable = (SendTablePacket)packet;
                gameForm.UpdateTable(sendTable.Table);
            });
            conClient.RegisterPacketHandler(PacketType.CB_SendChat, (con, packet) =>
            {
                var sendChat = (SendChatToClientPacket)packet;
                if (gameForm != null)
                {
                    gameForm.PrintChatMessage(sendChat.PlayerName, sendChat.Message);
                }
            });
            conClient.RegisterPacketHandler(PacketType.CB_EndGame, (con, packet) => {
                var endGame = (EndGamePacket)packet;

                if (gameForm != null)
                {
                    gameForm.ShowResultForm(endGame.Ranking);
                }
            });
        }

        public void RunInitialForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            startForm = new StartForm(this);
            Application.Run(startForm);
        }

        public void OpenGameForm()
        {
            this.gameForm = new GameForm(this);

            startForm.Hide();
            gameForm.FormClosing += (sender, e) =>
            {
                conClient.Disconnect();
                startForm.Show();
            };

            gameForm.Show();
        }

        public void Connect()
        {
            conClient.Connect(IPAddress.Parse(Properties.Settings.Default.ip), 
                Int32.Parse(Properties.Settings.Default.port));
        }

        public void Login(string nickname)
        {
            conClient.Connection.Send(new LoginPacket(nickname));
        }

        public void StartGame()
        {
            conClient.Connection.Send(new StartGamePacket());
        }

        public void UpdateTable(Tile tile, int i, int j)
        {
            conClient.Connection.Send(new UpdateTablePacket(tile, i, j));
        }

        public void UpdatePrivateTiles(List<Tile> tiles)
        {
            conClient.Connection.Send(new UpdatePrivateTilesPacket(tiles));
        }

        public void RequestRollback()
        {
            conClient.Connection.Send(new RequestRollbackPacket());
        }

        public void NextTurn()
        {
            conClient.Connection.Send(new NextTurnPacket());
        }

        public void SendChat(string message)
        {
            conClient.Connection.Send(new SendChatToServerPacket(message));
        }
    }
}
