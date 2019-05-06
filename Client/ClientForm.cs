using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private ConnectionClient client;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client = new ConnectionClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 7777);
            client.RegisterPacketHandler(PacketType.CB_SendChat, (connection, packet) =>
            {
                var sendChatToClient = (SendChatToClientPacket)packet;
                Invoke(new MethodInvoker(delegate ()
                {
                    textBox2.AppendText(sendChatToClient.Message);
                }));
            });
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            client.Connection.Send(new SendChatToServerPacket(textBox1.Text));
        }
    }
}
