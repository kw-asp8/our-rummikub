﻿using System;
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
    public partial class GameForm : Form
    {
        private bool clickPlus = false;
        public Button newButton = new Button();

        Timer timer = new Timer();

        public GameForm()
        {
            InitializeComponent();
            btn_timer.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_timer.Width, btn_timer.Height, 15, 15));
            btn_sort_num.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_sort_num.Width, btn_sort_num.Height, 15, 15));
            btn_sort_col.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_sort_col.Width, btn_sort_col.Height, 15, 15));
            Grid_tile.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, Grid_tile.Width, Grid_tile.Height, 15, 15));
            Grid_tile.BorderStyle = BorderStyle.FixedSingle; //border?
            profile1.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile1.Width, profile1.Height, 30, 50));
            profile2.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile2.Width, profile2.Height, 30, 50));
            profile3.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile3.Width, profile3.Height, 30, 50));
            profile4.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile4.Width, profile4.Height, 30, 50));

            //GameForm form1 = new GameForm();
            //form1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        public class RoundButton : Button
        {
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(grPath);
                base.OnPaint(e);
            }
        }

        private void btn_timer_Click(object sender, EventArgs e)
        {

        }

        class ButtonEx : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                GraphicsPath graphics = new GraphicsPath();
                graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(graphics);
                base.OnPaint(pevent);
            }
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

        private Point mousePoint;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        // 마우스 클릭시 먼저 선언된 mousePoint변수에 현재 마우스 위치값이 들어갑니다.

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        // 클릭상태로 마우스를 이동시 이동한 만큼에서 윈도우 위치값을 빼게됩니다.

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_exit_MouseLeave(object sender, EventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //private void btn_plus_Click(object sender, EventArgs e)
        //{
        //    if(clickPlus == false)
        //    {
        //        btn_plus.Visible = false;
        //        clickPlus = true;
        //        this.btn_plus.Click -= new System.EventHandler(this.btn_plus_Click);
        //        MainForm.Controls.Remove(btn_plus);

        //        MainForm.Controls.Add(btn_complete);
        //        this.newButton.Click += new System.EventHandler(this.btn_complete_Click);
        //        btn_complete.Visible = true;

        //        MainForm.Controls.Add(btn_return);
        //        this.newButton.Click += new System.EventHandler(this.btn_return_Click);
        //        btn_return.Visible = true;
        //    }
        //}

        //private void btn_complete_Click(object sender, EventArgs e)
        //{
        //    btn_plus.Visible = true;
        //    clickPlus = false;
        //    this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
        //    MainForm.Controls.Add(btn_plus);

        //    MainForm.Controls.Add(btn_complete);
        //    this.newButton.Click -= new System.EventHandler(this.btn_complete_Click);
        //    btn_complete.Visible = false;

        //    MainForm.Controls.Add(btn_return);
        //    this.newButton.Click -= new System.EventHandler(this.btn_return_Click);
        //    btn_return.Visible = false;
        //}

        //private void btn_return_Click(object sender, EventArgs e)
        //{
        //    btn_plus.Visible = true;
        //    clickPlus = false;
        //    this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
        //    MainForm.Controls.Add(btn_plus);

        //    MainForm.Controls.Add(btn_complete);
        //    this.newButton.Click -= new System.EventHandler(this.btn_complete_Click);
        //    btn_complete.Visible = false;

        //    MainForm.Controls.Add(btn_return);
        //    this.newButton.Click -= new System.EventHandler(this.btn_return_Click);
        //    btn_return.Visible = false;
        //}

        private void lbl_exit_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(102, 102, 102);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {

            //btn_timer.Text = (max - int.Parse(tmrClock.ToString())).ToString();

            //int interval = max - int.Parse(tmrClock.ToString());
            btn_timer.Text = (int.Parse(btn_timer.Text) - 1).ToString();

            if (btn_timer.Text == "0")
            {
                GameResultForm dlg = new GameResultForm();
                tmrClock.Stop();

                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;
                dlg.Show();
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            tmrClock.Start();
        }
    }
}