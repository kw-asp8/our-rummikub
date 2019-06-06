﻿namespace Client
{
    partial class GameForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.Chatting = new System.Windows.Forms.Panel();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txtbox_chat = new System.Windows.Forms.TextBox();
            this.MainForm = new System.Windows.Forms.Panel();
            this.remain4 = new System.Windows.Forms.Label();
            this.remain3 = new System.Windows.Forms.Label();
            this.remain2 = new System.Windows.Forms.Label();
            this.remain1 = new System.Windows.Forms.Label();
            this.nickname4 = new System.Windows.Forms.Label();
            this.nickname3 = new System.Windows.Forms.Label();
            this.nickname2 = new System.Windows.Forms.Label();
            this.nickname1 = new System.Windows.Forms.Label();
            this.tgpHolding = new Client.TileGridPanel();
            this.tileTable = new System.Windows.Forms.PictureBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.tgpTable = new Client.TileGridPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_complete = new System.Windows.Forms.Button();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.profile4 = new System.Windows.Forms.PictureBox();
            this.profile3 = new System.Windows.Forms.PictureBox();
            this.profile2 = new System.Windows.Forms.PictureBox();
            this.profile1 = new System.Windows.Forms.PictureBox();
            this.btn_sort_col = new System.Windows.Forms.Button();
            this.btn_sort_num = new System.Windows.Forms.Button();
            this.btn_timer = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.Chatting.SuspendLayout();
            this.MainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chatting
            // 
            this.Chatting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.Chatting.Controls.Add(this.txt_log);
            this.Chatting.Controls.Add(this.btn_send);
            this.Chatting.Controls.Add(this.txtbox_chat);
            this.Chatting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chatting.Location = new System.Drawing.Point(0, 501);
            this.Chatting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chatting.Name = "Chatting";
            this.Chatting.Size = new System.Drawing.Size(748, 129);
            this.Chatting.TabIndex = 0;
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.txt_log.ForeColor = System.Drawing.Color.White;
            this.txt_log.Location = new System.Drawing.Point(11, 4);
            this.txt_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(728, 85);
            this.txt_log.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_send.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.btn_send.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_send.Location = new System.Drawing.Point(769, 122);
            this.btn_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 28);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "전송";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // txtbox_chat
            // 
            this.txtbox_chat.AcceptsReturn = true;
            this.txtbox_chat.Location = new System.Drawing.Point(14, 122);
            this.txtbox_chat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbox_chat.Name = "txtbox_chat";
            this.txtbox_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_chat.Size = new System.Drawing.Size(749, 25);
            this.txtbox_chat.TabIndex = 2;
            this.txtbox_chat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbox_chat_KeyUp);
            // 
            // MainForm
            // 
            this.MainForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.MainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainForm.Controls.Add(this.remain4);
            this.MainForm.Controls.Add(this.remain3);
            this.MainForm.Controls.Add(this.remain2);
            this.MainForm.Controls.Add(this.remain1);
            this.MainForm.Controls.Add(this.nickname4);
            this.MainForm.Controls.Add(this.nickname3);
            this.MainForm.Controls.Add(this.nickname2);
            this.MainForm.Controls.Add(this.nickname1);
            this.MainForm.Controls.Add(this.tgpHolding);
            this.MainForm.Controls.Add(this.tileTable);
            this.MainForm.Controls.Add(this.lbl_title);
            this.MainForm.Controls.Add(this.tgpTable);
            this.MainForm.Controls.Add(this.btnStart);
            this.MainForm.Controls.Add(this.btn_return);
            this.MainForm.Controls.Add(this.btn_complete);
            this.MainForm.Controls.Add(this.lbl_exit);
            this.MainForm.Controls.Add(this.profile4);
            this.MainForm.Controls.Add(this.profile3);
            this.MainForm.Controls.Add(this.profile2);
            this.MainForm.Controls.Add(this.profile1);
            this.MainForm.Controls.Add(this.btn_sort_col);
            this.MainForm.Controls.Add(this.btn_sort_num);
            this.MainForm.Controls.Add(this.btn_timer);
            this.MainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainForm.Location = new System.Drawing.Point(0, 0);
            this.MainForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainForm.Name = "MainForm";
            this.MainForm.Size = new System.Drawing.Size(748, 501);
            this.MainForm.TabIndex = 1;
            this.MainForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MainForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // remain4
            // 
            this.remain4.Location = new System.Drawing.Point(70, 315);
            this.remain4.Name = "remain4";
            this.remain4.Size = new System.Drawing.Size(24, 24);
            this.remain4.TabIndex = 21;
            this.remain4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain3
            // 
            this.remain3.Location = new System.Drawing.Point(70, 222);
            this.remain3.Name = "remain3";
            this.remain3.Size = new System.Drawing.Size(24, 24);
            this.remain3.TabIndex = 20;
            this.remain3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain2
            // 
            this.remain2.Location = new System.Drawing.Point(70, 129);
            this.remain2.Name = "remain2";
            this.remain2.Size = new System.Drawing.Size(24, 24);
            this.remain2.TabIndex = 19;
            this.remain2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain1
            // 
            this.remain1.Location = new System.Drawing.Point(70, 34);
            this.remain1.Name = "remain1";
            this.remain1.Size = new System.Drawing.Size(24, 24);
            this.remain1.TabIndex = 18;
            this.remain1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname4
            // 
            this.nickname4.Location = new System.Drawing.Point(15, 382);
            this.nickname4.Name = "nickname4";
            this.nickname4.Size = new System.Drawing.Size(73, 12);
            this.nickname4.TabIndex = 17;
            this.nickname4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname3
            // 
            this.nickname3.Location = new System.Drawing.Point(15, 288);
            this.nickname3.Name = "nickname3";
            this.nickname3.Size = new System.Drawing.Size(73, 12);
            this.nickname3.TabIndex = 16;
            this.nickname3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname2
            // 
            this.nickname2.Location = new System.Drawing.Point(15, 194);
            this.nickname2.Name = "nickname2";
            this.nickname2.Size = new System.Drawing.Size(73, 12);
            this.nickname2.TabIndex = 15;
            this.nickname2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname1
            // 
            this.nickname1.Location = new System.Drawing.Point(15, 98);
            this.nickname1.Name = "nickname1";
            this.nickname1.Size = new System.Drawing.Size(73, 12);
            this.nickname1.TabIndex = 14;
            this.nickname1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tgpHolding
            // 
            this.tgpHolding.Location = new System.Drawing.Point(117, 500);
            this.tgpHolding.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tgpHolding.Name = "tgpHolding";
            this.tgpHolding.OnPickup = null;
            this.tgpHolding.OnPlace = null;
            this.tgpHolding.OptionRemoveSpaces = false;
            this.tgpHolding.Size = new System.Drawing.Size(617, 120);
            this.tgpHolding.TabIndex = 13;
            this.tgpHolding.TileSize = new System.Drawing.Size(0, 0);
            // 
            // tileTable
            // 
            this.tileTable.BackColor = System.Drawing.Color.Transparent;
            this.tileTable.ErrorImage = null;
            this.tileTable.Image = global::Client.Properties.Resources.tiletable;
            this.tileTable.InitialImage = null;
            this.tileTable.Location = new System.Drawing.Point(11, 438);
            this.tileTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tileTable.Name = "tileTable";
            this.tileTable.Size = new System.Drawing.Size(83, 55);
            this.tileTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tileTable.TabIndex = 1;
            this.tileTable.TabStop = false;
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.Color.Navy;
            this.lbl_title.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_title.Font = new System.Drawing.Font("Garamond", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_title.Location = new System.Drawing.Point(693, 451);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(214, 45);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Rummikub";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tgpTable
            // 
            this.tgpTable.Location = new System.Drawing.Point(117, 42);
            this.tgpTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tgpTable.Name = "tgpTable";
            this.tgpTable.OnPickup = null;
            this.tgpTable.OnPlace = null;
            this.tgpTable.OptionRemoveSpaces = false;
            this.tgpTable.Size = new System.Drawing.Size(617, 450);
            this.tgpTable.TabIndex = 2;
            this.tgpTable.TileSize = new System.Drawing.Size(0, 0);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 400);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 33);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.btn_return.BackgroundImage = global::Client.Properties.Resources.returnButton;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_return.FlatAppearance.BorderSize = 0;
            this.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_return.Location = new System.Drawing.Point(648, 354);
            this.btn_return.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(91, 79);
            this.btn_return.TabIndex = 12;
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.Btn_return_Click);
            // 
            // btn_complete
            // 
            this.btn_complete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.btn_complete.BackgroundImage = global::Client.Properties.Resources.check_button;
            this.btn_complete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_complete.FlatAppearance.BorderSize = 0;
            this.btn_complete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_complete.Location = new System.Drawing.Point(648, 288);
            this.btn_complete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_complete.Name = "btn_complete";
            this.btn_complete.Size = new System.Drawing.Size(90, 66);
            this.btn_complete.TabIndex = 11;
            this.btn_complete.UseVisualStyleBackColor = false;
            this.btn_complete.Click += new System.EventHandler(this.Btn_complete_Click);
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_exit.Location = new System.Drawing.Point(716, 2);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(27, 28);
            this.lbl_exit.TabIndex = 9;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            this.lbl_exit.MouseLeave += new System.EventHandler(this.lbl_exit_MouseLeave);
            this.lbl_exit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_exit_MouseMove);
            // 
            // profile4
            // 
            this.profile4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile4.BackColor = System.Drawing.Color.Transparent;
            this.profile4.Image = global::Client.Properties.Resources.프사4;
            this.profile4.Location = new System.Drawing.Point(15, 317);
            this.profile4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile4.Name = "profile4";
            this.profile4.Size = new System.Drawing.Size(73, 56);
            this.profile4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile4.TabIndex = 6;
            this.profile4.TabStop = false;
            // 
            // profile3
            // 
            this.profile3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile3.BackColor = System.Drawing.Color.Transparent;
            this.profile3.Image = global::Client.Properties.Resources.프사3;
            this.profile3.Location = new System.Drawing.Point(15, 222);
            this.profile3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile3.Name = "profile3";
            this.profile3.Size = new System.Drawing.Size(73, 56);
            this.profile3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile3.TabIndex = 5;
            this.profile3.TabStop = false;
            // 
            // profile2
            // 
            this.profile2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile2.BackColor = System.Drawing.Color.Transparent;
            this.profile2.Image = global::Client.Properties.Resources.프사2;
            this.profile2.Location = new System.Drawing.Point(13, 129);
            this.profile2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile2.Name = "profile2";
            this.profile2.Size = new System.Drawing.Size(73, 56);
            this.profile2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile2.TabIndex = 4;
            this.profile2.TabStop = false;
            // 
            // profile1
            // 
            this.profile1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Image = global::Client.Properties.Resources.프사1;
            this.profile1.Location = new System.Drawing.Point(13, 34);
            this.profile1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(73, 56);
            this.profile1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile1.TabIndex = 2;
            this.profile1.TabStop = false;
            // 
            // btn_sort_col
            // 
            this.btn_sort_col.AllowDrop = true;
            this.btn_sort_col.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.btn_sort_col.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_col.FlatAppearance.BorderSize = 0;
            this.btn_sort_col.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_col.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sort_col.Image = global::Client.Properties.Resources.buttonImage;
            this.btn_sort_col.Location = new System.Drawing.Point(648, 203);
            this.btn_sort_col.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sort_col.Name = "btn_sort_col";
            this.btn_sort_col.Size = new System.Drawing.Size(90, 80);
            this.btn_sort_col.TabIndex = 2;
            this.btn_sort_col.UseVisualStyleBackColor = false;
            // 
            // btn_sort_num
            // 
            this.btn_sort_num.AllowDrop = true;
            this.btn_sort_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.btn_sort_num.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_num.FlatAppearance.BorderSize = 0;
            this.btn_sort_num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_num.Font = new System.Drawing.Font("Gadugi", 20F);
            this.btn_sort_num.ForeColor = System.Drawing.Color.Red;
            this.btn_sort_num.Location = new System.Drawing.Point(648, 118);
            this.btn_sort_num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sort_num.Name = "btn_sort_num";
            this.btn_sort_num.Size = new System.Drawing.Size(90, 80);
            this.btn_sort_num.TabIndex = 1;
            this.btn_sort_num.Text = "789";
            this.btn_sort_num.UseVisualStyleBackColor = false;
            // 
            // btn_timer
            // 
            this.btn_timer.AllowDrop = true;
            this.btn_timer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(250)))));
            this.btn_timer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_timer.FlatAppearance.BorderSize = 0;
            this.btn_timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_timer.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_timer.Location = new System.Drawing.Point(648, 34);
            this.btn_timer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(90, 80);
            this.btn_timer.TabIndex = 0;
            this.btn_timer.Text = "60";
            this.btn_timer.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tiletable.jpg");
            this.imageList1.Images.SetKeyName(1, "프사1.JPG");
            this.imageList1.Images.SetKeyName(2, "프사2.JPG");
            this.imageList1.Images.SetKeyName(3, "프사3.JPG");
            this.imageList1.Images.SetKeyName(4, "프사4.JPG");
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 630);
            this.Controls.Add(this.MainForm);
            this.Controls.Add(this.Chatting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Rummikub";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Chatting.ResumeLayout(false);
            this.Chatting.PerformLayout();
            this.MainForm.ResumeLayout(false);
            this.MainForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Chatting;
        private System.Windows.Forms.Panel MainForm;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.Button btn_sort_num;
        private System.Windows.Forms.Button btn_sort_col;
        private System.Windows.Forms.PictureBox profile1;
        private System.Windows.Forms.PictureBox profile3;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtbox_chat;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_complete;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Button btnStart;
        private Client.TileGridPanel tgpHolding;
        private System.Windows.Forms.Label lbl_title;
        private Client.TileGridPanel tgpTable;
        private System.Windows.Forms.Label remain4;
        private System.Windows.Forms.Label remain3;
        private System.Windows.Forms.Label remain2;
        private System.Windows.Forms.Label remain1;
        private System.Windows.Forms.Label nickname4;
        private System.Windows.Forms.Label nickname3;
        private System.Windows.Forms.Label nickname2;
        private System.Windows.Forms.Label nickname1;
        private System.Windows.Forms.PictureBox profile2;
        private System.Windows.Forms.PictureBox profile4;
        private System.Windows.Forms.PictureBox tileTable;
    }
}

