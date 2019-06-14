using Common;
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
    public partial class ProfileForm : Form
    {
        Boolean isMove = false;
        Point fPt;

        private GameClient client;
        
        public ProfileForm(GameClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        public void UpdateLoginStatus(bool success)
        {
            if(success)
            {
                this.Close();
            }
            else
                textBox1.Clear();
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
            client.Player = new PlayerInfo(textBox1.Text, 0, 0);
            client.Connect();
            client.Login(textBox1.Text);
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                client.Player = new PlayerInfo(textBox1.Text, 0, 0);
                client.Connect();
                client.Login(textBox1.Text);
            }
        }

        private void Btn_start_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderColor = Color.Black;
        }

        private void Btn_start_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.Black;
        }
    }
}
