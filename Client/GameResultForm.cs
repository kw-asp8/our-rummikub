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
        private List<PlayerInfo> ranking;

        public GameResultForm(List<PlayerInfo> ranking)
        {
            InitializeComponent();
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
            Application.Exit();
        }

        private void lbl_exit_MouseLeave(object sender, EventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void lbl_exit_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(102, 102, 102);
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
    }
}
