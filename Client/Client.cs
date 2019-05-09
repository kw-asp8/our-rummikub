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
    public class Client
    {
        private ConnectionClient conClient = new ConnectionClient();
        private GameForm gameForm;

        public Client()
        {
            conClient.RegisterPacketHandler(PacketType.CB_SendRoomStatus, (con, packet) => {
                var sendRoomStatus = (SendRoomStatusPacket)packet;
                gameForm.UpdateRoomStatus(sendRoomStatus.RoomStatus);
            });
            conClient.RegisterPacketHandler(PacketType.CB_SendGameStatus, (con, packet) => {
                var sendGameStatus = (SendGameStatusPacket)packet;
                gameForm.UpdateGameStatus(sendGameStatus.GameStatus);
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

                GameResultForm resultForm = new GameResultForm(endGame.Ranking);
                resultForm.StartPosition = FormStartPosition.CenterParent;
                resultForm.Owner = gameForm;
                resultForm.Show();
            });
        }

        public void RunInitialForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm(this));
        }

        public void OpenGameForm()
        {
            this.gameForm = new GameForm(this);
            gameForm.Show();
        }

        public void Connect()
        {
            conClient.Connect(IPAddress.Parse("127.0.0.1"), 7777);
        }

        public void Login(string nickname)
        {
            conClient.Connection.Send(new LoginPacket(nickname));
        }

        public void StartGame()
        {
            conClient.Connection.Send(new StartGamePacket());
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
