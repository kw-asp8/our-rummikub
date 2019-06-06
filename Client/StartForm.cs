using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class StartForm : Form
    {
        Boolean isMove = false;
        Point fPt;

        private GameClient client;

        public StartForm(GameClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfileForm profile1 = new ProfileForm(client);
            profile1.Show();
            client.profileForm = profile1;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
