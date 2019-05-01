namespace Client
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.Chatting = new System.Windows.Forms.Panel();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txtbox_chat = new System.Windows.Forms.TextBox();
            this.Main = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tileTable = new System.Windows.Forms.PictureBox();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.lbl_plus = new System.Windows.Forms.Label();
            this.btn_plus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.Grid_tile = new System.Windows.Forms.DataGridView();
            this.btn_sort_col = new System.Windows.Forms.Button();
            this.btn_sort_num = new System.Windows.Forms.Button();
            this.btn_timer = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.profile4 = new System.Windows.Forms.PictureBox();
            this.profile3 = new System.Windows.Forms.PictureBox();
            this.profile2 = new System.Windows.Forms.PictureBox();
            this.profile1 = new System.Windows.Forms.PictureBox();
            this.Chatting.SuspendLayout();
            this.Main.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chatting
            // 
            this.Chatting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.Chatting.Controls.Add(this.txt_log);
            this.Chatting.Controls.Add(this.btn_send);
            this.Chatting.Controls.Add(this.txtbox_chat);
            this.Chatting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chatting.Location = new System.Drawing.Point(0, 601);
            this.Chatting.Name = "Chatting";
            this.Chatting.Size = new System.Drawing.Size(855, 118);
            this.Chatting.TabIndex = 0;
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.txt_log.Location = new System.Drawing.Point(12, 0);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(831, 73);
            this.txt_log.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_send.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.btn_send.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_send.Location = new System.Drawing.Point(768, 79);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 36);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "전송";
            this.btn_send.UseVisualStyleBackColor = false;
            // 
            // txtbox_chat
            // 
            this.txtbox_chat.Location = new System.Drawing.Point(12, 79);
            this.txtbox_chat.Multiline = true;
            this.txtbox_chat.Name = "txtbox_chat";
            this.txtbox_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_chat.Size = new System.Drawing.Size(749, 36);
            this.txtbox_chat.TabIndex = 2;
            // 
            // Main
            // 
            this.Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.Main.Controls.Add(this.panel2);
            this.Main.Controls.Add(this.lbl_exit);
            this.Main.Controls.Add(this.lbl_plus);
            this.Main.Controls.Add(this.btn_plus);
            this.Main.Controls.Add(this.profile4);
            this.Main.Controls.Add(this.profile3);
            this.Main.Controls.Add(this.profile2);
            this.Main.Controls.Add(this.profile1);
            this.Main.Controls.Add(this.panel1);
            this.Main.Controls.Add(this.btn_sort_col);
            this.Main.Controls.Add(this.btn_sort_num);
            this.Main.Controls.Add(this.btn_timer);
            this.Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(855, 601);
            this.Main.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tileTable);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(118, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 128);
            this.panel2.TabIndex = 10;
            // 
            // tileTable
            // 
            this.tileTable.BackColor = System.Drawing.Color.Transparent;
            this.tileTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTable.ErrorImage = null;
            this.tileTable.Image = global::Client.Properties.Resources.tiletable;
            this.tileTable.InitialImage = null;
            this.tileTable.Location = new System.Drawing.Point(0, 0);
            this.tileTable.Name = "tileTable";
            this.tileTable.Size = new System.Drawing.Size(602, 128);
            this.tileTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tileTable.TabIndex = 1;
            this.tileTable.TabStop = false;
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_exit.Location = new System.Drawing.Point(818, 3);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(34, 36);
            this.lbl_exit.TabIndex = 9;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            this.lbl_exit.MouseLeave += new System.EventHandler(this.lbl_exit_MouseLeave);
            this.lbl_exit.MouseHover += new System.EventHandler(this.lbl_exit_MouseHover);
            // 
            // lbl_plus
            // 
            this.lbl_plus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_plus.AutoSize = true;
            this.lbl_plus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.lbl_plus.Font = new System.Drawing.Font("Gill Sans MT", 40F, System.Drawing.FontStyle.Bold);
            this.lbl_plus.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_plus.Location = new System.Drawing.Point(750, 388);
            this.lbl_plus.Name = "lbl_plus";
            this.lbl_plus.Size = new System.Drawing.Size(79, 93);
            this.lbl_plus.TabIndex = 8;
            this.lbl_plus.Text = "+";
            // 
            // btn_plus
            // 
            this.btn_plus.AllowDrop = true;
            this.btn_plus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(220)))), ((int)(((byte)(102)))));
            this.btn_plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_plus.FlatAppearance.BorderSize = 0;
            this.btn_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_plus.Font = new System.Drawing.Font("Gadugi", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_plus.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_plus.Location = new System.Drawing.Point(726, 361);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(117, 144);
            this.btn_plus.TabIndex = 7;
            this.btn_plus.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Controls.Add(this.Grid_tile);
            this.panel1.Location = new System.Drawing.Point(118, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 419);
            this.panel1.TabIndex = 3;
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
            this.lbl_title.Location = new System.Drawing.Point(173, 169);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(268, 56);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Rummikub";
            // 
            // Grid_tile
            // 
            this.Grid_tile.BackgroundColor = System.Drawing.Color.Navy;
            this.Grid_tile.CausesValidation = false;
            this.Grid_tile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_tile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_tile.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_tile.Location = new System.Drawing.Point(0, 0);
            this.Grid_tile.Name = "Grid_tile";
            this.Grid_tile.RowTemplate.Height = 27;
            this.Grid_tile.Size = new System.Drawing.Size(602, 419);
            this.Grid_tile.TabIndex = 0;
            // 
            // btn_sort_col
            // 
            this.btn_sort_col.AllowDrop = true;
            this.btn_sort_col.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.btn_sort_col.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_col.FlatAppearance.BorderSize = 0;
            this.btn_sort_col.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_col.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sort_col.Location = new System.Drawing.Point(727, 254);
            this.btn_sort_col.Name = "btn_sort_col";
            this.btn_sort_col.Size = new System.Drawing.Size(116, 100);
            this.btn_sort_col.TabIndex = 2;
            this.btn_sort_col.Text = "777";
            this.btn_sort_col.UseVisualStyleBackColor = false;
            // 
            // btn_sort_num
            // 
            this.btn_sort_num.AllowDrop = true;
            this.btn_sort_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.btn_sort_num.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_num.FlatAppearance.BorderSize = 0;
            this.btn_sort_num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_num.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sort_num.ForeColor = System.Drawing.Color.Red;
            this.btn_sort_num.Location = new System.Drawing.Point(727, 148);
            this.btn_sort_num.Name = "btn_sort_num";
            this.btn_sort_num.Size = new System.Drawing.Size(116, 100);
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
            this.btn_timer.Location = new System.Drawing.Point(727, 42);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(116, 100);
            this.btn_timer.TabIndex = 0;
            this.btn_timer.Text = "60";
            this.btn_timer.UseVisualStyleBackColor = false;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // profile4
            // 
            this.profile4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile4.BackColor = System.Drawing.Color.Transparent;
            this.profile4.Image = global::Client.Properties.Resources.프사4;
            this.profile4.Location = new System.Drawing.Point(12, 360);
            this.profile4.Name = "profile4";
            this.profile4.Size = new System.Drawing.Size(100, 88);
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
            this.profile3.Location = new System.Drawing.Point(12, 254);
            this.profile3.Name = "profile3";
            this.profile3.Size = new System.Drawing.Size(100, 88);
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
            this.profile2.Location = new System.Drawing.Point(12, 148);
            this.profile2.Name = "profile2";
            this.profile2.Size = new System.Drawing.Size(100, 88);
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
            this.profile1.Location = new System.Drawing.Point(12, 42);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(100, 88);
            this.profile1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile1.TabIndex = 2;
            this.profile1.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 719);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.Chatting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientForm";
            this.Text = "Rummikub";
            this.Load += new System.EventHandler(this.Background_Load);
            this.Chatting.ResumeLayout(false);
            this.Chatting.PerformLayout();
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tileTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Chatting;
        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.Button btn_sort_num;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Grid_tile;
        private System.Windows.Forms.Button btn_sort_col;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox profile1;
        private System.Windows.Forms.PictureBox profile4;
        private System.Windows.Forms.PictureBox profile3;
        private System.Windows.Forms.PictureBox profile2;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.Label lbl_plus;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox tileTable;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtbox_chat;
        private System.Windows.Forms.ImageList imageList1;
    }
}

