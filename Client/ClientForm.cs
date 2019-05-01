﻿using System;
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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            btn_timer.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_timer.Width, btn_timer.Height, 15, 15));
            btn_sort_num.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_sort_num.Width, btn_sort_num.Height, 15, 15));
            btn_sort_col.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_sort_col.Width, btn_sort_col.Height, 15, 15));
            Grid_tile.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, Grid_tile.Width, Grid_tile.Height, 15, 15));
            Grid_tile.BorderStyle = BorderStyle.FixedSingle; //border?
            profile1.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, profile1.Width, profile1.Height, 15, 30));
            profile2.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, profile2.Width, profile2.Height, 15, 30));
            profile3.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, profile3.Width, profile3.Height, 15, 30));
            profile4.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, profile4.Width, profile4.Height, 15, 30));
            btn_plus.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, btn_plus.Width, btn_plus.Height, 30, 30));
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

        private void Background_Load(object sender, EventArgs e)
        {
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_exit_MouseHover(object sender, EventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(102, 102, 102);
        }

        private void lbl_exit_MouseLeave(object sender, EventArgs e)
        {
            lbl_exit.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
