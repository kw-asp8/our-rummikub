using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GameResultForm : Form
    {
        private GameClient client;
        private List<PlayerInfo> ranking;

        public GameResultForm(GameClient client, List<PlayerInfo> ranking)
        {
            InitializeComponent();
            this.client = client;
            this.ranking = ranking;
            btn_regame.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, btn_regame.Width, btn_regame.Height, 30, 30));
            btn_main.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, btn_main.Width, btn_main.Height, 30, 30));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]            //Dll임포트

        private static extern IntPtr CreateRoundRectRgn                            //파라미터

       (
           int nLeftRect,      // x-coordinate of upper-left corner
           int nTopRect,       // y-coordinate of upper-left corner
           int nRightRect,     // x-coordinate of lower-right corner
           int nBottomRect,    // y-coordinate of lower-right corner   
           int nWidthEllipse,  // height of ellipse
           int nHeightEllipse  // width of ellipse  
       );

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Point mousePoint;

        private void GameResult_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void GameResult_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void GameResult_Load(object sender, EventArgs e)
        {
            lbl_first.Text = ranking[0].Nickname;
            for (int i = 0; i < ranking.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        lbl_first.Text = ranking[i].Nickname;
                        lbl_first_score.Text = ranking[i].Score.ToString();
                        break;
                    case 1:
                        lbl_second.Text = ranking[i].Nickname;
                        lbl_second_score.Text = ranking[i].Score.ToString();
                        break;
                    case 2:
                        lbl_third.Text = ranking[i].Nickname;
                        lbl_third_score.Text = ranking[i].Score.ToString();
                        break;
                    case 3:
                        lbl_forth.Text = ranking[i].Nickname;
                        lbl_forth_score.Text = ranking[i].Score.ToString();
                        break;
                }
            }
        }

        private bool iHaveToQuit = false;

        private void Btn_regame_Click(object sender, EventArgs e)
        {
            iHaveToQuit = true;
            this.Close();
            client.gameForm.Close();

            string oldNickname = client.Player.Nickname;
            client.Player = new PlayerInfo(oldNickname, 0, 0);
            client.Connect();
            client.Login(oldNickname);
        }

        private void Btn_main_Click(object sender, EventArgs e)
        {
            iHaveToQuit = true;
            this.Close();
            client.gameForm.Close();
        }

        private void GameResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!iHaveToQuit)
            {
                iHaveToQuit = true;
                client.gameForm.Close();
            }
        }
    }
}
