namespace Client
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btn_complete = new System.Windows.Forms.Button();
            this.remain4 = new System.Windows.Forms.Label();
            this.remain3 = new System.Windows.Forms.Label();
            this.remain2 = new System.Windows.Forms.Label();
            this.remain1 = new System.Windows.Forms.Label();
            this.nickname4 = new System.Windows.Forms.Label();
            this.nickname3 = new System.Windows.Forms.Label();
            this.nickname2 = new System.Windows.Forms.Label();
            this.nickname1 = new System.Windows.Forms.Label();
            this.tileTable = new System.Windows.Forms.PictureBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.profile4 = new System.Windows.Forms.PictureBox();
            this.profile3 = new System.Windows.Forms.PictureBox();
            this.profile2 = new System.Windows.Forms.PictureBox();
            this.profile1 = new System.Windows.Forms.PictureBox();
            this.btn_sort_col = new System.Windows.Forms.Button();
            this.btn_sort_num = new System.Windows.Forms.Button();
            this.btn_timer = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tgpHolding = new Client.TileGridPanel();
            this.tgpTable = new Client.TileGridPanel();
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
            this.Chatting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Chatting.Controls.Add(this.txt_log);
            this.Chatting.Controls.Add(this.btn_send);
            this.Chatting.Controls.Add(this.txtbox_chat);
            this.Chatting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chatting.Location = new System.Drawing.Point(0, 428);
            this.Chatting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chatting.Name = "Chatting";
            this.Chatting.Size = new System.Drawing.Size(780, 129);
            this.Chatting.TabIndex = 0;
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.txt_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_log.ForeColor = System.Drawing.Color.White;
            this.txt_log.Location = new System.Drawing.Point(0, 3);
            this.txt_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(780, 103);
            this.txt_log.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btn_send.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.btn_send.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btn_send.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btn_send.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.Location = new System.Drawing.Point(713, 107);
            this.btn_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(67, 21);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // txtbox_chat
            // 
            this.txtbox_chat.AcceptsReturn = true;
            this.txtbox_chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.txtbox_chat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox_chat.ForeColor = System.Drawing.Color.White;
            this.txtbox_chat.Location = new System.Drawing.Point(0, 107);
            this.txtbox_chat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbox_chat.Name = "txtbox_chat";
            this.txtbox_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_chat.Size = new System.Drawing.Size(714, 21);
            this.txtbox_chat.TabIndex = 2;
            this.txtbox_chat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbox_chat_KeyUp);
            // 
            // MainForm
            // 
            this.MainForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.MainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainForm.Controls.Add(this.btnStart);
            this.MainForm.Controls.Add(this.btn_complete);
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
            this.MainForm.Controls.Add(this.btn_return);
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
            this.MainForm.Size = new System.Drawing.Size(780, 428);
            this.MainForm.TabIndex = 1;
            this.MainForm.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MainForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MainForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(669, 255);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 72);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.OutlineBtn_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.OutlineBtn_MouseLeave);
            // 
            // btn_complete
            // 
            this.btn_complete.AllowDrop = true;
            this.btn_complete.BackColor = System.Drawing.Color.Transparent;
            this.btn_complete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_complete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_complete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_complete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_complete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_complete.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_complete.ForeColor = System.Drawing.Color.White;
            this.btn_complete.Location = new System.Drawing.Point(669, 255);
            this.btn_complete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_complete.Name = "btn_complete";
            this.btn_complete.Size = new System.Drawing.Size(98, 72);
            this.btn_complete.TabIndex = 22;
            this.btn_complete.Text = "FINISH";
            this.btn_complete.UseVisualStyleBackColor = false;
            this.btn_complete.Click += new System.EventHandler(this.Btn_complete_Click);
            this.btn_complete.MouseEnter += new System.EventHandler(this.OutlineBtn_MouseEnter);
            this.btn_complete.MouseLeave += new System.EventHandler(this.OutlineBtn_MouseLeave);
            // 
            // remain4
            // 
            this.remain4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.remain4.ForeColor = System.Drawing.Color.White;
            this.remain4.Location = new System.Drawing.Point(68, 292);
            this.remain4.Name = "remain4";
            this.remain4.Size = new System.Drawing.Size(24, 24);
            this.remain4.TabIndex = 21;
            this.remain4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain3
            // 
            this.remain3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.remain3.ForeColor = System.Drawing.Color.White;
            this.remain3.Location = new System.Drawing.Point(68, 199);
            this.remain3.Name = "remain3";
            this.remain3.Size = new System.Drawing.Size(24, 24);
            this.remain3.TabIndex = 20;
            this.remain3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain2
            // 
            this.remain2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.remain2.ForeColor = System.Drawing.Color.White;
            this.remain2.Location = new System.Drawing.Point(67, 106);
            this.remain2.Name = "remain2";
            this.remain2.Size = new System.Drawing.Size(24, 24);
            this.remain2.TabIndex = 19;
            this.remain2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remain1
            // 
            this.remain1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.remain1.ForeColor = System.Drawing.Color.White;
            this.remain1.Location = new System.Drawing.Point(67, 11);
            this.remain1.Name = "remain1";
            this.remain1.Size = new System.Drawing.Size(24, 24);
            this.remain1.TabIndex = 18;
            this.remain1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname4
            // 
            this.nickname4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nickname4.ForeColor = System.Drawing.Color.White;
            this.nickname4.Location = new System.Drawing.Point(13, 360);
            this.nickname4.Name = "nickname4";
            this.nickname4.Size = new System.Drawing.Size(60, 12);
            this.nickname4.TabIndex = 17;
            this.nickname4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname3
            // 
            this.nickname3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nickname3.ForeColor = System.Drawing.Color.White;
            this.nickname3.Location = new System.Drawing.Point(13, 265);
            this.nickname3.Name = "nickname3";
            this.nickname3.Size = new System.Drawing.Size(60, 12);
            this.nickname3.TabIndex = 16;
            this.nickname3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname2
            // 
            this.nickname2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nickname2.ForeColor = System.Drawing.Color.White;
            this.nickname2.Location = new System.Drawing.Point(13, 172);
            this.nickname2.Name = "nickname2";
            this.nickname2.Size = new System.Drawing.Size(60, 12);
            this.nickname2.TabIndex = 15;
            this.nickname2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname1
            // 
            this.nickname1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nickname1.ForeColor = System.Drawing.Color.White;
            this.nickname1.Location = new System.Drawing.Point(13, 77);
            this.nickname1.Name = "nickname1";
            this.nickname1.Size = new System.Drawing.Size(60, 11);
            this.nickname1.TabIndex = 14;
            this.nickname1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lbl_title.Location = new System.Drawing.Point(661, 438);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(214, 45);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Rummikub";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_title.Click += new System.EventHandler(this.Lbl_title_Click);
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.Color.Transparent;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_return.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_return.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_return.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_return.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_return.ForeColor = System.Drawing.Color.White;
            this.btn_return.Location = new System.Drawing.Point(669, 336);
            this.btn_return.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(98, 72);
            this.btn_return.TabIndex = 12;
            this.btn_return.Text = "ROLLBACK";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.Btn_return_Click);
            this.btn_return.MouseEnter += new System.EventHandler(this.OutlineBtn_MouseEnter);
            this.btn_return.MouseLeave += new System.EventHandler(this.OutlineBtn_MouseLeave);
            // 
            // profile4
            // 
            this.profile4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.profile4.BackColor = System.Drawing.Color.Transparent;
            this.profile4.Image = global::Client.Properties.Resources.프사4;
            this.profile4.Location = new System.Drawing.Point(13, 294);
            this.profile4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile4.Name = "profile4";
            this.profile4.Size = new System.Drawing.Size(62, 63);
            this.profile4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile4.TabIndex = 6;
            this.profile4.TabStop = false;
            // 
            // profile3
            // 
            this.profile3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.profile3.BackColor = System.Drawing.Color.Transparent;
            this.profile3.Image = global::Client.Properties.Resources.프사3;
            this.profile3.Location = new System.Drawing.Point(13, 199);
            this.profile3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile3.Name = "profile3";
            this.profile3.Size = new System.Drawing.Size(62, 63);
            this.profile3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile3.TabIndex = 5;
            this.profile3.TabStop = false;
            // 
            // profile2
            // 
            this.profile2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.profile2.BackColor = System.Drawing.Color.Transparent;
            this.profile2.Image = global::Client.Properties.Resources.프사2;
            this.profile2.Location = new System.Drawing.Point(11, 106);
            this.profile2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile2.Name = "profile2";
            this.profile2.Size = new System.Drawing.Size(62, 63);
            this.profile2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile2.TabIndex = 4;
            this.profile2.TabStop = false;
            // 
            // profile1
            // 
            this.profile1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Image = global::Client.Properties.Resources.프사1;
            this.profile1.Location = new System.Drawing.Point(11, 11);
            this.profile1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(62, 63);
            this.profile1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile1.TabIndex = 2;
            this.profile1.TabStop = false;
            // 
            // btn_sort_col
            // 
            this.btn_sort_col.AllowDrop = true;
            this.btn_sort_col.BackColor = System.Drawing.Color.Transparent;
            this.btn_sort_col.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_col.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_sort_col.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_sort_col.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_sort_col.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_col.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sort_col.ForeColor = System.Drawing.Color.White;
            this.btn_sort_col.Location = new System.Drawing.Point(669, 174);
            this.btn_sort_col.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sort_col.Name = "btn_sort_col";
            this.btn_sort_col.Size = new System.Drawing.Size(98, 72);
            this.btn_sort_col.TabIndex = 2;
            this.btn_sort_col.Text = "777";
            this.btn_sort_col.UseVisualStyleBackColor = false;
            this.btn_sort_col.Click += new System.EventHandler(this.Btn_sort_col_Click);
            this.btn_sort_col.MouseEnter += new System.EventHandler(this.OutlineBtn_MouseEnter);
            this.btn_sort_col.MouseLeave += new System.EventHandler(this.OutlineBtn_MouseLeave);
            // 
            // btn_sort_num
            // 
            this.btn_sort_num.AllowDrop = true;
            this.btn_sort_num.BackColor = System.Drawing.Color.Transparent;
            this.btn_sort_num.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sort_num.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_sort_num.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_sort_num.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_sort_num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_num.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sort_num.ForeColor = System.Drawing.Color.White;
            this.btn_sort_num.Location = new System.Drawing.Point(669, 92);
            this.btn_sort_num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sort_num.Name = "btn_sort_num";
            this.btn_sort_num.Size = new System.Drawing.Size(98, 72);
            this.btn_sort_num.TabIndex = 1;
            this.btn_sort_num.Text = "789";
            this.btn_sort_num.UseVisualStyleBackColor = false;
            this.btn_sort_num.Click += new System.EventHandler(this.btn_sort_num_Click);
            this.btn_sort_num.MouseEnter += new System.EventHandler(this.OutlineBtn_MouseEnter);
            this.btn_sort_num.MouseLeave += new System.EventHandler(this.OutlineBtn_MouseLeave);
            // 
            // btn_timer
            // 
            this.btn_timer.AllowDrop = true;
            this.btn_timer.BackColor = System.Drawing.Color.White;
            this.btn_timer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_timer.Enabled = false;
            this.btn_timer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_timer.FlatAppearance.BorderSize = 2;
            this.btn_timer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_timer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_timer.Font = new System.Drawing.Font("나눔바른고딕 UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btn_timer.Location = new System.Drawing.Point(669, 11);
            this.btn_timer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(98, 72);
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
            // tgpHolding
            // 
            this.tgpHolding.Location = new System.Drawing.Point(108, 312);
            this.tgpHolding.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tgpHolding.Name = "tgpHolding";
            this.tgpHolding.OnPickup = null;
            this.tgpHolding.OnPlace = null;
            this.tgpHolding.OptionRemoveSpaces = false;
            this.tgpHolding.Size = new System.Drawing.Size(540, 96);
            this.tgpHolding.TabIndex = 13;
            this.tgpHolding.TileSize = new System.Drawing.Size(0, 0);
            // 
            // tgpTable
            // 
            this.tgpTable.Location = new System.Drawing.Point(108, 11);
            this.tgpTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tgpTable.Name = "tgpTable";
            this.tgpTable.OnPickup = null;
            this.tgpTable.OnPlace = null;
            this.tgpTable.OptionRemoveSpaces = false;
            this.tgpTable.Size = new System.Drawing.Size(540, 288);
            this.tgpTable.TabIndex = 2;
            this.tgpTable.TileSize = new System.Drawing.Size(0, 0);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.MainForm);
            this.Controls.Add(this.Chatting);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.Text = "OurRummikub";
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
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtbox_chat;
        private System.Windows.Forms.ImageList imageList1;
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
        private System.Windows.Forms.Button btn_complete;
    }
}

